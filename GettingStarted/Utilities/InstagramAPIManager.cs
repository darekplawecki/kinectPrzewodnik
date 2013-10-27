using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using InstaSharp;
using Newtonsoft.Json;

namespace Przewodnik.Utilities
{
    class InstagramAPIManager
    {
        const string clientId = "728767bae37a4bd999b2d17af0ba26fe";
        const string clientSecret = "1333cc751d364232ac11554210cfd2f6";
        const string redirectUri = "http://www.pwr.wroc.pl"; // Any URL 
        const string oAuthUri = "https://api.instagram.com/oauth";
        const string apiUri = "https://api.instagram.com/v1";

        const string login = "zpikinect";
        const string password = "zpipwr2013";

        const int user_id = 239473388;
        const string user_name = "wroclaw_official";

        InstagramConfig config;
        AuthInfo authInfo;

        public InstagramAPIManager()
        {
            config = new InstaSharp.InstagramConfig(apiUri, oAuthUri, clientId, clientSecret, redirectUri);

            List<Auth.Scope> scopes = new List<Auth.Scope>();
            scopes.Add(Auth.Scope.basic);

            authInfo = GetInstagramAuth(oAuthUri, clientId, redirectUri, config, login, password);

        }

        public void saveRecentImages()
        {
            var users = new InstaSharp.Endpoints.Users.Authenticated(config, authInfo);
            var result = users.Feed(user_name, 100);

            dynamic imagesList = JsonConvert.DeserializeObject(result.Json);

            string[] parts = Environment.CurrentDirectory.Split(new string[] { "bin\\" }, StringSplitOptions.None);
            string projectPath = parts[0];

            int count = 1;
            foreach (var data in imagesList.data)
            {
                string img_url = data.images.standard_resolution.url;
                System.Drawing.Image img = GetImageFromUrl(img_url);
                img.Save(projectPath + "Content\\SleepScreen\\Instagram\\" + count + ".jpg");
                count++;
            }
        }

        private static System.Drawing.Image GetImageFromUrl(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);

            using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream stream = httpWebReponse.GetResponseStream())
                {
                    return System.Drawing.Image.FromStream(stream);
                }
            }
        }

        private static AuthInfo GetInstagramAuth(string oAuthUri, string clientId, string redirectUri,
            InstagramConfig config, string login, string password)
        {
            List<Auth.Scope> scopes = new List<Auth.Scope>();
            scopes.Add(Auth.Scope.basic);

            var link = InstaSharp.Auth.AuthLink(oAuthUri, clientId, redirectUri, scopes);
            
            // User name in the specified node
            CookieAwareWebClient client = new CookieAwareWebClient();
            // We went to the login page
            var result = client.DownloadData(link);
            var html = System.Text.Encoding.Default.GetString(result);

            // Take the token
            string csr = "";
            string pattern = @"csrfmiddlewaretoken""\svalue=""(.+)""";
            var r = new System.Text.RegularExpressions.Regex(pattern);
            var m = r.Match(html);
            csr = m.Groups[1].Value;

            // Login
            string loginLink = string.Format(
                "https://instagram.com/accounts/login/?next=/oauth/authorize/%3Fclient_id%3D{0}%26redirect_uri%3Dhttp%3A//www.pwr.wroc.pl%26response_type%3Dcode%26scope%3Dbasic", clientId);

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("csrfmiddlewaretoken", csr);
            parameters.Add("username", login);
            parameters.Add("password", password);

            // You need to add the secret cookies received pre-login

            // Looking for something headers
            string agent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            client.Headers["Referer"] = loginLink;
            client.Headers["Host"] = "instagram.com";
            client.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            client.Headers["User-Agent"] = agent;
            client.Headers["Accept-Language"] = "pl-PL";
            client.Headers["Accept"] = "text/html, application/xhtml+xml, */*";
            client.Headers["Cache-Control"] = "no-cache";
            
            // request
            var result2 = client.UploadValues(loginLink, "POST", parameters);
            // Fasting data received code
            // New link is not on the api, and on instagram
            
            string newPostLink = string.Format(
                "https://instagram.com/oauth/authorize/?client_id={0}&redirect_uri=http://www.pwr.wroc.pl&response_type=code&scope=basic", clientId);

            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create(newPostLink);
            request.AllowAutoRedirect = false;
            request.CookieContainer = client.CookieContainer;
            request.Referer = newPostLink;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = agent;

            string postData = string.Format("csrfmiddlewaretoken={0}&allow=Authorize", csr);
            request.ContentLength = postData.Length;

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] loginDataBytes = encoding.GetBytes(postData);
            request.ContentLength = loginDataBytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(loginDataBytes, 0, loginDataBytes.Length);

            // send the request
            var response = request.GetResponse();
            string location = response.Headers["Location"];

            // Now take out the code and get the authentication
            pattern = @"www.pwr.wroc.pl\?code=(.+)";
            r = new System.Text.RegularExpressions.Regex(pattern);
            m = r.Match(location);
            string code = m.Groups[1].Value;
            // Finally, we get an authentication token
            var auth = new InstaSharp.Auth(config); //.OAuth(InstaSharpConfig.config);

            // now we have to call back to instagram and include the code they gave us
            // along with our client secret
            var oauthResponse = auth.RequestToken(code);

            return oauthResponse;
        }
    }
}


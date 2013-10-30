namespace Przewodnik.Utilities.Twitter
{
    class TwitterFollowers
    {
        public static string GetFollowerName(long id)
        {
            switch (id)
            {
                case 162477349:
                    return "wroclaw";

                case 85552998:
                    return "gazeta_wroclawska";

                case 236324537:
                    return "gazeta_wroclaw";
                default:
                    return "";

            }
        }
    }
}

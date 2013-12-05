using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.Kinect;
using Microsoft.Speech.AudioFormat;
using Microsoft.Speech.Recognition;

namespace Przewodnik.Utilities
{
    public class SoundRecognizer
    {
        private KinectSensor sensor;
        private SpeechRecognitionEngine speechEngine;

        public EventHandler startSaid;
        public EventHandler stopSaid;
        public EventHandler dontUnderstandSaid;

        public SoundRecognizer(KinectSensor sensor)
        {
            this.sensor = sensor;
        }

        private static RecognizerInfo GetKinectRecognizer()
        {
            foreach (RecognizerInfo recognizer in SpeechRecognitionEngine.InstalledRecognizers())
            {
                string value;
                recognizer.AdditionalInfo.TryGetValue("Kinect", out value);
                if ("True".Equals(value, StringComparison.OrdinalIgnoreCase) && "en-US".Equals(recognizer.Culture.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return recognizer;
                }
            }

            return null;
        }

        public void Start()
        {

            this.sensor.Start();

            RecognizerInfo ri = GetKinectRecognizer();

            if (null != ri)
            {
                this.speechEngine = new SpeechRecognitionEngine(ri.Id);

                var directions = new Choices();
                directions.Add(new SemanticResultValue("start", "START"));
                directions.Add(new SemanticResultValue("starts", "START"));
                directions.Add(new SemanticResultValue("stop", "STOP"));
                directions.Add(new SemanticResultValue("stops", "STOP"));
                var gb = new GrammarBuilder { Culture = ri.Culture };
                gb.Append(directions);
                var g = new Grammar(gb);

                speechEngine.LoadGrammar(g);


                speechEngine.SpeechRecognized += SpeechRecognized;
                speechEngine.SpeechRecognitionRejected += SpeechRejected;

                speechEngine.SetInputToAudioStream(
                    sensor.AudioSource.Start(), new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
                speechEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            else
            {
                MessageBox.Show("No speech recognizer 101");
            }
        }

        public void Stop()
        {
            this.sensor.AudioSource.Stop();

            if (null != this.speechEngine)
            {
                this.speechEngine.SpeechRecognized -= SpeechRecognized;
                this.speechEngine.SpeechRecognitionRejected -= SpeechRejected;
                this.speechEngine.RecognizeAsyncStop();
            }
        }

        private void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            const double ConfidenceThreshold = 0.3;

            if (e.Result.Confidence >= ConfidenceThreshold)
            {
                switch (e.Result.Semantics.Value.ToString())
                {
                    case "START":
                        startSaid(this, new EventArgs());
                        break;

                    case "STOP":
                        stopSaid(this, new EventArgs());
                        break;
                    default:
                        dontUnderstandSaid(this, new EventArgs());
                        break;
                }
            }
        }

        private void SpeechRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            MessageBox.Show("Nieczaje rejected");
            dontUnderstandSaid(this, new EventArgs());
        }
    }
}

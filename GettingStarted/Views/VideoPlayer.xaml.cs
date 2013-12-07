using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Kinect.Toolkit;
using Przewodnik.Utilities;
using Przewodnik.ViewModels;
using Przewodnik.Content.Traslations;

namespace Przewodnik.Views
{

    public partial class VideoPlayer : IKinectPage
    {
        private KinectPageFactory pageFactory;

        private DispatcherTimer progressTimer;

        VideoPlayerViewModel viewModel;

        public SoundRecognizer sr;

        private Navigator navigator;

        public VideoPlayer(KinectPageFactory pageFactory, Navigator navigator)
        {
            InitializeComponent();
            this.navigator = navigator;
            
            try
            {
                sr = new SoundRecognizer(MainWindow.KinectController.KinectSensorChooser.Kinect);
                sr.startSaid += playVideo;
                sr.stopSaid += stopVideo;
                sr.dontUnderstandSaid += dontUnderstand;
            }
            catch (Exception e)
            {
                navigator.GoHome();
            }
            
            viewModel = new VideoPlayerViewModel();
            VideoPlayerGrid.DataContext = viewModel;

            string[] parts = Environment.CurrentDirectory.Split(new string[] { "bin\\" }, StringSplitOptions.None);
            string projectPath = parts[0];
            Player.Source = new Uri(projectPath + "Content\\Videos\\wroclaw_promo.wmv");

            progressTimer = new DispatcherTimer();
            progressTimer.Interval = TimeSpan.FromSeconds(1);
            progressTimer.Tick += OnProgressUpdateTick;

            Player.MediaOpened += this.OnVideoOpened;
            Player.MediaEnded += this.OnVideoEnded;

            PlayVideo();

            this.pageFactory = pageFactory;
        }

        public Grid GetView()
        {
            return VideoPlayerGrid;
        }

        public void OnNavigateTo()
        {
            MicrophoneStatusPlay.Text = AppResources.GetText("V_stop");
            pageFactory.ShowTopBar(false);
            
            try
            {
                sr.Start();
            }
            catch (Exception e)
            {
                navigator.GoHome();
            }
        }

        private void PlayVideo()
        {
            if (viewModel.CanResume || viewModel.CanReplay)
            {
                if (viewModel.CanReplay) Player.Position = TimeSpan.Zero;

                viewModel.setPlayingState();
                progressTimer.Start();
                Player.Play();
            }
        }

        private void PauseVideo()
        {
            if (viewModel.CanPause)
            {
                viewModel.setPausedState();
                progressTimer.Stop();
                Player.Pause();
            }
        }

        private void OnVideoEnded(object sender, RoutedEventArgs e)
        {
            Player.Pause();
            viewModel.setStoppedState();
        }

        private void OnVideoOpened(object sender, RoutedEventArgs e)
        {
            if (null != VideoProgressBar)
            {
                VideoProgressBar.Maximum = Player.NaturalDuration.TimeSpan.TotalMilliseconds;
            }

            if (null != DurationTextBlock)
            {
                DurationTextBlock.Text = Player.NaturalDuration.TimeSpan.ToString(@"mm\:ss", CultureInfo.InvariantCulture);
            }
        }

        private void OnProgressUpdateTick(object sender, EventArgs e)
        {
            if (null != VideoProgressBar)
            {
                VideoProgressBar.Value = Player.Position.TotalMilliseconds;
            }

            if (null != CurrentProgressTextBlock)
            {
                CurrentProgressTextBlock.Text = Player.Position.ToString(@"mm\:ss", CultureInfo.InvariantCulture);
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            PlayVideo();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            PauseVideo();
        }

        private void stopVideo(object sender, EventArgs e)
        {
            PauseVideo();
            MicrophoneStatusPlay.Text = AppResources.GetText("V_start");
        }

        private void dontUnderstand(object sender, EventArgs e)
        {
            MicrophoneStatusPlay.Text = AppResources.GetText("V_dontunderstand");
        }

        private void playVideo(object sender, EventArgs e)
        {
            PlayVideo();
            MicrophoneStatusPlay.Text = AppResources.GetText("V_stop");
        }



        private void backClicked(object sender, EventArgs e)
        {
            sr.Stop();
            pageFactory.ShowTopBar(true);
            navigator.GoBack();

        }
    }
}

using Microsoft.Kinect;
using Przewodnik.Utilities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Media;
using System.Globalization;
using System.IO;

namespace Przewodnik.Views
{

    partial class PostcardPage : IKinectPage
    {
        private const double ACCEPTED_HAND_MOVING = 0.05;
        private const int COUNTER = 3;

        private Point _positionRightHand;
        private Point _positionLeftHand;

        private List<Image> _backgroundPhotos;
        private int _actualBackgroundPhotosIndex;
        // right = 1; left = -1; nomove = 0;
        private int _directionBackgroundPhotos;


        private KinectPageFactory pageFactory;

        private KinectController _kinectController;


        public PostcardPage(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            this.pageFactory = pageFactory;

            _kinectController = MainWindow.KinectController;
            _kinectController.PropertyChanged += KinectControllerPropertyChanged;

            _actualBackgroundPhotosIndex = 0;
            _directionBackgroundPhotos = 0;
            _backgroundPhotos = new List<Image>();
            _backgroundPhotos.Add(new Image { Source = new BitmapImage(new Uri("../Content/Postcard/Background/background_1.jpg", UriKind.Relative)) });
            _backgroundPhotos.Add(new Image { Source = new BitmapImage(new Uri("../Content/Postcard/Background/background_2.jpg", UriKind.Relative)) });
            _backgroundPhotos.Add(new Image { Source = new BitmapImage(new Uri("../Content/Postcard/Background/background_3.jpg", UriKind.Relative)) });
            _backgroundPhotos.Add(new Image { Source = new BitmapImage(new Uri("../Content/Postcard/Background/background_4.jpg", UriKind.Relative)) });

            BackgroundPhoto.ContentTemplate = Application.Current.Resources["NextImageTransition"] as DataTemplate;
            BackgroundPhoto.Content = _backgroundPhotos[_actualBackgroundPhotosIndex];
        }

        private void KinectControllerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            MaskedColor.Source = _kinectController.ForegroundBitmap;

            if (_kinectController.LeftHandJoint.TrackingState == JointTrackingState.Tracked || _kinectController.RightHandJoint.TrackingState == JointTrackingState.Tracked)
            {

                if (_kinectController.IsRightHandGrip && !_kinectController.IsLeftHandGrip)
                {

                    double handDistaceX = Math.Abs((double)_kinectController.RightHandJoint.Position.X - _positionRightHand.X);
                    if (handDistaceX > ACCEPTED_HAND_MOVING)
                    {
                        if ((double)_kinectController.RightHandJoint.Position.X < _positionRightHand.X)
                        {
                            if (_actualBackgroundPhotosIndex < (_backgroundPhotos.Count - 1) && (_directionBackgroundPhotos == 0 || _directionBackgroundPhotos == -1))
                            {
                                BackgroundPhoto.ContentTemplate = Application.Current.Resources["NextImageTransition"] as DataTemplate;
                                BackgroundPhoto.Content = _backgroundPhotos[++_actualBackgroundPhotosIndex];
                                _directionBackgroundPhotos = 1;
                            }
                        }
                        else
                        {
                            if (_actualBackgroundPhotosIndex > 0 && (_directionBackgroundPhotos == 0 || _directionBackgroundPhotos == 1))
                            {
                                BackgroundPhoto.ContentTemplate = Application.Current.Resources["PreviousImageTransition"] as DataTemplate;
                                BackgroundPhoto.Content = _backgroundPhotos[--_actualBackgroundPhotosIndex];
                                _directionBackgroundPhotos = -1;
                            }
                        }
                    }

                }
                else if (_kinectController.IsLeftHandGrip && !_kinectController.IsRightHandGrip)
                {

                }
                else
                {
                    _positionRightHand = new Point(_kinectController.RightHandJoint.Position.X, _kinectController.RightHandJoint.Position.Y);
                    _positionLeftHand = new Point(_kinectController.LeftHandJoint.Position.X, _kinectController.LeftHandJoint.Position.Y);
                    _directionBackgroundPhotos = 0;
                }

            }
        }

        public Grid GetView()
        {
            return PostcardGrid;
        }

        public void OnNavigateTo()
        {
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (_actualBackgroundPhotosIndex > 0 && (_directionBackgroundPhotos == 0 || _directionBackgroundPhotos == 1))
            {
                BackgroundPhoto.ContentTemplate = Application.Current.Resources["PreviousImageTransition"] as DataTemplate;
                BackgroundPhoto.Content = _backgroundPhotos[--_actualBackgroundPhotosIndex];
                _directionBackgroundPhotos = -1;
            }
        }

        private void SnapshootButton_Click(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            int _counter = COUNTER;
            timer.Tick += (s, ee) =>
            {
                if (_counter == 0)
                {
                    Counter.Dispatcher.Invoke(new Action(() => Counter.Text = ""));
                    timer.Stop();
                }
                else if (_counter == 1)
                {
                    _counter--;
                    Counter.Dispatcher.Invoke(new Action(() => Counter.Text = "SNAP!"));
                    TakeSnapshot();
                }
                else
                {
                    _counter--;
                    Counter.Dispatcher.Invoke(new Action(() => Counter.Text = _counter.ToString()));
                }
            };
            timer.Start();
            Counter.Dispatcher.Invoke(new Action(() => Counter.Text = _counter.ToString()));
        }

        private void TakeSnapshot()
        {
            int colorWidth = _kinectController.ForegroundBitmap.PixelWidth;
            int colorHeight = _kinectController.ForegroundBitmap.PixelHeight;

            // create a render target that we'll render our controls to
            var renderBitmap = new RenderTargetBitmap(colorWidth, colorHeight, 96.0, 96.0, PixelFormats.Pbgra32);

            var dv = new DrawingVisual();
            using (var dc = dv.RenderOpen())
            {
                // render the backdrop
                var backdropBrush = new VisualBrush(BackgroundPhoto);
                dc.DrawRectangle(backdropBrush, null, new Rect(new Point(), new Size(colorWidth, colorHeight)));

                // render the color image masked out by players
                var colorBrush = new VisualBrush(MaskedColor);
                dc.DrawRectangle(colorBrush, null, new Rect(new Point(), new Size(colorWidth, colorHeight)));
            }

            renderBitmap.Render(dv);

            // create a png bitmap encoder which knows how to save a .png file
            BitmapEncoder encoder = new PngBitmapEncoder();

            // create frame from the writable bitmap and add to encoder
            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));

            var time = DateTime.Now.ToString("hh'-'mm'-'ss", CultureInfo.CurrentUICulture.DateTimeFormat);

            var myPhotos = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            var path = Path.Combine(myPhotos, "KinectSnapshot-" + time + ".png");

            // write the new file to disk
            try
            {
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    encoder.Save(fs);
                }
            }
            catch (IOException)
            {

            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_actualBackgroundPhotosIndex < (_backgroundPhotos.Count - 1) && (_directionBackgroundPhotos == 0 || _directionBackgroundPhotos == -1))
            {
                BackgroundPhoto.ContentTemplate = Application.Current.Resources["NextImageTransition"] as DataTemplate;
                BackgroundPhoto.Content = _backgroundPhotos[++_actualBackgroundPhotosIndex];
                _directionBackgroundPhotos = 1;
            }
        }
    }


}

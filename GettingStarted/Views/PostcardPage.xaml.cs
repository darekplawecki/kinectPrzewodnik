using Microsoft.Kinect;
using Przewodnik.Utilities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Media;
using System.Globalization;
using System.IO;
using System.Net;
using Przewodnik.Content.Traslations;

namespace Przewodnik.Views
{

    partial class PostcardPage : IKinectPage
    {
        private const double ACCEPTED_HAND_MOVING = 0.05;
        private const int COUNTER = 3;

        private double _distanceTwoHand;

        private Point _positionRightHand;
        private Point _positionLeftHand;

        private List<Image> _backgroundPhotos;
        private int _actualBackgroundPhotosIndex;
        // right = 1; left = -1; nomove = 0;
        private int _directionBackgroundPhotos;

        private Boolean _quickStartState = true;
        private int _quickStartStep;

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

            // Samouczek
            _quickStartStep = _quickStartState ? 1 : 0;
            if (_quickStartStep == 1)
            {
                QuickStartCanvas.Visibility = Visibility.Visible;
                QuickStartTextBlock.Text = AppResources.GetText("S_Foto_przesuniecie");

                CameraFrame.Visibility = Visibility.Hidden;
                NavigationButtons.Visibility = Visibility.Hidden;
            }
            else
            {
                QuickStartCanvas.Visibility = Visibility.Hidden;
            }
        }

        private void KinectControllerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            MaskedColor.Source = _kinectController.ForegroundBitmap;

            if (_kinectController.LeftHandJoint.TrackingState == JointTrackingState.Tracked || _kinectController.RightHandJoint.TrackingState == JointTrackingState.Tracked)
            {

                if (_kinectController.IsLeftHandGrip && _kinectController.IsRightHandGrip)
                {
                    double handDistance = GetHandDistance(_kinectController.LeftHandJoint.Position.X, _kinectController.LeftHandJoint.Position.Y, _kinectController.RightHandJoint.Position.X, _kinectController.RightHandJoint.Position.Y);
                    if ((handDistance - ACCEPTED_HAND_MOVING) > _distanceTwoHand)
                    {
                        ZoomIn(10);

                        // quickstart
                        if (_quickStartStep == 3)
                        {
                            _quickStartStep = 0;
                            _quickStartState = false;
                            QuickStartCanvas.Visibility = Visibility.Hidden;

                            CameraFrame.Visibility = Visibility.Visible;
                            NavigationButtons.Visibility = Visibility.Visible;
                        }
                    }
                    else if ((handDistance + ACCEPTED_HAND_MOVING) < _distanceTwoHand)
                    {
                        ZoomOut(10);

                        // quickstart
                        if (_quickStartStep == 2)
                        {
                            _quickStartStep = 3;
                            StartTimer();
                            QuickStartTextBlock.Text = AppResources.GetText("S_Foto_powiekszenie");
                        }
                    }
                    _positionRightHand = new Point(_kinectController.RightHandJoint.Position.X, _kinectController.RightHandJoint.Position.Y);
                    _positionLeftHand = new Point(_kinectController.LeftHandJoint.Position.X, _kinectController.LeftHandJoint.Position.Y);

                }
                else if (_kinectController.IsRightHandGrip && !_kinectController.IsLeftHandGrip)
                {

                    double handDistaceX = Math.Abs((double)_kinectController.RightHandJoint.Position.X - _positionRightHand.X);
                    if (handDistaceX > ACCEPTED_HAND_MOVING)
                    {
                        if ((double)_kinectController.RightHandJoint.Position.X < _positionRightHand.X)
                        {
                            if (_directionBackgroundPhotos == 0 || _directionBackgroundPhotos == -1)
                            {
                                TransitToNextImage();
                            }
                        }
                        else
                        {
                            if (_directionBackgroundPhotos == 0 || _directionBackgroundPhotos == 1)
                            {
                                TransitToPreviousImage();
                            }
                        }

                        // quickstart
                        if (_quickStartStep == 1)
                        {
                            _quickStartStep = 2;
                            StartTimer();
                            QuickStartTextBlock.Text = AppResources.GetText("S_Foto_pomniejszenie");
                        }
                    }

                }
                else if (_kinectController.IsLeftHandGrip && !_kinectController.IsRightHandGrip)
                {
                    double handDistaceX = Math.Abs((double)_kinectController.LeftHandJoint.Position.X - _positionLeftHand.X);
                    if (handDistaceX > ACCEPTED_HAND_MOVING)
                    {
                        if ((double)_kinectController.LeftHandJoint.Position.X < _positionLeftHand.X)
                        {
                            if (_directionBackgroundPhotos == 0 || _directionBackgroundPhotos == -1)
                            {
                                TransitToNextImage();
                            }
                        }
                        else
                        {
                            if (_directionBackgroundPhotos == 0 || _directionBackgroundPhotos == 1)
                            {
                                TransitToPreviousImage();
                            }
                        }

                        // quickstart
                        if (_quickStartStep == 1)
                        {
                            _quickStartStep = 2;
                            StartTimer();
                            QuickStartTextBlock.Text = AppResources.GetText("S_Foto_pomniejszenie");
                        }
                    }
                }
                else
                {
                    _distanceTwoHand = GetHandDistance(_kinectController.LeftHandJoint.Position.X, _kinectController.LeftHandJoint.Position.Y, _kinectController.RightHandJoint.Position.X, _kinectController.RightHandJoint.Position.Y);
                    _positionRightHand = new Point(_kinectController.RightHandJoint.Position.X, _kinectController.RightHandJoint.Position.Y);
                    _positionLeftHand = new Point(_kinectController.LeftHandJoint.Position.X, _kinectController.LeftHandJoint.Position.Y);
                    _directionBackgroundPhotos = 0;
                }

            }
        }

        private void StartTimer()
        {
            DispatcherTimer timer;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            int _counter = COUNTER;
            QuickStartCanvas.Visibility = Visibility.Hidden;
            timer.Tick += (s, ee) =>
            {
                if (_counter == 0)
                {
                    QuickStartCanvas.Visibility = Visibility.Visible;
                    timer.Stop();

                }
                else
                {
                    _counter--;
                    QuickStartCanvas.Visibility = Visibility.Hidden;
                }
            };

            timer.Start();
        }

        public Grid GetView()
        {
            return PostcardGrid;
        }

        public void OnNavigateTo()
        {
            prepareTranslation();
        }

        private void prepareTranslation()
        {
            pomin.Text = AppResources.GetText("S_Mapa_pominiecie");
        }

        private void SnapshootButton_Click(object sender, RoutedEventArgs e)
        {
            if (_kinectController.KinectSensorChooser.Kinect != null)
            {
                CameraFrame.Visibility = Visibility.Hidden;
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                int _counter = COUNTER;
                timer.Tick += (s, ee) =>
                {
                    if (_counter == 0)
                    {
                        Counter.Dispatcher.Invoke(new Action(() => Counter.Text = ""));
                        timer.Stop();
                        CameraFrame.Visibility = Visibility.Visible;
                    }
                    else if (_counter == 1)
                    {
                        _counter--;
                        Counter.Dispatcher.Invoke(new Action(() => Counter.Text = AppResources.GetText("P_Snap")));
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
        }

        private void TakeSnapshot()
        {
            int colorWidth = _kinectController.ForegroundBitmap.PixelWidth;
            int colorHeight = _kinectController.ForegroundBitmap.PixelHeight;

            // create a render target that we'll render our controls to
            var renderBitmap = new RenderTargetBitmap(colorWidth, colorHeight, 96.0, 96.0, PixelFormats.Pbgra32);

            double imageResizeWidth = (BackgroundPhoto.ActualWidth * colorWidth) / Camera.ActualWidth;
            double imageResizeHeight = (imageResizeWidth * BackgroundPhoto.ActualHeight) / BackgroundPhoto.ActualWidth;

            string[] parts = Environment.CurrentDirectory.Split(new string[] { "bin\\" }, StringSplitOptions.None);
            string projectPath = parts[0];

            var dv = new DrawingVisual();
            using (var dc = dv.RenderOpen())
            {
                // render the backdrop
                var backdropBrush = new VisualBrush(BackgroundPhoto);
                dc.DrawRectangle(backdropBrush, null, new Rect(new Point(-1 * (imageResizeWidth - colorWidth) / 2, -1 * (imageResizeHeight - colorHeight) / 2), new Size(imageResizeWidth, imageResizeHeight)));

                // render the color image masked out by players
                var colorBrush = new VisualBrush(MaskedColor);
                dc.DrawRectangle(colorBrush, null, new Rect(new Point(), new Size(colorWidth, colorHeight)));

                Image border = new Image { Source = new BitmapImage(new Uri(projectPath + "Content\\Postcard\\postcard_border.png")) };
                var postcardBorder = new VisualBrush();
                postcardBorder.Visual = border;
                dc.DrawImage(border.Source, new Rect(new Point(), new Size(colorWidth, colorHeight)));
            }

            renderBitmap.Render(dv);

            // create a png bitmap encoder which knows how to save a .png file
            BitmapEncoder encoder = new PngBitmapEncoder();

            // create frame from the writable bitmap and add to encoder
            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));

            var time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss", CultureInfo.CurrentUICulture.DateTimeFormat);

            string path = projectPath + "Content\\Postcard\\Photo\\";
            string fileName = time + ".png";

            // write the new file to disk
            try
            {
                using (var fs = new FileStream(path + fileName, FileMode.Create))
                {
                    encoder.Save(fs);
                }

                if (SaveFTP(path, fileName))
                {
                    // WYŚWIELTELENIE KODU QR
                    qrControl.Text = "http://zpi.puchalski.pl/" + fileName;
                    qrControl.Visibility = Visibility.Visible;

                }
                else
                {
                    // WYŚWIETLENIE BŁĘDU O PROBLEMIE Z INTERNETEM, BRAK QR!!
                    MessageBox.Show("Błąd z zapisem zdjęcia na serwerze. Nie ma QR.");
                }
                File.Delete(path + fileName);

            }
            catch (IOException)
            {

            }
        }

        private Boolean SaveFTP(String path, String fileName)
        {
            string ftpAddress = "ftp://puchalski.pl/";
            string username = "zpi@puchalski.pl";
            string password = "LNge3Oh4";

            try
            {

                byte[] buffer = File.ReadAllBytes(path + fileName);

                WebRequest request = WebRequest.Create(ftpAddress + fileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(username, password);
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }


        public double GetHandDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Abs(Math.Pow((x2 - x1), 2) + Math.Abs(Math.Pow((y2 - y1), 2))));
        }

        private void ZoomIn(int pixels)
        {
            double actualWidth = BackgroundPhoto.ActualWidth;
            double actualHeight = BackgroundPhoto.ActualHeight;
            double newWidth = actualWidth + pixels;
            double newHeight = (newWidth * actualHeight) / actualWidth;

            BackgroundPhoto.Width = newWidth;
            BackgroundPhoto.Height = newHeight;
        }

        private void ZoomOut(int pixels)
        {
            double actualWidth = BackgroundPhoto.ActualWidth;
            double actualHeight = BackgroundPhoto.ActualHeight;
            double newWidth = actualWidth - pixels;
            double newHeight = (newWidth * actualHeight) / actualWidth;

            if (newWidth >= Camera.ActualWidth + 1 && newHeight >= Camera.ActualHeight)
            {
                BackgroundPhoto.Width = newWidth;
                BackgroundPhoto.Height = newHeight;
            }
        }

        private void TransitToNextImage()
        {
            if (_actualBackgroundPhotosIndex >= (_backgroundPhotos.Count - 1))
            {
                _actualBackgroundPhotosIndex = -1;
            }

            BackgroundPhoto.ContentTemplate = Application.Current.Resources["NextImageTransition"] as DataTemplate;
            BackgroundPhoto.Content = _backgroundPhotos[++_actualBackgroundPhotosIndex];
            _directionBackgroundPhotos = 1;
        }

        private void TransitToPreviousImage()
        {
            if (_actualBackgroundPhotosIndex <= 0)
            {
                _actualBackgroundPhotosIndex = _backgroundPhotos.Count;
            }

            BackgroundPhoto.ContentTemplate = Application.Current.Resources["PreviousImageTransition"] as DataTemplate;
            BackgroundPhoto.Content = _backgroundPhotos[--_actualBackgroundPhotosIndex];
            _directionBackgroundPhotos = -1;
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (_actualBackgroundPhotosIndex > 0 && (_directionBackgroundPhotos == 0 || _directionBackgroundPhotos == 1))
            {
                TransitToPreviousImage();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_actualBackgroundPhotosIndex < (_backgroundPhotos.Count - 1) && (_directionBackgroundPhotos == 0 || _directionBackgroundPhotos == -1))
            {
                TransitToNextImage();
            }
        }

        private void QuickStartCancel_Click(object sender, RoutedEventArgs e)
        {
            _quickStartStep = 0;
            _quickStartState = false;
            QuickStartCanvas.Visibility = Visibility.Hidden;

            CameraFrame.Visibility = Visibility.Visible;
            NavigationButtons.Visibility = Visibility.Visible;
        }

    }
}

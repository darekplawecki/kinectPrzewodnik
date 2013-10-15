using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect;
using Przewodnik.Views;
using Przewodnik.Utilities;

namespace Przewodnik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private const int MinimumScreenWidth = 1920;
        private const int MinimumScreenHeight = 1080;

        private KinectSensorChooser sensorChooser;
        private Navigator navigator;
        private KinectPageFactory pageFactory;

        //private readonly KinectController _controller = new KinectController();

        private readonly MouseMovementDetector _movementDetector;


        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            navigator = new Navigator(this);
            pageFactory = new KinectPageFactory(navigator);

            _movementDetector = new MouseMovementDetector(this);
            _movementDetector.OnMovingChanged += OnIsMouseMovingChanged;
            _movementDetector.Start();

            SetView(pageFactory.GetSleepScreen().GetView());
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            this.sensorChooser = new KinectSensorChooser();
            this.sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
            sensorChooserUi.KinectSensorChooser = this.sensorChooser as KinectSensorChooser;
            this.sensorChooser.Start();

            // check resolution
            double height = SystemParameters.PrimaryScreenHeight;
            double width = SystemParameters.PrimaryScreenWidth;
            if (width < MinimumScreenWidth || height < MinimumScreenHeight)
            {
                MessageBoxResult continueResult = MessageBox.Show(Properties.Resources.SmallerScreenResolutionMessage, Properties.Resources.SmallerScreenResolutionTitle, MessageBoxButton.YesNo);
                if (continueResult == MessageBoxResult.No)
                {
                    this.Close();
                }
            }

        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (null == e)
            {
                throw new ArgumentNullException("e");
            }

            if (Key.Escape == e.Key)
            {
                this.Close();
            }

            base.OnKeyUp(e);
        }

        private void OnIsMouseMovingChanged(object sender, EventArgs e)
        {
            if (_movementDetector.IsMoving == true) Wake();
            else Sleep();
        }

        public void Wake()
        {
            SetView(pageFactory.GetMainMenu().GetView());
        }
        public void Sleep()
        {
            IKinectPage first = pageFactory.GetSleepScreen();
            pageFactory.NavigateTo(first);
        }

        private void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs args)
        {
            bool error = false;
            if (args.OldSensor != null)
            {
                try
                {
                    args.OldSensor.DepthStream.Range = DepthRange.Default;
                    args.OldSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    args.OldSensor.DepthStream.Disable();
                    args.OldSensor.SkeletonStream.Disable();
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                    error = true;
                }
            }



            if (args.NewSensor != null)
            {
                try
                {
                    args.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    args.NewSensor.SkeletonStream.Enable();
                    try
                    {
                        args.NewSensor.DepthStream.Range = DepthRange.Near;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;
                        args.NewSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;
                    }
                    catch (InvalidOperationException)
                    {
                        // Non Kinect for Windows devices do not support Near mode, so reset back to default mode.
                        args.NewSensor.DepthStream.Range = DepthRange.Default;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;
                        //error = true;
                    }
                }

                catch (InvalidOperationException)
                {
                    error = true;
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }
            }
            if (!error)
            {
                KinectRegion.KinectSensor = args.NewSensor;
            }
        }

        public void SetView(Grid grid)
        {
            PageContentGrid.Children.Clear();
            PageContentGrid.Children.Add(grid);
        }

    }
}

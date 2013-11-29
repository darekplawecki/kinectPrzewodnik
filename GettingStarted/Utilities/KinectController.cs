using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using Microsoft.Kinect.Toolkit.Interaction;
using Microsoft.Kinect.Toolkit.BackgroundRemoval;
using Przewodnik.ViewModels;
using System.Windows.Media.Imaging;
using System.Diagnostics;

namespace Przewodnik.Utilities
{
    [Export(typeof(KinectController))]
    public class KinectController : ViewModelBase
    {

        private readonly KinectSensorChooser _sensorChooser;
        public KinectSensorChooser KinectSensorChooser
        {
            get { return _sensorChooser; }
        }

        private Skeleton[] skeletons;

        private BackgroundRemovedColorStream _backgroundRemovedColorStream;
        private WriteableBitmap _foregroundBitmap;
        public WriteableBitmap ForegroundBitmap
        {
            get { return _foregroundBitmap; }
            set
            {
                _foregroundBitmap = value;
                OnPropertyChanged("ForegroundBitmap");
            }
        }

        private InteractionStream interactionStream;
        class InteractionAdapter : IInteractionClient
        {
            public InteractionInfo GetInteractionInfoAtLocation(int skeletonTrackingId, InteractionHandType handType, double x, double y)
            {
                var interactionInfo = new InteractionInfo
                {
                    IsPressTarget = false,
                    IsGripTarget = false,
                };

                return interactionInfo;
            }
        }

        private UserInfo[] userInfos;

        private Navigator _navigator;
        public Navigator Navigator
        {
            get
            {
                return _navigator;
            }

            set
            {
                _navigator = value;
            }
        }



        private readonly EngagementStateManager engagementStateManager = new EngagementStateManager();

        private const double HandoffConfirmationStasisSeconds = 0.5;

        private readonly TimeSpan disengagementHandoffNavigationTimeout = TimeSpan.FromSeconds(10.0);

        private readonly TimeSpan disengagementNoHandoffNavigationTimeout = TimeSpan.FromSeconds(2.0);

        private readonly RelayCommand shutdownCommand;

        private readonly RelayCommand<RoutedEventArgs> engagementConfirmationCommand;

        private readonly RelayCommand<RoutedEventArgs> engagementHandoffConfirmationCommand;

        private readonly int[] recommendedUserTrackingIds = new int[2];

        private readonly DispatcherTimer handoffConfirmationStasisTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(HandoffConfirmationStasisSeconds) };

        private readonly DispatcherTimer disengagementNavigationTimer = new DispatcherTimer();

        private bool isInEngagementOverrideMode;

        private bool isUserEngaged;

        private bool isUserEngagementCandidate;

        private bool isUserActive;

        private bool isUserTracked;

        private PromptState startBannerState = PromptState.Hidden;

        private PromptState engagementConfirmationState = PromptState.Hidden;

        private bool isEngagementHandoffBarrierEnabled;


        #region "Left & Right Handoff Message State, Text, Brush, Confirmation State"

        private PromptState _leftHandoffMessageState = PromptState.Hidden;
        public PromptState LeftHandoffMessageState
        {
            get
            {
                return _leftHandoffMessageState;
            }

            protected set
            {
                _leftHandoffMessageState = value;
                OnPropertyChanged("LeftHandoffMessageState");
            }
        }

        private PromptState _rightHandoffMessageState = PromptState.Hidden;
        public PromptState RightHandoffMessageState
        {
            get
            {
                return _rightHandoffMessageState;
            }

            protected set
            {
                _rightHandoffMessageState = value;
                OnPropertyChanged("RightHandoffMessageState");
            }
        }

        private string _leftHandoffMessageText;
        public string LeftHandoffMessageText
        {
            get
            {
                return _leftHandoffMessageText;
            }

            protected set
            {
                _leftHandoffMessageText = value;
                OnPropertyChanged("LeftHandoffMessageText");
            }
        }

        private string _rightHandoffMessageText;
        public string RightHandoffMessageText
        {
            get
            {
                return _rightHandoffMessageText;
            }

            protected set
            {
                _rightHandoffMessageText = value;
                OnPropertyChanged("RightHandoffMessageText");
            }
        }

        private Brush _leftHandoffMessageBrush;
        public Brush LeftHandoffMessageBrush
        {
            get
            {
                return _leftHandoffMessageBrush;
            }

            protected set
            {
                _leftHandoffMessageBrush = value;
                OnPropertyChanged("LeftHandoffMessageBrush");
            }
        }

        private Brush _rightHandoffMessageBrush;
        public Brush RightHandoffMessageBrush
        {
            get
            {
                return _rightHandoffMessageBrush;
            }

            protected set
            {
                _rightHandoffMessageBrush = value;
                OnPropertyChanged("RightHandoffMessageBrush");
            }
        }

        private PromptState _leftHandoffConfirmationState = PromptState.Hidden;
        public PromptState LeftHandoffConfirmationState
        {
            get
            {
                return _leftHandoffConfirmationState;
            }

            protected set
            {
                _leftHandoffConfirmationState = value;
                OnPropertyChanged("LeftHandoffConfirmationState");
            }
        }

        private PromptState _rightHandoffConfirmationState = PromptState.Hidden;
        public PromptState RightHandoffConfirmationState
        {
            get
            {
                return _rightHandoffConfirmationState;
            }

            protected set
            {
                _rightHandoffConfirmationState = value;
                OnPropertyChanged("RightHandoffConfirmationState");
            }
        }

        #endregion


        #region "InteractionHand Type, Joint, Grip, Primary"

        private InteractionHandEventType _leftHandInteractionType;
        public InteractionHandEventType LeftHandInteractionType
        {
            get { return this._leftHandInteractionType; }
            set
            {
                this._leftHandInteractionType = value;
                OnPropertyChanged("LeftHandInteractionType");
            }
        }

        private InteractionHandEventType _rightHandInteractionType;
        public InteractionHandEventType RightHandInteractionType
        {
            get { return this._rightHandInteractionType; }
            set
            {
                this._rightHandInteractionType = value;
                OnPropertyChanged("RightHandInteractionType");
            }
        }

        private Joint _leftHandJoint;
        public Joint LeftHandJoint
        {
            get { return this._leftHandJoint; }
            set
            {
                _leftHandJoint = value;
                OnPropertyChanged("LeftHandJoint");
            }
        }

        private Joint _rightHandJoint;
        public Joint RightHandJoint
        {
            get { return this._rightHandJoint; }
            set
            {
                this._rightHandJoint = value;
                OnPropertyChanged("RightHandJoint");
            }
        }

        private bool _isLeftHandGrip;
        public bool IsLeftHandGrip
        {
            get { return this._isLeftHandGrip; }
            set
            {
                this._isLeftHandGrip = value;
                OnPropertyChanged("IsLeftHandGrip");
            }
        }

        private bool _isRightHandGrip;
        public bool IsRightHandGrip
        {
            get { return this._isRightHandGrip; }
            set
            {
                this._isRightHandGrip = value;
                OnPropertyChanged("IsRightHandGrip");
            }
        }

        private bool _isPrimaryLeftHand;
        public bool IsPrimaryLeftHand
        {
            get { return _isPrimaryLeftHand; }
            set
            {
                _isPrimaryLeftHand = value;
                OnPropertyChanged("IsPrimaryLeftHand");
            }
        }

        private bool _isPrimaryRightHand;
        public bool IsPrimaryRightHand
        {
            get { return _isPrimaryRightHand; }
            set
            {
                _isPrimaryRightHand = value;
                OnPropertyChanged("IsPrimaryRightHand");
            }
        }

        #endregion



        public KinectController()
        {
            _sensorChooser = new KinectSensorChooser();

            QueryPrimaryUserCallback = this.OnQueryPrimaryUserCallback;
            PreEngagementUserColors = new Dictionary<int, Color>();
            PostEngagementUserColors = new Dictionary<int, Color>();

            engagementStateManager.TrackedUsersChanged += this.OnEngagementManagerTrackedUsersChanged;
            engagementStateManager.CandidateUserChanged += this.OnEngagementManagerCandidateUserChanged;
            engagementStateManager.EngagedUserChanged += this.OnEngagementManagerEngagedUserChanged;
            engagementStateManager.PrimaryUserChanged += this.OnEngagementManagerPrimaryUserChanged;

            handoffConfirmationStasisTimer.Tick += this.OnHandoffConfirmationStasisTimerTick;
            disengagementNavigationTimer.Tick += this.OnDisengagementNavigationTick;

            shutdownCommand = new RelayCommand(this.Cleanup);
            engagementConfirmationCommand = new RelayCommand<RoutedEventArgs>(this.OnEngagementConfirmation);
            engagementHandoffConfirmationCommand = new RelayCommand<RoutedEventArgs>(this.OnEngagementHandoffConfirmation);

            _sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
            _sensorChooser.Start();
        }


        private void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs e)
        {
            if (null != e.OldSensor)
            {
                try
                {
                    e.OldSensor.AllFramesReady -= AllFramesReady;

                    e.OldSensor.SkeletonStream.AppChoosesSkeletons = false;
                    e.OldSensor.DepthStream.Range = DepthRange.Default;
                    e.OldSensor.SkeletonStream.EnableTrackingInNearRange = false;

                    e.OldSensor.DepthStream.Disable();
                    e.OldSensor.ColorStream.Disable();
                    e.OldSensor.SkeletonStream.Disable();

                    if (null != _backgroundRemovedColorStream)
                    {
                        _backgroundRemovedColorStream.BackgroundRemovedFrameReady -= BackgroundRemovedFrameReadyHandler;
                        _backgroundRemovedColorStream.Dispose();
                        _backgroundRemovedColorStream = null;
                    }
                }
                catch (InvalidOperationException) { }

                this.engagementStateManager.Reset();
            }

            if (e.NewSensor != null)
            {
                try
                {
                    e.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    e.NewSensor.ColorStream.Enable();
                    e.NewSensor.SkeletonStream.Enable();

                    InteractionAdapter interactionAdapter = new InteractionAdapter();
                    interactionStream = new InteractionStream(e.NewSensor, interactionAdapter);
                    interactionStream.InteractionFrameReady += new EventHandler<InteractionFrameReadyEventArgs>(HandsInteractionFrameReady);
                    userInfos = new UserInfo[InteractionFrame.UserInfoArrayLength];

                    _backgroundRemovedColorStream = new BackgroundRemovedColorStream(e.NewSensor);
                    _backgroundRemovedColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30, DepthImageFormat.Resolution640x480Fps30);

                    if (null == skeletons)
                    {
                        skeletons = new Skeleton[e.NewSensor.SkeletonStream.FrameSkeletonArrayLength];
                    }

                    _backgroundRemovedColorStream.BackgroundRemovedFrameReady += BackgroundRemovedFrameReadyHandler;

                    e.NewSensor.AllFramesReady += AllFramesReady;

                    try
                    {
                        e.NewSensor.DepthStream.Range = DepthRange.Near;
                        e.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;
                    }
                    catch (InvalidOperationException)
                    {
                        e.NewSensor.DepthStream.Range = DepthRange.Default;
                        e.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    }
                    e.NewSensor.SkeletonStream.AppChoosesSkeletons = true;

                }
                catch (InvalidOperationException) { }
            }

            // NAVIGATE
            Debug.WriteLine("Kinect sensor changes, reset to sleep screen.");
            _navigator.GoSleep();
            this.IsUserEngaged = false;
        }


        private void HandsInteractionFrameReady(object sender, InteractionFrameReadyEventArgs e)
        {
            using (InteractionFrame interactionFrame = e.OpenInteractionFrame())
            {
                if (interactionFrame != null)
                {
                    interactionFrame.CopyInteractionDataTo(this.userInfos);
                }
                else
                {
                    return;
                }
            }

            foreach (UserInfo userInfo in userInfos)
            {
                foreach (InteractionHandPointer interactionHandPointer in userInfo.HandPointers)
                {
                    // track if the left hand or right hand is griped
                    if (interactionHandPointer.HandType == InteractionHandType.Left)
                    {
                        IsPrimaryLeftHand = interactionHandPointer.IsPrimaryForUser;

                        switch (interactionHandPointer.HandEventType)
                        {
                            case InteractionHandEventType.Grip:
                                LeftHandInteractionType = interactionHandPointer.HandEventType;
                                IsLeftHandGrip = true;
                                break;
                            case InteractionHandEventType.GripRelease:
                                this.LeftHandInteractionType = interactionHandPointer.HandEventType;
                                this.IsLeftHandGrip = false;
                                break;
                        }

                    }
                    else if (interactionHandPointer.HandType == InteractionHandType.Right)
                    {
                        IsPrimaryRightHand = interactionHandPointer.IsPrimaryForUser;

                        switch (interactionHandPointer.HandEventType)
                        {
                            case InteractionHandEventType.Grip:
                                this.RightHandInteractionType = interactionHandPointer.HandEventType;
                                this.IsRightHandGrip = true;
                                break;
                            case InteractionHandEventType.GripRelease:
                                this.RightHandInteractionType = interactionHandPointer.HandEventType;
                                this.IsRightHandGrip = false;
                                break;
                        }
                    }
                }
            }

        }

        private void AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            if (null == this._sensorChooser || null == this._sensorChooser.Kinect || this._sensorChooser.Kinect != sender)
            {
                return;
            }

            try
            {
                using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
                {
                    if (null != depthFrame)
                    {
                        _backgroundRemovedColorStream.ProcessDepth(depthFrame.GetRawPixelData(), depthFrame.Timestamp);
                        interactionStream.ProcessDepth(depthFrame.GetRawPixelData(), depthFrame.Timestamp);
                    }
                }

                using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
                {
                    if (null != colorFrame)
                    {
                        _backgroundRemovedColorStream.ProcessColor(colorFrame.GetRawPixelData(), colorFrame.Timestamp);
                    }
                }

                using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
                {
                    if (null != skeletonFrame)
                    {
                        if (null == skeletons || skeletons.Length != skeletonFrame.SkeletonArrayLength)
                        {
                            skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                        }

                        skeletonFrame.CopySkeletonDataTo(this.skeletons);

                        _backgroundRemovedColorStream.ProcessSkeleton(this.skeletons, skeletonFrame.Timestamp);

                        engagementStateManager.ChooseTrackedUsers(skeletons, skeletonFrame.Timestamp, this.recommendedUserTrackingIds);
                        var sensor = sender as KinectSensor;
                        if (null != sensor)
                        {
                            try
                            {
                                sensor.SkeletonStream.ChooseSkeletons(this.recommendedUserTrackingIds[0], this.recommendedUserTrackingIds[1]);

                                Skeleton skeleton = GetPrimarySkeleton(skeletons);
                                if (skeleton != null)
                                {
                                    var accelerometerReading = _sensorChooser.Kinect.AccelerometerGetCurrentReading();
                                    interactionStream.ProcessSkeleton(skeletons, accelerometerReading, skeletonFrame.Timestamp);

                                    LeftHandJoint = skeleton.Joints[JointType.HandLeft];
                                    RightHandJoint = skeleton.Joints[JointType.HandRight];
                                }

                            }
                            catch (InvalidOperationException) { }
                        }
                    }
                }

                ChooseSkeleton();
            }
            catch (InvalidOperationException) { }
        }

        private void BackgroundRemovedFrameReadyHandler(object sender, BackgroundRemovedColorFrameReadyEventArgs e)
        {
            using (var backgroundRemovedFrame = e.OpenBackgroundRemovedColorFrame())
            {
                if (backgroundRemovedFrame != null)
                {
                    if (null == ForegroundBitmap || ForegroundBitmap.PixelWidth != backgroundRemovedFrame.Width
                        || ForegroundBitmap.PixelHeight != backgroundRemovedFrame.Height)
                    {
                        ForegroundBitmap = new WriteableBitmap(backgroundRemovedFrame.Width, backgroundRemovedFrame.Height, 96.0, 96.0, PixelFormats.Bgra32, null);
                    }

                    // Write the pixel data into our bitmap
                    ForegroundBitmap.WritePixels(
                        new Int32Rect(0, 0, ForegroundBitmap.PixelWidth, ForegroundBitmap.PixelHeight),
                        backgroundRemovedFrame.GetRawPixelData(),
                        ForegroundBitmap.PixelWidth * sizeof(int),
                        0);
                }
            }
        }


        private int _currentlyTrackedSkeletonId;
        private void ChooseSkeleton()
        {
            var isTrackedSkeltonVisible = false;
            var nearestDistance = float.MaxValue;
            var nearestSkeleton = 0;

            foreach (var skel in skeletons)
            {
                if (null == skel)
                {
                    continue;
                }

                if (skel.TrackingState != SkeletonTrackingState.Tracked)
                {
                    continue;
                }

                if (skel.TrackingId == _currentlyTrackedSkeletonId)
                {
                    isTrackedSkeltonVisible = true;
                    break;
                }

                if (skel.Position.Z < nearestDistance)
                {
                    nearestDistance = skel.Position.Z;
                    nearestSkeleton = skel.TrackingId;
                }
            }

            if (!isTrackedSkeltonVisible && nearestSkeleton != 0)
            {
                _backgroundRemovedColorStream.SetTrackedPlayer(nearestSkeleton);
                _currentlyTrackedSkeletonId = nearestSkeleton;
            }
        }

        private Skeleton GetPrimarySkeleton(Skeleton[] skeletons)
        {
            Skeleton skeleton = null;
            if (skeletons != null)
            {
                for (int i = 0; i < skeletons.Length; i++)
                {
                    if (skeletons[i].TrackingState == SkeletonTrackingState.Tracked)
                    {
                        if (skeleton == null)
                        {
                            skeleton = skeletons[i];
                        }
                        else
                        {
                            if (skeleton.Position.Z > skeletons[i].Position.Z)
                            {
                                skeleton = skeletons[i];
                            }
                        }
                    }
                }
            }
            return skeleton;
        }




        public ICommand ShutdownCommand
        {
            get { return this.shutdownCommand; }
        }

        public ICommand EngagementConfirmationCommand
        {
            get { return this.engagementConfirmationCommand; }
        }

        public ICommand EngagementHandoffConfirmationCommand
        {
            get { return this.engagementHandoffConfirmationCommand; }
        }



        public QueryPrimaryUserTrackingIdCallback QueryPrimaryUserCallback { get; private set; }

        private int OnQueryPrimaryUserCallback(int proposedTrackingId, IEnumerable<HandPointer> candidateHandPointers, long timestamp)
        {
            return this.engagementStateManager.QueryPrimaryUserCallback(proposedTrackingId, candidateHandPointers);
        }


        public bool IsInEngagementOverrideMode
        {
            get
            {
                return this.isInEngagementOverrideMode;
            }

            set
            {
                this.isInEngagementOverrideMode = value;

                this.UpdateUserEngaged();
                this.UpdateUserTracked();
            }
        }

        public bool IsUserEngaged
        {
            get
            {
                return this.isUserEngaged;
            }

            protected set
            {
                bool wasEngaged = this.isUserEngaged;

                this.isUserEngaged = value;
                this.OnPropertyChanged("IsUserEngaged");

                if (wasEngaged != this.isUserEngaged)
                {
                    this.PerformEngagementChangeNavigation();
                }

                this.UpdateCurrentNavigationContextState();
                this.UpdateUserActive();
                this.UpdateStartBannerState();
                this.UpdateEngagementHandoffBarrier();
            }
        }

        public bool IsUserEngagementCandidate
        {
            get
            {
                return this.isUserEngagementCandidate;
            }

            protected set
            {
                this.isUserEngagementCandidate = value;
                this.OnPropertyChanged("IsUserEngagementCandidate");

                this.UpdateUserActive();
                this.UpdateStartBannerState();
                this.UpdateEngagementConfirmationState();
                this.UpdateEngagementHandoffBarrier();
            }
        }

        public bool IsUserActive
        {
            get
            {
                return this.isUserActive;
            }

            protected set
            {
                this.isUserActive = value;
                this.OnPropertyChanged("IsUserActive");
            }
        }

        public bool IsUserTracked
        {
            get
            {
                return this.isUserTracked;
            }

            protected set
            {
                this.isUserTracked = value;
                this.OnPropertyChanged("IsUserTracked");

                this.UpdateStartBannerState();
            }
        }



        public PromptState StartBannerState
        {
            get
            {
                return this.startBannerState;
            }

            protected set
            {
                this.startBannerState = value;
                this.OnPropertyChanged("StartBannerState");
            }
        }

        public PromptState EngagementConfirmationState
        {
            get
            {
                return this.engagementConfirmationState;
            }

            protected set
            {
                this.engagementConfirmationState = value;
                this.OnPropertyChanged("EngagementConfirmationState");
            }
        }

        public bool IsEngagementHandoffBarrierEnabled
        {
            get
            {
                return this.isEngagementHandoffBarrierEnabled;
            }

            protected set
            {
                this.isEngagementHandoffBarrierEnabled = value;
                this.OnPropertyChanged("IsEngagementHandoffBarrierEnabled");
            }
        }



        public Color EngagedUserColor { get; set; }

        public Color TrackedUserColor { get; set; }

        public Brush EngagedUserMessageBrush { get; set; }

        public Brush TrackedUserMessageBrush { get; set; }

        public Dictionary<int, Color> PreEngagementUserColors { get; private set; }

        public Dictionary<int, Color> PostEngagementUserColors { get; private set; }

        internal void OnHandPointersUpdated(ICollection<HandPointer> handPointers)
        {
            this.engagementStateManager.UpdateHandPointers(handPointers);
        }

        private void Cleanup()
        {

            this._sensorChooser.Stop();
        }



        private void OnEngagementConfirmation(RoutedEventArgs e)
        {
            if (this.engagementStateManager.ConfirmCandidateEngagement(this.engagementStateManager.CandidateUserTrackingId))
            {
                this.UpdateEngagementConfirmationState();
            }
        }

        private void OnEngagementHandoffConfirmation(RoutedEventArgs e)
        {
            if (this.engagementStateManager.ConfirmCandidateEngagement(this.engagementStateManager.CandidateUserTrackingId))
            {
                this.UpdateEngagementHandoffBarrier();
                this.UpdateEngagementHandoffState(true);
            }
        }

        private void OnEngagementManagerTrackedUsersChanged(object sender, EventArgs e)
        {
            this.UpdateUserTracked();
            this.UpdateUserColors();
            this.UpdateEngagementHandoffState(false);
        }

        private void OnEngagementManagerEngagedUserChanged(object sender, UserTrackingIdChangedEventArgs e)
        {
            this.UpdateUserEngaged();
        }

        private void OnEngagementManagerCandidateUserChanged(object sender, UserTrackingIdChangedEventArgs e)
        {
            this.IsUserEngagementCandidate = EngagementStateManager.InvalidUserTrackingId != e.NewValue;
        }

        private void OnEngagementManagerPrimaryUserChanged(object sender, UserTrackingIdChangedEventArgs e)
        {
            this.UpdateCurrentNavigationContextState();
        }



        private void UpdateUserColors()
        {
            this.PreEngagementUserColors.Clear();
            this.PostEngagementUserColors.Clear();

            foreach (var trackingId in this.engagementStateManager.TrackedUserTrackingIds)
            {
                if (trackingId == this.engagementStateManager.EngagedUserTrackingId)
                {
                    this.PreEngagementUserColors[trackingId] = this.EngagedUserColor;
                    this.PostEngagementUserColors[trackingId] = this.EngagedUserColor;
                }
                else
                {
                    this.PreEngagementUserColors[trackingId] = this.EngagedUserColor;

                    if ((this.engagementStateManager.EngagedUserTrackingId == EngagementStateManager.InvalidUserTrackingId) ||
                        (this.engagementStateManager.EngagedUserTrackingId != this.engagementStateManager.PrimaryUserTrackingId))
                    {
                        // Differentiate tracked users from background users only if there is no
                        // engaged user currently interacting.
                        this.PostEngagementUserColors[trackingId] = this.TrackedUserColor;
                    }
                }
            }
        }


        private void UpdateUserEngaged()
        {
            this.IsUserEngaged = this.IsInEngagementOverrideMode
                                 || (EngagementStateManager.InvalidUserTrackingId != this.engagementStateManager.EngagedUserTrackingId);
        }

        private void UpdateUserActive()
        {
            this.IsUserActive = this.IsUserEngagementCandidate || this.IsUserEngaged;
        }

        private void UpdateUserTracked()
        {
            this.IsUserTracked = this.IsInEngagementOverrideMode || (this.engagementStateManager.TrackedUserTrackingIds.Count > 0);
        }


        private void UpdateStartBannerState()
        {
            var state = PromptState.Hidden;

            if (this.IsUserTracked)
            {
                state = this.IsUserEngagementCandidate || this.IsUserEngaged ? PromptState.Dismissed : PromptState.Prompting;
            }

            this.StartBannerState = state;
        }

        private void UpdateEngagementConfirmationState()
        {
            var state = PromptState.Hidden;

            if (this.IsUserEngaged)
            {
                state = PromptState.Dismissed;
            }
            else if (this.IsUserEngagementCandidate)
            {
                state = PromptState.Prompting;
            }

            this.EngagementConfirmationState = state;
        }

        private void UpdateEngagementHandoffBarrier()
        {
            this.IsEngagementHandoffBarrierEnabled = this.IsUserEngaged && this.IsUserEngagementCandidate;
        }

        private void UpdateEngagementHandoffState(bool confirmHandoff)
        {
            if (this.handoffConfirmationStasisTimer.IsEnabled)
            {
                // If timer is already running, wait for it to finish
                return;
            }

            if (confirmHandoff)
            {
                // If confirming handoff, mark handoff confirmation prompts as
                // dismissed and start timer to re-update state later.
                this.ClearEngagementHandoff();
                this.LeftHandoffConfirmationState = PromptState.Dismissed;
                this.RightHandoffConfirmationState = PromptState.Dismissed;
                this.handoffConfirmationStasisTimer.Start();

                return;
            }

            if ((this.engagementStateManager.EngagedUserTrackingId == EngagementStateManager.InvalidUserTrackingId) ||
                (this.engagementStateManager.EngagedUserTrackingId == this.engagementStateManager.PrimaryUserTrackingId) ||
                (this.engagementStateManager.TrackedUserTrackingIds.Count < 2))
            {
                // If we're currently transitioning engagement states, if there is no engaged
                // user, if engaged user is actively interacting, or there is nobody besides the
                // engaged user, then there is no need for engagement handoff UI to be shown.
                this.ClearEngagementHandoff();
                return;
            }

            int nonEngagedId = this.engagementStateManager.TrackedUserTrackingIds.FirstOrDefault(trackingId => trackingId != this.engagementStateManager.EngagedUserTrackingId);

            SkeletonPoint? lastEngagedPosition =
                this.engagementStateManager.TryGetLastPositionForId(this.engagementStateManager.EngagedUserTrackingId);
            SkeletonPoint? lastNonEngagedPosition = this.engagementStateManager.TryGetLastPositionForId(nonEngagedId);

            if (!lastEngagedPosition.HasValue || !lastNonEngagedPosition.HasValue)
            {
                // If we can't determine the relative position of engaged and non-engaged user,
                // we don't show an engagement handoff prompt at all.
                this.ClearEngagementHandoff();
                return;
            }

            PromptState engagedMessageState = PromptState.Hidden;
            string engagedMessageText = string.Empty;
            Brush engagedBrush = this.EngagedUserMessageBrush;
            PromptState engagedConfirmationState = PromptState.Hidden;
            PromptState nonEngagedMessageState = PromptState.Prompting;
            string nonEngagedMessageText = Properties.Resources.EngagementHandoffGetStarted;
            Brush nonEngagedBrush = this.TrackedUserMessageBrush;
            PromptState nonEngagedConfirmationState = PromptState.Hidden;

            if ((EngagementStateManager.InvalidUserTrackingId != this.engagementStateManager.CandidateUserTrackingId) &&
                (nonEngagedId == this.engagementStateManager.CandidateUserTrackingId))
            {
                // If non-engaged user is an engagement candidate
                engagedMessageState = PromptState.Prompting;
                engagedMessageText = Properties.Resources.EngagementHandoffKeepControl;
                nonEngagedMessageText = string.Empty;
                nonEngagedConfirmationState = PromptState.Prompting;
            }

            bool isEngagedOnLeft = lastEngagedPosition.Value.X < lastNonEngagedPosition.Value.X;

            this.LeftHandoffMessageState = isEngagedOnLeft ? engagedMessageState : nonEngagedMessageState;
            this.LeftHandoffMessageText = isEngagedOnLeft ? engagedMessageText : nonEngagedMessageText;
            this.LeftHandoffMessageBrush = isEngagedOnLeft ? engagedBrush : nonEngagedBrush;
            this.LeftHandoffConfirmationState = isEngagedOnLeft ? engagedConfirmationState : nonEngagedConfirmationState;
            this.RightHandoffMessageState = isEngagedOnLeft ? nonEngagedMessageState : engagedMessageState;
            this.RightHandoffMessageText = isEngagedOnLeft ? nonEngagedMessageText : engagedMessageText;
            this.RightHandoffMessageBrush = isEngagedOnLeft ? nonEngagedBrush : engagedBrush;
            this.RightHandoffConfirmationState = isEngagedOnLeft ? nonEngagedConfirmationState : engagedConfirmationState;
        }

        private void ClearEngagementHandoff()
        {
            this.LeftHandoffMessageState = PromptState.Hidden;
            this.LeftHandoffMessageText = string.Empty;
            this.LeftHandoffConfirmationState = PromptState.Hidden;
            this.RightHandoffMessageState = PromptState.Hidden;
            this.RightHandoffMessageText = string.Empty;
            this.RightHandoffConfirmationState = PromptState.Hidden;
        }

        private void UpdateCurrentNavigationContextState()
        {
            //var viewModel = NavigationManager.CurrentNavigationContext as ViewModelBase;
            //if (null != viewModel)
            //{
            //    int primaryUserTrackingId = this.engagementStateManager.PrimaryUserTrackingId;
            //    int engagedUserTrackingId = this.engagementStateManager.EngagedUserTrackingId;

            //    // Application views should only care about interaction state of currently engaged user
            //    viewModel.IsUserInteracting = this.IsInEngagementOverrideMode
            //                                  ||
            //                                  ((primaryUserTrackingId != EngagementStateManager.InvalidUserTrackingId)
            //                                   && (primaryUserTrackingId == engagedUserTrackingId));
            //}
        }

        private void StartDisengagementNavigationTimer()
        {
            bool isAnotherUserTracked = this.engagementStateManager.TrackedUserTrackingIds.Any(trackingId => trackingId != EngagementStateManager.InvalidUserTrackingId);

            this.disengagementNavigationTimer.Interval = isAnotherUserTracked ? this.disengagementHandoffNavigationTimeout : this.disengagementNoHandoffNavigationTimeout;
            this.disengagementNavigationTimer.Start();
        }

        private void PerformEngagementChangeNavigation()
        {
            if (this.disengagementNavigationTimer.IsEnabled)
            {
                this.disengagementNavigationTimer.Stop();

                if (!this.IsUserEngaged)
                {
                    // If disengagement timer was already started, and another user got disengaged, reset timer
                    this.StartDisengagementNavigationTimer();
                }
                //// Else if a user just became engaged while waiting for disengagement timer to fire, don't take
                //// any navigation actions
            }
            else if (!this.disengagementNavigationTimer.IsEnabled)
            {
                if (this.IsUserEngaged)
                {
                    // If there was no engaged user and now there is, initiate a navigation to the home screen.

                    // NAVIGATE
                    //MessageBox.Show("Timer Stop");
                    _navigator.GoHome();
                    //MessageBox.Show("Zalogowany = MENU GŁÓWNE", "Navigate");
                }
                else
                {
                    // Wait until timeout period before navigating to attract scren
                    this.StartDisengagementNavigationTimer();
                }
            }
            //// Else If we have just changed between interacting users, no navigation action is undertaken
        }

        private void OnHandoffConfirmationStasisTimerTick(object sender, EventArgs e)
        {
            this.handoffConfirmationStasisTimer.Stop();
            this.UpdateEngagementHandoffState(false);
        }

        private void OnDisengagementNavigationTick(object sender, EventArgs e)
        {
            // If a user disengaged and nobody took control before timer expired, go back to attract screen
            this.disengagementNavigationTimer.Stop();

            // NAVIGATE
            _navigator.GoSleep();
            //MessageBox.Show("Brak osoby nawigującej = INSTAGRAM", "Navigate");
        }

        private void OnNavigationManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if ("CurrentNavigationContext".Equals(e.PropertyName))
            {
                this.UpdateCurrentNavigationContextState();
            }
        }
    }
}

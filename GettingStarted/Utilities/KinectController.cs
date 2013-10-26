using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;

namespace Przewodnik.Utilities
{
    [Export(typeof(KinectController))]
    public class KinectController : ViewModelBase
    {
        private const double HandoffConfirmationStasisSeconds = 0.5;

        private readonly KinectSensorChooser sensorChooser;

        private Navigator _navigator;

        private readonly EngagementStateManager engagementStateManager = new EngagementStateManager();

        private readonly TimeSpan disengagementHandoffNavigationTimeout = TimeSpan.FromSeconds(10.0);

        private readonly TimeSpan disengagementNoHandoffNavigationTimeout = TimeSpan.FromSeconds(2.0);

        private readonly RelayCommand shutdownCommand;

        private readonly RelayCommand<RoutedEventArgs> engagementConfirmationCommand;

        private readonly RelayCommand<RoutedEventArgs> engagementHandoffConfirmationCommand;

        private readonly int[] recommendedUserTrackingIds = new int[2];

        private readonly DispatcherTimer handoffConfirmationStasisTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(HandoffConfirmationStasisSeconds) };

        private readonly DispatcherTimer disengagementNavigationTimer = new DispatcherTimer();

        private Skeleton[] skeletons;

        private bool isInEngagementOverrideMode;

        private bool isUserEngaged;

        private bool isUserEngagementCandidate;

        private bool isUserActive;

        private bool isUserTracked;

        private PromptState startBannerState = PromptState.Hidden;

        private PromptState engagementConfirmationState = PromptState.Hidden;

        private bool isEngagementHandoffBarrierEnabled;

        private PromptState leftHandoffMessageState = PromptState.Hidden;

        private string leftHandoffMessageText;

        private Brush leftHandoffMessageBrush;

        private PromptState leftHandoffConfirmationState = PromptState.Hidden;

        private PromptState rightHandoffMessageState = PromptState.Hidden;

        private string rightHandoffMessageText;

        private Brush rightHandoffMessageBrush;

        private PromptState rightHandoffConfirmationState = PromptState.Hidden;


        public KinectController()
        {
            sensorChooser = new KinectSensorChooser();

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

            sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
            sensorChooser.Start();
        }

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

        public KinectSensorChooser KinectSensorChooser
        {
            get { return this.sensorChooser; }
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

        public PromptState LeftHandoffMessageState
        {
            get
            {
                return this.leftHandoffMessageState;
            }

            protected set
            {
                this.leftHandoffMessageState = value;
                this.OnPropertyChanged("LeftHandoffMessageState");
            }
        }

        public string LeftHandoffMessageText
        {
            get
            {
                return this.leftHandoffMessageText;
            }

            protected set
            {
                this.leftHandoffMessageText = value;
                this.OnPropertyChanged("LeftHandoffMessageText");
            }
        }

        public Brush LeftHandoffMessageBrush
        {
            get
            {
                return this.leftHandoffMessageBrush;
            }

            protected set
            {
                this.leftHandoffMessageBrush = value;
                this.OnPropertyChanged("LeftHandoffMessageBrush");
            }
        }

        public PromptState LeftHandoffConfirmationState
        {
            get
            {
                return this.leftHandoffConfirmationState;
            }

            protected set
            {
                this.leftHandoffConfirmationState = value;
                this.OnPropertyChanged("LeftHandoffConfirmationState");
            }
        }

        public PromptState RightHandoffMessageState
        {
            get
            {
                return this.rightHandoffMessageState;
            }

            protected set
            {
                this.rightHandoffMessageState = value;
                this.OnPropertyChanged("RightHandoffMessageState");
            }
        }

        public string RightHandoffMessageText
        {
            get
            {
                return this.rightHandoffMessageText;
            }

            protected set
            {
                this.rightHandoffMessageText = value;
                this.OnPropertyChanged("RightHandoffMessageText");
            }
        }

        public Brush RightHandoffMessageBrush
        {
            get
            {
                return this.rightHandoffMessageBrush;
            }

            protected set
            {
                this.rightHandoffMessageBrush = value;
                this.OnPropertyChanged("RightHandoffMessageBrush");
            }
        }

        public PromptState RightHandoffConfirmationState
        {
            get
            {
                return this.rightHandoffConfirmationState;
            }

            protected set
            {
                this.rightHandoffConfirmationState = value;
                this.OnPropertyChanged("RightHandoffConfirmationState");
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

        private void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs e)
        {
            KinectSensor oldSensor = e.OldSensor;
            KinectSensor newSensor = e.NewSensor;

            if (null != oldSensor)
            {
                try
                {
                    oldSensor.SkeletonFrameReady -= this.OnSkeletonFrameReady;
                    oldSensor.SkeletonStream.AppChoosesSkeletons = false;
                    oldSensor.DepthStream.Range = DepthRange.Default;
                    oldSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    oldSensor.DepthStream.Disable();
                    oldSensor.SkeletonStream.Disable();
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }

                this.engagementStateManager.Reset();
            }

            if (null != newSensor)
            {
                try
                {
                    newSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    newSensor.SkeletonStream.Enable();

                    try
                    {
                        newSensor.DepthStream.Range = DepthRange.Near;
                        newSensor.SkeletonStream.EnableTrackingInNearRange = true;
                    }
                    catch (InvalidOperationException)
                    {
                        // Non Kinect for Windows devices do not support Near mode, so reset back to default mode.
                        newSensor.DepthStream.Range = DepthRange.Default;
                        newSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    }

                    newSensor.SkeletonStream.AppChoosesSkeletons = true;
                    newSensor.SkeletonFrameReady += this.OnSkeletonFrameReady;
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }
            }

            // Whenever the Kinect sensor changes, we have no controlling user, so reset to attract screen
            
            // NAVIGATE
            _navigator.GoSleep();
            //MessageBox.Show("Start programu = INSTAGRAM", "Navigate");
            this.IsUserEngaged = false;
        }

        private void Cleanup()
        {
            this.sensorChooser.Stop();
        }

        private void OnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            bool haveSkeletons = false;
            long timestamp = 0;

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (null != skeletonFrame)
                {
                    if ((null == this.skeletons) || (this.skeletons.Length != skeletonFrame.SkeletonArrayLength))
                    {
                        this.skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    }

                    // Let engagement state manager choose which users to track.
                    skeletonFrame.CopySkeletonDataTo(this.skeletons);
                    timestamp = skeletonFrame.Timestamp;
                    haveSkeletons = true;
                }
            }

            if (haveSkeletons)
            {
                this.engagementStateManager.ChooseTrackedUsers(this.skeletons, timestamp, this.recommendedUserTrackingIds);

                var sensor = sender as KinectSensor;
                if (null != sensor)
                {
                    try
                    {
                        sensor.SkeletonStream.ChooseSkeletons(this.recommendedUserTrackingIds[0], this.recommendedUserTrackingIds[1]);
                    }
                    catch (InvalidOperationException)
                    {
                        // KinectSensor might enter an invalid state while choosing skeletons.
                        // E.g.: sensor might be abruptly unplugged.
                    }
                }
            }
        }

        private int OnQueryPrimaryUserCallback(int proposedTrackingId, IEnumerable<HandPointer> candidateHandPointers, long timestamp)
        {
            return this.engagementStateManager.QueryPrimaryUserCallback(proposedTrackingId, candidateHandPointers);
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

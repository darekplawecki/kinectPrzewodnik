using System;
using System.Windows;
using Microsoft.Kinect;
using Microsoft.Maps.MapControl.WPF;
using Przewodnik.Models;
using Przewodnik.Utilities;
using Przewodnik.Utilities.DataLoader;

namespace Przewodnik.ViewModels
{
    class MapViewModel : ViewModelBase
    {

        private const double ACCEPTED_HAND_MOVING = 0.05;
        private const double SPEED_ZOOMING = 0.01; // zalezy od parametru oraz jak zmienila sie odleglosc rak, od momentu zlapania
        private const double SPEED_MOVING = 1.0;

        private double _dependsMovementZoom;

        private KinectController _kinectController;
        private KinectHandUtilities _kinectHandUtilities;

        #region "Map Component Properties"

        /// <summary>
        /// Componenet for Bing Map Control
        /// </summary>
        private BingMap _bingMap;
        public BingMap BingMap
        {
            get { return this._bingMap; }
            set
            {
                this._bingMap = value;
                OnPropertyChanged("BingMap");
            }
        }

        private Location _mapCenterPoint;
        public Location MapCenterPoint
        {
            get { return _mapCenterPoint; }
            set
            {
                _mapCenterPoint = value;
                OnPropertyChanged("MapCenterPoint");
            }
        }

        /// <summary>
        /// Properties for Map Zoom Level
        /// </summary>
        private double _mapZoomLevel;
        public double MapZoomLevel
        {
            get { return this._mapZoomLevel; }
            set
            {
                _mapZoomLevel = value;
                OnPropertyChanged("MapZoomLevel");
            }
        }

        #endregion

        // zmienne zapamietane w momencie zlapania dloni
        private double _distanceTwoHand;
        private Point _positionRightHand;
        private Point _positionLeftHand;

        private double _leftHandX;
        public double LeftHandX
        {
            get { return _leftHandX; }
            set
            {
                _leftHandX = value;
                OnPropertyChanged("LeftHandX");
            }
        }

        private double _leftHandY;
        public double LeftHandY
        {
            get { return _leftHandY; }
            set
            {
                _leftHandY = value;
                OnPropertyChanged("LeftHandY");
            }
        }

        private double _rightHandX;
        public double RightHandX
        {
            get { return _rightHandX; }
            set
            {
                _rightHandX = value;
                OnPropertyChanged("RightHandX");
            }
        }

        private double _rightHandY;
        public double RightHandY
        {
            get { return _rightHandY; }
            set
            {
                _rightHandY = value;
                OnPropertyChanged("RightHandY");
            }
        }


        private Visibility _interactionIcoZoomVisibility;
        public Visibility InteractionIcoZoomVisibility
        {
            get { return _interactionIcoZoomVisibility; }
            set
            {
                _interactionIcoZoomVisibility = value;
                OnPropertyChanged("InteractionIcoZoomVisibility");
            }
        }
        private Visibility _interactionIcoZoomPlusVisibility;
        public Visibility InteractionIcoZoomPlusVisibility
        {
            get { return _interactionIcoZoomPlusVisibility; }
            set
            {
                _interactionIcoZoomPlusVisibility = value;
                OnPropertyChanged("InteractionIcoZoomPlusVisibility");
            }
        }
        private Visibility _interactionIcoZoomMinusVisibility;
        public Visibility InteractionIcoZoomMinusVisibility
        {
            get { return _interactionIcoZoomMinusVisibility; }
            set
            {
                _interactionIcoZoomMinusVisibility = value;
                OnPropertyChanged("InteractionIcoZoomMinusVisibility");
            }
        }
        private Visibility _interactionIcoMoveVisibility;
        public Visibility InteractionIcoMoveVisibility
        {
            get { return _interactionIcoMoveVisibility; }
            set
            {
                _interactionIcoMoveVisibility = value;
                OnPropertyChanged("InteractionIcoMoveVisibility");
            }
        }

        private Visibility _pointerLeftHandVisibility;
        public Visibility PointerLeftHandVisibility
        {
            get { return _pointerLeftHandVisibility; }
            set
            {
                _pointerLeftHandVisibility = value;
                OnPropertyChanged("PointerLeftHandVisibility");
            }
        }
        private Visibility _pointerRightHandVisibility;
        public Visibility PointerRightHandVisibility
        {
            get { return _pointerRightHandVisibility; }
            set
            {
                _pointerRightHandVisibility = value;
                OnPropertyChanged("PointerRightHandVisibility");
            }
        }
        private Visibility _pointerLeftHandGripVisibility;
        public Visibility PointerLeftHandGripVisibility
        {
            get { return _pointerLeftHandGripVisibility; }
            set
            {
                _pointerLeftHandGripVisibility = value;
                OnPropertyChanged("PointerLeftHandGripVisibility");
            }
        }
        private Visibility _pointerRightHandGripVisibility;
        public Visibility PointerRightHandGripVisibility
        {
            get { return _pointerRightHandGripVisibility; }
            set
            {
                _pointerRightHandGripVisibility = value;
                OnPropertyChanged("PointerRightHandGripVisibility");
            }
        }


        private string _testMessageHand;
        public string TestMessageHand
        {
            get { return this._testMessageHand; }
            set
            {
                this._testMessageHand = value;
                OnPropertyChanged("TestMessageHand");
            }
        }


        public MapViewModel()
        {

            MapLoader loader = MapLoader.Instance;


            InteractionIco(null);

            _bingMap = loader.BingMap;

            BingMap.CenterLocation = loader.StartLocation;
            MapCenterPoint = BingMap.CenterLocation;
            MapZoomLevel = 14;
            computeDependsMovementZoom();

            _kinectController = MainWindow.KinectController;
            _kinectController.PropertyChanged += KinectControllerPropertyChanged;

            _kinectHandUtilities = KinectHandUtilities.Instance;
        }

        void KinectControllerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Point[] points = _kinectHandUtilities.GetHandsPostion(_kinectController.LeftHandJoint, _kinectController.RightHandJoint);
            LeftHandX = points[0].X;
            LeftHandY = points[0].Y;
            RightHandX = points[1].X;
            RightHandY = points[1].Y;

            TestMessageHand = "NL: (" + LeftHandX + ", " + LeftHandY + ")\n" +
                                "NR: (" + RightHandX + ", " + RightHandY + ")\n" +
                                "SL: (" + _kinectController.LeftHandJoint.Position.X + ", " + _kinectController.LeftHandJoint.Position.Y + ")\n" +
                                "SR: (" + _kinectController.RightHandJoint.Position.X + ", " + _kinectController.RightHandJoint.Position.Y + ")\n" +
                                "LHT: " + _kinectController.LeftHandJoint.TrackingState + " " + _kinectController.LeftHandJoint + "\n" +
                                "RHT: " + _kinectController.RightHandJoint.TrackingState + " " + _kinectController.RightHandJoint + "\n";

            if (_kinectController.LeftHandJoint.TrackingState == JointTrackingState.Tracked || _kinectController.RightHandJoint.TrackingState == JointTrackingState.Tracked)
            {
                if (_kinectController.IsLeftHandGrip && _kinectController.IsRightHandGrip)
                {
                    InteractionIco("Zoom");

                    double handDistance = GetHandDistance(_kinectController.LeftHandJoint.Position.X, _kinectController.LeftHandJoint.Position.Y, _kinectController.RightHandJoint.Position.X, _kinectController.RightHandJoint.Position.Y);
                    if ((handDistance - ACCEPTED_HAND_MOVING) > _distanceTwoHand)
                    {
                        InteractionIco("ZoomPlus");
                        double newZoom = MapZoomLevel + SPEED_ZOOMING * Math.Abs(handDistance - _distanceTwoHand);
                        if (newZoom <= 19)
                        {
                            MapZoomLevel = newZoom;
                            computeDependsMovementZoom();
                        }
                    }
                    else if ((handDistance + ACCEPTED_HAND_MOVING) < _distanceTwoHand)
                    {
                        InteractionIco("ZoomMinus");
                        double newZoom = MapZoomLevel - SPEED_ZOOMING * Math.Abs(handDistance - _distanceTwoHand);
                        if (newZoom >= 3)
                        {
                            MapZoomLevel = newZoom;
                            computeDependsMovementZoom();
                        }
                    }
                }
                else if (_kinectController.IsRightHandGrip && !_kinectController.IsLeftHandGrip)
                {
                    double handDistaceX = Math.Abs((double)_kinectController.RightHandJoint.Position.X - _positionRightHand.X);
                    if (handDistaceX > ACCEPTED_HAND_MOVING)
                    {
                        InteractionIco("Move");

                        if ((double)_kinectController.RightHandJoint.Position.X < _positionRightHand.X)
                            BingMap.CenterLocation.Longitude += (handDistaceX / _dependsMovementZoom) * SPEED_MOVING;
                        else
                            BingMap.CenterLocation.Longitude -= (handDistaceX / _dependsMovementZoom) * SPEED_MOVING;

                        MapCenterPoint = BingMap.CenterLocation;
                    }

                    double handDistaceY = Math.Abs((double)_kinectController.RightHandJoint.Position.Y - _positionRightHand.Y);
                    if (handDistaceY > ACCEPTED_HAND_MOVING)
                    {
                        InteractionIco("Move");

                        if ((double)_kinectController.RightHandJoint.Position.Y < _positionRightHand.Y)
                            BingMap.CenterLocation.Latitude += (handDistaceY / _dependsMovementZoom) * SPEED_MOVING;
                        else
                            BingMap.CenterLocation.Latitude -= (handDistaceY / _dependsMovementZoom) * SPEED_MOVING;

                        MapCenterPoint = BingMap.CenterLocation;
                    }
                }
                else if (_kinectController.IsLeftHandGrip && !_kinectController.IsRightHandGrip)
                {
                    double handDistaceX = Math.Abs((double)_kinectController.LeftHandJoint.Position.X - _positionLeftHand.X);
                    if (handDistaceX > ACCEPTED_HAND_MOVING)
                    {
                        InteractionIco("Move");

                        if ((double)_kinectController.LeftHandJoint.Position.X < _positionLeftHand.X)
                            BingMap.CenterLocation.Longitude += (handDistaceX / _dependsMovementZoom) * SPEED_MOVING;
                        else
                            BingMap.CenterLocation.Longitude -= (handDistaceX / _dependsMovementZoom) * SPEED_MOVING;

                        MapCenterPoint = BingMap.CenterLocation;
                    }

                    double handDistaceY = Math.Abs((double)_kinectController.LeftHandJoint.Position.Y - _positionLeftHand.Y);
                    if (handDistaceY > ACCEPTED_HAND_MOVING)
                    {
                        InteractionIco("Move");

                        if ((double)_kinectController.LeftHandJoint.Position.Y < _positionLeftHand.Y)
                            BingMap.CenterLocation.Latitude += (handDistaceY / _dependsMovementZoom) * SPEED_MOVING;
                        else
                            BingMap.CenterLocation.Latitude -= (handDistaceY / _dependsMovementZoom) * SPEED_MOVING;

                        MapCenterPoint = BingMap.CenterLocation;
                    }
                }
                else
                {
                    InteractionIco(null);
                    
                    _distanceTwoHand = GetHandDistance(_kinectController.LeftHandJoint.Position.X, _kinectController.LeftHandJoint.Position.Y, _kinectController.RightHandJoint.Position.X, _kinectController.RightHandJoint.Position.Y);
                    _positionRightHand = new Point(_kinectController.RightHandJoint.Position.X, _kinectController.RightHandJoint.Position.Y);
                    _positionLeftHand = new Point(_kinectController.LeftHandJoint.Position.X, _kinectController.LeftHandJoint.Position.Y);
                }
            }
        }

        public double GetHandDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Abs(Math.Pow((x2 - x1), 2) + Math.Abs(Math.Pow((y2 - y1), 2))));
        }

        private void computeDependsMovementZoom()
        {
            _dependsMovementZoom = 0.1019 * Math.Exp(0.6844 * MapZoomLevel);
        }

        private void InteractionIco(String type)
        {

            switch (type)
            {
                case "":
                case null:
                    {
                        InteractionIcoZoomVisibility = InteractionIcoZoomPlusVisibility = InteractionIcoZoomMinusVisibility = InteractionIcoMoveVisibility = Visibility.Hidden;
                    } break;
                case "Zoom":
                    {
                        InteractionIcoZoomPlusVisibility = InteractionIcoZoomMinusVisibility = InteractionIcoMoveVisibility = Visibility.Hidden;
                        InteractionIcoZoomVisibility = Visibility.Visible;
                    } break;
                case "ZoomPlus":
                    {
                        InteractionIcoZoomVisibility = InteractionIcoZoomMinusVisibility = InteractionIcoMoveVisibility = Visibility.Hidden;
                        InteractionIcoZoomPlusVisibility = Visibility.Visible;
                    } break;
                case "ZoomMinus":
                    {
                        InteractionIcoZoomVisibility = InteractionIcoZoomPlusVisibility = InteractionIcoMoveVisibility = Visibility.Hidden;
                        InteractionIcoZoomMinusVisibility = Visibility.Visible;
                    } break;
                case "Move":
                    {
                        InteractionIcoZoomVisibility = InteractionIcoZoomPlusVisibility = InteractionIcoZoomMinusVisibility = Visibility.Hidden;
                        InteractionIcoMoveVisibility = Visibility.Visible;
                    } break;
            }

        }

    }
}

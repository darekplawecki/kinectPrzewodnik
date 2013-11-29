using System;
using System.Windows;
using Microsoft.Kinect;
using Microsoft.Maps.MapControl.WPF;
using Przewodnik.Models;
using Przewodnik.Utilities;
using Przewodnik.Utilities.DataLoader;

namespace Przewodnik.ViewModels
{
    public class MapViewModel : ViewModelBase
    {

        private const double ACCEPTED_HAND_MOVING = 0.05;
        private const double SPEED_ZOOMING = 0.01; // zalezy od parametru oraz jak zmienila sie odleglosc rak, od momentu zlapania
        private const double SPEED_MOVING = 1.0;

        private MapLoader _loader;

        private int _quickStartStep;

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

        private Visibility _quickStartVisibility;
        public Visibility QuickStartVisibility
        {
            get { return _quickStartVisibility; }
            set
            {
                _quickStartVisibility = value;
                OnPropertyChanged("QuickStartVisibility");
            }
        }
        private String _quickStartText;
        public String QuickStartText
        {
            get { return _quickStartText; }
            set
            {
                _quickStartText = value;
                OnPropertyChanged("QuickStartText");
            }
        }



        public MapViewModel()
        {

            _loader = MapLoader.Instance;

            InteractionIco(null);

            _bingMap = _loader.BingMap;

            BingMap.CenterLocation = _loader.StartLocation;
            MapCenterPoint = BingMap.CenterLocation;
            MapZoomLevel = 14;
            computeDependsMovementZoom();

            _kinectController = MainWindow.KinectController;
            _kinectController.PropertyChanged += KinectControllerPropertyChanged;

            _kinectHandUtilities = KinectHandUtilities.Instance;

            // Samouczek
            _quickStartStep = _loader.FirstRun ? 1 : 0;
            if (_quickStartStep == 1)
            {
                QuickStartVisibility = Visibility.Visible;
                QuickStartText = "Aby przesunąć mapę, zaciśnij 1 pięść i przesuń w wybranym kierunku.";
            }
            else
            {
                QuickStartVisibility = Visibility.Hidden;
            }

        }

        void KinectControllerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

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

                        // quickstart
                        if (_quickStartStep == 2)
                        {
                            _quickStartStep = 3;
                            QuickStartText = "Aby pomniejszyć mapę, zaciśnij obie pięści, a następnie przybliż rece do siebie.";
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

                        // quickstart
                        if (_quickStartStep == 3)
                        {
                            _quickStartStep = 0;
                            _loader.FirstRun = false;
                            QuickStartVisibility = Visibility.Hidden;
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

                        // quickstart
                        if (_quickStartStep == 1)
                        {
                            _quickStartStep = 2;
                            QuickStartText = "Aby powiększyć mapę, zaciśnij obie pięści, a następnie oddal rece od siebie.";
                        }
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

                        // quickstart
                        if (_quickStartStep == 1)
                        {
                            _quickStartStep = 2;
                            QuickStartText = "Aby powiększyć mapę, zaciśnij obie pięści, a następnie oddal rece od siebie.";
                        }
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

                        // quickstart
                        if (_quickStartStep == 1)
                        {
                            _quickStartStep = 2;
                            QuickStartText = "Aby powiększyć mapę, zaciśnij obie pięści, a następnie oddal rece od siebie.";
                        }
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

                        // quickstart
                        if (_quickStartStep == 1)
                        {
                            _quickStartStep = 2;
                            QuickStartText = "Aby powiększyć mapę, zaciśnij obie pięści, a następnie oddal rece od siebie.";
                        }
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

        public void defaultLocation()
        {
            BingMap.CenterLocation.Longitude = 17.046638;
            BingMap.CenterLocation.Latitude = 51.109521;
            MapCenterPoint = BingMap.CenterLocation;
        }



    }
}

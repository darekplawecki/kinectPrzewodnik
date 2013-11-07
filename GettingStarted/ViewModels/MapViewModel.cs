using System;
using System.Windows;
using Microsoft.Kinect;
using Microsoft.Maps.MapControl.WPF;
using Przewodnik.Models;
using Przewodnik.Utilities;

namespace Przewodnik.ViewModels
{
    class MapViewModel : ViewModelBase
    {

        private const double ACCEPTED_HAND_MOVING = 0.05;
        private const double SPEED_ZOOMING = 0.01; // zalezy od parametru oraz jak zmienila sie odleglosc rak, od momentu zlapania
        private const double SPEED_MOVING = 1.0;

        private double _dependsMovementZoom;

        private KinectController _kinectController;

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
            _bingMap = new BingMap();

            BingMap.CenterLocation = new Location(51.109521, 17.046638);
            MapCenterPoint = BingMap.CenterLocation;
            MapZoomLevel = 14;
            computeDependsMovementZoom();

            _kinectController = MainWindow.KinectController;
            _kinectController.PropertyChanged += KinectControllerPropertyChanged;
        }

        void KinectControllerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (_kinectController.LeftHandJoint.TrackingState == JointTrackingState.Tracked || _kinectController.RightHandJoint.TrackingState == JointTrackingState.Tracked)
            {
                if (_kinectController.IsLeftHandGrip && _kinectController.IsRightHandGrip)
                {
                    double handDistance = GetHandDistance(_kinectController.LeftHandJoint.Position.X, _kinectController.LeftHandJoint.Position.Y, _kinectController.RightHandJoint.Position.X, _kinectController.RightHandJoint.Position.Y);
                    if ((handDistance - ACCEPTED_HAND_MOVING) > _distanceTwoHand)
                    {
                        double newZoom = MapZoomLevel + SPEED_ZOOMING * Math.Abs(handDistance - _distanceTwoHand);
                        if (newZoom >= 3 && newZoom <= 19)
                        {
                            MapZoomLevel = newZoom;
                            computeDependsMovementZoom();
                        }
                    }
                    else if ((handDistance + ACCEPTED_HAND_MOVING) < _distanceTwoHand)
                    {
                        double newZoom = MapZoomLevel - SPEED_ZOOMING * Math.Abs(handDistance - _distanceTwoHand);
                        if (newZoom >= 3 && newZoom <= 19)
                        {
                            MapZoomLevel = newZoom;
                            computeDependsMovementZoom();
                        } 
                    }
                }
                else if (_kinectController.IsRightHandGrip && !_kinectController.IsLeftHandGrip)
                {
                    double handDistaceX = Math.Abs((double) _kinectController.RightHandJoint.Position.X - _positionRightHand.X);
                    if (handDistaceX > ACCEPTED_HAND_MOVING)
                    {
                        if ((double)_kinectController.RightHandJoint.Position.X < _positionRightHand.X)
                            BingMap.CenterLocation.Longitude += (handDistaceX / _dependsMovementZoom) * SPEED_MOVING;
                        else
                            BingMap.CenterLocation.Longitude -= (handDistaceX / _dependsMovementZoom) * SPEED_MOVING;

                        MapCenterPoint = BingMap.CenterLocation;
                    }

                    double handDistaceY = Math.Abs((double)_kinectController.RightHandJoint.Position.Y - _positionRightHand.Y);
                    if (handDistaceY > ACCEPTED_HAND_MOVING)
                    {
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
                        if ((double)_kinectController.LeftHandJoint.Position.X < _positionLeftHand.X)
                            BingMap.CenterLocation.Longitude += (handDistaceX / _dependsMovementZoom) * SPEED_MOVING;
                        else
                            BingMap.CenterLocation.Longitude -= (handDistaceX / _dependsMovementZoom) * SPEED_MOVING;

                        MapCenterPoint = BingMap.CenterLocation;
                    }

                    double handDistaceY = Math.Abs((double)_kinectController.LeftHandJoint.Position.Y - _positionLeftHand.Y);
                    if (handDistaceY > ACCEPTED_HAND_MOVING)
                    {
                        if ((double)_kinectController.LeftHandJoint.Position.Y < _positionLeftHand.Y)
                            BingMap.CenterLocation.Latitude += (handDistaceY / _dependsMovementZoom) * SPEED_MOVING;
                        else
                            BingMap.CenterLocation.Latitude -= (handDistaceY / _dependsMovementZoom) * SPEED_MOVING;

                        MapCenterPoint = BingMap.CenterLocation;
                    }
                }
                else
                {
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

    }
}

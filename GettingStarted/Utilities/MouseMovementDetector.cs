using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;

namespace Przewodnik.Utilities
{

    public class MouseMovementDetector
    {

        private const double StationaryMouseInterval = 3000; // milliseconds


        private readonly DispatcherTimer _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(StationaryMouseInterval)
        };
        private readonly Window _window;
        private Point? _lastMousePosition;
        private bool _isMoving;


        public MouseMovementDetector(Window window)
        {
            if (window == null)
            {
                throw new ArgumentNullException("window");
            }

            _window = window;

            _timer.Tick += (s, args) =>
            {
                IsMoving = false;
                _timer.Stop();
            };
        }

        public event EventHandler<EventArgs> OnMovingChanged;

        public bool IsMoving
        {
            get
            {
                return this._isMoving;
            }

            set
            {
                bool oldValue = this._isMoving;
                _isMoving = value;

                if ((oldValue != value) && (OnMovingChanged != null))
                {
                    OnMovingChanged(this, EventArgs.Empty);
                }
            }
        }

        public void Start()
        {
            _window.MouseMove += OnMouseMove;
        }

        public void Stop()
        {
            this._window.MouseMove -= OnMouseMove;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            Point mousePosition = _window.PointToScreen(e.GetPosition(_window));

            if (_lastMousePosition.HasValue && _lastMousePosition.Value != mousePosition)
            {
                IsMoving = true;
                _timer.Stop();
                _timer.Start();
            }

            _lastMousePosition = mousePosition;
        }
    }
}
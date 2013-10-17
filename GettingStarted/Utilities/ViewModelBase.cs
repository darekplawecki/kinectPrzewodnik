using System;
using System.ComponentModel;
using System.Windows;

namespace Przewodnik.Utilities
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        internal const string NormalVisualState = "Normal";

        internal const string NavigatedToVisualState = "NavigatedTo";

        internal const string NavigatedFromVisualState = "NavigatedFrom";

        private string currentVisualStateName;

        private bool isUserInteracting = true;


        protected ViewModelBase()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string VisualStateName
        {
            get
            {
                return currentVisualStateName;
            }

            protected set
            {
                currentVisualStateName = value;
                OnPropertyChanged("VisualStateName");
            }
        }

        public bool IsUserInteracting
        {
            get
            {
                return this.isUserInteracting;
            }

            set
            {
                if (value != this.isUserInteracting)
                {
                    this.isUserInteracting = value;
                    this.OnPropertyChanged("IsUserInteracting");
                }
            }
        }

        public virtual void Initialize(Uri parameter)
        {
        }

        public virtual void OnNavigatedTo()
        {
            this.VisualStateName = NavigatedToVisualState;
        }

        public virtual void OnNavigatedFrom()
        {
            this.VisualStateName = NavigatedFromVisualState;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);

            //MessageBox.Show(propertyName, "OnPropertyChanged");

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new ArgumentException("Invalid property name: " + propertyName);
            }
        }
    }
}
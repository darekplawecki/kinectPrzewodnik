using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Przewodnik.Models
{
    class SleepScreenModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private Image currentImage1;
        private Image currentImage2;
        private Image currentImage3;
        private Image currentImage4;
        private Image currentImage5;
        private Image currentImage6;

        public Image CurrentImage1
        {
            get
            {
                return currentImage1;
            }

            set
            {
                currentImage1 = value;
                OnPropertyChanged("CurrentImage1");
            }
        }

        public Image CurrentImage2
        {
            get
            {
                return currentImage2;
            }

            set
            {
                currentImage2 = value;
                OnPropertyChanged("CurrentImage2");
            }
        }

        public Image CurrentImage3
        {
            get
            {
                return currentImage3;
            }

            set
            {
                currentImage3 = value;
                OnPropertyChanged("CurrentImage3");
            }
        }

        public Image CurrentImage4
        {
            get
            {
                return currentImage4;
            }

            set
            {
                currentImage4 = value;
                OnPropertyChanged("CurrentImage4");
            }
        }

        public Image CurrentImage5
        {
            get
            {
                return currentImage5;
            }

            set
            {
                currentImage5 = value;
                OnPropertyChanged("CurrentImage5");
            }
        }

        public Image CurrentImage6
        {
            get
            {
                return currentImage6;
            }

            set
            {
                currentImage6 = value;
                OnPropertyChanged("CurrentImage6");
            }
        }
    }
}

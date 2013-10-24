using Microsoft.Kinect.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xaml;
using Przewodnik.Utilities;
using Przewodnik.Controls;
using System.ComponentModel;
using System.Windows.Data;

namespace Przewodnik.Views
{
    
    partial class SleepScreen : IKinectPage
    {
        internal const double TimerIntervalMilliseconds = 3000;

        private DispatcherTimer tickTimer;
        private Random random;

        private ObservableCollection<Image> images;
        private Image currentImage1;
        private Image currentImage2;
        private Image currentImage3;
        private Image currentImage4;
        private Image currentImage5;
        private Image currentImage6;
        private int currentIndex = 0;

        private string modelContentUri;

        private KinectPageFactory pageFactory;

        public SleepScreen(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            
            this.pageFactory = pageFactory;

            this.modelContentUri = "Content/SleepScreen/Instagram";
            this.LoadModels(modelContentUri);
            this.random = new Random();
            this.tickTimer = new DispatcherTimer();
            this.tickTimer.Interval = TimeSpan.FromMilliseconds(TimerIntervalMilliseconds);
            this.tickTimer.Tick += (s, e) =>
            {
                this.currentIndex = this.currentIndex < this.Images.Count - 1 ? ++this.currentIndex : 0;
                int idImage;
                if (differentImages())
                {
                    idImage = random.Next(1, 7);
                }
                else
                {
                    idImage = indexOfRepeatedImage();
                    this.currentIndex = this.currentIndex < this.Images.Count - 1 ? ++this.currentIndex : 0;
                }
                switch (idImage)
                {
                    case 1:
                        this.CurrentImage1 = this.Images[this.currentIndex];
                        break;
                    case 2:
                        this.CurrentImage2 = this.Images[this.currentIndex];
                        break;
                    case 3:
                        this.CurrentImage3 = this.Images[this.currentIndex];
                        break;
                    case 4:
                        this.CurrentImage4 = this.Images[this.currentIndex];
                        break;
                    case 5:
                        this.CurrentImage5 = this.Images[this.currentIndex];
                        break;
                    case 6:
                        this.CurrentImage6 = this.Images[this.currentIndex];
                        break;
                }

            };
        }

        private void OpenMainMenu(object sender, RoutedEventArgs e)
        {
            this.tickTimer.Stop();
            pageFactory.NavigateTo(pageFactory.GetMainMenu());
        }

        public Grid GetView()
        {
            return SleepScreenGrid;
        }

        public ObservableCollection<Image> Images
        {
            get
            {
                return this.images;
            }
        }

        public Image CurrentImage1
        {
            get
            {
                return this.currentImage1;
            }

            protected set
            {
                this.currentImage1 = value;
                AttractCarousel1.Content = this.currentImage1;
            }
        }
        public Image CurrentImage2
        {
            get
            {
                return this.currentImage2;
            }

            protected set
            {
                this.currentImage2 = value;
                AttractCarousel2.Content = this.currentImage2;
            }
        }
        public Image CurrentImage3
        {
            get
            {
                return this.currentImage3;
            }

            protected set
            {
                this.currentImage3 = value;
                AttractCarousel3.Content = this.currentImage3;
            }
        }
        public Image CurrentImage4
        {
            get
            {
                return this.currentImage4;
            }

            protected set
            {
                this.currentImage4 = value;
                AttractCarousel4.Content = this.currentImage4;
            }
        }
        public Image CurrentImage5
        {
            get
            {
                return this.currentImage5;
            }

            protected set
            {
                this.currentImage5 = value;
                AttractCarousel5.Content = this.currentImage5;
            }
        }
        public Image CurrentImage6
        {
            get
            {
                return this.currentImage6;
            }

            protected set
            {
                this.currentImage6 = value;
                AttractCarousel6.Content = this.currentImage6;
            }
        }

        protected void LoadModels(string modelContentPath)
        {
            this.images = new ObservableCollection<Image>();

            string projectPath = Environment.CurrentDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 9);

            string[] files = Directory.GetFiles(projectPath + modelContentPath);

            for (int i = 0; i < files.Length; i++)
            {
                this.images.Add(new Image() { Source = new BitmapImage(new Uri(files[i].ToString())) });
            }
        }

        private bool differentImages()
        {
            return this.CurrentImage1 != this.Images[this.currentIndex] &&
                this.CurrentImage2 != this.Images[this.currentIndex] &&
                this.CurrentImage3 != this.Images[this.currentIndex] &&
                this.CurrentImage4 != this.Images[this.currentIndex] &&
                this.CurrentImage5 != this.Images[this.currentIndex] &&
                this.CurrentImage6 != this.Images[this.currentIndex];
        }

        private int indexOfRepeatedImage()
        {
            int index = 0;

            if (this.CurrentImage1 == this.Images[this.currentIndex])
            {
                index = 1;
            }
            else if (this.CurrentImage2 == this.Images[this.currentIndex])
            {
                index = 2;
            }
            else if (this.CurrentImage3 == this.Images[this.currentIndex])
            {
                index = 3;
            }
            else if (this.CurrentImage4 == this.Images[this.currentIndex])
            {
                index = 4;
            }
            else if (this.CurrentImage5 == this.Images[this.currentIndex])
            {
                index = 5;
            }
            else if (this.CurrentImage6 == this.Images[this.currentIndex])
            {
                index = 6;
            }
            return index;
        }

        private void SleepScreenGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if (0 < this.Images.Count)
            {
                this.CurrentImage1 = this.Images[0];
                this.CurrentImage2 = this.Images[1];
                this.CurrentImage3 = this.Images[2];
                this.CurrentImage4 = this.Images[3];
                this.CurrentImage5 = this.Images[4];
                this.CurrentImage6 = this.Images[5];
                this.currentIndex = 5;
                this.tickTimer.Start();
            }

        }

    }





}


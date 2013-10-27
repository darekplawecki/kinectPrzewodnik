using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Przewodnik.Models;

namespace Przewodnik.ViewModels
{
    class SleepScreenViewModel
    {
        public DispatcherTimer tickTimer;
        internal const double TimerIntervalMilliseconds = 3000;

        public ObservableCollection<SleepScreenModel> CurrentImages { get; set; }

        private ObservableCollection<Image> images;
        private string modelContentUri;

        private Random random;
        private int currentIndex = 0;

        public SleepScreenViewModel()
        {
            CurrentImages = new ObservableCollection<SleepScreenModel>();

            this.modelContentUri = "Content\\SleepScreen\\Instagram";
            this.LoadModels(modelContentUri);

            this.random = new Random();
            this.tickTimer = new DispatcherTimer();
            this.tickTimer.Interval = TimeSpan.FromMilliseconds(TimerIntervalMilliseconds);
            this.tickTimer.Tick += ChangeImage;
        }

        protected void LoadModels(string modelContentPath)
        {
            this.images = new ObservableCollection<Image>();

            string[] parts = Environment.CurrentDirectory.Split(new string[] { "bin\\" }, StringSplitOptions.None);
            string projectPath = parts[0];

            string[] files = Directory.GetFiles(projectPath + modelContentPath);

            for (int i = 0; i < files.Length; i++)
            {
                this.images.Add(new Image() { Source = new BitmapImage(new Uri(files[i].ToString())) });
            }
        }

        private void ChangeImage(object sender, EventArgs e)
        {
            this.currentIndex = this.currentIndex < this.images.Count - 1 ? ++this.currentIndex : 0;
            int idImage;
            if (DifferentImages())
            {
                idImage = random.Next(1, 7);
            }
            else
            {
                idImage = IndexOfRepeatedImage();
                this.currentIndex = this.currentIndex < this.images.Count - 1 ? ++this.currentIndex : 0;
            }
            switch (idImage)
            {
                case 1:
                    CurrentImages[0].CurrentImage1 = this.images[this.currentIndex];
                    break;
                case 2:
                    CurrentImages[0].CurrentImage2 = this.images[this.currentIndex];
                    break;
                case 3:
                    CurrentImages[0].CurrentImage3 = this.images[this.currentIndex];
                    break;
                case 4:
                    CurrentImages[0].CurrentImage4 = this.images[this.currentIndex];
                    break;
                case 5:
                    CurrentImages[0].CurrentImage5 = this.images[this.currentIndex];
                    break;
                case 6:
                    CurrentImages[0].CurrentImage6 = this.images[this.currentIndex];
                    break;
            }
        }

        private bool DifferentImages()
        {
            return CurrentImages[0].CurrentImage1 != this.images[this.currentIndex] &&
                CurrentImages[0].CurrentImage2 != this.images[this.currentIndex] &&
                CurrentImages[0].CurrentImage3 != this.images[this.currentIndex] &&
                CurrentImages[0].CurrentImage4 != this.images[this.currentIndex] &&
                CurrentImages[0].CurrentImage5 != this.images[this.currentIndex] &&
                CurrentImages[0].CurrentImage6 != this.images[this.currentIndex];
        }

        private int IndexOfRepeatedImage()
        {
            int index = 0;

            if (CurrentImages[0].CurrentImage1 == this.images[this.currentIndex])
            {
                index = 1;
            }
            else if (CurrentImages[0].CurrentImage2 == this.images[this.currentIndex])
            {
                index = 2;
            }
            else if (CurrentImages[0].CurrentImage3 == this.images[this.currentIndex])
            {
                index = 3;
            }
            else if (CurrentImages[0].CurrentImage4 == this.images[this.currentIndex])
            {
                index = 4;
            }
            else if (CurrentImages[0].CurrentImage5 == this.images[this.currentIndex])
            {
                index = 5;
            }
            else if (CurrentImages[0].CurrentImage6 == this.images[this.currentIndex])
            {
                index = 6;
            }

            return index;
        }

        public void InitSleepScreen()
        {
            if (0 < this.images.Count)
            {
                CurrentImages.Add(new SleepScreenModel
                {
                    CurrentImage1 = this.images[0],
                    CurrentImage2 = this.images[1],
                    CurrentImage3 = this.images[2],
                    CurrentImage4 = this.images[3],
                    CurrentImage5 = this.images[4],
                    CurrentImage6 = this.images[5]
                });
                this.currentIndex = 5;
                this.tickTimer.Start();
            }
        }

    }
}

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
        internal const double TimerIntervalMilliseconds = 3000;
        private SleepScreenModel model;
        private ObservableCollection<Image> images;
        private string modelContentUri;
        public DispatcherTimer tickTimer;
        private Random random;
        private int currentIndex = 0;

        public SleepScreenViewModel()
        {
            model = new SleepScreenModel();

            this.modelContentUri = "Content/SleepScreen/Instagram";
            this.LoadModels(modelContentUri);

            this.random = new Random();
            this.tickTimer = new DispatcherTimer();
            this.tickTimer.Interval = TimeSpan.FromMilliseconds(TimerIntervalMilliseconds);
            this.tickTimer.Tick += ChangeImage;
        }

        public List<Image> GetCurrentImages()
        {
            return model.CurrentImages;
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

        private void ChangeImage(object sender, EventArgs e)
        {
            this.currentIndex = this.currentIndex < this.images.Count - 1 ? ++this.currentIndex : 0;
            int idImage;
            if (DifferentImages())
            {
                idImage = random.Next(0, 5);
            }
            else
            {
                idImage = IndexOfRepeatedImage();
                this.currentIndex = this.currentIndex < this.images.Count - 1 ? ++this.currentIndex : 0;
            }

            model.CurrentImages[idImage] = this.images[this.currentIndex];
        }

        private bool DifferentImages()
        {
            foreach (Image i in model.CurrentImages)
            {
                if (i == images[currentIndex]) return false;
            }
            return true;
        }

        private int IndexOfRepeatedImage()
        {
            foreach (Image i in model.CurrentImages)
            {
                if (i == images[currentIndex]) return model.CurrentImages.IndexOf(i);
            }
            return 0;
        }

        public void SleepScreenGrid_Loaded()
        {
            if (0 < this.images.Count)
            {
                model.CurrentImages.Clear();
                for (int i = 0; i < model.CurrentImages.Capacity; i++)
                {
                    model.CurrentImages.Add(new Image());
                    model.CurrentImages[i] = images[i];
                }
                this.currentIndex = 5;
                this.tickTimer.Start();
            }
        }

    }
}

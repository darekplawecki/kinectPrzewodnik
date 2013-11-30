using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Przewodnik.Utilities.DataLoader
{
    public class PeriodicLoader
    {
        private DispatcherTimer loadingTimer;
        private DataLoader dataLoader;
        public PeriodicLoader(int seconds)
        {
            dataLoader = new DataLoader();
            loadingTimer = new DispatcherTimer();
            loadingTimer.Interval = TimeSpan.FromSeconds(seconds);


            loadingTimer.Tick += (s, e) =>
            {
                load();
            };
        }

        private void load()
        {
            dataLoader.PeriodLoad();
            Debug.WriteLine("Periodic loader performed");

        }

        public void Start()
        {
            loadingTimer.Start();
        }


    }
}

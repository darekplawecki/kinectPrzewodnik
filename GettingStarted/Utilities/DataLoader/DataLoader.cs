using System;
using System.Windows;
using Przewodnik.Content.Traslations;

namespace Przewodnik.Utilities.DataLoader
{
    class DataLoader
    {
        public EventHandler beforeLoaderEvents;
        public EventHandler afterLoaderEvents;

        public DataLoader()
        {

        }

        public bool EarlyLoad()
        {
            LoadInstagram();
            LoadTwitter();
            LoadMaps();
            if (!LoadCalendar()) return false;
            LoadWeather();
            return true;
        }

        public void PeriodLoad()
        {
            new TwitterLoader().LoadTwitter();
            //TODO tu do wstawienia jest ładowanie pogody
        }

        private void CalendarEventLoaded(object sender, EventArgs eventArgs)
        {
            if (eventArgs != null)
            {
                AfterDataLoaderEventArgs eventRetreived = eventArgs as AfterDataLoaderEventArgs;
                afterLoaderEvents(this, new AfterDataLoaderEventArgs(eventRetreived.Many, eventRetreived.Of));
            }
        }

        private void LoadInstagram()
        {
            beforeLoaderEvents(this, new BeforeDataLoaderEventArgs(AppResources.GetText("LOAD_instagram")));
            new InstagramLoader().LoadInstagram();
            afterLoaderEvents(this, new AfterDataLoaderEventArgs(1, 10));
        }

        private void LoadTwitter()
        {
            beforeLoaderEvents(this, new BeforeDataLoaderEventArgs(AppResources.GetText("LOAD_twitter")));
            new TwitterLoader().LoadTwitter();
            afterLoaderEvents(this, new AfterDataLoaderEventArgs(2, 10));
        }

        private void LoadMaps()
        {
            beforeLoaderEvents(this, new BeforeDataLoaderEventArgs(AppResources.GetText("LOAD_maps")));
            MapLoader ml = MapLoader.Instance;
            afterLoaderEvents(this, new AfterDataLoaderEventArgs(3, 10));
        }

        private bool LoadCalendar()
        {
            try
            {
                beforeLoaderEvents(this, new BeforeDataLoaderEventArgs(AppResources.GetText("LOAD_events")));
                CalendarLoader cl = CalendarLoader.Instance;
                cl.calendarEventLoaded += CalendarEventLoaded;
                cl.LoadEvents();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void LoadWeather()
        {
            beforeLoaderEvents(this, new BeforeDataLoaderEventArgs(AppResources.GetText("LOAD_weather")));
            WeatherLoader wl = WeatherLoader.Instance;
            afterLoaderEvents(this, new AfterDataLoaderEventArgs(5, 5));
        }

    }
}

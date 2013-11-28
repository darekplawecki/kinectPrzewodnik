using System;
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

        public bool Load()
        {
            LoadInstagram();
            LoadTwitter();
            LoadMaps();
            LoadCalendar();
            LoadWeather();
            return true;
        }

        private void LoadInstagram()
        {
            beforeLoaderEvents(this, new BeforeDataLoaderEventArgs(AppResources.GetText("LOAD_instagram")));
            new InstagramLoader().LoadInstagram();
            afterLoaderEvents(this, new AfterDataLoaderEventArgs(1, 5));
        }

        private void LoadTwitter()
        {
            beforeLoaderEvents(this, new BeforeDataLoaderEventArgs(AppResources.GetText("LOAD_twitter")));
            new TwitterLoader().LoadTwitter();
            afterLoaderEvents(this, new AfterDataLoaderEventArgs(2, 5));
        }

        private void LoadMaps()
        {
            beforeLoaderEvents(this, new BeforeDataLoaderEventArgs(AppResources.GetText("LOAD_maps")));
            MapLoader ml = MapLoader.Instance;
            afterLoaderEvents(this, new AfterDataLoaderEventArgs(3, 5));
        }

        private void LoadCalendar()
        {
            beforeLoaderEvents(this, new BeforeDataLoaderEventArgs(AppResources.GetText("LOAD_events")));
            CalendarLoader cl = CalendarLoader.Instance;
            afterLoaderEvents(this, new AfterDataLoaderEventArgs(4, 5));
        }

        private void LoadWeather()
        {
            beforeLoaderEvents(this, new BeforeDataLoaderEventArgs(AppResources.GetText("LOAD_weather")));
            WeatherLoader wl = WeatherLoader.Instance;
            afterLoaderEvents(this, new AfterDataLoaderEventArgs(5, 5));
        }

    }
}

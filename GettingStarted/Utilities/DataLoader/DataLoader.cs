using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Przewodnik.Content.Traslations;
using Przewodnik.Utilities.Twitter;

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


        //WYTYCZNE, CO DO ŁADOWANIA:
        //- Tworzymy własną klasę i w niej dokonujemy ładowania.
        //- Efekt wyjściowy ma nie wyrzucać wyjątków - jeżeli coś idzie nie tak, wyjątki obsługujemy
        //  w własnym loaderze, a nie tej (dataLoader) klasie.
        //- DataLoader przed wywolaniem jakiegokolwiek ladowania ponizej juz sprawdzil, czy uzytkownik
        //  jest podlaczony do internetu. Jezeli nie jest, aplikacja w ogole sie nie uruchamia.
        // W tej chwili wysypuje się błąd, ponieważ mój DataLoader jest taki głupi, albo ja, że nie potrafi wczytać pogody.
        //  W tej chwili wysypuje sie blad, bo Jadzia wczytuje pogode, zanim wlaczy sie DataLoader.
        //  Po przezuceniu pogody w odpowiednie miejsce bedzie dzialac.

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

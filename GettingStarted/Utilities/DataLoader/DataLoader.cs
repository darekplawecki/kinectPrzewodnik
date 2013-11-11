using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Przewodnik.Utilities.Twitter;

namespace Przewodnik.Utilities.DataLoader
{
    class DataLoader
    {
        public EventHandler loaderEvents;

        public DataLoader()
        {

        }

        public bool Load()
        {
            //LoadInstagram();
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
        //  W tej chwili wysypuje sie blad, bo Jadzia wczytuje pogode, zanim wlaczy sie DataLoader.
        //  Po przezuceniu pogody w odpowiednie miejsce bedzie dzialac.

        private void LoadInstagram()
        {
            new InstagramLoader().LoadInstagram();
            loaderEvents(this, new DataLoaderEventArgs(1, 5));
        }

        private void LoadTwitter()
        {
            new TwitterLoader().LoadTwitter();
            loaderEvents(this, new DataLoaderEventArgs(2, 5));
        }

        private void LoadMaps()
        {
            Thread.Sleep(1000);
            loaderEvents(this, new DataLoaderEventArgs(3, 5));
        }

        private void LoadCalendar()
        {
            Thread.Sleep(1000);
            loaderEvents(this, new DataLoaderEventArgs(4, 5));
        }

        private void LoadWeather()
        {
            Thread.Sleep(1000);
            loaderEvents(this, new DataLoaderEventArgs(5, 5));
        }
    }
}

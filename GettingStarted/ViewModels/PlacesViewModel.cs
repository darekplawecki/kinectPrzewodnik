using Przewodnik.Content.Traslations;
using Przewodnik.Models;
using System.Collections.Generic;

namespace Przewodnik.ViewModels
{
    public class PlacesViewModel
    {
        public List<PlacesModel> modelList;

        public PlacesViewModel()
        {
            modelList = new List<PlacesModel>();
            AddPlaces();
        }

        public void AddPlaces()
        {
            modelList.Add(new PlacesModel(AppResources.GetText("B_zakupy"), "Magnolia Park", 16.989183, 51.118782));
            modelList.Add(new PlacesModel(AppResources.GetText("B_zakupy"), "Arkady Wrocławskie S.A.", 17.028753, 51.099751));
            modelList.Add(new PlacesModel(AppResources.GetText("B_zakupy"), "Galeria Dominikańska", 17.040428, 51.108349));
            modelList.Add(new PlacesModel(AppResources.GetText("B_zakupy"), "Ferio Gaj", 17.047623, 51.077213));
            modelList.Add(new PlacesModel(AppResources.GetText("B_zakupy"), "Galeria Handlowa Sky Tower", 17.019886, 51.094265));
            modelList.Add(new PlacesModel(AppResources.GetText("B_zakupy"), "CH Krzyki", 17.004389, 51.074837));
            modelList.Add(new PlacesModel(AppResources.GetText("B_zakupy"), "Pasaż Grunwaldzki", 17.059277, 51.112469));
            modelList.Add(new PlacesModel(AppResources.GetText("B_zakupy"), "Dom Handlowy Feniks", 17.033262, 51.109501));
            modelList.Add(new PlacesModel(AppResources.GetText("B_zakupy"), "Renoma", 17.030952, 51.103699));
            modelList.Add(new PlacesModel(AppResources.GetText("B_zakupy"), "CH Korona", 17.087585, 51.141743));
            modelList.Add(new PlacesModel(AppResources.GetText("B_zakupy"), "CH Marino", 17.026613, 51.151882));
            modelList.Add(new PlacesModel(AppResources.GetText("B_zakupy"), "CH Arena", 17.027430, 51.095112));
            modelList.Add(new PlacesModel(AppResources.GetText("B_zakupy"), "Park Handlowy \"Bielany\"", 16.958696, 51.047901));
            modelList.Add(new PlacesModel(AppResources.GetText("B_zakupy"), "CH Factory", 16.945896, 51.107510));

            modelList.Add(new PlacesModel(AppResources.GetText("B_hotele"), "Hotel Patio", 17.029713, 51.111652));
            modelList.Add(new PlacesModel(AppResources.GetText("B_hotele"), "Art Hotel", 17.029980, 51.112251));
            modelList.Add(new PlacesModel(AppResources.GetText("B_hotele"), "Hotel Orbis", 17.024862, 51.098213));
            modelList.Add(new PlacesModel(AppResources.GetText("B_hotele"), "Qubus Hotel", 17.035208, 51.109146));
            modelList.Add(new PlacesModel(AppResources.GetText("B_hotele"), "Hotel \"Monopol\"", 17.031237, 51.106087));
            modelList.Add(new PlacesModel(AppResources.GetText("B_hotele"), "Puro Hotel", 17.024578, 51.108158));
            modelList.Add(new PlacesModel(AppResources.GetText("B_hotele"), "Hotel HP Park Plaza", 17.036180, 51.117504));
            modelList.Add(new PlacesModel(AppResources.GetText("B_hotele"), "Radisson Blu Hotel", 17.044180, 51.110752));
            modelList.Add(new PlacesModel(AppResources.GetText("B_hotele"), "Leoapart", 17.032408, 51.112591));
            modelList.Add(new PlacesModel(AppResources.GetText("B_hotele"), "Campanile", 17.026028, 51.116867));
            modelList.Add(new PlacesModel(AppResources.GetText("B_hotele"), "Europeum Hotel", 17.027868, 51.108131));
            modelList.Add(new PlacesModel(AppResources.GetText("B_hotele"), "Best Western Hotel Prima", 17.030058, 51.112415));
            modelList.Add(new PlacesModel(AppResources.GetText("B_hotele"), "Hotel Duet", 17.024225, 51.111221));
            modelList.Add(new PlacesModel(AppResources.GetText("B_hotele"), "Hotel Lothus", 17.037647, 51.109425));
            modelList.Add(new PlacesModel(AppResources.GetText("B_hotele"), "Hotel Polonia", 17.030731, 51.101196));

            modelList.Add(new PlacesModel(AppResources.GetText("B_urzedy"), "Urząd Stanu Cywilnego", 17.022951, 51.110641));
            modelList.Add(new PlacesModel(AppResources.GetText("B_urzedy"), "Urząd Skarbowy - Śródmieście", 17.025009, 51.102345));
            modelList.Add(new PlacesModel(AppResources.GetText("B_urzedy"), "Urząd Skarbowy - Krzyki", 17.023655, 51.087185));
            modelList.Add(new PlacesModel(AppResources.GetText("B_urzedy"), "Urząd Skarbowy - Stare Miasto", 17.013332, 51.114166));
            modelList.Add(new PlacesModel(AppResources.GetText("B_urzedy"), "Urząd Miejski", 17.037464, 51.110538));
            modelList.Add(new PlacesModel(AppResources.GetText("B_urzedy"), "Urząd Statystyczny", 17.036810, 51.108006));
            modelList.Add(new PlacesModel(AppResources.GetText("B_urzedy"), "Powiatowy Rzecznik Konsumentów", 17.047197, 51.099476));
            modelList.Add(new PlacesModel(AppResources.GetText("B_urzedy"), "Komisariat Policji", 17.056465, 51.137661));
            modelList.Add(new PlacesModel(AppResources.GetText("B_urzedy"), "Dolnośląski Urząd Wojewódzki", 17.049654, 51.110222));
            modelList.Add(new PlacesModel(AppResources.GetText("B_urzedy"), "Ratusz Wrocławski", 17.031857, 51.109802));

            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Park Południowy", 17.011938, 51.076431));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Park Kleciński", 16.989107, 51.062706));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Park Grabiszyński", 16.979267, 51.091412));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Park Szczytnicki", 17.081886, 51.111996));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Park Juliusza Słowackiego", 17.045067, 51.109718));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Park Złotnicki", 16.879543, 51.136021));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Park Brochowski", 17.071733, 51.061440));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Park Staszica", 17.031040, 51.124111));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Park Gajowicki", 17.006958, 51.091179));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Park Marii Dąbrowskiej", 17.044041, 51.144886));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Park Zachodni", 16.978651, 51.131844));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Park Leśnicki", 16.873922, 51.149261));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Park Biskupiński", 17.104420, 51.097347));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Park Strachowicki", 16.898661, 51.109440));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Park Świętej Edyty Stein", 17.050848, 51.121410));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Park Pilczycki", 16.952480, 51.140648));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Ogród Japoński", 17.079947, 51.109615));
            modelList.Add(new PlacesModel(AppResources.GetText("B_parki"), "Ogród Botaniczny", 17.044706, 51.116131));

            modelList.Add(new PlacesModel(AppResources.GetText("B_kina"), "Kino 5D Extreme", 16.989183, 51.118782));
            modelList.Add(new PlacesModel(AppResources.GetText("B_kina"), "Multikino", 17.060349, 51.112259));
            modelList.Add(new PlacesModel(AppResources.GetText("B_kina"), "Helios", 16.987127, 51.118027));
            modelList.Add(new PlacesModel(AppResources.GetText("B_kina"), "Kino Nowe Horyzonty", 17.026434, 51.109432));
            modelList.Add(new PlacesModel(AppResources.GetText("B_kina"), "Multikino", 17.028584, 51.099861));
            modelList.Add(new PlacesModel(AppResources.GetText("B_kina"), "Kino Cinema City", 17.086805, 51.141624));

            modelList.Add(new PlacesModel(AppResources.GetText("B_teatry"), "Teatr Polski - Scena im. J.Grzegorzewskiego", 17.026320, 51.101257));
            modelList.Add(new PlacesModel(AppResources.GetText("B_teatry"), "Teatr Pieśń Kozła", 17.039806, 51.110352));
            modelList.Add(new PlacesModel(AppResources.GetText("B_teatry"), "Wrocławski Teatr Komedia", 17.033092, 51.105129));
            modelList.Add(new PlacesModel(AppResources.GetText("B_teatry"), "Teatr Muzyczny Capitol", 17.031406, 51.100960));
            modelList.Add(new PlacesModel(AppResources.GetText("B_teatry"), "Wrocławski Teatr Lalek", 17.033096, 51.105125));
            modelList.Add(new PlacesModel(AppResources.GetText("B_teatry"), "Wrocławski Teatr Piosenki", 17.045609, 51.142006));
            modelList.Add(new PlacesModel(AppResources.GetText("B_teatry"), "Wrocławski Teatr Współczesny im. Edmunda Wiercińskiego", 17.028811, 51.112179));
            modelList.Add(new PlacesModel(AppResources.GetText("B_teatry"), "Teatr Formy", 17.009089, 51.087334));
            modelList.Add(new PlacesModel(AppResources.GetText("B_teatry"), "Teatr Tańca Dawnego Invenzione", 16.961550, 51.079254));
            modelList.Add(new PlacesModel(AppResources.GetText("B_teatry"), "Teatr Polski - Scena Kameralna", 17.031874, 51.106396));
            modelList.Add(new PlacesModel(AppResources.GetText("B_teatry"), "Teatr Arka", 17.032219, 51.106293));
            modelList.Add(new PlacesModel(AppResources.GetText("B_teatry"), "Wrocławski Teatr Pantomimy", 17.020370, 51.080471));
            modelList.Add(new PlacesModel(AppResources.GetText("B_teatry"), "Opera Wrocławska", 17.031246, 51.105656));

            modelList.Add(new PlacesModel(AppResources.GetText("B_transport"), "Dworzec Kolejowy PKP Wrocław Główny", 17.036806, 51.099087));
            modelList.Add(new PlacesModel(AppResources.GetText("B_transport"), "Dworzec autobusowy Polbus-PKS Sp. z o.o.", 17.034044, 51.096882));
            modelList.Add(new PlacesModel(AppResources.GetText("B_transport"), "Dworzec Kolejowy Wrocław Muchobór", 16.974092, 51.111591));
            modelList.Add(new PlacesModel(AppResources.GetText("B_transport"), "Dworzec Kolejowy Wrocław Pawłowice", 17.109020, 51.168331));
            modelList.Add(new PlacesModel(AppResources.GetText("B_transport"), "Dworzec Kolejowy Wrocław Zakrzów", 17.122150, 51.158779));
            modelList.Add(new PlacesModel(AppResources.GetText("B_transport"), "Dworzec Kolejowy Wrocław Świebodzki", 17.020147, 51.108051));
            modelList.Add(new PlacesModel(AppResources.GetText("B_transport"), "Dworzec Kolejowy Wrocław Nadodrze", 17.032175, 51.125671));
            modelList.Add(new PlacesModel(AppResources.GetText("B_transport"), "Dworzec Kolejowy Wrocław Mikołajów", 16.998188, 51.115578));
            modelList.Add(new PlacesModel(AppResources.GetText("B_transport"), "Dworzec Kolejowy Wrocław Popowice", 17.001572, 51.126923));
            modelList.Add(new PlacesModel(AppResources.GetText("B_transport"), "Dworzec Kolejowy Wrocław Żerniki", 16.915762, 51.126034));
            modelList.Add(new PlacesModel(AppResources.GetText("B_transport"), "Dworzec Kolejowy Wrocław Pracze", 16.903410, 51.169792));
            modelList.Add(new PlacesModel(AppResources.GetText("B_transport"), "Port Lotniczy Wrocław", 16.880424, 51.109463));

            modelList.Add(new PlacesModel(AppResources.GetText("B_atrakcje"), "ZOO Wrocław", 17.074360, 51.104942));
            modelList.Add(new PlacesModel(AppResources.GetText("B_atrakcje"), "Rynek", 17.031311, 51.109417));
            modelList.Add(new PlacesModel(AppResources.GetText("B_atrakcje"), "Hala Stulecia", 17.077385, 51.106785));
            modelList.Add(new PlacesModel(AppResources.GetText("B_atrakcje"), "Ostrów Tumski", 17.046732, 51.114544));
            modelList.Add(new PlacesModel(AppResources.GetText("B_atrakcje"), "Pałac królewski we Wrocławiu", 17.029341, 51.107738));
            modelList.Add(new PlacesModel(AppResources.GetText("B_atrakcje"), "Fontanna na Pergoli", 17.073841, 51.107586));
            modelList.Add(new PlacesModel(AppResources.GetText("B_atrakcje"), "Wyspa Słodowa", 17.037573, 51.116005));
            modelList.Add(new PlacesModel(AppResources.GetText("B_atrakcje"), "Aquapark Wrocław", 17.032928, 51.090694));
            modelList.Add(new PlacesModel(AppResources.GetText("B_atrakcje"), "Wyspa Przygody Opatowicka", 17.124229, 51.096813));

            modelList.Add(new PlacesModel(AppResources.GetText("B_koscioly"), "Kościół św. Marii Magdaleny", 17.035036, 51.109482));
            modelList.Add(new PlacesModel(AppResources.GetText("B_koscioly"), "Kościół Najświętszego Imienia Jezus", 17.035158, 51.113998));
            modelList.Add(new PlacesModel(AppResources.GetText("B_koscioly"), "Kościół Św. Wojciecha", 17.039122, 51.109333));
            modelList.Add(new PlacesModel(AppResources.GetText("B_koscioly"), "Kościół Miłosierdzia Bożego", 16.959543, 51.127846));
            modelList.Add(new PlacesModel(AppResources.GetText("B_koscioly"), "Kościół Opieki Św. Józefa", 17.041718, 51.121460));
            modelList.Add(new PlacesModel(AppResources.GetText("B_koscioly"), "Kościół Najświętszej Maryi Panny Królowej Polski", 16.977530, 51.064510));
            modelList.Add(new PlacesModel(AppResources.GetText("B_koscioly"), "Kościół Św. Michała Archanioła", 16.941208, 51.098644));
            modelList.Add(new PlacesModel(AppResources.GetText("B_koscioly"), "Kościół p.w. św. Antoniego z Padwy", 17.024374, 51.109344));
            modelList.Add(new PlacesModel(AppResources.GetText("B_koscioly"), "Kościół św. Klary", 17.037544, 51.112972));
            modelList.Add(new PlacesModel(AppResources.GetText("B_koscioly"), "Franciszkańskie Duszpasterstwo Akademickie \"Porcjunkula\"", 17.009979, 51.092834));
            modelList.Add(new PlacesModel(AppResources.GetText("B_koscioly"), "Kościół Chrystusa Króla", 17.013390, 51.115253));
            modelList.Add(new PlacesModel(AppResources.GetText("B_koscioly"), "Kościół Św. Wawrzyńca", 17.068516, 51.118469));
            modelList.Add(new PlacesModel(AppResources.GetText("B_koscioly"), "Salezjańskie Duszpasterstwo Akademickie MOST", 17.055820, 51.109657));

            modelList.Add(new PlacesModel(AppResources.GetText("B_muzea"), "Panorama Racławicka", 17.044344, 51.110130));
            modelList.Add(new PlacesModel(AppResources.GetText("B_muzea"), "Muzeum Narodowe we Wrocławiu", 17.047499, 51.110687));
            modelList.Add(new PlacesModel(AppResources.GetText("B_muzea"), "Muzeum Architektury", 17.041950, 51.109524));
            modelList.Add(new PlacesModel(AppResources.GetText("B_muzea"), "Muzeum Poczty i Telekomunikacji", 17.044445, 51.108334));
            modelList.Add(new PlacesModel(AppResources.GetText("B_muzea"), "Muzeum Miejskie Wrocławia", 17.032356, 51.109570));
            modelList.Add(new PlacesModel(AppResources.GetText("B_muzea"), "Muzeum Współczesne Wrocław", 17.005304, 51.113224));
            modelList.Add(new PlacesModel(AppResources.GetText("B_muzea"), "Muzeum Geologiczne", 17.028919, 51.116161));
            modelList.Add(new PlacesModel(AppResources.GetText("B_muzea"), "Muzeum ASP we Wrocławiu", 17.044498, 51.105927));
            modelList.Add(new PlacesModel(AppResources.GetText("B_muzea"), "Ogrody Doświadczeń. Humanitarium", 16.907616, 51.170868));
            modelList.Add(new PlacesModel(AppResources.GetText("B_muzea"), "Muzeum Człowieka", 17.034975, 51.113682));
            modelList.Add(new PlacesModel(AppResources.GetText("B_muzea"), "Mauzoleum Piastów Wrocławskich", 17.037251, 51.112873));
            modelList.Add(new PlacesModel(AppResources.GetText("B_muzea"), "Topacz. Muzeum Motoryzacji", 16.991419, 51.034012));
            modelList.Add(new PlacesModel(AppResources.GetText("B_muzea"), "Muzeum Hanny i Eugeniusza Geppertów", 17.030050, 51.108776));
            modelList.Add(new PlacesModel(AppResources.GetText("B_muzea"), "Muzeum Radia", 17.037251, 51.112873));

            modelList.Add(new PlacesModel(AppResources.GetText("B_sciezka"), "Ratusz", 17.0322311941425, 51.10961550445235));
            modelList.Add(new PlacesModel(AppResources.GetText("B_sciezka"), "Katedra św. Jana Chrzciciela", 17.046696703543937, 51.11419350450952));
            modelList.Add(new PlacesModel(AppResources.GetText("B_sciezka"), "Kościół NPM na Piasku", 17.041355973478105, 51.1146234720666));
            modelList.Add(new PlacesModel(AppResources.GetText("B_sciezka"), "Uniwersytet Wrocławski", 17.033948718105233, 51.1139111756929));
            modelList.Add(new PlacesModel(AppResources.GetText("B_sciezka"), "Kościół garnizonowy św. Elżbiety", 17.030599531047102, 51.111284712340634));
            modelList.Add(new PlacesModel(AppResources.GetText("B_sciezka"), "Katedra św. Marii Magdaleny", 17.03463444004598, 51.10953700252115));
            modelList.Add(new PlacesModel(AppResources.GetText("B_sciezka"), "Kościół św. Wojciecha", 17.039982764821676, 51.10912274141305));
            modelList.Add(new PlacesModel(AppResources.GetText("B_sciezka"), "Muzeum Architektury", 17.041790898241427, 51.109468323679714));
            modelList.Add(new PlacesModel(AppResources.GetText("B_sciezka"), "Opera", 17.03049879828873, 51.105715113544804));
            modelList.Add(new PlacesModel(AppResources.GetText("B_sciezka"), "Kościół św. Stanisława, Wacława i Doroty", 17.028535421289828, 51.106954609209815));
            modelList.Add(new PlacesModel(AppResources.GetText("B_sciezka"), "Biblioteka Uniwersytecka", 17.028417404093172, 51.10866222950187));

        }

    }
}

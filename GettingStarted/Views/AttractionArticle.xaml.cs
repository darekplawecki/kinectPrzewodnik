using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xaml;
using Przewodnik.Models;
using System.Windows.Media.Imaging;
using Microsoft.Kinect.Toolkit.Controls;

namespace Przewodnik.Views
{

    partial class AttractionArticle : IKinectPage
    {
        private KinectPageFactory pageFactory;
        private AttractionModel model;

        private string title = string.Empty;
        private string description = string.Empty;
        private List<string> photos;

        public AttractionArticle(KinectPageFactory pageFactory, String parameter)
        {
            InitializeComponent();
            model = new AttractionModel();

            this.title = model.getTitleFor(parameter);
            this.description = setDescription(parameter);
            this.photos = setPhotos(parameter);
            this.pageFactory = pageFactory;

            titleTextBlock.Text = this.title;
            bigImageSource.Source = new BitmapImage(new Uri(this.photos[0], UriKind.Relative));
            firstImageSource.Source = new BitmapImage(new Uri(this.photos[0], UriKind.Relative));
            secondImageSource.Source = new BitmapImage(new Uri(this.photos[1], UriKind.Relative));
            thirdImageSource.Source = new BitmapImage(new Uri(this.photos[2], UriKind.Relative));
            descriptionTextBlock.Text = this.description;
        }

        public Grid GetView()
        {
            return AttractionArticleGrid;
        }


        public string setDescription(String parameter)
        {
            switch (parameter)
            {
                case "Rynek":
                    return "Jest sercem Wrocławia, tętniącym życiem o każdej porze dnia i nocy.\nNależy do największych założeń urbanistycznych tego typu w Europie. W jego centrum znajdują się Sukiennice i gmach ratusza, który jest zabytkiem architektury gotyckiej i renesansowej. Na szczycie 66-metrowej wieży znajduje się najstarszy wizerunek herbu miasta, stworzony w połowie XVI w. Przed wschodnią fasadą ratusza stoi pręgierz (kopia średniowiecznego, zniszczonego w 1945 r.), przed zachodnią - pomnik Aleksandra Fredry przeniesiony ze Lwowa w 1956 r. \nRynek z czterech stron otaczają mieszczańskie kamienice, w tym najcenniejsze: Pod Siedmioma Elektorami, Pod Złotym Słońcem, Jaś i Małgosia.";
                case "OstrówTumski":
                    return "Najstarszą częścią Wrocławia jest Ostrów Tumski.\nOtoczony wodami Odry dawny gród, który dał początek miastu, mieści wspaniałe zabytki architektoniczne. Najokazalsze z nich to odbudowane po wojennych zniszczeniach gotycka katedra św. Jana Chrzciciela oraz kościół Świętego Krzyża. Znajduje się tu również Muzeum Archidiecezjalne, będące najstarszą, zachowującą ciągłość historyczną placówką muzealną we Wrocławiu – od ponad 100 lat gromadzi ono zabytki sztuki sakralnej, które, wycofane z użytku kultowego, posiadają ogromną wartość historyczną i artystyczną. Wśród nich znaleźć możemy Księgę henrykowską z XIII–XIV wieku z pierwszym zdaniem zapisanym w języku polskim.";
                case "HalaStulecia":
                    return "Hala Stulecia uznawana za jedno z najważniejszych dzieł w architekturze światowej XX w.\nZaprojektowana przez wybitnego miejskiego architekta Maxa Berga. Powstała w 1913 r. z okazji międzynarodowej wystawy w stulecie bitwy pod Lipskiem. W 2006 r. obiekt wpisano na Listę Światowego Dziedzictwa UNESCO. W Hali odbywają się imprezy sportowe o charakterze lokalnym, krajowym jak i międzynarodowym.";
                case "PałacKrólewski":
                    return "Pałac Królewski ulokowany jest w południowej części historycznego Starego Miasta we Wrocławiu, przy ulicy Kazimierza Wielkiego, w obszarze zwanym dziś Dzielnicą Czterech Wyznań.\nPoczątki pałacu sięgają początku XVIII w. Obecnie odrestaurowany Pałac Królewski stanowi jeden z najważniejszych zabytków Wrocławia oraz centrum wystawiennicze, gdzie w przestronnych salach prezentowana jest wystawa „1000 lat Wrocławia”.\nMuzeum Historyczne gromadzi i udostępnia zabytki z zakresu historii i sztuki dotyczące dziejów Wrocławia, wyroby rzemiosła artystycznego oraz ikonografię Wrocławia w tym grafiki, ryciny i fotografię. W skład zbiorów Muzeum wchodzą kolekcję dokumentów i druków ulotnych, plakatów, sztandarów. Unikatowa jest kolekcja ilustrująca historię wrocławskich teatrów.";
                case "PanoramaRacławicka":
                    return "„Panorama Racławicka”, oddział Muzeum Narodowego we Wrocławiu, jest miejscem szczególnie godnym zobaczenia.\n„Panorama Racławicka”, oddział Muzeum Narodowego we Wrocławiu, jest miejscem szczególnie godnym zobaczenia. Unikatowe płótno o wymiarach 120x15 m jest dziełem zespołu malarzy pod kierownictwem J. Styki i W. Kossaka. Obraz powstał we Lwowie w 1894 roku. We Wrocławiu został udostępniony 14 czerwca 1985 roku. Seanse odbywają się co pół godziny.";
                case "OgródJapoński":
                    return "Największy i najstarszy w mieście, został założony w 1785 r. jako prywatny ogród w majątku Stare Szczytniki.\nGłówną atrakcją parku jest powstały w 1913 r., a później wielokrotnie odbudowywany Ogród Japoński. Przygotowany i urządzony przez największego wówczas japonistę - entuzjastę, hrabiego Fritza von Hochberga, przy udziale japońskiego ogrodnika Mankichi Arai - był perłą wystawy. Po ekspozycji zabrano jednak liczne, wypożyczone na czas wystawy, detale (decydujące o japońskości założenia ogrodu). Od 1996 r. rozpoczęto prace rewaloryzacyjne przy udziale specjalistów japońskich z miasta Nagoya (ogrodników, architektów aranżacji kamiennych, architektów ogrodów itd.). Dzięki obecności japońskich specjalistów wszystkie projekty i prace, do najdrobniejszych szczegółów, odpowiadają oryginalnej japońskiej sztuce ogrodowej. Ogród, nawiązując do założeń historycznych z roku 1913, uzyskał jednocześnie wiele zupełnie nowych elementów nadających mu charakter rzeczywiście zgodny z zasadami japońskiej sztuki ogrodowej. Dawną kaskadę przebudowano na kaskadę „męską”, o szybko spadającej kurtynie wody. Wybudowano też drugą kaskadę „żeńską” wolno płynącą, o dwóch stopniach pośrednich. Woda z obu kaskad płynie do stawu o bardzo urozmaiconej linii brzegowej.";
                case "FontannaMultimedialna":
                    return "Fontanna działa sezonowo - od początku maja do końca października.\nPołożona w malowniczym parku Szczytnickim, otoczona pergolą i w bezpośrednim sąsiedztwie Hali Stulecia, multimedialna wrocławska fontanna jest największym tego typu obiektem w Polsce i jednym z największych w Europie. Otwarta została 4 czerwca 2009 z okazji 20. rocznicy wolnych wyborów. Jej powierzchnia wynosi ok. 1 hektara. W fontannie zainstalowano prawie 300 dysz, z których tryska woda w formie gejzerów, mgiełki, piany itp. na wysokość nawet 40 m. Tym sposobem tworzy się ogromny ekran wodny, na którym wyświetlane są wizualizacje z towarzyszeniem muzyki i efektów laserowych. Pokazy do muzyki klasycznej (m.in. Bizet, Beethoven, Wagner), a także współczesnej (Jean-Michel Jarre, Apocalyptica, Faith No More) odbywają się o każdej pełnej godzinie i trwają od trzech i pół do osiemnastu minut, a przy wyjątkowych okazjach odbywają się pokazy specjalne.";
                case "WyspaSłodowa":
                    return "Wyspa Słodowa we Wrocławiu - niewielka wysepka na Odrze w obrębie wrocławskiego Starego Miasta, w sąsiedztwie mniejszych nieco od niej Wyspy Bielarskiej i Wyspy Młyńskiej.\nWyspa Słodowa jest ulubionym miejscem wypoczynku dla Wrocławian i tłumnie odwiedzane przez turystów. Imponujące sąsiedztwo zespołu wysp, położonych w historycznie najstarszej części miasta, przesądza o atrakcyjności tego miejsca. Co roku urządza się tutaj majówki i studenckie imprezy związane z hucznymi obchodami Juwenaliów. Podczas wakacji licznie organizowane są tu imprezy plenerowe.";
                case "ZOO":
                    return "Misją wrocławskiego ZOO jest zachowanie różnorodności biologicznej w trosce o pełnowartościowy rozwój przyszłych pokoleń.\nWrocławski Ogród Zoologiczny na 33 ha powierzchni tworzy atrakcyjne, tematyczne ekspozycje fauny poszczególnych kontynentów (Pawilon Madagaskaru, Sahara, wybieg niedźwiedzi brunatnych, basen płetwonogich). Daje schronienie 4500 zwierzętom ponad 800 gatunków, w tym zagrożonym wyginięciem, a nawet nie występującym już w naturalnym środowisku. Trwa budowa kompleksu ekspozycji środowisk wodnych Afryki (Afrykarium).";
                case "OgródBotaniczny":
                    return "Ogród Botaniczny Uniwersytetu Wrocławskiego, nazywany oazą piękna i spokoju w sercu wielkiego miasta, to żywe muzeum, a zarazem ośrodek naukowy i dydaktyczny oraz ulubione miejsce wypoczynku wrocławian. Położony jest po północnej stronie katedry Św. Jana Chrzciciela i kościoła Św.Krzyża, częściowo w obrębie historycznego Ostrowa Tumskiego, w odległości ok. 2 km od Rynku. Jest drugim (po ogrodzie krakowskim ) najstarszym tego typu ogrodem w Polsce, wpisanym na listę zabytków woj. dolnośląskiego i mieszczącym się w granicach podlegającego szczególnej ochronie historycznego centrum Wrocławia.";
                default:
                    return "smuteczek :( ";
            }
        }

        public List<string> setPhotos(String parameter)
        {
            switch (parameter)
            {
                case "Rynek":
                    return new List<string> { "../Content/Attractions/rynek1.jpg", "../Content/Attractions/rynek2.jpg", "../Content/Attractions/rynek3.jpg" };
                case "OstrówTumski":
                    return new List<string> { "../Content/Attractions/ostrowtumski1.jpg", "../Content/Attractions/ostrowtumski2.jpg", "../Content/Attractions/ostrowtumski3.jpg" };
                case "HalaStulecia":
                    return new List<string> { "../Content/Attractions/halastulecia1.jpg", "../Content/Attractions/halastulecia2.jpg", "../Content/Attractions/halastulecia3.jpg" };
                case "PałacKrólewski":
                    return new List<string> { "../Content/Attractions/palackrolewski1.jpg", "../Content/Attractions/palackrolewski2.jpg", "../Content/Attractions/palackrolewski3.jpg" };
                case "PanoramaRacławicka":
                    return new List<string> { "../Content/Attractions/panoramaraclawicka1.jpg", "../Content/Attractions/panoramaraclawicka2.jpg", "../Content/Attractions/panoramaraclawicka3.jpg" };
                case "OgródJapoński":
                    return new List<string> { "../Content/Attractions/ogrodjaponski1.jpg", "../Content/Attractions/ogrodjaponski2.jpg", "../Content/Attractions/ogrodjaponski3.jpg" };
                case "FontannaMultimedialna":
                    return new List<string> { "../Content/Attractions/fontanna1.jpg", "../Content/Attractions/fontanna2.jpg", "../Content/Attractions/fontanna3.jpg" };
                case "WyspaSłodowa":
                    return new List<string> { "../Content/Attractions/wyspaslodowa1.jpg", "../Content/Attractions/wyspaslodowa2.jpg", "../Content/Attractions/wyspaslodowa3.jpg" };
                case "ZOO":
                    return new List<string> { "../Content/Attractions/zoo1.jpg", "../Content/Attractions/zoo2.jpg", "../Content/Attractions/zoo3.jpg" };
                case "OgródBotaniczny":
                    return new List<string> { "../Content/Attractions/ogrodbotaniczny1.jpg", "../Content/Attractions/ogrodbotaniczny2.jpg", "../Content/Attractions/ogrodbotaniczny3.jpg" };
                default:
                    return new List<string> { "smuteczek :( " };
            }
        }

        private void KinectTileButton_Click(object sender, RoutedEventArgs e)
        {
            switch (((KinectTileButton)sender).Name)
            {
                case "FirstImageButton":
                    bigImageSource.Source = new BitmapImage(new Uri(this.photos[0], UriKind.Relative));
                    break;
                case "SecondImageButton":
                    bigImageSource.Source = new BitmapImage(new Uri(this.photos[1], UriKind.Relative));
                    break;
                case "ThirdImageButton":
                    bigImageSource.Source = new BitmapImage(new Uri(this.photos[2], UriKind.Relative));
                    break;
                default: bigImageSource.Source = new BitmapImage(new Uri(this.photos[0], UriKind.Relative));
                    break;
            }

        }

    }


}

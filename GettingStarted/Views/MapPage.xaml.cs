using System.Windows.Controls;
using Microsoft.Maps.MapControl.WPF;
using Przewodnik.ViewModels;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using Microsoft.Kinect.Toolkit.Controls;
using Przewodnik.Content.Traslations;
using Przewodnik.Models;

namespace Przewodnik.Views
{
    partial class MapPage : IKinectPage
    {
        private KinectPageFactory _pageFactory;
        public PlacesViewModel pvm;
        public MapViewModel mvm;

        public MapPage(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            KinectRegion.AddQueryInteractionStatusHandler(MasterBingMap, OnQuery);
            _pageFactory = pageFactory;

            pvm = new PlacesViewModel();
            mvm = new MapViewModel();
            MapGrid.DataContext = mvm;
        }

        //Variable to track GripInterationStatus
        bool isGripinInteraction = false;

        private void OnQuery(object sender, QueryInteractionStatusEventArgs handPointerEventArgs)
        {

            //If a grip detected change the cursor image to grip
            if (handPointerEventArgs.HandPointer.HandEventType == HandEventType.Grip)
            {
                isGripinInteraction = true;
                handPointerEventArgs.IsInGripInteraction = true;
            }

           //If Grip Release detected change the cursor image to open
            else if (handPointerEventArgs.HandPointer.HandEventType == HandEventType.GripRelease)
            {
                isGripinInteraction = false;
                handPointerEventArgs.IsInGripInteraction = false;
            }

            //If no change in state do not change the cursor
            else if (handPointerEventArgs.HandPointer.HandEventType == HandEventType.None)
            {
                handPointerEventArgs.IsInGripInteraction = isGripinInteraction;
            }

            handPointerEventArgs.Handled = true;
        }

        public Grid GetView()
        {
            return MapPageGrid;
        }

        private void addPin(double latitude, double longitude)
        {
            Pushpin pin = new Pushpin();
            pin.Location = new Location(latitude, longitude);
            //pin.Content = number.ToString();
            pin.Background = new SolidColorBrush(Colors.Blue);
            //pin.ToolTip = desc;
            MasterBingMap.Children.Add(pin);

        }

        public void OnNavigateTo()
        {
            prepareTranslation();
        }

        private void addCanvas(double latitude, double longitude, string nameOfPlace, string color)
        {
            Canvas canvas = new Canvas();
            canvas.Width = 100;
            canvas.Height = 50;

            MapLayer mapLayer = new MapLayer();
            Location location = new Location() { Latitude = latitude, Longitude = longitude };
            PositionOrigin position = PositionOrigin.BottomLeft;

            System.Windows.Media.Color myColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(color);

            Path path = new Path();
            path.Data = Geometry.Parse("M 0,0 L 20,0 20,40 10,50 0,40 0,0");
            path.Fill = new SolidColorBrush(myColor);
            path.StrokeThickness = 2;

            TextBlock textBlock = new TextBlock();
            textBlock.FontSize = 18;
            textBlock.Foreground = new SolidColorBrush(Colors.Black);
            textBlock.Text = nameOfPlace;

            path.Opacity = 0.7;

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;

            Thickness margin = path.Margin;
            margin.Right = 5;
            path.Margin = margin;

            stackPanel.Children.Add(path);
            stackPanel.Children.Add(textBlock);

            mapLayer.AddChild(stackPanel, location, position);

            MasterBingMap.Children.Add(mapLayer);
        }

        private Location addLocation(double latitude, double longitude)
        {
            return new Location(longitude, latitude);
        }

        private LocationCollection firstPath()
        {
            LocationCollection locationCollection = new LocationCollection();

            locationCollection.Add(addLocation(17.025222, 51.107034));
            locationCollection.Add(addLocation(17.027738, 51.106017));
            locationCollection.Add(addLocation(17.0308151, 51.1044239));
            locationCollection.Add(addLocation(17.0308941, 51.1045911));
            locationCollection.Add(addLocation(17.0315548, 51.104534));
            locationCollection.Add(addLocation(17.0320709, 51.1044829));
            locationCollection.Add(addLocation(17.0337208, 51.1044429));
            locationCollection.Add(addLocation(17.0353089, 51.1043619));
            locationCollection.Add(addLocation(17.0361252, 51.104718));
            locationCollection.Add(addLocation(17.0374571, 51.1045809));
            locationCollection.Add(addLocation(17.03722926126, 51.10399079330045));
            locationCollection.Add(addLocation(17.037450543503727, 51.10393774151254));
            locationCollection.Add(addLocation(17.037650037719754, 51.104438729466345));
            locationCollection.Add(addLocation(17.038814099835534, 51.10430147881477));
            locationCollection.Add(addLocation(17.03999049085525, 51.104072532933294));
            locationCollection.Add(addLocation(17.040154105605158, 51.104159268111545));
            locationCollection.Add(addLocation(17.040324425877603, 51.10525396996395));
            locationCollection.Add(addLocation(17.040355271281275, 51.10575668205113));
            locationCollection.Add(addLocation(17.040259056606686, 51.10593104647287));
            locationCollection.Add(addLocation(17.04031050427953, 51.10607389088402));
            locationCollection.Add(addLocation(17.04051703437368, 51.10629956065495));
            locationCollection.Add(addLocation(17.040970327697195, 51.10732684941973));
            locationCollection.Add(addLocation(17.040526696323557, 51.107380276225186));
            locationCollection.Add(addLocation(17.040642031311197, 51.10776424014629));
            locationCollection.Add(addLocation(17.040793673187494, 51.1077287770316));
            locationCollection.Add(addLocation(17.042806613551686, 51.10886291532025));
            locationCollection.Add(addLocation(17.042955525331593, 51.10883804836211));
            locationCollection.Add(addLocation(17.043309697744352, 51.10897216981621));
            locationCollection.Add(addLocation(17.04397220337103, 51.109005849829465));
            locationCollection.Add(addLocation(17.044078843599916, 51.10917886530298));
            locationCollection.Add(addLocation(17.04559373793345, 51.10997416544823));
            locationCollection.Add(addLocation(17.045680058430964, 51.11069412333176));
            locationCollection.Add(addLocation(17.044344797917525, 51.11066942150198));
            locationCollection.Add(addLocation(17.044328835276797, 51.11151024136963));
            locationCollection.Add(addLocation(17.044440115839482, 51.11206721418598));
            locationCollection.Add(addLocation(17.041808619802524, 51.11284736626865));
            locationCollection.Add(addLocation(17.03960920841031, 51.11333231542539));
            locationCollection.Add(addLocation(17.040049090688754, 51.113871141852904));
            locationCollection.Add(addLocation(17.039459004705478, 51.114073200143416));
            locationCollection.Add(addLocation(17.03840757877164, 51.11520134269379));
            locationCollection.Add(addLocation(17.038321073990943, 51.11576141028059));
            locationCollection.Add(addLocation(17.038414951306464, 51.115939887848));
            locationCollection.Add(addLocation(17.03716526065826, 51.115837372642));
            locationCollection.Add(addLocation(17.03537354503631, 51.11599227748535));
            locationCollection.Add(addLocation(17.033839321479793, 51.11677689621473));
            locationCollection.Add(addLocation(17.03343162570953, 51.11625494103286));
            locationCollection.Add(addLocation(17.03410754238128, 51.11424788424645));
            locationCollection.Add(addLocation(17.03036854301452, 51.1130085841741));
            locationCollection.Add(addLocation(17.02843198810577, 51.11268528303685));
            locationCollection.Add(addLocation(17.02764878307342, 51.11249668966223));
            locationCollection.Add(addLocation(17.027230358467097, 51.11214644278162));
            locationCollection.Add(addLocation(17.02692995105743, 51.111594124999364));
            locationCollection.Add(addLocation(17.02352814440318, 51.11129748786667));
            locationCollection.Add(addLocation(17.023251876874646, 51.11103441600177));
            locationCollection.Add(addLocation(17.02265815941797, 51.11100633257003));
            locationCollection.Add(addLocation(17.022506614608627, 51.110901087002794));
            locationCollection.Add(addLocation(17.022396644039016, 51.11086404050609));
            locationCollection.Add(addLocation(17.022558917684417, 51.110651022573734));
            locationCollection.Add(addLocation(17.022608538551193, 51.11017951693901));
            locationCollection.Add(addLocation(17.02267827598558, 51.109970705763885));
            locationCollection.Add(addLocation(17.02253976254694, 51.10835360249141));
            locationCollection.Add(addLocation(17.022715315947718, 51.10812266901459));
            locationCollection.Add(addLocation(17.025222, 51.107034));

            return locationCollection;

        }

        private LocationCollection secondPath()
        {
            LocationCollection locationCollection = new LocationCollection();

            locationCollection.Add(addLocation(17.027847517506892, 51.11010203354339));
            locationCollection.Add(addLocation(17.026790727155024, 51.110364730573764));
            locationCollection.Add(addLocation(17.02742372848254, 51.10881772749377));
            locationCollection.Add(addLocation(17.027960170285517, 51.10907032783925));
            locationCollection.Add(addLocation(17.02840541698199, 51.109178103566464));
            locationCollection.Add(addLocation(17.028829206006343, 51.109188207528));
            locationCollection.Add(addLocation(17.03014885284167, 51.10963614760324));
            locationCollection.Add(addLocation(17.03249085055679, 51.109188207528));
            locationCollection.Add(addLocation(17.033451081384122, 51.11049578452115));
            locationCollection.Add(addLocation(17.035908940161306, 51.11001080559714));
            locationCollection.Add(addLocation(17.035474422300894, 51.10912166435155));
            locationCollection.Add(addLocation(17.033146264875967, 51.10970769118519));
            locationCollection.Add(addLocation(17.03229868682726, 51.107509808467));
            locationCollection.Add(addLocation(17.031436916226742, 51.105764891289866));
            locationCollection.Add(addLocation(17.03302478396356, 51.10552574589562));
            locationCollection.Add(addLocation(17.0324561556524, 51.104901481365964));
            locationCollection.Add(addLocation(17.03198408686578, 51.10479706397305));
            locationCollection.Add(addLocation(17.0309970339483, 51.104847588547464));
            locationCollection.Add(addLocation(17.03168904387414, 51.1065034829677));
            locationCollection.Add(addLocation(17.03061587226732, 51.106685307924174));
            locationCollection.Add(addLocation(17.030932372931076, 51.10757449604106));
            locationCollection.Add(addLocation(17.027301313776086, 51.10850405106392));
            locationCollection.Add(addLocation(17.026078226465295, 51.1076014084224));
            locationCollection.Add(addLocation(17.024786317757883, 51.10810238101511));
            locationCollection.Add(addLocation(17.02507599633149, 51.10839876986747));
            locationCollection.Add(addLocation(17.025472963265695, 51.10821015899952));
            locationCollection.Add(addLocation(17.02638491433076, 51.10887702968939));
            locationCollection.Add(addLocation(17.023026788644113, 51.109786383305135));
            locationCollection.Add(addLocation(17.023273551873483, 51.11103307756289));
            locationCollection.Add(addLocation(17.023745620660105, 51.11132271195889));
            locationCollection.Add(addLocation(17.026942813805857, 51.111740321148275));
            locationCollection.Add(addLocation(17.03079765566909, 51.111107170255586));
            locationCollection.Add(addLocation(17.031248266783592, 51.112020684042875));
            locationCollection.Add(addLocation(17.03005736598098, 51.11222611819033));
            locationCollection.Add(addLocation(17.030143196669457, 51.11238440289414));
            locationCollection.Add(addLocation(17.03129654654586, 51.112175601681365));
            locationCollection.Add(addLocation(17.03226214179122, 51.11193985724272));
            locationCollection.Add(addLocation(17.03278785475814, 51.11345687260174));
            locationCollection.Add(addLocation(17.03357105979049, 51.113645462057725));
            locationCollection.Add(addLocation(17.03474732487111, 51.113789483159096));
            locationCollection.Add(addLocation(17.035546623157547, 51.11372886539253));
            locationCollection.Add(addLocation(17.03575455164074, 51.114632568404474));
            locationCollection.Add(addLocation(17.036634316197624, 51.11441367453305));
            locationCollection.Add(addLocation(17.035861840001335, 51.11279929450395));
            locationCollection.Add(addLocation(17.037855928395864, 51.11243894666824));
            locationCollection.Add(addLocation(17.03927658994866, 51.112604577649456));
            locationCollection.Add(addLocation(17.039668192464834, 51.11305585231683));
            locationCollection.Add(addLocation(17.041305255572507, 51.11268203555491));
            locationCollection.Add(addLocation(17.04075808493347, 51.11193776074573));
            locationCollection.Add(addLocation(17.040661525408932, 51.110668186061154));
            locationCollection.Add(addLocation(17.03919167486877, 51.11070860059099));
            locationCollection.Add(addLocation(17.03875715700836, 51.10924028230077));
            locationCollection.Add(addLocation(17.039320420901486, 51.10904493887294));
            locationCollection.Add(addLocation(17.04144359811593, 51.109070114755525));
            locationCollection.Add(addLocation(17.04167963250924, 51.109423752921444));
            locationCollection.Add(addLocation(17.042752516115197, 51.1092149383316));
            locationCollection.Add(addLocation(17.04317094072152, 51.109827907511935));
            locationCollection.Add(addLocation(17.043183887652766, 51.11065556080494));
            locationCollection.Add(addLocation(17.04580708806933, 51.11068923959147));
            locationCollection.Add(addLocation(17.046536648921382, 51.1116739174161));
            locationCollection.Add(addLocation(17.044439997691548, 51.11207569488546));
            locationCollection.Add(addLocation(17.04086557661003, 51.11309039477009));
            locationCollection.Add(addLocation(17.03965444726054, 51.113424027883454));
            locationCollection.Add(addLocation(17.041279865923563, 51.11579652877537));
            locationCollection.Add(addLocation(17.03949126595559, 51.116262995606185));
            locationCollection.Add(addLocation(17.03823599213662, 51.11621248351028));
            locationCollection.Add(addLocation(17.038375467005395, 51.11518202470021));
            locationCollection.Add(addLocation(17.039620011988305, 51.11386009137807));
            locationCollection.Add(addLocation(17.040607064905785, 51.11356036988152));
            locationCollection.Add(addLocation(17.04158239126954, 51.11378937075075));
            locationCollection.Add(addLocation(17.0420973754004, 51.11422716337148));
            locationCollection.Add(addLocation(17.04181842566285, 51.11469565242826));
            locationCollection.Add(addLocation(17.043533259101178, 51.11453737564113));
            locationCollection.Add(addLocation(17.045998619597928, 51.1140106974296));

            return locationCollection;
        }

        private LocationCollection thirdPath()
        {
            LocationCollection locationCollection = new LocationCollection();

            locationCollection.Add(addLocation(17.082312338668807, 51.063541070828926));
            locationCollection.Add(addLocation(17.080595724899275, 51.064458058671406));
            locationCollection.Add(addLocation(17.075381510574324, 51.0641883582504));
            locationCollection.Add(addLocation(17.073743024428843, 51.06478169710246));
            locationCollection.Add(addLocation(17.072884717544078, 51.06390517111719));
            locationCollection.Add(addLocation(17.070181050857066, 51.06397259678223));
            locationCollection.Add(addLocation(17.06737009580946, 51.06455245344754));
            locationCollection.Add(addLocation(17.063933296755632, 51.06805234440392));
            locationCollection.Add(addLocation(17.054060318679465, 51.06981696126237));
            locationCollection.Add(addLocation(17.044490196914328, 51.07014056222541));
            locationCollection.Add(addLocation(17.039323888177673, 51.06849556718064));
            locationCollection.Add(addLocation(17.032543263788025, 51.07070685846629));
            locationCollection.Add(addLocation(17.015040966032803, 51.070855173003366));
            locationCollection.Add(addLocation(17.011189313887417, 51.07148887521683));
            locationCollection.Add(addLocation(17.01073785590362, 51.07067315055067));
            locationCollection.Add(addLocation(17.010147769920344, 51.07072708320388));
            locationCollection.Add(addLocation(17.00584006755613, 51.06933391519868));
            locationCollection.Add(addLocation(17.00509977786802, 51.06942830003171));
            locationCollection.Add(addLocation(17.003029407451315, 51.06992718809449));
            locationCollection.Add(addLocation(17.003576578090353, 51.070864274107194));
            locationCollection.Add(addLocation(16.99462985974978, 51.073171930096194));
            locationCollection.Add(addLocation(16.99961271501378, 51.08023107445768));
            locationCollection.Add(addLocation(16.998958256014145, 51.08112077140481));
            locationCollection.Add(addLocation(16.996447708376206, 51.08057246398356));
            locationCollection.Add(addLocation(16.994774009950913, 51.0831536880867));
            locationCollection.Add(addLocation(16.989262842501752, 51.081711355378886));
            locationCollection.Add(addLocation(16.989818059767835, 51.08087896066476));
            locationCollection.Add(addLocation(16.98643921510881, 51.081290104865076));
            locationCollection.Add(addLocation(16.982650695078362, 51.081795605021384));
            locationCollection.Add(addLocation(16.97901897386672, 51.082133950259234));
            locationCollection.Add(addLocation(16.978418159047383, 51.08271357940112));
            locationCollection.Add(addLocation(16.97429613026404, 51.08364995414187));
            locationCollection.Add(addLocation(16.97324111123374, 51.084838320219774));
            locationCollection.Add(addLocation(16.972404262021094, 51.085124749016));
            locationCollection.Add(addLocation(16.975665828183246, 51.087950660756604));
            locationCollection.Add(addLocation(16.976127168133807, 51.08860728622275));
            locationCollection.Add(addLocation(16.977993274867103, 51.092653987588285));
            locationCollection.Add(addLocation(16.978789566228436, 51.09399617115033));
            locationCollection.Add(addLocation(16.980254052350567, 51.094478736874436));
            locationCollection.Add(addLocation(16.97888612575297, 51.09535805281786));
            locationCollection.Add(addLocation(16.976192939093842, 51.09628981563074));
            locationCollection.Add(addLocation(16.97519498542938, 51.09686215286933));
            locationCollection.Add(addLocation(16.97313504890594, 51.101129886410504));
            locationCollection.Add(addLocation(16.9708759215183, 51.105577925096824));
            locationCollection.Add(addLocation(16.96542600294095, 51.10441986506824));
            locationCollection.Add(addLocation(16.964156660323617, 51.10674592285715));
            locationCollection.Add(addLocation(16.963201793914315, 51.109143791631936));
            locationCollection.Add(addLocation(16.96279409814405, 51.111459276439135));
            locationCollection.Add(addLocation(16.962553383359065, 51.11147381597032));
            locationCollection.Add(addLocation(16.96346533442413, 51.1130431935575));
            locationCollection.Add(addLocation(16.96565845818197, 51.11402411151376));
            locationCollection.Add(addLocation(16.965572627493493, 51.1142598453197));
            locationCollection.Add(addLocation(16.966345103689783, 51.11448210752098));
            locationCollection.Add(addLocation(16.96666696877157, 51.115128682391386));
            locationCollection.Add(addLocation(16.96714976639425, 51.115317265024345));
            locationCollection.Add(addLocation(16.96812609047567, 51.11527011943826));
            locationCollection.Add(addLocation(16.96844795555746, 51.115404820985155));
            locationCollection.Add(addLocation(16.968952210852258, 51.1166690012349));
            locationCollection.Add(addLocation(16.970000642349117, 51.118149121041675));
            locationCollection.Add(addLocation(16.971856730987422, 51.119801904589444));
            locationCollection.Add(addLocation(16.970301049758785, 51.11993659292485));
            locationCollection.Add(addLocation(16.96541378479102, 51.12052141502561));
            locationCollection.Add(addLocation(16.96195909957984, 51.12118137383868));
            locationCollection.Add(addLocation(16.960125485102825, 51.12240713040048));
            locationCollection.Add(addLocation(16.958355227152996, 51.12374718628017));
            locationCollection.Add(addLocation(16.9622819811508, 51.12578155900265));
            locationCollection.Add(addLocation(16.96353725496977, 51.12696393302439));
            locationCollection.Add(addLocation(16.966579665061307, 51.130995684680926));
            locationCollection.Add(addLocation(16.96861128249371, 51.13172149428658));
            locationCollection.Add(addLocation(16.96891168990338, 51.132219710579854));
            locationCollection.Add(addLocation(16.97539190688336, 51.13033453953957));
            locationCollection.Add(addLocation(16.97721612207019, 51.128987941679995));
            locationCollection.Add(addLocation(16.980027077117796, 51.12865128608009));
            locationCollection.Add(addLocation(16.982280132690306, 51.1300382913793));
            locationCollection.Add(addLocation(16.983791475051646, 51.13116941049419));
            locationCollection.Add(addLocation(16.986623887771373, 51.13141178955726));
            locationCollection.Add(addLocation(16.98877319769649, 51.1320042663559));
            locationCollection.Add(addLocation(17.00067837734412, 51.137056572196855));
            locationCollection.Add(addLocation(17.001343565179813, 51.13632952007587));
            locationCollection.Add(addLocation(17.001257734491336, 51.13572363456276));
            locationCollection.Add(addLocation(16.99791033764075, 51.13614102321267));
            locationCollection.Add(addLocation(16.996236639215457, 51.13627566390775));
            locationCollection.Add(addLocation(16.993017988397586, 51.13788393239069));
            locationCollection.Add(addLocation(16.99047836117003, 51.13921680765895));
            locationCollection.Add(addLocation(16.991572702448106, 51.141293075307715));
            locationCollection.Add(addLocation(16.987603033106065, 51.143935675473514));
            locationCollection.Add(addLocation(16.984574466567032, 51.14689630947379));
            locationCollection.Add(addLocation(16.98440280519008, 51.147569352196406));
            locationCollection.Add(addLocation(16.983008056502335, 51.14892886855948));
            locationCollection.Add(addLocation(16.98214974961757, 51.15028834487519));
            locationCollection.Add(addLocation(16.981753574163246, 51.15190946793724));
            locationCollection.Add(addLocation(16.979758010656166, 51.152858352258804));
            locationCollection.Add(addLocation(16.979339586049843, 51.15447790386176));
            locationCollection.Add(addLocation(16.97916792467289, 51.155972286407916));
            locationCollection.Add(addLocation(16.9788997037714, 51.156625009603914));
            locationCollection.Add(addLocation(16.979092822820473, 51.15845479854291));
            locationCollection.Add(addLocation(16.98048757150754, 51.15958824032844));
            locationCollection.Add(addLocation(16.980852351933564, 51.16032838317789));
            locationCollection.Add(addLocation(16.981693689055174, 51.16109869630218));
            locationCollection.Add(addLocation(16.98201555413696, 51.16166387886249));
            locationCollection.Add(addLocation(16.982830945677488, 51.162134859039874));
            locationCollection.Add(addLocation(16.98423429603073, 51.1630156593303));
            locationCollection.Add(addLocation(16.984593474214968, 51.16332558292569));
            locationCollection.Add(addLocation(16.98812300629257, 51.16679043140599));
            locationCollection.Add(addLocation(16.98813373512863, 51.168205138250954));
            locationCollection.Add(addLocation(16.995238850090814, 51.169016714184664));
            locationCollection.Add(addLocation(16.996955463860346, 51.16947416492208));
            locationCollection.Add(addLocation(16.997899601433588, 51.167738518954735));
            locationCollection.Add(addLocation(16.99908752388719, 51.16501744917251));
            locationCollection.Add(addLocation(17.001158189246688, 51.165293289519084));
            locationCollection.Add(addLocation(17.003945629511414, 51.1645962392989));
            locationCollection.Add(addLocation(17.005136530314026, 51.16436749030553));
            locationCollection.Add(addLocation(17.00900390106435, 51.169655007972835));
            locationCollection.Add(addLocation(17.01177422466327, 51.16734753540293));
            locationCollection.Add(addLocation(17.01201025905658, 51.167273532914265));
            locationCollection.Add(addLocation(17.01277200641681, 51.16669496390985));
            locationCollection.Add(addLocation(17.01373760166217, 51.166468073019175));
            locationCollection.Add(addLocation(17.014145297432435, 51.165849127655505));
            locationCollection.Add(addLocation(17.014359874153627, 51.16526381298568));
            locationCollection.Add(addLocation(17.014701333890553, 51.165015514253156));
            locationCollection.Add(addLocation(17.017619577298756, 51.163918864318426));
            locationCollection.Add(addLocation(17.01841962972391, 51.16463806076253));
            locationCollection.Add(addLocation(17.019235021264436, 51.165035004492935));
            locationCollection.Add(addLocation(17.023455587688865, 51.16809750426371));
            locationCollection.Add(addLocation(17.024635759655418, 51.168837510586094));
            locationCollection.Add(addLocation(17.025927781343974, 51.16903932843146));
            locationCollection.Add(addLocation(17.027376174212016, 51.16899223767986));
            locationCollection.Add(addLocation(17.03162303609566, 51.16763331241958));
            locationCollection.Add(addLocation(17.03338256520943, 51.16672509747265));
            locationCollection.Add(addLocation(17.034545299824696, 51.16613758041242));
            locationCollection.Add(addLocation(17.035403606709462, 51.16570027978528));
            locationCollection.Add(addLocation(17.0374635432329, 51.164899296121355));
            locationCollection.Add(addLocation(17.04325880842775, 51.16255568749883));
            locationCollection.Add(addLocation(17.044573533548842, 51.16178966098348));
            locationCollection.Add(addLocation(17.04542111159755, 51.16156089807175));
            locationCollection.Add(addLocation(17.04589013262948, 51.162617234982726));
            locationCollection.Add(addLocation(17.046330014907923, 51.162765254783196));
            locationCollection.Add(addLocation(17.04967741175851, 51.160881330967065));
            locationCollection.Add(addLocation(17.050871873325086, 51.16161472474126));
            locationCollection.Add(addLocation(17.05512735027942, 51.1598686913032));
            locationCollection.Add(addLocation(17.058302795535205, 51.15860960036941));
            locationCollection.Add(addLocation(17.059424270458532, 51.158317249301184));
            locationCollection.Add(addLocation(17.06508637502498, 51.15524516803983));
            locationCollection.Add(addLocation(17.068814029376092, 51.15300430840158));
            locationCollection.Add(addLocation(17.073969881615838, 51.14999738199667));
            locationCollection.Add(addLocation(17.074077169976434, 51.14963395926561));
            locationCollection.Add(addLocation(17.07551066438097, 51.14899867546374));
            locationCollection.Add(addLocation(17.07581107179064, 51.148368537612065));
            locationCollection.Add(addLocation(17.075660868085805, 51.14784357422088));
            locationCollection.Add(addLocation(17.07950538965858, 51.147962752033024));
            locationCollection.Add(addLocation(17.080079382387765, 51.147871892613));
            locationCollection.Add(addLocation(17.080068653551706, 51.14758585253015));
            locationCollection.Add(addLocation(17.08205375105041, 51.14380172912734));
            locationCollection.Add(addLocation(17.08128127485412, 51.1436334556317));
            locationCollection.Add(addLocation(17.08179625898498, 51.14097804401012));
            locationCollection.Add(addLocation(17.08202156454223, 51.13963610914212));
            locationCollection.Add(addLocation(17.089239917802747, 51.141023027962724));
            locationCollection.Add(addLocation(17.09090288739198, 51.13818339101063));
            locationCollection.Add(addLocation(17.089239917802747, 51.13790738856755));
            locationCollection.Add(addLocation(17.087198069136683, 51.13774351760057));
            locationCollection.Add(addLocation(17.088195850890223, 51.1347881580246));
            locationCollection.Add(addLocation(17.08753794765769, 51.13406381640113));
            locationCollection.Add(addLocation(17.087709609034643, 51.1336396765652));
            locationCollection.Add(addLocation(17.0868191156417, 51.13311454565639));
            locationCollection.Add(addLocation(17.087098065379248, 51.131929223161194));
            locationCollection.Add(addLocation(17.08926861995756, 51.132137935107544));
            locationCollection.Add(addLocation(17.091178352776165, 51.13189555985571));
            locationCollection.Add(addLocation(17.09231560939848, 51.13139734006522));
            locationCollection.Add(addLocation(17.095061464383505, 51.13051626150156));
            locationCollection.Add(addLocation(17.097582740857504, 51.129829504201574));
            locationCollection.Add(addLocation(17.101289134749745, 51.12865305082456));
            locationCollection.Add(addLocation(17.10543046546874, 51.13170306084329));
            locationCollection.Add(addLocation(17.107342294552463, 51.13144250912183));
            locationCollection.Add(addLocation(17.1094558752562, 51.13146270730623));
            locationCollection.Add(addLocation(17.110298428369877, 51.13154349995548));
            locationCollection.Add(addLocation(17.110802683664676, 51.131718550210614));
            locationCollection.Add(addLocation(17.11358765570138, 51.12911686837534));
            locationCollection.Add(addLocation(17.11645025161925, 51.126479110731715));
            locationCollection.Add(addLocation(17.11946138185956, 51.12361860683983));
            locationCollection.Add(addLocation(17.120287502236145, 51.12196857333857));
            locationCollection.Add(addLocation(17.12197365378653, 51.11967126506874));
            locationCollection.Add(addLocation(17.1227246723107, 51.11894365596282));
            locationCollection.Add(addLocation(17.12431610137167, 51.118054686586916));
            locationCollection.Add(addLocation(17.124959831535243, 51.11761019548462));
            locationCollection.Add(addLocation(17.12564036084295, 51.117112051582595));
            locationCollection.Add(addLocation(17.128311841021784, 51.11603446802834));
            locationCollection.Add(addLocation(17.129127317849328, 51.11546629108147));
            locationCollection.Add(addLocation(17.12984614986532, 51.11565487233654));
            locationCollection.Add(addLocation(17.131766611519982, 51.11545282096237));
            locationCollection.Add(addLocation(17.13266471162123, 51.11543261577635));
            locationCollection.Add(addLocation(17.133315091677762, 51.113718723460124));
            locationCollection.Add(addLocation(17.13385689789877, 51.11328766139892));
            locationCollection.Add(addLocation(17.13385689789877, 51.10959911056851));
            locationCollection.Add(addLocation(17.133931999751187, 51.10722911770892));
            locationCollection.Add(addLocation(17.134039288111783, 51.105233702577976));
            locationCollection.Add(addLocation(17.133760338374234, 51.1044164481009));
            locationCollection.Add(addLocation(17.133277540751553, 51.10393814212208));
            locationCollection.Add(addLocation(17.129402354044146, 51.101067479026746));
            locationCollection.Add(addLocation(17.127175748104882, 51.10286446794265));
            locationCollection.Add(addLocation(17.125188578141703, 51.104381042695564));
            locationCollection.Add(addLocation(17.12455557681419, 51.10406441792222));
            locationCollection.Add(addLocation(17.124716509355082, 51.10322232020478));
            locationCollection.Add(addLocation(17.12455557681419, 51.10305389882043));
            locationCollection.Add(addLocation(17.12331103183128, 51.10238694411212));
            locationCollection.Add(addLocation(17.123332489503397, 51.10165235326601));
            locationCollection.Add(addLocation(17.122914064897074, 51.101241390053524));
            locationCollection.Add(addLocation(17.121160553228844, 51.10101232700521));
            locationCollection.Add(addLocation(17.119851635229576, 51.101079698607826));
            locationCollection.Add(addLocation(17.118095390737103, 51.1004981735232));
            locationCollection.Add(addLocation(17.117115367508692, 51.10135379509787));
            locationCollection.Add(addLocation(17.11467992172317, 51.103371637934146));
            locationCollection.Add(addLocation(17.11237767718456, 51.105054937885555));
            locationCollection.Add(addLocation(17.10970791040871, 51.10598515276639));
            locationCollection.Add(addLocation(17.10590070248091, 51.106565027319526));
            locationCollection.Add(addLocation(17.092080457688933, 51.106298274279816));
            locationCollection.Add(addLocation(17.091565473558074, 51.10465456471902));
            locationCollection.Add(addLocation(17.090728624345427, 51.10470845776256));
            locationCollection.Add(addLocation(17.090320928575164, 51.1037787939547));
            locationCollection.Add(addLocation(17.090814455033904, 51.10147512609481));
            locationCollection.Add(addLocation(17.090964658738738, 51.099965991572354));
            locationCollection.Add(addLocation(17.090736670972472, 51.0986384891191));
            locationCollection.Add(addLocation(17.089731427789737, 51.09880692658993));
            locationCollection.Add(addLocation(17.08746407060929, 51.098894513832256));
            locationCollection.Add(addLocation(17.086680685768933, 51.09856630300965));
            locationCollection.Add(addLocation(17.085071360359997, 51.09850566527524));
            locationCollection.Add(addLocation(17.083604913106328, 51.09890281746041));
            locationCollection.Add(addLocation(17.08253202950037, 51.09940138774358));
            locationCollection.Add(addLocation(17.07958350732172, 51.10032977839501));
            locationCollection.Add(addLocation(17.077705961011294, 51.101010237115744));
            locationCollection.Add(addLocation(17.074644984042997, 51.102338540580554));
            locationCollection.Add(addLocation(17.07254213217532, 51.10289096897544));
            locationCollection.Add(addLocation(17.07105082396304, 51.10345686438851));
            locationCollection.Add(addLocation(17.068810804341894, 51.10165810141109));
            locationCollection.Add(addLocation(17.071107623413546, 51.09910023954618));
            locationCollection.Add(addLocation(17.07399368031357, 51.09753038848549));
            locationCollection.Add(addLocation(17.079035427969135, 51.0955630210008));
            locationCollection.Add(addLocation(17.073655651079566, 51.091921751201376));
            locationCollection.Add(addLocation(17.073355243669898, 51.091362453160635));
            locationCollection.Add(addLocation(17.073129938112647, 51.09083010295927));
            locationCollection.Add(addLocation(17.07214940200282, 51.08962119837508));
            locationCollection.Add(addLocation(17.07216013083888, 51.08945946629043));
            locationCollection.Add(addLocation(17.070250398020278, 51.08887221933579));
            locationCollection.Add(addLocation(17.0694652089197, 51.08881126553923));
            locationCollection.Add(addLocation(17.068767834575826, 51.08906060576142));
            locationCollection.Add(addLocation(17.067276526363546, 51.08831932007745));
            locationCollection.Add(addLocation(17.070823970453265, 51.08567548210045));
            locationCollection.Add(addLocation(17.072802300977546, 51.08455190825016));
            locationCollection.Add(addLocation(17.077476412625593, 51.081880092259304));
            locationCollection.Add(addLocation(17.07632826687744, 51.08074910113332));
            locationCollection.Add(addLocation(17.076011766213682, 51.079991779251195));
            locationCollection.Add(addLocation(17.076129783410337, 51.07867045676074));
            locationCollection.Add(addLocation(17.076178063172605, 51.078043284877495));
            locationCollection.Add(addLocation(17.07554506184509, 51.077588298085324));
            locationCollection.Add(addLocation(17.075244654435423, 51.07725179236714));
            locationCollection.Add(addLocation(17.07610296132019, 51.07561434663721));
            locationCollection.Add(addLocation(17.076650131959227, 51.074646908756264));
            locationCollection.Add(addLocation(17.076709140557554, 51.074076702283676));
            locationCollection.Add(addLocation(17.07530366303375, 51.07258750698953));
            locationCollection.Add(addLocation(17.073168979981105, 51.0702576077714));
            locationCollection.Add(addLocation(17.07354448924319, 51.06785287143412));
            locationCollection.Add(addLocation(17.073941456177394, 51.06553521289472));
            locationCollection.Add(addLocation(17.073952185013454, 51.065029535083475));
            locationCollection.Add(addLocation(17.073803322413127, 51.06478232921622));
            locationCollection.Add(addLocation(17.075430208573678, 51.064142650412954));
            locationCollection.Add(addLocation(17.07723072581342, 51.06424210272428));
            locationCollection.Add(addLocation(17.080633461620025, 51.0645134884529));
            locationCollection.Add(addLocation(17.082370806271445, 51.063594430187976));

            return locationCollection;
        }

        private void drawPolyline(LocationCollection locations)
        {
            MapPolyline polyline = new MapPolyline();
            polyline.Stroke = new SolidColorBrush(Colors.Blue);
            polyline.StrokeThickness = 5;
            polyline.Opacity = 0.7;
            polyline.Locations = locations;
            MasterBingMap.Children.Add(polyline);
        }

        private void startLocation(int zoom)
        {
            cleanMap();
            mvm.defaultLocation();
            MasterBingMap.ZoomLevel = zoom;
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            startLocation(15);
        }

        private void cleanMap()
        {
            MasterBingMap.Children.RemoveRange(0, MasterBingMap.Children.Count);
        }

        private void showObjects(string filter, string color)
        {
            for (int i = 0; i < pvm.modelList.Count; i++)
            {
                if (pvm.modelList[i].Category.ToString().Equals(AppResources.GetText(filter)))
                {
                    addCanvas(pvm.modelList[i].Latitude, pvm.modelList[i].Longtitude, pvm.modelList[i].NameOfPlace, color);
                }
            }
        }

        private void hotele_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void atrakcje_turystyczne_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void koscioly_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void kina_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void centra_handlowe_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void muzea_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void parki_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void transport_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void urzedy_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void teatry_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void sciezka1_Click(object sender, RoutedEventArgs e)
        {
            startLocation(15);
            showObjects("B_sciezka", ((KinectTileButton)sender).Background.ToString());
            drawPolyline(firstPath());
        }

        private void sciezka2_Click(object sender, RoutedEventArgs e)
        {
            startLocation(15);
            showObjects("B_sciezka", ((KinectTileButton)sender).Background.ToString());
            drawPolyline(secondPath());
        }

        private void sciezka3_Click(object sender, RoutedEventArgs e)
        {
            startLocation(12);
            drawPolyline(thirdPath());
        }

        private void prepareTranslation()
        {
            koscioly.Text = AppResources.GetText("B_koscioly");
            hotele.Text = AppResources.GetText("B_hotele");
            urzedy.Text = AppResources.GetText("B_urzedy");
            muzea.Text = AppResources.GetText("B_muzea");
            parki.Text = AppResources.GetText("B_parki");
            zakupy.Text = AppResources.GetText("B_zakupy");
            transport.Text = AppResources.GetText("B_transport");
            kina.Text = AppResources.GetText("B_kina");
            teatry.Text = AppResources.GetText("B_teatry");
            centrum.Text = AppResources.GetText("B_centrum");
            atrakcje.Text = AppResources.GetText("B_atrakcje");
            zwiedzanie.Text = AppResources.GetText("B_sciezka_zwiedzanie");
            spacer.Text = AppResources.GetText("B_sciezka_spacer");
            rowerem.Text = AppResources.GetText("B_sciezka_rower");
        }

    }

}

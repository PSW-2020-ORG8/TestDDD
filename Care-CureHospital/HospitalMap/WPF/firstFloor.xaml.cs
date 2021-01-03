using HospitalMap.Code.Controller;
using HospitalMap.Code.Model;
using HospitalMap.Code.Model.Canvas;
using HospitalMap.Code.Repository;
using HospitalMap.Code.Repository.DoctorsRepository;
using HospitalMap.Code.Repository.RectangleRepository;
using HospitalMap.Repository;
using HospitalMap.WPF.Converter;
using HospitalMap.WPF.ModelWPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HospitalMap.WPF
{
    /// <summary>
    /// Interaction logic for prviSprat.xaml
    /// </summary>
    public partial class FirstFloor : Window, INotifyPropertyChanged
    {
        public Rectangle Dinamicly = new Rectangle();
        public ObservableCollection<Rectangles> Rectangle { get; set; }

        public ObservableCollection<PatientsRoomVieW> RoomsInfo { get; set; }

        public ObservableCollection<DoctorRoomView> DrOfficeInfo { get; set; }

        public ObservableCollection<StorageModel> storage { get; set; }

        public Rectangles SearchedRectangle = new Rectangles();

        public ObservableCollection<PatientsRoomVieW> SearchedPatientsRooms { get; set; }
        public ObservableCollection<DoctorRoomView> SearchedDoctorsRooms { get; set; }

        public ObservableCollection<RoomWorkTime> SearchedAnotherRooms { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private PatientsRoomVieW _room;

        public PatientsRoomVieW Room
        {
            get
            {
                return _room;
            }
            set
            {
                if (value != _room)
                {
                    _room = value;
                    OnPropertyChanged("Room");
                }
            }
        }
        public FirstFloor()
        {
            InitializeComponent();
            CreateDynamicCanvas();
            FirstFloorRepository.GetInstance();
            InformationEditRepository.GetInstance();
            DoctorsRoomRepository.GetInstance();
            StorageRepository.GetInstance();
            Room = InformationEditRepository.GetInstance().GetById("R1");
            RoomTxt.Text = Room.NameOfRoom;
        }

        public FirstFloor(string Id)
        {
            InitializeComponent();
            CreateDynamicCanvas();
            FirstFloorRepository.GetInstance();
            InformationEditRepository.GetInstance();
            DrawSelectedRectangle(Id);
            DoctorsRoomRepository.GetInstance();
            StorageRepository.GetInstance();
            Room = InformationEditRepository.GetInstance().GetById("R1");
            RoomTxt.Text = Room.NameOfRoom;

            SearchedPatientsRooms = new ObservableCollection<PatientsRoomVieW>();
            SearchedDoctorsRooms = new ObservableCollection<DoctorRoomView>();
            SearchedAnotherRooms = new ObservableCollection<RoomWorkTime>();
        }

        private void DrawSelectedRectangle(string Id)
        {
            SearchedRectangle = FirstFloorRepository.GetInstance().GetById(Id);

            Rectangle rect = new Rectangle()
            {

                Fill = Brushes.Transparent,
                Height = SearchedRectangle.Height,
                Width = SearchedRectangle.Width,
                Name = SearchedRectangle.Id,
                Stroke = Brushes.Red,
                StrokeThickness = 5

            };
            Canvas.SetLeft(rect, SearchedRectangle.Left);
            Canvas.SetTop(rect, SearchedRectangle.Top);
            canvas.Children.Add(rect);
        }

        private void CreateDynamicCanvas()
        {
            Rectangle = new ObservableCollection<Rectangles>();
            Rectangle = FirstFloorRepository.GetInstance().GetAllRectangles();           
           
            RoomsInfo = new ObservableCollection<PatientsRoomVieW>(PatientsRoomConverter.ConvertRoomToPatientsRoomView(
             Backend.App.Instance().RoomService.GetAllEntitiesByType(3).ToList()));
           

            DrOfficeInfo = new ObservableCollection<DoctorRoomView>(DoctorRoomConverter.ConvertRoomToDoctorRoomView(
             Backend.App.Instance().RoomService.GetAllEntitiesByType(1).ToList()));

           
            storage = StorageRepository.GetInstance().GetAllStorage();

            foreach (Rectangles r in Rectangle)
            {
                Rectangle rect = new Rectangle()
                {
                    Fill = r.Paint,
                    Height = r.Height,
                    Width = r.Width,
                    Name = r.Id
                };

                TextBlock txtb = new TextBlock()
                {
                    Width = r.WidthText,
                    Height = r.HeightText,
                    Text = r.Text,
                    Background = r.Background
                };
                canvas.Children.Add(txtb);
                foreach (PatientsRoomVieW room in RoomsInfo)
                {
                    if (r.Id.Equals(room.IdOfRoom))
                    {
                        rect.MouseDown += RoomInformation;
                    }
                }

                foreach (DoctorRoomView room in DrOfficeInfo)
                {
                    if (r.Id.Equals(room.IdOfRoom))
                    {
                        rect.MouseDown += DrOfficeInformation;
                    }
                }

                foreach (StorageModel s in storage)
                {
                    if (r.Id.Equals(s.IdS))
                    {
                        rect.MouseDown += StorageInfo;
                        break;
                    }
                }

                Canvas.SetLeft(txtb, r.LeftText);
                Canvas.SetTop(txtb, r.TopText);
                Canvas.SetLeft(rect, r.Left);
                Canvas.SetTop(rect, r.Top);
                canvas.Children.Add(rect);
                
            }

        }

        private void StorageInfo(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            RoomItems s = new RoomItems("", rect.Name);
            s.Show();
        }

        private void RoomInformation(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            RoomInformation worktime1 = new RoomInformation(rect.Name);
            worktime1.Show(); 
        }

     


        private void DrOfficeInformation(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            DoctorOfficeInformation worktime1 = new DoctorOfficeInformation(rect.Name);
            worktime1.Show();
        }

        private void GroundFloorClick(object sender, RoutedEventArgs e)
        {
            GroundFloor p = new GroundFloor();
            p.Show();
            this.Close();

        }

        private void FirstFloor1(object sender, RoutedEventArgs e)
        {
            FirstFloor psprat = new FirstFloor();
            psprat.Show();
            this.Close();
        }

        private void Map(object sender, RoutedEventArgs e)
        {
            MainWindow map = new MainWindow(3);
            map.Show();
            this.Close();
        }

        private void GroundFloor2(object sender, RoutedEventArgs e)
        {
            GroundFloor2 p = new GroundFloor2();
            p.Show();
            this.Close();

        }

        private void SecondFloor(object sender, RoutedEventArgs e)
        {
            FirstFloor firstf = new FirstFloor();
            firstf.Show();
            this.Close();
        }

        private void Room1(object sender, MouseButtonEventArgs e)
        {
            RoomInformation room = new RoomInformation();
            room.Show();
        }
        
        private void ButtonClick1(object sender, RoutedEventArgs e)
        {
            HospitalMap.WPF.Login.role = 0;
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {



            if (EquipmnetRadioButon.IsChecked == true && !search.Text.ToString().Equals(""))
            {
                ObservableCollection<StorageModel> equipments = new ObservableCollection<StorageModel>();
                equipments = StorageRepository.GetInstance().SearchedItemsByName(search.Text);

                if (equipments.Count == 0)
                {
                    MessageBox.Show("There are no items like '" + search.Text + "' in storage!", "Storage");
                    return;
                }

                Storage storage = new Storage(equipments);
                storage.Show();

            }

            if (RoomsRadioButon.IsChecked == true)
            {
                SearchController _searchController = new SearchController();

                SearchedPatientsRooms = new ObservableCollection<PatientsRoomVieW>(PatientsRoomConverter.ConvertRoomToPatientsRoomView(_searchController.SearchPatientsRooms(search.Text.ToString()).ToList()));


                SearchedDoctorsRooms = new ObservableCollection<DoctorRoomView>(DoctorRoomConverter.ConvertRoomToDoctorRoomView(_searchController.SearchDoctorsRooms(search.Text.ToString()).ToList()));

                SearchedAnotherRooms = new ObservableCollection<RoomWorkTime>(WorkTimeRoomConverter.ConvertRoomToRoomWorkTime(_searchController.SearchAnotherRooms(search.Text.ToString()).ToList()));

                if (SearchedPatientsRooms.Count == 0 && SearchedDoctorsRooms.Count == 0 && SearchedAnotherRooms.Count == 0)
                {
                    MessageBox.Show("There are no search results! ", "Notice", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                SearchedRooms searchedRoom = new SearchedRooms(SearchedPatientsRooms, SearchedDoctorsRooms, SearchedAnotherRooms);
                searchedRoom.Show();

            }





        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Schedule s = new Schedule();
            s.Show();

        }

    }

}

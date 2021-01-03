using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HospitalMap.Code.Model.Canvas;
using HospitalMap.Code.Repository.RectangleRepository;
using HospitalMap.Code.Repository;
using HospitalMap.WPF;
using HospitalMap.Repository;
using HospitalMap.WPF.ModelWPF;
using HospitalMap.Code.Model;
using HospitalMap.Code.Repository.RoomInformatioRepository;
using HospitalMap.Code.Repository.DoctorsRepository;
using HospitalMap.WPF.Converter;
using HospitalMap.Code.Controller;

namespace HospitalMap.WPF
{
    /// <summary>
    /// Interaction logic for prizemlje.xaml
    /// </summary>
    public partial class GroundFloor2 : Window
    {

        public Rectangle Dinamicly = new Rectangle();
        public ObservableCollection<Rectangles> Rectangle { get; set; }
        public ObservableCollection<DoctorRoomView> DrOfficeInfo { get; set; }

        public ObservableCollection<StorageModel> storage { get; set; }

        public ObservableCollection<RoomWorkTime> WorkTime { get; set; }

        public Rectangles SearchedRectangle = new Rectangles();

        public ObservableCollection<PatientsRoomVieW> SearchedPatientsRooms { get; set; }
        public ObservableCollection<DoctorRoomView> SearchedDoctorsRooms { get; set; }

        public ObservableCollection<RoomWorkTime> SearchedAnotherRooms { get; set; }

        public GroundFloor2()
        {
            InitializeComponent();
            CreateDynamicCanvas();
            GroundFloor2Repository.GetInstance();
            InformationEditRepository.GetInstance();
            StorageRepository.GetInstance();
            RoomWorkTimeRepository.GetInstance();

        }


        public GroundFloor2(string Id)
        {
            InitializeComponent();
            CreateDynamicCanvas();
            GroundFloor2Repository.GetInstance();
            DoctorsRoomRepository.GetInstance();
            DrawSelectedRectangle(Id);
            InformationEditRepository.GetInstance();
            StorageRepository.GetInstance();
            RoomWorkTimeRepository.GetInstance();


            SearchedPatientsRooms = new ObservableCollection<PatientsRoomVieW>();
            SearchedDoctorsRooms = new ObservableCollection<DoctorRoomView>();
            SearchedAnotherRooms = new ObservableCollection<RoomWorkTime>();
        }

        private void DrawSelectedRectangle(string Id)
        {
            SearchedRectangle = GroundFloor2Repository.GetInstance().GetById(Id);

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
            Rectangle = GroundFloor2Repository.GetInstance().GetAllRectangles();
           
            storage = StorageRepository.GetInstance().GetAllStorage();
            
            DrOfficeInfo = new ObservableCollection<DoctorRoomView>(DoctorRoomConverter.ConvertRoomToDoctorRoomView(
            Backend.App.Instance().RoomService.GetAllEntitiesByType(1).ToList()));

            WorkTime = new ObservableCollection<RoomWorkTime>(WorkTimeRoomConverter.ConvertRoomToRoomWorkTime(
             Backend.App.Instance().RoomService.GetAllEntitiesByType(4).ToList()));

            foreach (Rectangles r in Rectangle)
            {
                Rectangle rect = new Rectangle()
                {
                    Fill = r.Paint,
                    Height = r.Height,
                    Width = r.Width,
                    Name=r.Id
                };

                TextBlock txtb = new TextBlock()
                {
                    Width = r.WidthText,
                    Height = r.HeightText,
                    Text = r.Text,
                    Background = r.Background
                };
                canvas.Children.Add(txtb);
                foreach (DoctorRoomView room in DrOfficeInfo)
                {
                    if (r.Id.Equals(room.IdOfRoom))
                    {
                        rect.MouseDown += RoomInformation;
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

                foreach (RoomWorkTime s in WorkTime)
                {
                    if (r.Id.Equals(s.IdOfRoom))
                    {
                        rect.MouseDown += WorkTimeInfo;
                    }
                }

                Canvas.SetLeft(txtb, r.LeftText);
                Canvas.SetTop(txtb, r.TopText);
                Canvas.SetLeft(rect, r.Left);
                Canvas.SetTop(rect, r.Top);
                canvas.Children.Add(rect);

            }

        }

        private void WorkTimeInfo(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            WorkTimeView s = new WorkTimeView(rect.Name);
            s.Show();
        }
        private void GroundFloorClick(object sender, RoutedEventArgs e)
        {
            GroundFloor p = new GroundFloor();
            p.Show();
            this.Close();
            

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
            DoctorOfficeInformation worktime1 = new DoctorOfficeInformation(rect.Name);
            worktime1.Show();
        }
        private void FirstFloor(object sender, RoutedEventArgs e)
        {
            FirstFloor firstf = new FirstFloor();
            firstf.Show();
            this.Close();
        }

        private void Map(object sender, RoutedEventArgs e)
        {
            MainWindow map = new MainWindow(3);
            map.Show();
            this.Close();
        }

        private void GroundFloor(object sender, RoutedEventArgs e)
        {
            GroundFloor2 p = new GroundFloor2();
            p.Show();
            this.Close();

        }

        private void SecondFloor(object sender, RoutedEventArgs e)
        {
            FirstFloor secondf = new FirstFloor();
            secondf.Show();
            this.Close();
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

using HospitalMap.WPF.ModelWPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
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
    /// Interaction logic for SearchedRooms.xaml
    /// </summary>
    public partial class SearchedRooms : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }




        private ObservableCollection<PatientsRoomVieW> _patientsRooms;

        public ObservableCollection<PatientsRoomVieW> PatientsRooms
        {
            get { return _patientsRooms; }
            set { _patientsRooms = value; OnPropertyChanged("PatientsRooms"); }

        }

        public PatientsRoomVieW SelectedPatientRoom;

        public DoctorRoomView SelectedDoctorRoom;
        public RoomWorkTime SelectedAnotherRoom { get; set; }


        private ObservableCollection<DoctorRoomView> _doctorsRooms;

        public ObservableCollection<DoctorRoomView> DoctorsRooms
        {
            get { return _doctorsRooms; }
            set { _doctorsRooms = value; OnPropertyChanged("DoctorsRooms"); }

        }


        private ObservableCollection<RoomWorkTime> _anothersRooms;

        public ObservableCollection<RoomWorkTime> AnothersRooms
        {
            get { return _anothersRooms; }
            set { _anothersRooms = value; OnPropertyChanged("AnothersRooms"); }

        }

       

        public SearchedRooms(ObservableCollection<PatientsRoomVieW> patientsRooms, ObservableCollection<DoctorRoomView> doctorsRooms, ObservableCollection<RoomWorkTime> anothersRooms)
        {
            InitializeComponent();
            this.DataContext = this;

            PatientsRooms = patientsRooms;
            DoctorsRooms = doctorsRooms;
            AnothersRooms = anothersRooms;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedPatientRoom = (PatientsRoomVieW)PatientsRoomDataGrid.SelectedItem;

            FirstFloor f = new FirstFloor(SelectedPatientRoom.IdOfRoom);
            f.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SelectedDoctorRoom = (DoctorRoomView)DoctorsRoomDataGrid.SelectedItem;
            if (SelectedDoctorRoom.IdOfRoom.Contains("A"))
            {
                GroundFloor f = new GroundFloor(SelectedDoctorRoom.IdOfRoom);
                f.Show();
            }
            else if (SelectedDoctorRoom.IdOfRoom.Contains("B"))
            {
                GroundFloor2 f = new GroundFloor2(SelectedDoctorRoom.IdOfRoom);
                f.Show();
            }
            else
            {
                FirstFloor f = new FirstFloor(SelectedDoctorRoom.IdOfRoom);
                f.Show();

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SelectedAnotherRoom = (RoomWorkTime)AnotherRoomsDataGrid.SelectedItem;

           if(SelectedAnotherRoom.IdOfRoom.Equals("HospitalA") || SelectedAnotherRoom.IdOfRoom.Equals("HospitalB"))
            {
                MessageBox.Show("Clinic A and Clinic B are located on the complex maps! ", "Notice", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (SelectedAnotherRoom.IdOfRoom.Contains("A"))
            {
                GroundFloor f = new GroundFloor(SelectedAnotherRoom.IdOfRoom);
                f.Show();
            }
            else if (SelectedAnotherRoom.IdOfRoom.Contains("B"))
            {
                GroundFloor2 f = new GroundFloor2(SelectedAnotherRoom.IdOfRoom);
                f.Show();
            }
            
        }
    }
}

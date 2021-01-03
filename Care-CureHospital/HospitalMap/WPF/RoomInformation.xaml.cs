using HospitalMap.Controller;
using HospitalMap.WPF.Converter;
using HospitalMap.WPF.ModelWPF;
using Model.Term;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for RoomInformation.xaml
    /// </summary>
    public partial class RoomInformation : Window
    {
        private InformationEditController informationControler = new InformationEditController();
        public PatientsRoomVieW room
        {
            get;
            set;
        }

        public RoomInformation()
        {
            InitializeComponent();
            this.DataContext = this;

            

            if (Login.role != 3)
            {

                ButonSave.Visibility = Visibility.Hidden;

                Roomtxt.IsEnabled = false;
                FloorTxt.IsEnabled = false;
                BedCapacityTxt.IsEnabled = false;
                OcupiedBedsTxt.IsEnabled = false;
                AvailableBedsTxt.IsEnabled = false;
                ClinicTxt.IsEnabled = false;


            }

           


        }


        public RoomInformation(String id)
        {
            InitializeComponent();
            this.DataContext = this;

            RoomTextBlock.Visibility = Visibility.Hidden;
            Roomtxt.Visibility = Visibility.Hidden;

            if (Login.role != 3)
            {

                ButonSave.Visibility = Visibility.Hidden;

                Roomtxt.IsEnabled = false;
                FloorTxt.IsEnabled = false;
                BedCapacityTxt.IsEnabled = false;
                OcupiedBedsTxt.IsEnabled = false;
                AvailableBedsTxt.IsEnabled = false;
                ClinicTxt.IsEnabled = false;


            }
            if (Login.role == 2)
            {
                BedCapacityTxt.Visibility = Visibility.Hidden;
                OcupiedBedsTxt.Visibility = Visibility.Hidden;
                AvailableBedsTxt.Visibility = Visibility.Hidden;
                BedCapacity.Visibility = Visibility.Hidden;
                OccupiedBeds.Visibility = Visibility.Hidden;
                AvailableBeds.Visibility = Visibility.Hidden;

            }

            Room r1 = informationControler.GetRoomById(id);
            if (r1 != null)
            {
                room = PatientsRoomConverter.ConvertRoomToPatientsRoomView(informationControler.GetRoomById(id));
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Room r1 = informationControler.GetEntity(room.IdOfRoomInMySQLDataBase);

            r1.RoomId = room.NameOfRoom;
            r1.IdRoomClinic = room.IdOfRoom;
            r1.NameOfClinic = room.NameOfClinic;
            r1.NumberOfFloor = room.NumberOfFloor;
            r1.BedCapacity = room.BedCapacity;
            r1.AvailableBeds = room.AvailableBeds;
            r1.OccupiedBeds = room.OccupiedBeds;


            informationControler.UpdateEntity(r1);
            this.Close();


        }
    }
}

using HospitalMap.Code.Model;
using HospitalMap.Code.Repository;
using HospitalMap.Code.Repository.DoctorsRepository;
using HospitalMap.Controller;
using HospitalMap.WPF.Converter;
using HospitalMap.WPF.ModelWPF;
using Model.AllActors;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
    /// Interaction logic for DoctorOfficeInformation.xaml
    /// </summary>
    public partial class DoctorOfficeInformation : Window
    {





        private InformationEditController _informationControler = new InformationEditController();
        public DoctorRoomView DoctorsRoom
        {
            get;
            set;
        }


        public  ObservableCollection<DoctorView> AllDoctors
        {
            get;
            set;
        }

        public ObservableCollection<string> AllNameAndSurnameAndJmbgFromDoctors
        {
            get;
            set;
        }

        private static string _idRoom;
        Doctor doctor;
        public DoctorOfficeInformation(string Id)
        {
            
            InitializeComponent();
            this.DataContext = this;


            if(Login.role != 3)
            {

                NewDoctor.Visibility= Visibility.Hidden;
                ButtonSave.Visibility = Visibility.Hidden;
                DoctorsComboBox.Visibility = Visibility.Hidden;
                FromTXT.IsEnabled = false;
                ToTXT.IsEnabled = false;
                NameOfCurrentDoctor.IsEnabled = false;
                SurnameOfCurrentDoctor.IsEnabled = false;

                

                NumberOfFloorTxt.IsEnabled = false;
                NameOfClinicTxt.IsEnabled = false;



            }

            Room r1 = _informationControler.GetRoomById(Id);
            if (r1 != null)
            {
                Room room = _informationControler.GetRoomById(Id);

                DoctorsRoom = DoctorRoomConverter.ConvertRoomToDoctorRoomView(_informationControler.GetRoomById(Id));
                doctor = _informationControler.GetDoctorById(room.DoctordId);

                DoctorsRoom.NameOfDoctor = doctor.Name;
                DoctorsRoom.SurnameOfDoctor= doctor.Surname;
                DoctorsRoom.JmbgOfDoctor = doctor.Jmbg;
                



            }
            

            _idRoom = Id;



            AllNameAndSurnameAndJmbgFromDoctors = new ObservableCollection<string>();

            
            AllDoctors = new ObservableCollection<DoctorView>(DoctorConverter.ConvertDoctorToDoctorViewList(
              Backend.App.Instance().DoctorService.GetAllEntities().ToList()));



            foreach (DoctorView curentDoctor in AllDoctors)
            {
                if (!curentDoctor.IdOfDoctor.Equals( doctor.Id.ToString()) )
                {
                    AllNameAndSurnameAndJmbgFromDoctors.Add(curentDoctor.NameOfDoctor + " " + curentDoctor.SurnameOfDoctor + " Doctor ID:" + curentDoctor.IdOfDoctor);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!DoctorsComboBox.Text.ToString().Equals(""))
            {


                string _selectedDoctor = DoctorsComboBox.Text;

                string[] niz = _selectedDoctor.Split(':');

                

                int selectedDoctorId= Int32.Parse(niz[1]);

                int from= Int32.Parse(DoctorsRoom.FromDateTime);
                int to= Int32.Parse(DoctorsRoom.ToDateTime);

                if(from >= to)
                {
                    MessageBox.Show("The initial hourly rate must be less than the final hourly rate! ", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

               

                Doctor selectedDoctor= _informationControler.GetDoctorById(selectedDoctorId);

                Room currentRoom = _informationControler.GetRoomById(_idRoom);

                currentRoom.DoctordId = selectedDoctor.Id;
                currentRoom.NameOfClinic = DoctorsRoom.NameOfClinic;
                currentRoom.NumberOfFloor = DoctorsRoom.NumberOfFloor;
                currentRoom.StartWorkTime = DoctorsRoom.FromDateTime;
                currentRoom.EndWorkTime = DoctorsRoom.ToDateTime;

                _informationControler.UpdateEntity(currentRoom);




                this.Close();

            }
            else
            {
                int from = Int32.Parse(DoctorsRoom.FromDateTime);
                int to = Int32.Parse(DoctorsRoom.ToDateTime);

                if (from >= to)
                {
                    MessageBox.Show("The initial hourly rate must be less than the final hourly rate! ", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Room currentRoom = _informationControler.GetRoomById(_idRoom);

                
                currentRoom.NameOfClinic = DoctorsRoom.NameOfClinic;
                currentRoom.NumberOfFloor = DoctorsRoom.NumberOfFloor;
                currentRoom.StartWorkTime = DoctorsRoom.FromDateTime;
                currentRoom.EndWorkTime = DoctorsRoom.ToDateTime;

                _informationControler.UpdateEntity(currentRoom);


               

                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ObservableCollection<StorageModel> equipments = new ObservableCollection<StorageModel>();
            equipments = StorageRepository.GetInstance().SearchedItemsByRoom(_idRoom);

            if (equipments.Count == 0)
            {
                MessageBox.Show("There are no items in room !", "Storage");
                return;
            }

            RoomItems room = new RoomItems(equipments);
            room.Show();
        }
    }
}

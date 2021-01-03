using HospitalMap.Code.Model;
using HospitalMap.Code.Repository;
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
    /// Interaction logic for RoomItems.xaml
    /// </summary>
    public partial class RoomItems : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private ObservableCollection<StorageModel> _equpments;

        public ObservableCollection<StorageModel> Equipments
        {
            get { return _equpments; }
            set { _equpments = value; OnPropertyChanged("Equipments"); }

        }

        public RoomItems()
        {
            InitializeComponent();
            this.DataContext = this;
            Equipments = StorageRepository.GetInstance().GetAllStorage();
            if (Equipments.Count == 0)
            {

                MessageBox.Show("There are no items in storage!", "Storage");
            }


        }
        public RoomItems(string search)
        {

            InitializeComponent();
            this.DataContext = this;
            Equipments = StorageRepository.GetInstance().SearchedItemsByName(search);
            if (Equipments.Count == 0)
            {

                MessageBox.Show("There are no items like '" + search + "' in storage!", "Storage");
            }
        }

        public RoomItems(ObservableCollection<StorageModel> equpments)
        {

            InitializeComponent();
            this.DataContext = this;
            Equipments = equpments;

        }

        public StorageModel SelectedDoctorRoom;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridStanje_u_Magacinu.SelectedIndex != -1)
            {
                SelectedDoctorRoom = (StorageModel)dataGridStanje_u_Magacinu.SelectedItem;
                if (SelectedDoctorRoom.Location.Contains("A"))
                {
                    GroundFloor f = new GroundFloor(SelectedDoctorRoom.Location);
                    f.Show();
                    this.Close();
                }
                else if (SelectedDoctorRoom.Location.Contains("B"))
                {
                    GroundFloor2 f = new GroundFloor2(SelectedDoctorRoom.Location);
                    f.Show();
                    this.Close();

                }
                else
                {
                    FirstFloor f = new FirstFloor(SelectedDoctorRoom.Location);
                    f.Show();
                    this.Close();


                }
            }
        }



        public RoomItems(string search, string idOfStorage)
        {

            InitializeComponent();
            this.DataContext = this;
            Equipments = StorageRepository.GetInstance().GetAllById(idOfStorage);

        }

    }
    }

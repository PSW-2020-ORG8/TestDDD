using HospitalMap.Code.Repository.DoctorsRepository;
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
    /// Interaction logic for AllDoctors.xaml
    /// </summary>
    public partial class AllDoctors : Window, INotifyPropertyChanged
    {
        


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private ObservableCollection<DoctorRoomView> _allDoctors;
        public ObservableCollection<DoctorRoomView> AllDoctorsInBothClinics
        {
            get { return _allDoctors; }
            set { _allDoctors = value; OnPropertyChanged("AllDoctorsInBothClinics"); }

        }


        public AllDoctors()
        {
            InitializeComponent();
            this.DataContext = this;
            AllDoctorsInBothClinics = DoctorsRoomRepository.GetInstance().GetAll();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (AllDoctorsDataGrid.SelectedItems.Count > 0)
            {

                DoctorRoomView selectedDoctor = new DoctorRoomView();
                selectedDoctor = (DoctorRoomView)AllDoctorsDataGrid.SelectedItem;

                AvailableTerms av = new AvailableTerms(selectedDoctor);
                av.Show();

                
            }
            else
            {
                MessageBox.Show("You must select at least one species", "Notice", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }
    }
}

using HospitalMap.WPF.Converter;
using HospitalMap.WPF.ModelWPF;
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
    /// Interaction logic for Doctor.xaml
    /// </summary>
    public partial class Doctors : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    

        public static DateTime Dstart
        {
            get;
            set;
        }

        public static DateTime Dend
        {
            get;
            set;
        }

        private ObservableCollection<DoctorView> _specs;
        public ObservableCollection<DoctorView> AllDoctors
        {
            get { return _specs; }
            set
            {
                _specs = value; OnPropertyChanged("AllDoctors");

            }
        }

        public static DoctorView SelektovaniDoktor
        {
            get;
            set;
        }

        public static SpecializationView Specijalizacija
        {
            get;
            set;
        }

        public Doctors()
        {
            InitializeComponent();
        }

        public Doctors(DateTime DatumS,DateTime DatumE,SpecializationView Spec)
        {
            InitializeComponent();
            this.DataContext = this;

            AllDoctors = new ObservableCollection<DoctorView>(DoctorConverter.ConvertDoctorToDoctorViewList(
             Backend.App.Instance().DoctorService.GetAllDoctorsBySpecialization(Spec.Id).ToList()));
            Doktori.SelectedIndex = 0;
            Dstart = DatumS;
            Dend = DatumE;
            Specijalizacija = Spec;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                      
            String priority = "";
            if (Prioritet.SelectedIndex == 0)
            {
                priority = "Doctor";

            }
            else if (Prioritet.SelectedIndex == 1)
            {

                priority = "DateRange";
            }

            
            ResultSchedule s = new ResultSchedule(Dstart, Dend, SelektovaniDoktor, priority);
            s.Show();
            this.Close();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Schedule s = new Schedule();
            s.Show();
            this.Close();
        }
    }
}

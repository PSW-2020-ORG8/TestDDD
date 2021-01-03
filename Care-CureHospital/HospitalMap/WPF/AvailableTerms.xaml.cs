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
    /// Interaction logic for AvailableTerms.xaml
    /// </summary>
    public partial class AvailableTerms : Window, INotifyPropertyChanged
    {
        public AvailableTerms(DoctorRoomView doctor)
        {
            InitializeComponent();
            this.DataContext = this;
            SelectedTermsForSelectedDoctor = doctor.MedicalTerms;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private ObservableCollection<MedicalTerm> _selectedTermsForSelectedDoctor;
        public ObservableCollection<MedicalTerm> SelectedTermsForSelectedDoctor
        {
            get { return _selectedTermsForSelectedDoctor; }
            set { _selectedTermsForSelectedDoctor = value; OnPropertyChanged("SelectedTermsForSelectedDoctor"); }

        }







    }
}

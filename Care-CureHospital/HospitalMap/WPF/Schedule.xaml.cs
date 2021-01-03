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
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public static SpecializationView Selektovan
        {
            get;
            set;
        }

        private ObservableCollection<SpecializationView> _specs;
        public ObservableCollection<SpecializationView> VrsteSpec
        {
            get { return _specs; }
            set
            {
                _specs = value; OnPropertyChanged("VrsteSpec");

            }
        }

        public Schedule()
        {
            InitializeComponent();
            this.DataContext = this;
            DatumS.SelectedDate = DateTime.Today;
            DatumE.SelectedDate = DateTime.Today;
            VrsteSpec = new ObservableCollection<SpecializationView>();
            Backend.App.Instance().SpetialitationService.GetAllEntities().ToList().ForEach(specialization => VrsteSpec.Add(SpecializationConverter.SpecializationToSpecializationDto(specialization)));
            Selektovan = VrsteSpec[0];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime Ds = new DateTime();
            Ds = (DateTime)DatumS.SelectedDate;
            DateTime De = new DateTime();
            De = (DateTime)DatumE.SelectedDate;
            

            Doctors s = new Doctors(Ds, De, Selektovan);
            s.Show();
            this.Close();
            
            
        }
    }
}

using HospitalMap.WPF.Converter;
using HospitalMap.WPF.ModelWPF;
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
    /// Interaction logic for ScheduleForPatient.xaml
    /// </summary>
    public partial class ScheduleForPatient : Window,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public WorkDayViewView SelectedApp;

        private ObservableCollection<PatientView> _specs;
        public ObservableCollection<PatientView> AllPatients
        {
            get { return _specs; }
            set
            {
                _specs = value; OnPropertyChanged("AllPatients");

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

        public static DoctorView DoctorS
        {
            get;
            set;
        }

        public static string PriorityS
        {
            get;
            set;
        }


        public static PatientView SelektovaniPacijent
        {
            get;
            set;
        }

        public ScheduleForPatient()
        {
            InitializeComponent();
        }


        public ScheduleForPatient(WorkDayViewView selectedAppointment, DateTime DatumS, DateTime DatumE, DoctorView Dr, String priority1)
        {
            InitializeComponent();
            this.DataContext = this;
            Dstart = DatumS;
            Dend = DatumE;
            DoctorS = Dr;
            PriorityS = priority1;

            AllPatients = new ObservableCollection<PatientView>(PatientConverter.ConvertPatientToPatientViewList(
           Backend.App.Instance().PatientService.GetAllEntities().ToList()));
           Pacijenti.SelectedIndex = 0;
           SelectedApp = selectedAppointment;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            ScheduleAppointmentView appointment = new ScheduleAppointmentView();
            appointment.StartTime = SelectedApp.AvailableAppointment.StartTime;
            appointment.EndTime = SelectedApp.AvailableAppointment.EndTime;
            appointment.DoctorWorkDayId = SelectedApp.Id;
            MedicalExamination medicalExamination = new MedicalExamination();
            medicalExamination.DoctorId = SelectedApp.DoctorId;
            medicalExamination.RoomId = SelectedApp.RoomId;
            appointment.MedicalExamination = medicalExamination;


            if (Backend.App.Instance().DoctorWorkDayService.ScheduleAppointment(ScheduleAppoitmentConverter.AppointmentDtoToAppointment(appointment, SelektovaniPacijent)))
            {
                MessageBox.Show("The appointment is successfully made ");
                ResultSchedule s = new ResultSchedule(Dstart,Dend,DoctorS,PriorityS);
                s.Show();
                this.Close();

            }
            else {
                MessageBox.Show("Error");


            }

        }
    }
}

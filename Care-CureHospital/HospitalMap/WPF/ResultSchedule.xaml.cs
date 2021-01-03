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
    /// Interaction logic for ResultSchedule.xaml
    /// </summary>
    public partial class ResultSchedule : Window ,INotifyPropertyChanged
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


        public WorkDayViewView SelectedRoom;

        private ObservableCollection<WorkDayViewView> _specs;
        public ObservableCollection<WorkDayViewView> SlobodniTerminiBind
        {
            get { return _specs; }
            set
            {
                _specs = value; OnPropertyChanged("SlobodniTerminiBind");

            }
        }

        public ResultSchedule()
        {
            InitializeComponent();
        }

        public ResultSchedule(DateTime DatumS,DateTime DatumE,DoctorView Dr,String priority1)
        {
            InitializeComponent();
            this.DataContext = this;
            String priority = priority1;
            Dstart = DatumS;
            Dend = DatumE;
            DoctorS = Dr;
            PriorityS = priority1;
            Dictionary<int, List<Appointment>> availableAppointments = Backend.App.Instance().DoctorWorkDayService.GetAvailableAppointmentsByDateRangeAndDoctorIdIncludingPriority(DatumS, DatumE, Int32.Parse(Dr.IdOfDoctor), priority);
            ObservableCollection<WorkDayView> SlobodniTermini = new ObservableCollection<WorkDayView>();
            SlobodniTermini = new ObservableCollection<WorkDayView>(WorkDayConverter.CreateDoctorWorkDayDtos(Backend.App.Instance().DoctorWorkDayService.GetDoctorWorkDaysByIds(availableAppointments.Keys.ToList()), availableAppointments));
            SlobodniTerminiBind = new ObservableCollection<WorkDayViewView>();
            foreach (WorkDayView w in SlobodniTermini) {
                foreach (Appointment a in w.AvailableAppointments) {
                    SlobodniTerminiBind.Add(new WorkDayViewView { Id = w.Id, DoctorId=w.DoctorId,RoomId=w.RoomId, IdOfRoom=w.IdOfRoom ,Specialization=w.Specialization,DoctorFullName=w.DoctorFullName,Date=w.Date,AvailableAppointment=a });
                
                
                }
            
            
            
            }
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedRoom = (WorkDayViewView)raspored.SelectedItem;

            if (SelectedRoom.IdOfRoom == null)
            {
                MessageBox.Show("Soba ne postoji na mapi");
                return;
            }
            if (SelectedRoom.IdOfRoom.Contains("A"))
            {
                GroundFloor f = new GroundFloor(SelectedRoom.IdOfRoom);
                f.Show();
            }
            else if (SelectedRoom.IdOfRoom.Contains("B"))
            {
                GroundFloor2 f = new GroundFloor2(SelectedRoom.IdOfRoom);
                f.Show();
            }
            else
            {
                FirstFloor f = new FirstFloor(SelectedRoom.IdOfRoom);
                f.Show();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SelectedRoom = (WorkDayViewView)raspored.SelectedItem;
            ScheduleForPatient s = new ScheduleForPatient(SelectedRoom,Dstart,Dend,DoctorS,PriorityS);
            s.Show();
            this.Close();
        }
    }
}

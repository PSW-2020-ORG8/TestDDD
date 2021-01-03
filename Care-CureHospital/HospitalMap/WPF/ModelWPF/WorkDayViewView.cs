using Model.Term;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HospitalMap.WPF.ModelWPF
{
    public class WorkDayViewView : INotifyPropertyChanged
    {

        private Appointment _ime;
        private string _doctorFullName;
        private string _specialization;
        private string _idOfRoom;
        private int _id;
        private int _doctorId;
        private int _roomId;
        private DateTime _date;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string IdOfRoom
        {
            get { return _idOfRoom; }
            set { _idOfRoom = value; OnPropertyChanged("AvailableAppointment"); }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("AvailableAppointment"); }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged("AvailableAppointment"); }
        }
        public int DoctorId
        {
            get { return _doctorId; }
            set { _doctorId = value; OnPropertyChanged("AvailableAppointment"); }
        }
        public int RoomId
        {
            get { return _roomId; }
            set { _roomId = value; OnPropertyChanged("AvailableAppointment"); }
        }
        public string Specialization
        {
            get { return _specialization; }
            set { _specialization = value; OnPropertyChanged("AvailableAppointment"); }
        }
        public string DoctorFullName
        {
            get { return _doctorFullName; }
            set { _doctorFullName = value; OnPropertyChanged("AvailableAppointment"); }
        }

        public Appointment AvailableAppointment
        {
            get { return _ime; }
            set { _ime = value; OnPropertyChanged("AvailableAppointment"); }
        }

    }
}

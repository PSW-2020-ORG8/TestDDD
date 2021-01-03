using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HospitalMap.WPF.ModelWPF
{
    public class MedicalTerm : INotifyPropertyChanged
    {


        private DateTime workDay;
        private string _startTime;
        private string _endTime;
        public MedicalTerm()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public DateTime WorkDay
        {
            get { return workDay; }
            set { workDay = value; OnPropertyChanged("WorkDay"); }
        }



        public string StartTime
        {
            get { return _startTime; }
            set { _startTime = value; OnPropertyChanged("StartTime"); }
        }


        public string EndTime
        {
            get { return _endTime; }
            set { _endTime = value; OnPropertyChanged("EndTime"); }
        }


    }
}

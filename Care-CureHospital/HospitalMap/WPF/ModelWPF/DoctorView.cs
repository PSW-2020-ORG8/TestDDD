using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HospitalMap.WPF.ModelWPF
{
   public class DoctorView : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private string _nameOfDoctor;
        private string _surnameOfDoctor;
        private string _idOfDoctor;

        public DoctorView()
        {
        }

        public string NameOfDoctor
        {
            get
            {
                return _nameOfDoctor;
            }
            set
            {
                if (value != _nameOfDoctor)
                {
                    _nameOfDoctor = value;
                    OnPropertyChanged("NameOfDoctor");
                }
            }
        }




        public string SurnameOfDoctor
        {
            get
            {
                return _surnameOfDoctor; ;
            }
            set
            {
                if (value != _surnameOfDoctor)
                {
                    _surnameOfDoctor = value;
                    OnPropertyChanged("SurnameOfDoctor");
                }
            }
        }

      



        public string IdOfDoctor
        {
            get
            {
                return _idOfDoctor; ;
            }
            set
            {
                if (value != _idOfDoctor)
                {
                    _idOfDoctor = value;
                    OnPropertyChanged("IdOfDoctor");
                }
            }
        }


        public override string ToString()
        {

            return NameOfDoctor+' '+SurnameOfDoctor;

        }

    }
}

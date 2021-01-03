using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HospitalMap.WPF.ModelWPF
{
    public class PatientView : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private string _nameOfPatient;
        private string _surnameOfPatient;
        private int _idOfPatient;
        private string _jmbgOfPatient;

        public PatientView()
        {
        }

        public string NameOfPatient
        {
            get
            {
                return _nameOfPatient;
            }
            set
            {
                if (value != _nameOfPatient)
                {
                    _nameOfPatient = value;
                    OnPropertyChanged("NameOfPatient");
                }
            }
        }




        public string SurnameOfPatient
        {
            get
            {
                return _surnameOfPatient; ;
            }
            set
            {
                if (value != _surnameOfPatient)
                {
                    _surnameOfPatient = value;
                    OnPropertyChanged("SurnameOfPatient");
                }
            }
        }





        public int IdOfPatient
        {
            get
            {
                return _idOfPatient; ;
            }
            set
            {
                if (value != _idOfPatient)
                {
                    _idOfPatient = value;
                    OnPropertyChanged("IdOfDoctor");
                }
            }
        }


        public string JmbgOfPatient
        {
            get
            {
                return _jmbgOfPatient; ;
            }
            set
            {
                if (value != _jmbgOfPatient)
                {
                    _jmbgOfPatient = value;
                    OnPropertyChanged("JmbgOfDoctor");
                }
            }
        }



        public override string ToString()
        {

            return NameOfPatient + ' ' + SurnameOfPatient+' '+JmbgOfPatient;

        }
    
    }
}

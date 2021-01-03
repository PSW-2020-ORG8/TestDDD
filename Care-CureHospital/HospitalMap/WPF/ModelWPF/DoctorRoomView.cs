using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace HospitalMap.WPF.ModelWPF
{
    public class DoctorRoomView : INotifyPropertyChanged
    {

        public DoctorRoomView() { }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }





        private ObservableCollection<MedicalTerm> _medicalTerms;
        public ObservableCollection<MedicalTerm> MedicalTerms
        {
            get { return _medicalTerms; }
            set { _medicalTerms = value; OnPropertyChanged("MedicalTerms"); }

        }


        private int _idOfRoomInMySQLDataBase;
        private string _idOfRoom;
        private int _typeOfRoomId;
        private string _nameOfRoom;
        private string _nameOfClinic;
        private string _numberOfFloor;
        private string _nameOfDoctor;
        private string _surnameOfDoctor;
        private string _jmbgOfDoctor;
        private string _fromDateTime;
        private string _toDateTime;


        public int IdOfRoomInMySQLDataBase
        {
            get
            {
                return _idOfRoomInMySQLDataBase;
            }
            set
            {
                if (value != _idOfRoomInMySQLDataBase)
                {
                    _idOfRoomInMySQLDataBase = value;
                    OnPropertyChanged("IdOfRoomInMySQLDataBase");
                }
            }
        }



        public int TypeOfRoomId
        {
            get
            {
                return _typeOfRoomId;
            }
            set
            {
                if (value != _typeOfRoomId)
                {
                    _typeOfRoomId = value;
                    OnPropertyChanged("TypeOfRoomId");
                }
            }
        }


        public string NameOfClinic
        {
            get
            {
                return _nameOfClinic;
            }
            set
            {
                if (value != _nameOfClinic)
                {
                    _nameOfClinic = value;
                    OnPropertyChanged("NameOfClinic");
                }
            }
        }






        public string NumberOfFloor
        {
            get
            {
                return _numberOfFloor;
            }
            set
            {
                if (value != _numberOfFloor)
                {
                    _numberOfFloor = value;
                    OnPropertyChanged("NumberOfFloor");
                }
            }
        }







        public string IdOfRoom
        {
            get
            {
                return _idOfRoom;
            }
            set
            {
                if (value != _idOfRoom)
                {
                    _idOfRoom = value;
                    OnPropertyChanged("IdOfRoom");
                }
            }
        }



        public string NameOfRoom
        {
            get
            {
                return _nameOfRoom;
            }
            set
            {
                if (value != _nameOfRoom)
                {
                    _nameOfRoom = value;
                    OnPropertyChanged("NameOfRoom");
                }
            }
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





        public string JmbgOfDoctor
        {
            get
            {
                return _jmbgOfDoctor; ;
            }
            set
            {
                if (value != _jmbgOfDoctor)
                {
                    _jmbgOfDoctor = value;
                    OnPropertyChanged("JmbgOfDoctor");
                }
            }
        }




        public string FromDateTime
        {
            get
            {
                return _fromDateTime;
            }
            set
            {
                if (value != _fromDateTime)
                {
                    _fromDateTime = value;
                    OnPropertyChanged("FromDateTime");
                }
            }
        }





        public string ToDateTime
        {
            get
            {
                return _toDateTime;
            }
            set
            {
                if (value != _toDateTime)
                {
                    _toDateTime = value;
                    OnPropertyChanged("ToDateTime");
                }
            }
        }





    }
}

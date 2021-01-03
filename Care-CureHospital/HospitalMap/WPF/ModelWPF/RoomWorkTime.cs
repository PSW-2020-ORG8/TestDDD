using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HospitalMap.WPF.ModelWPF
{
    public class RoomWorkTime : INotifyPropertyChanged
    {





        public RoomWorkTime() { }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private int _idOfRoomInMySQLDataBase;
        private int _typeOfRoomId;
        private string _nameOfClinic;
        private string _numberOfFloor;
        private string _nameOfRoom;
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




        private string _idOfRoom;

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

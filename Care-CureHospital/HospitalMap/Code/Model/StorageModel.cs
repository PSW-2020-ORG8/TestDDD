using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HospitalMap.Code.Model
{
    public class StorageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private string _idS;

        public string IdS
        {
            get
            {
                return _idS;
            }
            set
            {
                if (value != _idS)
                {
                    _idS = value;
                    OnPropertyChanged("IdS");
                }
            }
        }










        private string _id;

        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }


        private string _quantity;

        public string Quantity
        {
            get
            {
                return _quantity; ;
            }
            set
            {
                if (value != _quantity)
                {
                    _quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }

        private string _location;
        public string Location
        {
            get
            {
                return _location; ;
            }
            set
            {
                if (value != _location)
                {
                    _location = value;
                    OnPropertyChanged("Location");
                }
            }
        }





    }
}

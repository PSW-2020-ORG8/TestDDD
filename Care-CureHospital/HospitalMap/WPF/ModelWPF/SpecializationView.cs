using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HospitalMap.WPF.ModelWPF
{
    public class SpecializationView: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    
        public int Id { get; set; }
        public string SpecialitationForDoctor { get; set; }

        public SpecializationView() { }

        public override string ToString()
        {
            
                return SpecialitationForDoctor;

        }
    }
}

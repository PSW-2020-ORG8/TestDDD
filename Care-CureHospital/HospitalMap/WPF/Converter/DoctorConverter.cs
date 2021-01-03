using HospitalMap.WPF.ModelWPF;
using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMap.WPF.Converter
{
    public class DoctorConverter : AbstractConverter
    {

        public static DoctorView ConvertDoctorToDoctorView(Doctor doctor)
        {
            return new DoctorView
            {
                NameOfDoctor = doctor.Name,
                SurnameOfDoctor=doctor.Surname,
                IdOfDoctor=doctor.Id.ToString()

            };
        }

        public static IList<DoctorView> ConvertDoctorToDoctorViewList(IList<Doctor> doctors)
            => ConvertEntityListToViewList(doctors, ConvertDoctorToDoctorView);
    }
}

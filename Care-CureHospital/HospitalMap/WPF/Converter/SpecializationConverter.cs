using HospitalMap.WPF.ModelWPF;
using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMap.WPF.Converter
{
    class SpecializationConverter
    {
        public static Specialitation SpecializationDtoToSpecialization(SpecializationView dto)
        {
            Specialitation specialization = new Specialitation();
            specialization.Id = dto.Id;
            specialization.SpecialitationForDoctor = dto.SpecialitationForDoctor;
            return specialization;
        }

        public static SpecializationView SpecializationToSpecializationDto(Specialitation specialization)
        {
            SpecializationView dto = new SpecializationView();
            dto.Id = specialization.Id;
            dto.SpecialitationForDoctor = specialization.SpecialitationForDoctor;
            return dto;
        }
    }
}

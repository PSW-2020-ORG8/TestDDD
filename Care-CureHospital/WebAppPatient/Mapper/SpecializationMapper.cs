using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPatient.Dto;

namespace WebAppPatient.Mapper
{
    public class SpecializationMapper
    {
        public static Specialitation SpecializationDtoToSpecialization(SpecializationDto dto)
        {
            Specialitation specialization = new Specialitation();
            specialization.Id = dto.Id;
            specialization.SpecialitationForDoctor = dto.SpecialitationForDoctor;
            return specialization;
        }

        public static SpecializationDto SpecializationToSpecializationDto(Specialitation specialization)
        {
            SpecializationDto dto = new SpecializationDto();
            dto.Id = specialization.Id;
            dto.SpecialitationForDoctor = specialization.SpecialitationForDoctor;
            return dto;
        }
    }
}

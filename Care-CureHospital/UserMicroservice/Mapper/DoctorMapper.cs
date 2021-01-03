using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Dto;

namespace UserMicroservice.Mapper
{
    public class DoctorMapper
    {
        public static Doctor DoctorDtoToDoctor(DoctorDto dto)
        {
            Doctor doctor = new Doctor();
            doctor.Id = dto.Id;
            doctor.Name = dto.Name;
            doctor.Surname = dto.Surname;
            return doctor;
        }

        public static DoctorDto DoctorToDoctorDto(Doctor doctor)
        {
            DoctorDto dto = new DoctorDto();
            dto.Id = doctor.Id;
            dto.Name = doctor.Name;
            dto.Surname = doctor.Surname;
            return dto;
        }
    }
}

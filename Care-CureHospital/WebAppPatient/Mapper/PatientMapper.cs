using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPatient.Dto;

namespace WebAppPatient.Mapper
{
    public class PatientMapper
    {
        public static Patient PatientDtoToPatient(PatientDto dto)
        {
            Patient patient = new Patient();
            patient.Id = dto.Id;
            patient.Username = dto.Username;
            patient.Name = dto.Name;
            patient.Surname = dto.Surname;
            patient.Malicious = dto.Malicious;
            patient.Blocked = dto.Blocked;
            return patient;
        }

        public static PatientDto PatientToPatientDto(Patient patient, int numberOfCancelledAppointments)
        {
            PatientDto dto = new PatientDto();
            dto.Id = patient.Id;
            dto.Username = patient.Username;
            dto.Name = patient.Name;
            dto.Surname = patient.Surname;
            dto.NumberOfCancelledAppointents = numberOfCancelledAppointments;
            dto.Malicious = patient.Malicious;
            dto.Blocked = patient.Blocked;
            return dto;
        }
    }
}

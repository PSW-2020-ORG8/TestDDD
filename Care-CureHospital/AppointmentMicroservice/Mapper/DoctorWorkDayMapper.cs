using AppointmentMicroservice.Dto;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroservice.Mapper
{
    public class DoctorWorkDayMapper
    {
        public static DoctorWorkDayDto DoctorWorkDayToDoctorWorkDayDto(DoctorWorkDay doctorWorkDay, List<Appointment> availableAppointments)
        {
            DoctorWorkDayDto dto = null;

            if (doctorWorkDay != null)
            {
                dto = new DoctorWorkDayDto();

                dto.Id = doctorWorkDay.Id;
                dto.DoctorId = doctorWorkDay.DoctorId;
                dto.RoomId = doctorWorkDay.RoomId;
                dto.AvailableAppointments = availableAppointments;
                dto.Specialization = doctorWorkDay.Doctor.Specialitation.SpecialitationForDoctor;
                dto.DoctorFullName = "Dr " + doctorWorkDay.Doctor.Name + " " + doctorWorkDay.Doctor.Surname;
            }

            return dto;
        }

        public static List<DoctorWorkDayDto> CreateDoctorWorkDayDtos(List<DoctorWorkDay> doctorWorkDays, Dictionary<int, List<Appointment>> availableAppointments)
        {
            List<DoctorWorkDayDto> result = new List<DoctorWorkDayDto>();
            foreach (DoctorWorkDay doctorWorkDay in doctorWorkDays)
            {
                result.Add(DoctorWorkDayToDoctorWorkDayDto(doctorWorkDay, availableAppointments[doctorWorkDay.Id]));
            }
            return result;
        }
    }
}

using HospitalMap.WPF.ModelWPF;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMap.WPF.Converter
{
    class WorkDayConverter
    {
        public static WorkDayView DoctorWorkDayToDoctorWorkDayDto(DoctorWorkDay doctorWorkDay, List<Appointment> availableAppointments)
        {
            WorkDayView dto = null;

            if (doctorWorkDay != null)
            {
                dto = new WorkDayView();

                dto.IdOfRoom = doctorWorkDay.Room.IdRoomClinic;
                dto.Id = doctorWorkDay.Id;
                dto.DoctorId = doctorWorkDay.DoctorId;
                dto.RoomId = doctorWorkDay.RoomId;
                dto.AvailableAppointments = availableAppointments;
                dto.Specialization = doctorWorkDay.Doctor.Specialitation.SpecialitationForDoctor;
                dto.DoctorFullName = "Dr " + doctorWorkDay.Doctor.Name + " " + doctorWorkDay.Doctor.Surname;
            }

            return dto;
        }

        public static List<WorkDayView> CreateDoctorWorkDayDtos(List<DoctorWorkDay> doctorWorkDays, Dictionary<int, List<Appointment>> availableAppointments)
        {
            List<WorkDayView> result = new List<WorkDayView>();
            foreach (DoctorWorkDay doctorWorkDay in doctorWorkDays)
            {
                result.Add(DoctorWorkDayToDoctorWorkDayDto(doctorWorkDay, availableAppointments[doctorWorkDay.Id]));
            }
            return result;
        }
    }
}

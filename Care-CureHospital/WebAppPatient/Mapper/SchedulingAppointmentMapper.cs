using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPatient.Dto;

namespace WebAppPatient.Mapper
{
    public class SchedulingAppointmentMapper
    {
        public static Appointment AppointmentDtoToAppointment(SchedulingAppointmentDto dto)
        {
            Appointment appointment = new Appointment();

            appointment.Canceled = dto.Canceled;
            appointment.DoctorWorkDayId = dto.DoctorWorkDayId;
            appointment.StartTime = dto.StartTime;
            appointment.EndTime = dto.EndTime;
            appointment.MedicalExamination = dto.MedicalExamination;
            appointment.MedicalExamination.PatientId = 1;

            return appointment;
        }

    }
}

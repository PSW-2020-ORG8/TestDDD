using HospitalMap.WPF.ModelWPF;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMap.WPF.Converter
{
    class ScheduleAppoitmentConverter
    {
        public static Appointment AppointmentDtoToAppointment(ScheduleAppointmentView dto, PatientView patient)
        {
            Appointment appointment = new Appointment();
           
            appointment.Canceled = dto.Canceled;
            appointment.DoctorWorkDayId = dto.DoctorWorkDayId;
            appointment.StartTime = dto.StartTime;
            appointment.EndTime = dto.EndTime;
            appointment.MedicalExamination = dto.MedicalExamination;
            appointment.MedicalExamination.PatientId = patient.IdOfPatient;

            return appointment;
        }
    }
}

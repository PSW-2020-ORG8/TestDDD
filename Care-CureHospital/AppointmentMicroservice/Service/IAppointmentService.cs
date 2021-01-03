using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroservice.Service
{
    public interface IAppointmentService : IService<Appointment, int>
    {
        public List<Appointment> GetAllCancelledAppointmentsByPatient(int patientId);
        public List<Appointment> GetPreviousAppointmetsByPatient(int patientId, DateTime currentDate);
        public List<Appointment> GetScheduledAppointmetsByPatient(int patientId, DateTime currentDate);
        public List<Appointment> GetAllAppointmentsByPatient(int patientId);
        public Appointment CancelPatientAppointment(int appointmentId, DateTime today);
        public void SetIfPatientMalicious(int patientId, DateTime today);
        public int CountCancelledAppointmentsForPatient(int patientId, DateTime currentCancellationDate);
        public Appointment FilledSurveyForAppointment(int appointmentId);
    }
}

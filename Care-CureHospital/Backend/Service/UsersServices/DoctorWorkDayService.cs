using Backend.Repository.UsersRepository;
using Model.AllActors;
using Model.Term;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.UsersServices
{
    public class DoctorWorkDayService : IService<DoctorWorkDay, int>
    {
        IDoctorWorkDayRepository doctorWorkDayRepository;
        DoctorService doctorService;

        public DoctorWorkDayService(IDoctorWorkDayRepository doctorWorkDayRepository, DoctorService doctorService)
        {
            this.doctorWorkDayRepository = doctorWorkDayRepository;
            this.doctorService = doctorService;
        }
        public DoctorWorkDay AddEntity(DoctorWorkDay entity)
        {
            return doctorWorkDayRepository.AddEntity(entity);
        }

        public void DeleteEntity(DoctorWorkDay entity)
        {
            doctorWorkDayRepository.DeleteEntity(entity);
        }

        public IEnumerable<DoctorWorkDay> GetAllEntities()
        {
            return doctorWorkDayRepository.GetAllEntities();
        }

        public DoctorWorkDay GetEntity(int id)
        {
            return doctorWorkDayRepository.GetEntity(id);
        }

        public void UpdateEntity(DoctorWorkDay entity)
        {
            doctorWorkDayRepository.UpdateEntity(entity);
        }

        public DoctorWorkDay GetDoctorWorkDayByDateAndDoctorId(DateTime date, int doctorId)
        {
            return doctorWorkDayRepository.GetAllEntities().FirstOrDefault(doctorWorkDay => DateTime.Compare(doctorWorkDay.Date, date) == 0 && doctorWorkDay.DoctorId == doctorId);
        }

        public List<DoctorWorkDay> GetDoctorWorkDayByDateAndDoctorSpecialization(DateTime date, int doctorSpecializationId)
        {
            List<DoctorWorkDay> doctorWorkDaysByDate = doctorWorkDayRepository.GetAllEntities().Where(doctorWorkDay => DateTime.Compare(doctorWorkDay.Date, date) == 0).ToList();
            List<Doctor> doctors = doctorService.GetAllEntities().Where(doctor => doctor.SpecialitationId == doctorSpecializationId).ToList();
            return doctorWorkDaysByDate.Where(x => doctors.Any(y => y.Id == x.DoctorId)).ToList();
        }

        public List<Appointment> GetAvailableAppointmentsByDateAndDoctorId(DateTime date, int doctorId)
        {
            List<Appointment> result = new List<Appointment>();
            if(GetDoctorWorkDayByDateAndDoctorId(date, doctorId) != null) 
            {
                result = InitializeAvailableApoointmentsList(date);
                foreach (Appointment scheduledAppointment in GetDoctorWorkDayByDateAndDoctorId(date, doctorId).ScheduledAppointments)
                {
                    var appointment = result.Find(o => DateTime.Compare(o.StartTime, scheduledAppointment.StartTime) == 0);
                    if (appointment != null && scheduledAppointment.Canceled == false)
                    {
                        result.Remove(appointment);
                    }
                }
            }
            return result;
        }

        public Dictionary<int, List<Appointment>> GetAvailableAppointmentsByDateAndSpecialization(DateTime date, int doctorSpecializationId)
        {
            Dictionary<int, List<Appointment>> result = new Dictionary<int, List<Appointment>>();
            if (GetDoctorWorkDayByDateAndDoctorSpecialization(date, doctorSpecializationId).Count != 0)
            {
                foreach(DoctorWorkDay doctorWorkDay in GetDoctorWorkDayByDateAndDoctorSpecialization(date, doctorSpecializationId))
                {
                    result.Add(doctorWorkDay.Id, GetAvailableAppointmentsByDateAndDoctorId(date, doctorWorkDay.DoctorId));
                }
            }
            return result;
        }

        /// <summary> This method generate all appointment terms in work day (from 8AM to 8PM) </summary>
        public List<Appointment> InitializeAvailableApoointmentsList(DateTime date)
        {
            DateTime startTime = new DateTime(date.Year, date.Month, date.Day, 8, 0, 0);
            List<Appointment> result = new List<Appointment>();
            for (int i = 0; i < 24; i++)
            {
                Appointment appointmentTimePeriod = new Appointment { StartTime = startTime.AddMinutes(30 * i), EndTime = startTime.AddMinutes(30 * (i + 1)), Canceled = false };
                result.Add(appointmentTimePeriod);
            }
            return result;
        }

        public Dictionary<int, List<Appointment>> GetAvailableAppointmentsByDateRangeAndDoctorId(DateTime startDate, DateTime endDate, int doctorId)
        {
            Dictionary<int, List<Appointment>> result = new Dictionary<int, List<Appointment>>();
            for (DateTime date = startDate; DateTime.Compare(date, endDate) <= 0; date = date.AddDays(1))
            {
                if (GetDoctorWorkDayByDateAndDoctorId(date, doctorId) != null)
                {
                    result.Add(GetDoctorWorkDayByDateAndDoctorId(date, doctorId).Id, GetAvailableAppointmentsByDateAndDoctorId(date, doctorId));
                }
            }
            return result;
        }

        public Dictionary<int, List<Appointment>> GetAvailableAppointmentsByDateRangeAndDoctorIdIncludingPriority(DateTime startDate, DateTime endDate, int doctorId, string priority)
        {
            Dictionary<int, List<Appointment>> result = GetAvailableAppointmentsByDateRangeAndDoctorId(startDate, endDate, doctorId);           
            if (priority.Equals("DateRange"))
            {      
                if (GetNumberOfAvailableAppointments(result) == 0)
                {
                    int doctorSpecializationId = doctorService.GetSpecializationIdByDoctorId(doctorId);
                    result = GetAvailableAppointmentsForOtherDoctors(startDate, endDate, doctorSpecializationId);
                }
            } else if (priority.Equals("Doctor"))
            {
                if (GetNumberOfAvailableAppointments(result) == 0)
                {
                    result = GetAvailableAppointmentsByExpandDateRange(startDate, endDate, doctorId);
                }
            }
            return result;
        }

        private Dictionary<int, List<Appointment>> GetAvailableAppointmentsForOtherDoctors(DateTime startDate, DateTime endDate, int doctorSpecializationId)
        {
            Dictionary<int, List<Appointment>> result = new Dictionary<int, List<Appointment>>();
            for (DateTime date = startDate; DateTime.Compare(date, endDate) <= 0; date = date.AddDays(1))
            {
                Dictionary<int, List<Appointment>> temp = GetAvailableAppointmentsByDateAndSpecialization(date, doctorSpecializationId);
                foreach (int workDayId in temp.Keys)
                {
                    if (!result.ContainsKey(workDayId))
                    {
                        result.Add(workDayId, temp[workDayId]);
                    }
                }
            }
            return result;
        }

        private Dictionary<int, List<Appointment>> GetAvailableAppointmentsByExpandDateRange(DateTime startDate, DateTime endDate, int doctorId)
        {
            Dictionary<int, List<Appointment>> result = ExpandeDateRange(startDate, endDate, doctorId);
            int numberOfExpandingIteration = 0;
            while (GetNumberOfAvailableAppointments(result) == 0)
            {
                if (++numberOfExpandingIteration > 6)
                {
                    break;
                }
                result = ExpandeDateRange(startDate, endDate, doctorId);
            }
            return result;
        }

        private Dictionary<int, List<Appointment>> ExpandeDateRange(DateTime startDate, DateTime endDate, int doctorId)
        {
            DateTime newStartDate = startDate.AddDays(-1);
            if (DateTime.Compare(newStartDate, DateTime.Today) < 0)
            {
                newStartDate = DateTime.Today;
            }
            return GetAvailableAppointmentsByDateRangeAndDoctorId(newStartDate, endDate.AddDays(1), doctorId);
        }

        public bool ScheduleAppointment(Appointment appointment)
        {
            DoctorWorkDay doctorWorkDay = GetEntity(appointment.DoctorWorkDayId);
            if (CheckIfAppointmentTimeIsAvailableForGivenWorkDay(doctorWorkDay, appointment))
            {
                doctorWorkDay.ScheduledAppointments.Add(appointment);
                UpdateEntity(doctorWorkDay);
                return true;
            }
            return false;
        }

        private bool CheckIfPatientAlreadyHasAppointmentForGivenWorkDay(DoctorWorkDay doctorWorkDay, Appointment appointment)
        {
            if(doctorWorkDay.ScheduledAppointments.Where(o => o.MedicalExamination.PatientId == appointment.MedicalExamination.PatientId).ToList().Count == 0)
            {
                return true;
            }
            return false;
        }

        private bool CheckIfAppointmentTimeIsAvailableForGivenWorkDay(DoctorWorkDay doctorWorkDay, Appointment appointment)
        {
            if (doctorWorkDay.ScheduledAppointments.Where(o => DateTime.Compare(o.StartTime, appointment.StartTime) == 0 && o.Canceled == false).ToList().Count == 0)
            {
                return true;
            }
            return false;
        }

        public List<DoctorWorkDay> GetDoctorWorkDaysByIds(List<int> ids)
        {
            return GetAllEntities().Where(doctorWorkDay => ids.Contains(doctorWorkDay.Id)).ToList();
        }

        public int GetNumberOfAvailableAppointments(Dictionary<int, List<Appointment>> appointments)
        {
            int numberOfAvailableAppointments = 0;
            foreach (int key in appointments.Keys)
            {
                numberOfAvailableAppointments += appointments[key].Count;
            }
            return numberOfAvailableAppointments;
        }

        public void CancelPatientAppointment(int doctorWorkDayId, int appointmentId, DateTime today)
        {
            DoctorWorkDay doctorWorkDay = GetEntity(doctorWorkDayId);
            foreach(Appointment appointmentForCancelation in doctorWorkDay.ScheduledAppointments)
            {
                if(appointmentForCancelation.Id == appointmentId)
                {
                    if (today < appointmentForCancelation.StartTime.AddHours(-48))
                    {
                        appointmentForCancelation.Canceled = true;
                        appointmentForCancelation.CancellationDate = today;
                        UpdateEntity(doctorWorkDay);
                        return;
                    }
                }
            }        
        }
    }
}

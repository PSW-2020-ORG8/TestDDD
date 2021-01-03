using AppointmentMicroservice.Repository;
using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroservice.Service
{
    public class PatientService : IPatientService
    {
        public IPatientRepository patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public Patient BlockMaliciousPatient(int patientId)
        {
            Patient maliciousPatient = GetEntity(patientId);
            maliciousPatient.Blocked = true;
            UpdateEntity(maliciousPatient);
            return maliciousPatient;
        }

        public Patient AddEntity(Patient entity)
        {
            return patientRepository.AddEntity(entity);
        }

        public void DeleteEntity(Patient entity)
        {
            patientRepository.DeleteEntity(entity);
        }

        public IEnumerable<Patient> GetAllEntities()
        {
            return patientRepository.GetAllEntities();
        }

        public Patient GetEntity(int id)
        {
            return patientRepository.GetEntity(id);
        }

        public void UpdateEntity(Patient entity)
        {
            patientRepository.UpdateEntity(entity);
        }
    }
}

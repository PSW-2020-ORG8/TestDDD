using DocumentsMicroservice.Repository;
using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Service
{
    public class PatientService : IPatientService
    {
        public IPatientRepository patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
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

        public bool DoesUsernameExist(string username)
        {
            foreach (Patient patient in GetAllEntities())
            {
                if (patient.Username.Equals(username))
                {
                    return true;
                }
            }              
            return false;
        }
    }
}

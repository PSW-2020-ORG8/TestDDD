using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Service
{
    public interface IPatientService : IService<Patient, int>
    {
        public Patient BlockMaliciousPatient(int patientId);
        public List<Patient> GetMaliciousPatients();
        public Patient GetUserByUsername(string username);
        public bool DoesUsernameExist(string username);
    }
}

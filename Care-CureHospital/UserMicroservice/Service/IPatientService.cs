
using System.Collections.Generic;
using UserMicroservice.Domain;

namespace UserMicroservice.Service
{
    public interface IPatientService : IService<Patient, int>
    {
        public Patient BlockMaliciousPatient(int patientId);
        public List<Patient> GetMaliciousPatients();
        public Patient GetUserByUsername(string username);
        public bool DoesUsernameExist(string username);
    }
}

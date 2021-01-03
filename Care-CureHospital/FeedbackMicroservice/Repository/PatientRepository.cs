using FeedbackMicroservice.Repository.MySQL;
using FeedbackMicroservice.Repository.MySQL.Stream;
using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    public class PatientRepository : MySQLRepository<Patient, int>, IPatientRepository
    {

        public PatientRepository(IMySQLStream<Patient> stream)
         : base(stream)
        {
        }

        public Patient GetPatientByUsername(string username)
        {
            foreach (Patient patient in GetAllEntities())
            {
                if (patient.Username.Equals(username))
                    return patient;
            }
            return null;
        }

    }
}

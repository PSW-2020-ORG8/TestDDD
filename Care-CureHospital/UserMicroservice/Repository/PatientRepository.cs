using Model.AllActors;
using UserMicroservice.Repository.MySQL;
using UserMicroservice.Repository.MySQL.Stream;

namespace UserMicroservice.Repository
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

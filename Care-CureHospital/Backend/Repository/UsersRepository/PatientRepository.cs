using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.AllActors;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.UsersRepository
{
    public class PatientRepository : MySQLRepository<Patient, int>, IPatientRepository
    {

        public PatientRepository(IMySQLStream<Patient> stream, ISequencer<int> sequencer)
         : base(stream, sequencer)
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

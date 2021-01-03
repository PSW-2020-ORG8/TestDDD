using AppointmentMicroservice.Repository.MySQL;
using AppointmentMicroservice.Repository.MySQL.Stream;
using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroservice.Repository
{
    public class PatientRepository : MySQLRepository<Patient, int>, IPatientRepository
    {
        public PatientRepository(IMySQLStream<Patient> stream)
           : base(stream)
        {
        }
    }
}

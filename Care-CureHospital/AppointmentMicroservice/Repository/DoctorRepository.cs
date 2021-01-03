using AppointmentMicroservice.Repository.MySQL;
using AppointmentMicroservice.Repository.MySQL.Stream;
using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroservice.Repository
{
    public class DoctorRepository : MySQLRepository<Doctor, int>, IDoctorRepository
    {
        public DoctorRepository(IMySQLStream<Doctor> stream)
           : base(stream)
        {
        }
    }
}

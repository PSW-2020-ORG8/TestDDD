using AppointmentMicroservice.Repository.MySQL;
using AppointmentMicroservice.Repository.MySQL.Stream;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroservice.Repository
{
    public class DoctorWorkDayRepository : MySQLRepository<DoctorWorkDay, int>, IDoctorWorkDayRepository
    {
        public DoctorWorkDayRepository(IMySQLStream<DoctorWorkDay> stream)
            : base(stream)
        {
        }
    }
}


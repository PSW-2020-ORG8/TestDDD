using Backend.Model.PatientDoctor;
using DocumentsMicroservice.Repository.MySQL;
using DocumentsMicroservice.Repository.MySQL.Stream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Repository
{
    public class PrescriptionRepository : MySQLRepository<Prescription, int>, IPrescriptionRepository
    {
        public PrescriptionRepository(IMySQLStream<Prescription> stream)
            : base(stream)
        {
        }
    }
}

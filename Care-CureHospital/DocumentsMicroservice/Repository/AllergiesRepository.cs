using DocumentsMicroservice.Repository.MySQL;
using DocumentsMicroservice.Repository.MySQL.Stream;
using Model.PatientDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Repository
{
    public class AllergiesRepository : MySQLRepository<Allergies, int>, IAllergiesRepository
    {
        public AllergiesRepository(IMySQLStream<Allergies> stream)
            : base(stream)
        {
        }
    }
}

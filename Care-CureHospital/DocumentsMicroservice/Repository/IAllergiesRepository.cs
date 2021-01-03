using Model.PatientDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Repository
{
    public interface IAllergiesRepository : IRepository<Allergies, int>
    {
    }
}

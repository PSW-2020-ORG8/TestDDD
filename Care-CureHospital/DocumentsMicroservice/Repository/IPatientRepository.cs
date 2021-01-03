using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Repository
{
    public interface IPatientRepository : IRepository<Patient, int>
    {
    }
}

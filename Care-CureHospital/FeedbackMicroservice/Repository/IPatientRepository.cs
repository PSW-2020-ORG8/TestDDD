using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    public interface IPatientRepository : IRepository<Patient, int>
    {
        public Patient GetPatientByUsername(string username);
    }
}

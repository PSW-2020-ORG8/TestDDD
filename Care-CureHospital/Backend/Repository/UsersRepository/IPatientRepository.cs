using Model.AllActors;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.UsersRepository
{
    public interface IPatientRepository : IRepository<Patient, int>
    {
        public Patient GetPatientByUsername(string username);
    }
}

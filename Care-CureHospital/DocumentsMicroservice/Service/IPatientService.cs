using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Service
{
    public interface IPatientService : IService<Patient, int>
    {
        public bool DoesUsernameExist(string username);
    }
}

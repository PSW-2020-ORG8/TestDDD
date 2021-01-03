using Model.AllActors;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.UsersRepository
{
    public interface IDoctorRepository : IRepository<Doctor, int>
    {
    }
}

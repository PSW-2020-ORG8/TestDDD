using Model.AllActors;
using Model.Term;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.UsersRepository
{
    public interface IDoctorWorkDayRepository : IRepository<DoctorWorkDay, int>
    {
    }
}

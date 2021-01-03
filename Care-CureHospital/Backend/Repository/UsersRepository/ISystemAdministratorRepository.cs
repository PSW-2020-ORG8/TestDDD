using Model.AllActors;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.UsersRepository
{
    public interface ISystemAdministratorRepository : IRepository<SystemAdministrator, int>
    {
    }
}

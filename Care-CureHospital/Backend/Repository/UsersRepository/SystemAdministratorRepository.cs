using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.AllActors;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.UsersRepository
{
    public class SystemAdministratorRepository : MySQLRepository<SystemAdministrator, int>, ISystemAdministratorRepository
    {
        private static SystemAdministratorRepository instance;

        public static SystemAdministratorRepository Instance()
        {
            if (instance == null)
            {
                instance = new SystemAdministratorRepository(new MySQLStream<SystemAdministrator>(), new IntSequencer());
            }
            return instance;
        }

        public SystemAdministratorRepository(IMySQLStream<SystemAdministrator> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }
    }
}


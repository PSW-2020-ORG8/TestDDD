using UserMicroservice.Domain;
using UserMicroservice.Repository.MySQL;
using UserMicroservice.Repository.MySQL.Stream;

namespace UserMicroservice.Repository
{
    public class SystemAdministratorRepository : MySQLRepository<SystemAdministrator, int>, ISystemAdministratorRepository
    {
        public SystemAdministratorRepository(IMySQLStream<SystemAdministrator> stream)
            : base(stream)
        {
        }
    }
}

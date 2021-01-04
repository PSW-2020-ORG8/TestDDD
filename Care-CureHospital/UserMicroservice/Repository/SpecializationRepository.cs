using UserMicroservice.Domain;
using UserMicroservice.Repository.MySQL;
using UserMicroservice.Repository.MySQL.Stream;

namespace UserMicroservice.Repository
{
    public class SpecializationRepository : MySQLRepository<Specialitation, int>, ISpecializationRepository
    {
        public SpecializationRepository(IMySQLStream<Specialitation> stream)
         : base(stream)
        {
        }
    }
}

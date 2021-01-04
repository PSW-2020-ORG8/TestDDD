using UserMicroservice.Domain;
using UserMicroservice.Repository.MySQL;
using UserMicroservice.Repository.MySQL.Stream;

namespace UserMicroservice.Repository
{
    public class DoctorRepository : MySQLRepository<Doctor, int>, IDoctorRepository
    {
        public DoctorRepository(IMySQLStream<Doctor> stream)
            : base(stream)
        {
        }
    }
}

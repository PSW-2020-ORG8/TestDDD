using Model.Term;
using UserMicroservice.Repository.MySQL;
using UserMicroservice.Repository.MySQL.Stream;

namespace UserMicroservice.Repository
{
    public class AppointmentRepository : MySQLRepository<Appointment, int>, IAppointmentRepository
    {
        public AppointmentRepository(IMySQLStream<Appointment> stream)
            : base(stream)
        {
        }
    }
}

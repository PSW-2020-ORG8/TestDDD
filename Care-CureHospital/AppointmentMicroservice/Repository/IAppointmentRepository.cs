using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AppointmentMicroservice.Repository.IRepository;

namespace AppointmentMicroservice.Repository
{
    public interface IAppointmentRepository : IRepository<Appointment, int>
    {
    }
}

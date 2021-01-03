using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    public interface IAppointmentRepository : IRepository<Appointment, int>
    {
    }
}

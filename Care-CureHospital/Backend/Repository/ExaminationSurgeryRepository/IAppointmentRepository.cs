using Model.Term;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.ExaminationSurgeryRepository
{
    public interface IAppointmentRepository : IRepository<Appointment, int>
    {
    }
}

using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AppointmentMicroservice.Repository.IRepository;

namespace AppointmentMicroservice.Repository
{
    public interface IDoctorRepository : IRepository<Doctor, int>
    {
    }
}

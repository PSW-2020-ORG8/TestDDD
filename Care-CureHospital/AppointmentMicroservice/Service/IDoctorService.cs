using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroservice.Service
{
    interface IDoctorService : IService<Doctor, int>
    {
        public int GetSpecializationIdByDoctorId(int doctorId);
    }
}

using Backend.Model.PatientDoctor;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.DoctorRepository
{
    public interface IEPrescriptionRepository : IRepository<EPrescription, int>
    {
    }
}

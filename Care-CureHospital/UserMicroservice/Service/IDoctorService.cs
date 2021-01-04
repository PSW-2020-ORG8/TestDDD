using System.Collections.Generic;
using UserMicroservice.Domain;

namespace UserMicroservice.Service
{
    public interface IDoctorService : IService<Doctor, int>
    {
        public List<Doctor> GetAllDoctorsBySpecialization(int specializationId);
        public int GetSpecializationIdByDoctorId(int doctorId);
    }
}

using System.Collections.Generic;
using UserMicroservice.Domain;
using UserMicroservice.Repository;

namespace UserMicroservice.Service
{
    public class DoctorService : IDoctorService
    {
        IDoctorRepository doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public Doctor AddEntity(Doctor entity)
        {
            return doctorRepository.AddEntity(entity);
        }

        public void DeleteEntity(Doctor entity)
        {
            doctorRepository.DeleteEntity(entity);
        }

        public IEnumerable<Doctor> GetAllEntities()
        {
            return doctorRepository.GetAllEntities();
        }

        public Doctor GetEntity(int id)
        {
            return doctorRepository.GetEntity(id);
        }

        public void UpdateEntity(Doctor entity)
        {
            doctorRepository.UpdateEntity(entity);
        }

        public List<Doctor> GetAllDoctorsBySpecialization(int specializationId)
        {
            List<Doctor> doctorsBySpecialization = new List<Doctor>();
            foreach (Doctor doctor in GetAllEntities())
            {
                if (doctor.SpecialitationId == specializationId)
                {
                    doctorsBySpecialization.Add(doctor);
                }
            }
            return doctorsBySpecialization;
        }

        public int GetSpecializationIdByDoctorId(int doctorId)
        {
            return GetEntity(doctorId).SpecialitationId;
        }
    }
}

using AppointmentMicroservice.Repository;
using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroservice.Service
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

        public int GetSpecializationIdByDoctorId(int doctorId)
        {
            return GetEntity(doctorId).SpecialitationId;
        }
    }
}

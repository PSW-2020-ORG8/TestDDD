using DocumentsMicroservice.Repository;
using Model.PatientDoctor;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Service
{
    public class AllergiesService : IAllergiesService
    {
        public IAllergiesRepository allergiesRepository;

        public AllergiesService(IAllergiesRepository allergiesRepository)
        {
            this.allergiesRepository = allergiesRepository;
        }

        public Allergies GetEntity(int id)
        {
            return allergiesRepository.GetEntity(id);
        }

        public IEnumerable<Allergies> GetAllEntities()
        {
            return allergiesRepository.GetAllEntities();
        }

        public Allergies AddEntity(Allergies entity)
        {
            return allergiesRepository.AddEntity(entity);
        }

        public void UpdateEntity(Allergies entity)
        {
            allergiesRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Allergies entity)
        {
            allergiesRepository.DeleteEntity(entity);
        }
    }
}

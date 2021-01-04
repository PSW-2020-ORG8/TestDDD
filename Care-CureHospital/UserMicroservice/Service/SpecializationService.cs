using System.Collections.Generic;
using UserMicroservice.Domain;
using UserMicroservice.Repository;

namespace UserMicroservice.Service
{
    public class SpecializationService : ISpecializationService
    {
        public ISpecializationRepository specializationRepository;

        public SpecializationService(ISpecializationRepository specializationRepository)
        {
            this.specializationRepository = specializationRepository;
        }

        public Specialitation AddEntity(Specialitation entity)
        {
            return specializationRepository.AddEntity(entity);
        }

        public void DeleteEntity(Specialitation entity)
        {
            specializationRepository.DeleteEntity(entity);
        }

        public IEnumerable<Specialitation> GetAllEntities()
        {
            return specializationRepository.GetAllEntities();
        }

        public Specialitation GetEntity(int id)
        {
            return specializationRepository.GetEntity(id);
        }

        public void UpdateEntity(Specialitation entity)
        {
            specializationRepository.UpdateEntity(entity);
        }
    }
}

using Backend.Repository.UsersRepository;
using Model.AllActors;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.UsersServices
{
    public class SecretaryService : IService<Secretary, int>
    {
        ISecretaryRepository secretaryRepository;
        public SecretaryService(ISecretaryRepository secretaryRepository) {
            this.secretaryRepository = secretaryRepository;
        }
        public Secretary AddEntity(Secretary entity)
        {
            return secretaryRepository.AddEntity(entity);
        }

        public void DeleteEntity(Secretary entity)
        {
             secretaryRepository.DeleteEntity(entity);
        }

        public IEnumerable<Secretary> GetAllEntities()
        {
            return secretaryRepository.GetAllEntities();
        }

        public Secretary GetEntity(int id)
        {
            return secretaryRepository.GetEntity(id);
        }

        public void UpdateEntity(Secretary entity)
        {
            secretaryRepository.UpdateEntity(entity);
        }
    }
}

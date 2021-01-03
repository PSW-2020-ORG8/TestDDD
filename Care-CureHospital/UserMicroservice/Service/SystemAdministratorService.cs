using Model.AllActors;
using System.Collections.Generic;
using UserMicroservice.Repository;

namespace UserMicroservice.Service
{
    public class SystemAdministratorService : ISystemAdministratorService
    {
        ISystemAdministratorRepository systemAdministratorRepository;

        public SystemAdministratorService(ISystemAdministratorRepository systemAdministratorRepository)
        {
            this.systemAdministratorRepository = systemAdministratorRepository;
        }

        public SystemAdministrator AddEntity(SystemAdministrator entity)
        {
            return systemAdministratorRepository.AddEntity(entity);
        }

        public void DeleteEntity(SystemAdministrator entity)
        {
            systemAdministratorRepository.DeleteEntity(entity);
        }

        public IEnumerable<SystemAdministrator> GetAllEntities()
        {
            return systemAdministratorRepository.GetAllEntities();
        }

        public SystemAdministrator GetEntity(int id)
        {
            return systemAdministratorRepository.GetEntity(id);
        }

        public void UpdateEntity(SystemAdministrator entity)
        {
            systemAdministratorRepository.UpdateEntity(entity);
        }
    }
}

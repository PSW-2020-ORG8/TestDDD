using Backend.Repository.UsersRepository;
using Model.AllActors;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.UsersServices
{
    public class SystemAdministratorService : IService<SystemAdministrator, int>
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

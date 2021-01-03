using Backend.Repository.UsersRepository;
using Model.AllActors;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.UsersServices
{
    public class ManagerService : IService<Manager, int>
    {

        IManagerRepository managerRepository;

        public ManagerService(IManagerRepository managerRepository)
        {
            this.managerRepository = managerRepository;
        }
        public Manager AddEntity(Manager entity)
        {
            return managerRepository.AddEntity(entity);
        }

        public void DeleteEntity(Manager entity)
        {
            managerRepository.DeleteEntity(entity);
        }

        public IEnumerable<Manager> GetAllEntities()
        {
            return managerRepository.GetAllEntities();
        }

        public Manager GetEntity(int id)
        {
            return managerRepository.GetEntity(id);
        }

        public void UpdateEntity(Manager entity)
        {
            managerRepository.UpdateEntity(entity);
        }
    }
}

using Model.Manager;
using Repository.RoomsRepository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RoomsServices
{
    public class InventaryRoomService : IService<InventaryRoom, int>
    {
        public IInventaryRoomRepository inventaryRoomRepository;

        public InventaryRoomService(IInventaryRoomRepository inventaryRoomRepository)
        {
            this.inventaryRoomRepository = inventaryRoomRepository;
        }

        public InventaryRoom GetEntity(int id)
        {
            return inventaryRoomRepository.GetEntity(id);
        }

        public IEnumerable<InventaryRoom> GetAllEntities()
        {
            return inventaryRoomRepository.GetAllEntities();
        }

        public InventaryRoom AddEntity(InventaryRoom entity)
        {
            return inventaryRoomRepository.AddEntity(entity);
        }

        public void UpdateEntity(InventaryRoom entity)
        {
            inventaryRoomRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(InventaryRoom entity)
        {
            inventaryRoomRepository.DeleteEntity(entity);
        }

    }
}

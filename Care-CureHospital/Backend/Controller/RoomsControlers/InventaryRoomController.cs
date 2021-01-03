using Controller;
using Model.Manager;
using Service.RoomsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.RoomsControlers
{
    public class InventaryRoomController : IController<InventaryRoom, int>
    {
        public InventaryRoomService inventaryRoomService;

        public InventaryRoomController(InventaryRoomService inventaryRoomService)
        {
            this.inventaryRoomService = inventaryRoomService;
        }

        public InventaryRoom GetEntity(int id)
        {
            return inventaryRoomService.GetEntity(id);
        }

        public IEnumerable<InventaryRoom> GetAllEntities()
        {
            return inventaryRoomService.GetAllEntities();
        }

        public InventaryRoom AddEntity(InventaryRoom entity)
        {
            return inventaryRoomService.AddEntity(entity);
        }

        public void UpdateEntity(InventaryRoom entity)
        {
            inventaryRoomService.UpdateEntity(entity);
        }

        public void DeleteEntity(InventaryRoom entity)
        {
            inventaryRoomService.DeleteEntity(entity);
        }

    }
}

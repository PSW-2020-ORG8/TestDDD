using Model.Manager;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RoomsRepository
{
    public interface IInventaryRoomRepository : IRepository<InventaryRoom, int>
    {
    }
}

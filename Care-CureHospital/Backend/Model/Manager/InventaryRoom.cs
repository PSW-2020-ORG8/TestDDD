using HealthClinic.Repository;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Manager
{
    public class InventaryRoom : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public InventaryRoom() { }

        public InventaryRoom(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public InventaryRoom(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}

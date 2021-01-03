using Model.Manager;
using Repository.CSV.Converter;
using Repository.Csv;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;

namespace Repository.RoomsRepository
{
    public class InventaryRoomRepository : MySQLRepository<InventaryRoom, int>, IInventaryRoomRepository
    {
        private const string INVENTARY_FILE = "../../Resources/Data/inventaryRoom.csv";
        private static InventaryRoomRepository instance;

        public static InventaryRoomRepository Instance()
        {
            if (instance == null)
            {
                instance = new InventaryRoomRepository(new MySQLStream<InventaryRoom>(), new IntSequencer());
            }
            return instance;
        }

        public InventaryRoomRepository(IMySQLStream<InventaryRoom> stream, ISequencer<int> sequencer)
           : base(stream, sequencer)
        {
        }

    }
}

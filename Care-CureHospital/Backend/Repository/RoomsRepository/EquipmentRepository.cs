/***********************************************************************
 * Module:  UserRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.Manager;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;

namespace Repository.RoomsRepository
{
    public class EquipmentRepository : MySQLRepository<Equipment, int>, IEquipmentRepository
    {
        private const string EQUIPMENT_FILE = "../../Resources/Data/equipment.csv";
        private static EquipmentRepository instance;

        public static EquipmentRepository Instance()
        {
            if (instance == null)
            {
                instance = new EquipmentRepository(new MySQLStream<Equipment>(), new IntSequencer());
            }
            return instance;
        }

        public EquipmentRepository(IMySQLStream<Equipment> stream, ISequencer<int> sequencer)
           : base(stream, sequencer)
        {
        }

    }
}
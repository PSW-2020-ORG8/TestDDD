/***********************************************************************
 * Module:  UserRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.DoctorMenager;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;

namespace Repository.MedicamentRepository
{
    public class MedicamentRepository : MySQLRepository<Medicament, int>, IMedicamentRepository
    {
        private const string MEDICAMNET_FILE = "../../Resources/Data/medicaments.csv";
        private static MedicamentRepository instance;

        public static MedicamentRepository Instance()
        {
            if (instance == null)
            {
                instance = new MedicamentRepository(new MySQLStream<Medicament>(), new IntSequencer());
            }
            return instance;
        }

        public MedicamentRepository(IMySQLStream<Medicament> stream, ISequencer<int> sequencer)
           : base(stream, sequencer)
        {
        }

    }
}
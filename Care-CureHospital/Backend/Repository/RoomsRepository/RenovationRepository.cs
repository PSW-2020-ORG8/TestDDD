/***********************************************************************
 * Module:  RenovationRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.RenovationRepository
 ***********************************************************************/

using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.Term;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;

namespace Repository.RoomsRepository
{
    public class RenovationRepository : MySQLRepository<Renovation, int>, IRenovationRepository
    {
        private const string RENOVATION_FILE = "../../Resources/Data/renovation.csv";
        private static RenovationRepository instance;

        public static RenovationRepository Instance()
        {
            if (instance == null)
            {
                instance = new RenovationRepository(new MySQLStream<Renovation>(), new IntSequencer());
            }
            return instance;
        }

        public RenovationRepository(IMySQLStream<Renovation> stream, ISequencer<int> sequencer)
           : base(stream, sequencer)
        {
        }
    }
}
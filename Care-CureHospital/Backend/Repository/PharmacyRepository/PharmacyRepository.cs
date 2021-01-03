using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Pharmacy;
using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Repository.IDSequencer;

namespace Backend.Repository.PharmacyRepository
{
    public class PharmacyRepository : MySQLRepository<Pharmacies, int>, IPharmacyRepository
    {
        private static PharmacyRepository instance;

        public static PharmacyRepository Instance()
        {
            if (instance == null)
            {
                instance = new PharmacyRepository(new MySQLStream<Pharmacies>(), new IntSequencer());
            }
            return instance;
        } 
        public PharmacyRepository(IMySQLStream<Pharmacies> stream, ISequencer<int> sequencer) : base(stream, sequencer)
        {

        }

        
    }
}

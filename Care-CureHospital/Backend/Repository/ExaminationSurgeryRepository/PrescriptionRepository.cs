using Backend.Model.PatientDoctor;
using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.ExaminationSurgeryRepository
{
    public class PrescriptionRepository : MySQLRepository<Prescription, int>, IPrescriptionRepository
    {
        private static PrescriptionRepository instance;
        public static PrescriptionRepository Instance()
        {
            if (instance == null)
            {
                instance = new PrescriptionRepository(new MySQLStream<Prescription>(), new IntSequencer());
            }
            return instance;
        }

        public PrescriptionRepository(IMySQLStream<Prescription> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }
    }
}

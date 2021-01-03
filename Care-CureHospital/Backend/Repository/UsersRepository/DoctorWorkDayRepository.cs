using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.Term;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.UsersRepository
{
    public class DoctorWorkDayRepository : MySQLRepository<DoctorWorkDay, int>, IDoctorWorkDayRepository
    {
        private static DoctorWorkDayRepository instance;

        public static DoctorWorkDayRepository Instance()
        {
            if (instance == null)
            {
                instance = new DoctorWorkDayRepository(new MySQLStream<DoctorWorkDay>(), new IntSequencer());
            }
            return instance;
        }

        public DoctorWorkDayRepository(IMySQLStream<DoctorWorkDay> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }
    }
}

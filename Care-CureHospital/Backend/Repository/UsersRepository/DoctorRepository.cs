using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.AllActors;
using Model.Patient;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.UsersRepository
{
    public class DoctorRepository : MySQLRepository<Doctor, int>, IDoctorRepository
    {
        private static DoctorRepository instance;

        public static DoctorRepository Instance()
        {
            if (instance == null)
            {
                instance = new DoctorRepository(new MySQLStream<Doctor>(), new IntSequencer());
            }
            return instance;
        }

        public DoctorRepository(IMySQLStream<Doctor> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }
    }
}

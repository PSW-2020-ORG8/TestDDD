using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.Term;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.ExaminationSurgeryRepository
{
    public class AppointmentRepository : MySQLRepository<Appointment, int>, IAppointmentRepository
    {
        private static AppointmentRepository instance;

        public static AppointmentRepository Instance()
        {
            if (instance == null)
            {
                instance = new AppointmentRepository(new MySQLStream<Appointment>(), new IntSequencer());
            }
            return instance;
        }

        public AppointmentRepository(IMySQLStream<Appointment> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }
    }
}

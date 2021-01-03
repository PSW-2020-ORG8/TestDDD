using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.Patient;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.ExaminationSurgeryRepository
{
    public class AnswerRepository : MySQLRepository<Answer, int>, IAnswerRepository
    {

        private static AnswerRepository instance;

        public static AnswerRepository Instance()
        {
            if (instance == null)
            {
                instance = new AnswerRepository(new MySQLStream<Answer>(), new IntSequencer());
            }
            return instance;
        }

        public AnswerRepository(IMySQLStream<Answer> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }

    }
}

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
    class QuestionRepository : MySQLRepository<Question, int>, IQuestionRepository
    {
        private static QuestionRepository instance;

        public static QuestionRepository Instance()
        {
            if (instance == null)
            {
                instance = new QuestionRepository(new MySQLStream<Question>(), new IntSequencer());
            }
            return instance;
        }

        public QuestionRepository(IMySQLStream<Question> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }
    }
}

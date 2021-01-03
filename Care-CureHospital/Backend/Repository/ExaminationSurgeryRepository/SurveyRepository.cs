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
    public class SurveyRepository : MySQLRepository<Survey, int>, ISurveyRepository
    {
        private static SurveyRepository instance;

        public static SurveyRepository Instance()
        {
            if (instance == null)
            {
                instance = new SurveyRepository(new MySQLStream<Survey>(), new IntSequencer());
            }
            return instance;
        }

        public SurveyRepository(IMySQLStream<Survey> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }
    }
}

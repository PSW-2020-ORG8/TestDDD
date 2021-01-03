using FeedbackMicroservice.Repository.MySQL;
using FeedbackMicroservice.Repository.MySQL.Stream;
using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    public class SurveyRepository : MySQLRepository<Survey, int>, ISurveyRepository
    {
        public SurveyRepository(IMySQLStream<Survey> stream)
            : base(stream)
        {
        }
    }
}

using FeedbackMicroservice.Repository.MySQL;
using FeedbackMicroservice.Repository.MySQL.Stream;
using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    class QuestionRepository : MySQLRepository<Question, int>, IQuestionRepository
    {
        public QuestionRepository(IMySQLStream<Question> stream)
            : base(stream)
        {
        }
    }
}

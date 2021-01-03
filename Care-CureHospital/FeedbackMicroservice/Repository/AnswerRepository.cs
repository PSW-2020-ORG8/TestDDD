using FeedbackMicroservice.Repository.MySQL;
using FeedbackMicroservice.Repository.MySQL.Stream;
using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    public class AnswerRepository : MySQLRepository<Answer, int>, IAnswerRepository
    {
        public AnswerRepository(IMySQLStream<Answer> stream)
            : base(stream)
        {
        }

    }
}

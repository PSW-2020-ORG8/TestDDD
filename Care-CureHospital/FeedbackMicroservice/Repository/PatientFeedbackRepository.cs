using Backend.Model.BlogAndNotification;
using FeedbackMicroservice.Repository.MySQL;
using FeedbackMicroservice.Repository.MySQL.Stream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    public class PatientFeedbackRepository : MySQLRepository<PatientFeedback, int>, IPatientFeedbackRepository
    {

        public PatientFeedbackRepository(IMySQLStream<PatientFeedback> stream) :
            base(stream)
        {
        }
    }
}

using Backend.Model.BlogAndNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Service
{
    public interface IPatientFeedbackService : IService<PatientFeedback, int>
    {
        public IEnumerable<PatientFeedback> GetPublishedFeedbacks();
        public PatientFeedback PublishPatientFeedback(int id);
    }
}

using Backend.Model.BlogAndNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    public interface IPatientFeedbackRepository : IRepository<PatientFeedback, int>
    {
    }
}

using Backend.Model.BlogAndNotification;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Repository.BlogNotificationRepository
{
    public interface IPatientFeedbackRepository : IRepository<PatientFeedback, int>
    {
    }
}

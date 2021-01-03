using Backend.Model.BlogAndNotification;
using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Repository.BlogNotificationRepository
{
    public class PatientFeedbackRepository : MySQLRepository<PatientFeedback, int>, IPatientFeedbackRepository
    {
        
        public PatientFeedbackRepository(IMySQLStream<PatientFeedback> stream, ISequencer<int> sequencer) :
            base(stream, sequencer)
        {

        }
    }
}

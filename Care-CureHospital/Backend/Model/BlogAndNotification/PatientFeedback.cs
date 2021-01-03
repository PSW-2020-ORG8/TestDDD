using HealthClinic.Repository;
using Model.AllActors;
using Model.BlogAndNotification;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Backend.Model.BlogAndNotification
{
    public class PatientFeedback : Content, IIdentifiable<int>
    {
        public int Id { get; set; }
        public bool IsForPublishing { get; set; }
        public bool IsPublished { get; set; }
        public bool IsAnonymous { get; set; }
        public int PatientId { get; set; }
        
        public virtual Patient Patient { get; set; }
        
        public PatientFeedback()
        {
        }

        public PatientFeedback(int id, string text, DateTime publishingDate, bool isForPublishing, bool isPublished, bool isAnonymous, Patient patient)
            : base(text, publishingDate)
        {
            Id = id;
            IsForPublishing = isForPublishing;
            IsPublished = isPublished;
            IsAnonymous = isAnonymous;
            PatientId = patient.Id;
            Patient = patient;
        }

        public PatientFeedback(int id, string text, DateTime publishingDate, bool isForPublishing, bool isPublished, bool isAnonymous, int patientID)
            : base(text, publishingDate)
        {
            Id = id;
            IsForPublishing = isForPublishing;
            IsPublished = isPublished;
            IsAnonymous = isAnonymous;
            PatientId = patientID;
        }
        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}

using Backend.Model.BlogAndNotification;
using Backend.Repository.BlogNotificationRepository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Service.BlogNotificationServices
{
    public class PatientFeedbackService : IService<PatientFeedback, int>
    {
        public IPatientFeedbackRepository patientFeedbackRepository;
        public PatientFeedbackService(IPatientFeedbackRepository patientFeedbackRepository)
        {
            this.patientFeedbackRepository = patientFeedbackRepository;
        }

        /// <summary> This method calls <c>PatientFeedbackRepository</c> to post new <c>PatientFeedback</c>. </summary>
        public PatientFeedback AddEntity(PatientFeedback entity)
        {
            entity.PublishingDate = DateTime.Now;
            return patientFeedbackRepository.AddEntity(entity);
        }

        public void DeleteEntity(PatientFeedback entity)
        {
            patientFeedbackRepository.DeleteEntity(entity);
        }

        public IEnumerable<PatientFeedback> GetAllEntities()
        {
            return patientFeedbackRepository.GetAllEntities();
        }

        public PatientFeedback GetEntity(int id)
        {
            return patientFeedbackRepository.GetEntity(id);
        }

        public void UpdateEntity(PatientFeedback entity)
        {
            patientFeedbackRepository.UpdateEntity(entity);
        }

        /// <summary> This method calls <c>PatientFeedbackRepository</c> to get list of <c>PatientFeedback</c> where paramter <c>IsPublished</c> is true. </summary>
        public IEnumerable<PatientFeedback> GetPublishedFeedbacks()
        {
            return patientFeedbackRepository.GetAllEntities().Where(patientFeedback => patientFeedback.IsPublished.Equals(true));
        }

        /// <summary>This method calls <c>PatientFeedbackRepository</c> to change satus of <c>PatientFeedback</c> atribute <c>isPublished</c> on True></summary>
        public PatientFeedback PublishPatientFeedback(int id)
        {
            PatientFeedback patientFeedback = patientFeedbackRepository.GetEntity(id);
            patientFeedback.IsPublished = true;
            patientFeedbackRepository.UpdateEntity(patientFeedback);
            return patientFeedback;
        }
    }
}

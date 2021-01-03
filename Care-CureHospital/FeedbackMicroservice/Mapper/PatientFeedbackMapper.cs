using Backend.Model.BlogAndNotification;
using FeedbackMicroservice.Dto;
using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Mapper
{
    public class PatientFeedbackMapper
    {
        public static PatientFeedback PatientFeedbackDtoToPatientFeedback(PatientFeedbackDto dto, Patient patient)
        {
            PatientFeedback patientFeedback = new PatientFeedback();

            patientFeedback.IsForPublishing = dto.IsForPublishing;
            patientFeedback.IsPublished = dto.IsPublished;
            patientFeedback.IsAnonymous = dto.IsAnonymous;
            patientFeedback.PatientId = dto.PatientId;
            patientFeedback.Patient = null;
            patientFeedback.Text = dto.Text;

            return patientFeedback;
        }

        public static PatientFeedbackDto PatientFeedbackToPatientFeedbackDto(PatientFeedback patientFeedback)
        {
            PatientFeedbackDto dto = new PatientFeedbackDto();
            dto.Id = patientFeedback.Id;
            dto.IsForPublishing = patientFeedback.IsForPublishing;
            dto.IsPublished = patientFeedback.IsPublished;
            dto.IsAnonymous = patientFeedback.IsAnonymous;
            dto.PatientId = patientFeedback.PatientId;
            dto.Patient = patientFeedback.Patient.Name + " " + patientFeedback.Patient.Surname;
            dto.PublishingDate = patientFeedback.PublishingDate.ToString("dd.MM.yyyy. HH:mm");
            dto.Text = patientFeedback.Text;

            return dto;
        }
    }
}

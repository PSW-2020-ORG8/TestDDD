using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPatient.Dto;

namespace WebAppPatient.Mapper
{
    public class SurveyMapper
    {
        public static Survey SurveyDtoToSurvey(SurveyDto dto)
        {
            Survey survey = new Survey();

            survey.Title = dto.Title;
            survey.CommentSurvey = dto.CommentSurvey;
            survey.PublishingDate = DateTime.Now;
            survey.Answers = dto.Answers;
            survey.MedicalExaminationId = dto.MedicalExaminationID;
            return survey;
        }

        public static SurveyDto SurveyToSurveyDto(Survey survey)
        {
            SurveyDto dto = new SurveyDto();

            dto.Title = survey.Title;
            dto.CommentSurvey = survey.CommentSurvey;
            dto.PublishingDate = survey.PublishingDate;
            dto.Answers = new List<Answer>();
            foreach(Answer answer in survey.Answers)
            {
                dto.Answers.Add(new Answer(answer.QuestionId, answer.Grade));
            }

            return dto;
        }
    }
}

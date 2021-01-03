/***********************************************************************
 * Module:  Question.cs
 * Author:  Hacer
 * Purpose: Definition of the Class Patient.Question
 ***********************************************************************/

using HealthClinic.Repository;
using System;

namespace Model.Patient
{
    public class Answer : IIdentifiable<int>
    {
        public int Id { get; set; }
        public GradeOfQuestion Grade { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }

        public Answer(int id)
        {
            Id = id;
        }

        public Answer()
        {
        }


        public Answer(int id, GradeOfQuestion grade, int questionId, Question question, int surveyId, Survey survey) : this(id)
        {
            Grade = grade;
            QuestionId = questionId;
            Question = question;
            SurveyId = surveyId;
            Survey = survey;
        
        }

        public Answer(int questionId, GradeOfQuestion grade)
        {
            Grade = grade;
            QuestionId = questionId;
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

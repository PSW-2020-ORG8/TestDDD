using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Service
{
    public interface IAnswerService : IService<Answer, int>
    {
        public Dictionary<int, List<int>> GetAnswersByQuestion();
        public Dictionary<int, List<int>> GetAnswersForDoctorBySurveyIds(List<int> surveyIds);
    }
}

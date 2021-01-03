using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Service
{
    public interface ISurveyService : IService<Survey, int>
    {
        public Dictionary<int, List<int>> GetSurveyIdsForDoctorIds();
        public Dictionary<int, Dictionary<int, List<int>>> GetSurveyResultsForAllDoctors();
    }
}

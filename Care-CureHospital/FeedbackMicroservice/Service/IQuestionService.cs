using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Service
{
    public interface IQuestionService : IService<Question, int>
    {
        public List<int> GetDoctorTypeQuestionsIds();
    }
}

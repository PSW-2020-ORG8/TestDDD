using Backend.Repository.ExaminationSurgeryRepository;
using Model.Patient;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.ExaminationSurgeryServices
{
    public class QuestionService : IService<Question, int>
    {

        public IQuestionRepository questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public Question AddEntity(Question entity)
        {
            return questionRepository.AddEntity(entity);
        }

        public void DeleteEntity(Question entity)
        {
            questionRepository.DeleteEntity(entity);
        }

        public IEnumerable<Question> GetAllEntities()
        {
            return questionRepository.GetAllEntities();
        }

        public Question GetEntity(int id)
        {
            return questionRepository.GetEntity(id);
        }

        public void UpdateEntity(Question entity)
        {
            questionRepository.UpdateEntity(entity);
        }


        public List<int> GetDoctorTypeQuestionsIds()
        {
            return questionRepository.GetAllEntities().Where(q => q.QuestionType == QuestionType.Doctor).Select(q => q.Id).ToList();
        }
    }
}

using Backend.Repository.ExaminationSurgeryRepository;
using Model.Patient;
using Service;
using Service.ExaminationSurgeryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.ExaminationSurgeryServices
{
    public class SurveyService : IService<Survey, int>
    {
        public ISurveyRepository SurveyRepository;
        public MedicalExaminationService MedicalExaminationService;
        public AnswerService AnswerService;

        public SurveyService(ISurveyRepository surveyRepository, MedicalExaminationService medicalExaminationService, AnswerService answerService)
        {
            SurveyRepository = surveyRepository;
            MedicalExaminationService = medicalExaminationService;
            AnswerService = answerService;
        }

        public Survey GetEntity(int id)
        {
            return SurveyRepository.GetEntity(id);
        }

        public IEnumerable<Survey> GetAllEntities()
        {
            return SurveyRepository.GetAllEntities();
        }

        public Survey AddEntity(Survey entity)
        {
            return SurveyRepository.AddEntity(entity);
        }

        public void UpdateEntity(Survey entity)
        {
            SurveyRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Survey entity)
        {
            SurveyRepository.DeleteEntity(entity);
        }

        /// <summary> This method find which doctors are graded by surveys. </summary>
        /// <returns> Dictionary which keys represent doctor id and values represent lists of survey ids. </returns>
        public Dictionary<int, List<int>> GetSurveyIdsForDoctorIds()
        {
            Dictionary<int, List<int>> results = new Dictionary<int, List<int>>();
            foreach (Survey survey in GetAllEntities())
            {
                int doctorId = MedicalExaminationService.GetEntity(survey.MedicalExaminationId).DoctorId;
                if (!results.ContainsKey(doctorId))
                {
                    results.Add(doctorId, new List<int>());
                }
                results[doctorId].Add(survey.Id);
            }
            return results;
        }

        /// <summary> This method calculates survey statistics for all doctors. </summary>
        /// <returns> Dictionary which keys represent doctor id and values represent dictionaries with question results. </returns>
        public Dictionary<int, Dictionary<int, List<int>>> GetSurveyResultsForAllDoctors()
        {
            Dictionary<int, Dictionary<int, List<int>>> result = new Dictionary<int, Dictionary<int, List<int>>>();
            Dictionary<int, List<int>> surveyIdsForDoctorIds = GetSurveyIdsForDoctorIds();
            foreach (int doctorId in surveyIdsForDoctorIds.Keys)
            {
                result.Add(doctorId, AnswerService.GetAnswersForDoctorBySurveyIds(surveyIdsForDoctorIds[doctorId]));
            }
            return result;
        }
       
    }
}

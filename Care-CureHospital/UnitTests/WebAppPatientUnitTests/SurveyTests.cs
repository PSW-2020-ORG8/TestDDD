using Backend.Repository.ExaminationSurgeryRepository;
using Backend.Service.ExaminationSurgeryServices;
using Model.Patient;
using Model.Term;
using Moq;
using Repository.ExaminationSurgeryRepository;
using Service.ExaminationSurgeryServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.WebAppPatientUnitTests
{
    public class SurveyTests
    {
        [Fact]
        public void Post_survey()
        {
            SurveyService surveyService = new SurveyService(CreateSurveyStubRepository(), null, null);

            Survey survey = surveyService.AddEntity(new Survey(1, "Naslov ankete 1", new DateTime(2020, 11, 6, 8, 30, 0), "Komentar ankete 1", new List<Answer>()));

            Assert.NotNull(survey);
        }

        [Fact]
        public void Get_survey_ids_for_doctor_ids()
        {
            MedicalExaminationService medicalExaminationService = new MedicalExaminationService(CreateMedicalExaminationStubRepository());
            SurveyService surveyService = new SurveyService(CreateSurveyStubRepository(), medicalExaminationService, null);

            Dictionary<int, List<int>> results = surveyService.GetSurveyIdsForDoctorIds();

            Assert.Equal(2, results.Keys.Count);
        }



        private static ISurveyRepository CreateSurveyStubRepository()
        {
            var stubRepository = new Mock<ISurveyRepository>();

            var surveys = new List<Survey>();
            surveys.Add(new Survey(1, "Naslov ankete 1", "Komentar ankete 1", new DateTime(2020, 11, 6, 8, 30, 0), 1, null, new List<Answer>()));
            surveys.Add(new Survey(2, "Naslov ankete 2", "Komentar ankete 2", new DateTime(2020, 11, 9, 9, 30, 0), 2, null, new List<Answer>()));
            surveys.Add(new Survey(3, "Naslov ankete 3", "Komentar ankete 3", new DateTime(2020, 11, 11, 7, 30, 0), 3, null, new List<Answer>()));


            stubRepository.Setup(surveyRepository => surveyRepository.GetAllEntities()).Returns(surveys);
            stubRepository.Setup(survey => survey.AddEntity(It.IsAny<Survey>())).Returns(new Survey(1, "Naslov ankete 1", new DateTime(2020, 11, 6, 8, 30, 0), "Komentar ankete 1", new List<Answer>()));

            return stubRepository.Object;
        }

        private static IMedicalExaminationRepository CreateMedicalExaminationStubRepository()
        {
            var stubRepository = new Mock<IMedicalExaminationRepository>();

            var medicalExaminations = new List<MedicalExamination>();
            medicalExaminations.Add(new MedicalExamination() { Id = 1, DoctorId = 1 });
            medicalExaminations.Add(new MedicalExamination() { Id = 2, DoctorId = 1 });
            medicalExaminations.Add(new MedicalExamination() { Id = 3, DoctorId = 3 });

            stubRepository.Setup(medicalExaminationRepository => medicalExaminationRepository.GetAllEntities()).Returns(medicalExaminations);
            stubRepository.Setup(medicalExaminationRepository => medicalExaminationRepository.GetEntity(It.IsAny<int>())).Returns((int id) => medicalExaminations.Find(o => o.Id == (int)id));

            return stubRepository.Object;
        }


    }
}

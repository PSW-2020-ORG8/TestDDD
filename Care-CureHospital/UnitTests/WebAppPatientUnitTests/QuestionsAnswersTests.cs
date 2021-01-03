using Backend.Repository.ExaminationSurgeryRepository;
using Backend.Service.ExaminationSurgeryServices;
using Model.Patient;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.WebAppPatientUnitTests
{
    public class QuestionsAnswersTests
    {
        [Fact]
        public void Get_survey_results()
        {
            QuestionService questionService = new QuestionService(CreateQuestionStubRepository());
            AnswerService answerService = new AnswerService(CreateAnswerStubRepository(), questionService);

            Dictionary<int, List<int>> results = answerService.GetAnswersByQuestion();

            Assert.NotNull(results);
        }

        [Fact]
        public void Validate_survey_results()
        {
            QuestionService questionService = new QuestionService(CreateQuestionStubRepository());
            AnswerService answerService = new AnswerService(CreateAnswerStubRepository(), questionService);

            Dictionary<int, List<int>> results = answerService.GetAnswersByQuestion();

            Assert.Equal(3, results.Keys.Count);
        }

        [Fact]
        public void Get_doctor_type_questions_ids()
        {
            QuestionService questionService = new QuestionService(CreateQuestionStubRepository());

            List<int> results = questionService.GetDoctorTypeQuestionsIds();

            Assert.NotNull(results);
        }

        [Fact]
        public void Validate_doctor_type_questions_ids()
        {
            QuestionService questionService = new QuestionService(CreateQuestionStubRepository());

            List<int> results = questionService.GetDoctorTypeQuestionsIds();

            var expected = new List<int>() { 1, 2, 4 };

            Assert.Equal(expected, results);
        }

        [Fact]
        public void Get_answer_for_doctors_by_survey_ids()
        {
            QuestionService questionService = new QuestionService(CreateQuestionStubRepository());
            AnswerService answerService = new AnswerService(CreateAnswerStubRepository(), questionService);
            List<int> surveyIds = new List<int>() { 1, 3 };

            Dictionary<int, List<int>> results = answerService.GetAnswersForDoctorBySurveyIds(surveyIds);

            Assert.Equal(2, results.Keys.Count);
        }

        private static IAnswerRepository CreateAnswerStubRepository()
        {
            var stubRepository = new Mock<IAnswerRepository>();

            var answers = new List<Answer>();
            answers.Add(new Answer(1, GradeOfQuestion.Fair, 1, null, 1, null));
            answers.Add(new Answer(2, GradeOfQuestion.Poor, 2, null, 1, null));
            answers.Add(new Answer(3, GradeOfQuestion.Fair, 3, null, 1, null));
            answers.Add(new Answer(4, GradeOfQuestion.Fair, 1, null, 2, null));
            answers.Add(new Answer(5, GradeOfQuestion.Fair, 2, null, 2, null));
            answers.Add(new Answer(6, GradeOfQuestion.Fair, 3, null, 2, null));
            answers.Add(new Answer(7, GradeOfQuestion.Fair, 1, null, 3, null));
            answers.Add(new Answer(8, GradeOfQuestion.Fair, 2, null, 3, null));
            answers.Add(new Answer(9, GradeOfQuestion.Fair, 3, null, 3, null));

            stubRepository.Setup(answerRepository => answerRepository.GetAllEntities()).Returns(answers);
            return stubRepository.Object;
        }

        private static IQuestionRepository CreateQuestionStubRepository()
        {
            var stubRepository = new Mock<IQuestionRepository>();

            var questions = new List<Question>();
            questions.Add(new Question(1, "Pitanje1", QuestionType.Doctor));
            questions.Add(new Question(2, "Pitanje2", QuestionType.Doctor));
            questions.Add(new Question(3, "Pitanje3", QuestionType.Staff));
            questions.Add(new Question(4, "Pitanje4", QuestionType.Doctor));
            questions.Add(new Question(5, "Pitanje5", QuestionType.Staff));
            questions.Add(new Question(6, "Pitanje6", QuestionType.Hospital));

            stubRepository.Setup(questionRepository => questionRepository.GetAllEntities()).Returns(questions);
            return stubRepository.Object;
        }
    }
}

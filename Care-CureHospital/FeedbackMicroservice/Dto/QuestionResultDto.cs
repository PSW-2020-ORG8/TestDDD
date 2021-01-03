using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Dto
{
    public class QuestionResultDto
    {
        public int QuestionId { get; set; }

        public List<int> Grades { get; set; }

        public double AverageGrade { get; set; }

        public QuestionResultDto() { }

        public QuestionResultDto(int questionId, List<int> grades)
        {
            QuestionId = questionId;
            Grades = new List<int>(grades);
            for (int i = 0; i < Grades.Count; i++)
            {
                AverageGrade += Grades[i] * (i + 1);
            }
            AverageGrade = Math.Round(AverageGrade / Grades.Sum(), 2);
        }
    }
}

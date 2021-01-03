using Model.Patient;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPatient.Dto
{
    public class SurveyDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public String CommentSurvey { get; set; }
        public DateTime PublishingDate { get; set; }
        public int MedicalExaminationID { get; set; }
        public List<Answer> Answers { get; set; }

        public SurveyDto() { }
    }
}

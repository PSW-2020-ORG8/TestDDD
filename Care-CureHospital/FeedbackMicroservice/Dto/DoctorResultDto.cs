using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Dto
{
    public class DoctorResultDto
    {
        public Doctor Doctor { get; set; }

        public List<QuestionResultDto> QuestionResults { get; set; }


        public DoctorResultDto() { }

        public DoctorResultDto(Doctor doctor, List<QuestionResultDto> questionResults)
        {
            Doctor = doctor;
            QuestionResults = questionResults;
        }
    }
}

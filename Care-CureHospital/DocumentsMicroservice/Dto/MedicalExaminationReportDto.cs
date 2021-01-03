using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Dto
{
    public class MedicalExaminationReportDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Comment { get; set; }
        public string PublishingDate { get; set; }
        public string Doctor { get; set; }
        public string Room { get; set; }
        public Dictionary<string, string> SearchParams { get; set; }
        public List<string> LogicOperators { get; set; }
        public MedicalExaminationReportDto() { }
    }
}

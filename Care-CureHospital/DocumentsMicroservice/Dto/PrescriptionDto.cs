using Model.DoctorMenager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Dto
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Comment { get; set; }
        public string PublishingDate { get; set; }
        public string Doctor { get; set; }
        public List<Medicament> Medicaments { get; set; }
        public Dictionary<string, string> SearchParams { get; set; }
        public List<string> LogicOperators { get; set; }
        public PrescriptionDto() { }
    }
}

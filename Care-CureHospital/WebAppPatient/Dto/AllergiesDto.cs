using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPatient.Dto
{
    public class AllergiesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MedicalRecordId { get; set; }
        public string MedicalRecord { get; set; }
        public AllergiesDto() { }
    }
}

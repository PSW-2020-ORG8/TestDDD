using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPatient.Dto
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int NumberOfCancelledAppointents { get; set; }
        public bool Malicious { get; set; }
        public bool Blocked { get; set; }

        public PatientDto() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPatient.Dto
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public DoctorDto() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Dto
{
    public class SpecializationDto
    {
        public int Id { get; set; }
        public string SpecialitationForDoctor { get; set; }

        public SpecializationDto() { }
    }
}

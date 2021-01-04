using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Repository;

namespace UserMicroservice.Domain
{
    public class Specialitation : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string SpecialitationForDoctor { get; set; }

        public Specialitation(int id)
        {
            Id = id;
        }

        public Specialitation()
        {
        }

        public Specialitation(int id, string specialitation)
        {
            SpecialitationForDoctor = specialitation;
            Id = id;
        }

        public Specialitation(string specialitation)
        {
            SpecialitationForDoctor = specialitation;
        }

        public int GetId() => Id;


        public void SetId(int id) => Id = id;

    }
}

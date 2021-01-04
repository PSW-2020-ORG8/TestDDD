using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Domain
{
    public class Doctor : User
    {

        public int SpecialitationId { get; set; }
        public virtual Specialitation Specialitation { get; set; }

        public Doctor(int id, string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, Specialitation specialitation)
            : base(id, username, password, name, surname, jmbg, dateOfBirth, contactNumber, emailAddress)
        {
            Specialitation = specialitation;
        }


        public Doctor()
        {
        }

    }
}

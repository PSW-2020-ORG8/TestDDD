using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Domain
{
    public class Patient : User
    {
        public bool GuestAccount { get; set; }
        public bool Blocked { get; set; }
        public bool Malicious { get; set; }

        public Patient(int id, string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress,bool guestAccount)
            : base(id,username,password,name,surname,jmbg,dateOfBirth,contactNumber,emailAddress)
        {
            GuestAccount = guestAccount;
        }



      

        public Patient()
        {
        }
    }
}

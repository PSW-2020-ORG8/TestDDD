using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Domain
{
    public class Manager : User
    {
        public Manager(int id, string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress)
          : base(id, username, password, name, surname, jmbg, dateOfBirth, contactNumber, emailAddress)
        {
        }

        public Manager()
        {
        }
    }
}

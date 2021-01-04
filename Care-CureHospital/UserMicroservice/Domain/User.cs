using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Repository;

namespace UserMicroservice.Domain
{
    public class User : Person, IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        [NotMapped]
        public string Token { get; set; }

        public User()
        {
        }

        public User(int id, string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress,  string role)
            : base(name, surname, jmbg, dateOfBirth, contactNumber, emailAddress)
        {
            Username = username;
            Password = password;
            Role = role;
            Id = id;
        }
        public User(int id, string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress)
          : base(name, surname, jmbg, dateOfBirth, contactNumber, emailAddress)
        {
            Username = username;
            Password = password;
            Id = id;
        }


        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}

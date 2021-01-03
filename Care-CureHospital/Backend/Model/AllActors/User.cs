/***********************************************************************
 * Module:  User.cs
 * Author:  Stefan
 * Purpose: Definition of the Class AllActors.User
 ***********************************************************************/

using Backend.Model.AllActors;
using HealthClinic.Repository;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.AllActors
{
   public class User : Person, IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        [NotMapped]
        public string Token { get; set; }

        public User(int id)
        {
            Id = id;
        }

        public User()
        {
        }

        public User(int id, string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city, string role)
            : base(name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)
        {
            Username = username;
            Password = password;
            Role = role;
            Id = id;
        }

        public User(int id, string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city)
            : base(name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)
        {
            Username = username;
            Password = password;
            Id = id;
        }

        public User(string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city)
           : base(name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)
        {
            Username = username;
            Password = password;
        }

        public User(int id, string username, string password, string name, string parentName, string surname, Gender gender, string jmbg, string identityCard, string healthInsuranceCard, BloodGroup bloodGroup, DateTime dateOfBirth, string contactNumber, string emailAddress, City city) 
            : base(name, parentName, surname, gender, jmbg, identityCard, healthInsuranceCard, bloodGroup, dateOfBirth, contactNumber, emailAddress, city)
        {
            Username = username;
            Password = password;
            Id = id;
        }

        public User(string username, string password, string name, string parentName, string surname, Gender gender, string jmbg, string identityCard, string healthInsuranceCard, BloodGroup bloodGroup, DateTime dateOfBirth, string contactNumber, string emailAddress, City city)
           : base(name, parentName, surname, gender, jmbg, identityCard, healthInsuranceCard, bloodGroup, dateOfBirth, contactNumber, emailAddress, city)
        {
            Username = username;
            Password = password;       
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User(string name, string surname, string username)
        {
            Name = name;
            Surname = surname;
            Username = username;
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
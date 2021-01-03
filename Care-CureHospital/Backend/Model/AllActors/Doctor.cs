/***********************************************************************
 * Module:  Doctor.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Doctor.Doctor
 ***********************************************************************/

using Model.Doctor;
using System;

namespace Model.AllActors
{
   public class Doctor : User
   {
        public int SpecialitationId { get; set; }
        public virtual Specialitation Specialitation { get; set; }

        public Doctor(int id, string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city, Specialitation specialitation)
            : base(id, username, password, name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)
        {
            Specialitation = specialitation;
        }

        public Doctor(string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city, Specialitation specialitation)
            : base(username, password, name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)
        {
            Specialitation = specialitation;
        }

        public Doctor(string name, string surname, string username, Specialitation specialitation)
            : base(name, surname, username)
        {
            Specialitation = specialitation;
        }


        public Doctor(int id) : base(id)
        {
        }

        public Doctor()
        {
        }

    }
}
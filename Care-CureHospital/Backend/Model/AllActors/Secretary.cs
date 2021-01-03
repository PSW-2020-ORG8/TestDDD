/***********************************************************************
 * Module:  Secretary.cs
 * Author:  Stefan
 * Purpose: Definition of the Class AllActors.Secretary
 ***********************************************************************/

using System;

namespace Model.AllActors
{
   public class Secretary : User
   {
        public Secretary(int id, string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city)
            : base(id, username, password, name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)
        {
        }

        public Secretary(string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city)
            : base(username, password, name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)
        {
        }

        public Secretary(int id) : base(id)
        {
        }

        public Secretary()
        {
        }
    }
}
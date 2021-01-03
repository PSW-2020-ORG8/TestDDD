/***********************************************************************
 * Module:  Manager.cs
 * Author:  Stefan
 * Purpose: Definition of the Class AllActors.Manager
 ***********************************************************************/

using System;

namespace Model.AllActors
{
   public class Manager : User
   {
        public Manager(int id, string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city)
            : base(id, username, password, name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)
        {
        }

        public Manager(string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city)
           : base(username, password, name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)
        {
        }

        public Manager(int id) : base(id)
        {
        }

        public Manager()
        {
        }
    }
}
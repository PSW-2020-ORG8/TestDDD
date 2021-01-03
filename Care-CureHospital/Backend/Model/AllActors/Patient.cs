/***********************************************************************
 * Module:  Patient.cs
 * Author:  Stefan
 * Purpose: Definition of the Class AllActors.Patient
 ***********************************************************************/

using Backend.Model.AllActors;
using Model.PatientDoctor;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.AllActors
{
    public class Patient : User
    {
        public bool GuestAccount { get; set; }
        public bool Blocked { get; set; }
        public bool Malicious { get; set; }

        public Patient(int id, string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city,
            bool guestAccount)
            : base(id, username, password, name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)
        {
            GuestAccount = guestAccount;
        }

        public Patient(string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city,
            bool guestAccount)
            : base(username, password, name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)

        {
            GuestAccount = guestAccount;
        }

        public Patient(int id, string username, string password, string name, string parentName, string surname, Gender gender, string jmbg, string identityCard, 
            string healthInsuranceCard, BloodGroup bloodGroup, DateTime dateOfBirth, string contactNumber, string emailAddress, City city, bool guestAccount)
            : base(id, username, password, name, parentName, surname, gender, jmbg, identityCard, healthInsuranceCard, bloodGroup, dateOfBirth, contactNumber, emailAddress, city)
        {
            GuestAccount = guestAccount;
        }

        public Patient(string username, string password, string name, string parentName, string surname, Gender gender, string jmbg, string identityCard, 
            string healthInsuranceCard, BloodGroup bloodGroup, DateTime dateOfBirth, string contactNumber, string emailAddress, City city, bool guestAccount)
            : base(username, password, name, parentName, surname, gender, jmbg, identityCard, healthInsuranceCard, bloodGroup, dateOfBirth, contactNumber, emailAddress, city)

        {
            GuestAccount = guestAccount;
        }


        public Patient(string username, string password, string name, string parentName, string surname, Gender gender, string jmbg, string identityCard,
            string healthInsuranceCard, BloodGroup bloodGroup, DateTime dateOfBirth, string contactNumber, string emailAddress, City city, bool guestAccount, bool blocked, bool malicious)
            : base(username, password, name, parentName, surname, gender, jmbg, identityCard, healthInsuranceCard, bloodGroup, dateOfBirth, contactNumber, emailAddress, city)

        {
            GuestAccount = guestAccount;
            Blocked = blocked;
            Malicious = malicious;
        }

        public Patient(int id) : base(id)
        {
        }


        public Patient()
        {
        }
    }
}
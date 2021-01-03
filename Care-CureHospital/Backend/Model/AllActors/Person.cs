/***********************************************************************
 * Module:  Actor.cs
 * Author:  Stefan
 * Purpose: Definition of the Class AllActors.Actor
 ***********************************************************************/

using Backend.Model.AllActors;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.AllActors
{
    public class Person
    {
        public string Name { get; set; }
        public string ParentName { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public string Jmbg { get; set; }
        public string IdentityCard { get; set; }
        public string HealthInsuranceCard { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string EMail { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }

        public Person()
        {
        }

        public Person(string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city)
        {
            Name = name;
            Surname = surname;
            Jmbg = jmbg;
            DateOfBirth = dateOfBirth;
            ContactNumber = contactNumber;
            EMail = emailAddress;
            City = city;
        }

        public Person(string name, string parentName, string surname, Gender gender, string jmbg, string identityCard, string healthInsuranceCard, BloodGroup bloodGroup, DateTime dateOfBirth, string contactNumber, string emailAddress, City city)
        {
            Name = name;
            ParentName = parentName;
            Surname = surname;
            Gender = gender;
            Jmbg = jmbg;
            IdentityCard = identityCard;
            HealthInsuranceCard = healthInsuranceCard;
            BloodGroup = bloodGroup;
            DateOfBirth = dateOfBirth;
            ContactNumber = contactNumber;
            EMail = emailAddress;
            City = city;
        }
    
    }
}
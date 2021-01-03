// File:    Specialitation.cs
// Author:  Stefan
// Created: subota, 16. maj 2020. 22:07:34
// Purpose: Definition of Class Specialitation

using HealthClinic.Repository;
using System;

namespace Model.Doctor
{
    public class Specialitation : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string SpecialitationForDoctor { get; set; }

        public Specialitation(int id)
        {
            Id = id;
        }

        public Specialitation()
        {
        }

        public Specialitation(int id, string specialitation)
        {
            SpecialitationForDoctor = specialitation;
            Id = id;
        }

        public Specialitation(string specialitation)
        {
            SpecialitationForDoctor = specialitation;
        }

        public int GetId() => Id;


        public void SetId(int id) => Id = id;
        
    }
}
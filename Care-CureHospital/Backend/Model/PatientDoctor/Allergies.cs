// File:    Allergies.cs
// Author:  Stefan
// Created: subota, 16. maj 2020. 22:29:27
// Purpose: Definition of Class Allergies

using HealthClinic.Repository;
using System;

namespace Model.PatientDoctor
{
    public class Allergies : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }

        public Allergies(int id)
        {
            Id = id;
        }

        public Allergies()
        {
        }

        public Allergies(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public Allergies(string name)
        {
            Name = name;
        }

        public Allergies(int id, string name, int medicalRecordID) : this(id, name)
        {
            MedicalRecordId = medicalRecordID;
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
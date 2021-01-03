// File:    Diagnosis.cs
// Author:  Stefan
// Created: subota, 16. maj 2020. 22:29:28
// Purpose: Definition of Class Diagnosis

using HealthClinic.Repository;
using System;

namespace Model.PatientDoctor
{
    public class Diagnosis : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnamnesisId { get; set; }
        public virtual Anamnesis Anamnesis { get; set; }

        public Diagnosis(int id)
        {
            Id = id;
        }

        public Diagnosis()
        {
        }

        public Diagnosis(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public Diagnosis(string name)
        {
            Name = name;
        }

        public Diagnosis(int id, string name, int anamnesisID) : this(id, name)
        {
            AnamnesisId = anamnesisID;
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
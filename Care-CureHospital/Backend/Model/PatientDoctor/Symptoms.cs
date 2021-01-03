// File:    Symptoms.cs
// Author:  Stefan
// Created: subota, 16. maj 2020. 22:43:51
// Purpose: Definition of Class Symptoms

using HealthClinic.Repository;
using System;

namespace Model.PatientDoctor
{
    public class Symptoms : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnamnesisId { get; set; }
        public virtual Anamnesis Anamnesis { get; set; }

        public Symptoms(int id)
        {
            Id = id;
        }

        public Symptoms()
        {
        }

        public Symptoms(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public Symptoms(string name)
        {
            Name = name;
        }

        public Symptoms(int id, string name, int anamnesisID) : this(id, name)
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
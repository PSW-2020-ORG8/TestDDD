/***********************************************************************
 * Module:  Medicament.cs
 * Author:  Stefan
 * Purpose: Definition of the Class OtherClasses.Medicament
 ***********************************************************************/

using Backend.Model.PatientDoctor;
using HealthClinic.Repository;
using Model.PatientDoctor;
using System;
using System.Collections.Generic;


namespace Model.DoctorMenager
{
    public class Medicament : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public State StateOfValidation { get; set; }
        public int Quantity { get; set; }
        public string Ingredients { get; set; }
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }
        public int PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }


        public Medicament(int id, string code, string name, string producer, State stateOfValidation, int quantity, string ingredients)
        {
            Code = code;
            Name = name;
            Producer = producer;
            StateOfValidation = stateOfValidation;
            Quantity = quantity;
            Id = id;
            Ingredients = ingredients;
        }

        public Medicament(string code, string name, string producer, State stateOfValidation, int quantity, string ingredients)
        {
            Code = code;
            Name = name;
            Producer = producer;
            StateOfValidation = stateOfValidation;
            Quantity = quantity;
            Ingredients = ingredients;
        }

        public Medicament(string name)
        {
            Name = name;
        }

        public Medicament()
        {
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
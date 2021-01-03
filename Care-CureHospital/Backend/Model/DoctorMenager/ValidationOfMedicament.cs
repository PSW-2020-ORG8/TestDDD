// File:    ValidationOfMedicament.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 01:56:34
// Purpose: Definition of Class ValidationOfMedicament

using HealthClinic.Repository;
using System;
using System.Collections.Generic;

namespace Model.DoctorMenager
{
    public class ValidationOfMedicament : IIdentifiable<int>
    {
        public int Id { get; set; }
        public bool Approved { get; set; }
        public int MedicamentId { get; set; }
        public int DoctorId { get; set; }
        public int FeedbackOfValidationId { get; set; }
        public virtual Medicament Medicament { get; set; }
        public virtual Model.AllActors.Doctor Doctor { get; set; }
        public virtual FeedbackOfValidation FeedbackOfValidation { get; set; }

        public ValidationOfMedicament(int id)
        {
            Id = id;
        }

        public ValidationOfMedicament()
        {
        }

        public ValidationOfMedicament(int id, bool approved, Medicament medicament, FeedbackOfValidation feedbackOfValidation, Model.AllActors.Doctor doctor)
        {
            Approved = approved;
            Id = id;
            Medicament = medicament;
            FeedbackOfValidation = feedbackOfValidation;
            Doctor = doctor;
        }


        public ValidationOfMedicament(bool approved, Medicament medicament, FeedbackOfValidation feedbackOfValidation, Model.AllActors.Doctor doctor)
        {
            Approved = approved;
            Medicament = medicament;
            FeedbackOfValidation = feedbackOfValidation;
            Doctor = doctor;
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
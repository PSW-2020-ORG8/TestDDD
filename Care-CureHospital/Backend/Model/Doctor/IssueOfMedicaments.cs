/***********************************************************************
 * Module:  IssueOfMedicaments.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Doctor.IssueOfMedicaments
 ***********************************************************************/

using HealthClinic.Repository;
using Model.DoctorMenager;
using Model.PatientDoctor;
using System;
using System.Collections.Generic;

namespace Model.Doctor
{
    public class IssueOfMedicaments : IIdentifiable<int>
    {
        public int Id;
        public string Receipt { get; set; }
        public int MedicalRecordId { get; set; }
        public int DoctorId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }
        public virtual AllActors.Doctor Doctor { get; set; }
        public virtual List<Medicament> Medicaments { get; set; }

        public IssueOfMedicaments(int id)
        {
            Id = id;
        }

        public IssueOfMedicaments()
        {
        }

        public IssueOfMedicaments(int id, string receipt, MedicalRecord medicalRecord, AllActors.Doctor doctor, List<Medicament> medicaments)
        {
            Receipt = receipt;
            Id = id;
            MedicalRecord = medicalRecord;
            Doctor = doctor;
            Medicaments = medicaments;
        }

        public IssueOfMedicaments(string receipt, MedicalRecord medicalRecord, AllActors.Doctor doctor, List<Medicament> medicaments)
        {
            Receipt = receipt;
            MedicalRecord = medicalRecord;
            Doctor = doctor;
            Medicaments = medicaments;
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
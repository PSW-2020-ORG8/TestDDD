/***********************************************************************
 * Module:  MedicalRecord.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Doctor.MedicalRecord
 ***********************************************************************/

using HealthClinic.Repository;
using Model.DoctorMenager;
using System;
using System.Collections.Generic;


namespace Model.PatientDoctor
{
    public class MedicalRecord : IIdentifiable<int>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public virtual AllActors.Patient Patient { get; set; }
        public int AnamnesisId { get; set; }
        public virtual Anamnesis Anamnesis { get; set; }
        public virtual List<Allergies> Allergies { get; set; }
        public virtual List<Medicament> Medicaments { get; set; }
        public bool ActiveMedicalRecord { get; set; }

        public MedicalRecord(int id)
        {
            Id = id;
        }

        public MedicalRecord()
        {
        }

        public MedicalRecord(int id, AllActors.Patient patient, Anamnesis anamnesis, List<Allergies> allergies, List<Medicament> medicament) : this(id)
        {
            Patient = patient;
            Anamnesis = anamnesis;
            Allergies = allergies;
            Medicaments = medicament;
        }

        public MedicalRecord(AllActors.Patient patient, Anamnesis anamnesis, List<Allergies> allergies, List<Medicament> medicament)
        {
            Patient = patient;
            Anamnesis = anamnesis;
            Allergies = allergies;
            Medicaments = medicament;
        }

        public MedicalRecord(int id, int patientId, int anamnesisId, List<Allergies> allergies, List<Medicament> medicament) : this(id)
        {
            PatientId = patientId;
            AnamnesisId = anamnesisId;
            Allergies = allergies;
            Medicaments = medicament;
        }

        public MedicalRecord(int id, int patientId, AllActors.Patient patient, int anamnesisId, List<Allergies> allergies, List<Medicament> medicament, bool activeMedicalRecord) : this(id)
        {
            PatientId = patientId;
            Patient = patient;
            AnamnesisId = anamnesisId;
            Allergies = allergies;
            Medicaments = medicament;
            ActiveMedicalRecord = activeMedicalRecord;
        }

        public MedicalRecord(int id, AllActors.Patient patient, Anamnesis anamnesis, List<Allergies> allergies, List<Medicament> medicament, bool activeMedicalRecord) : this(id)
        {
            Patient = patient;
            Anamnesis = anamnesis;
            Allergies = allergies;
            Medicaments = medicament;
            ActiveMedicalRecord = activeMedicalRecord;
        }

        public MedicalRecord(AllActors.Patient patient, Anamnesis anamnesis, List<Allergies> allergies, List<Medicament> medicament, bool activeMedicalRecord)
        {
            Patient = patient;
            Anamnesis = anamnesis;
            Allergies = allergies;
            Medicaments = medicament;
            ActiveMedicalRecord = activeMedicalRecord;
        }

        public MedicalRecord(int id, int patientId, int anamnesisId, List<Allergies> allergies, List<Medicament> medicament, bool activeMedicalRecord) : this(id)
        {
            PatientId = patientId;
            AnamnesisId = anamnesisId;
            Allergies = allergies;
            Medicaments = medicament;
            ActiveMedicalRecord = activeMedicalRecord;
        }

        public void Review()
        {
            throw new NotImplementedException();
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
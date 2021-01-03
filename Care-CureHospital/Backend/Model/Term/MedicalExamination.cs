/***********************************************************************
 * Module:  MedicalExamination.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Term.MedicalExamination
 ***********************************************************************/

using HealthClinic.Repository;
using System;

namespace Model.Term
{
    public class MedicalExamination : Term, IIdentifiable<int>
    {
        public int Id { get; set; }
        public string ShortDescription { get; set; }
        public bool SurveyFilled { get; set; }
        public int RoomId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public virtual Room Room { get; set; }
        public virtual AllActors.Doctor Doctor { get; set; }
        public virtual AllActors.Patient Patient { get; set; }

        public MedicalExamination(int id)
        {
            Id = id;
        }

        public MedicalExamination()
        {
        }

        public MedicalExamination(int id, bool urgency, string shortDescription, Room room, AllActors.Doctor doctor, AllActors.Patient patient, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            SurveyFilled = urgency;
            ShortDescription = shortDescription;
            Id = id;
            Room = room;
            Doctor = doctor;
            Patient = patient;
        }

        public MedicalExamination(bool urgency, string shortDescription, Room room, AllActors.Doctor doctor, AllActors.Patient patient, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            SurveyFilled = urgency;
            ShortDescription = shortDescription;
            Room = room;
            Doctor = doctor;
            Patient = patient;
        }

        public MedicalExamination(int id, bool urgency, string shortDescription, int roomId, int doctorId, int patientId, Room room, AllActors.Doctor doctor, AllActors.Patient patient) : this(id)
        {
            SurveyFilled = urgency;
            ShortDescription = shortDescription;
            RoomId = roomId;
            DoctorId = doctorId;
            PatientId = patientId;
            Room = room;
            Doctor = doctor;
            Patient = patient;
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
/***********************************************************************
 * Module:  SurgerySchedule.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Doctor.SurgerySchedule
 ***********************************************************************/

using HealthClinic.Repository;
using Model.Doctor;
using Model.AllActors;
using System;

namespace Model.Term
{
    public class Surgery : Term, IIdentifiable<int>
    {
        public int Id { get; set; }
        public bool Urgency { get; set; }
        public string ShortDescription { get; set; }
        public int RoomId { get; set; }
        public int DoctorSpecialistId { get; set; }
        public int PatientId { get; set; }
        public virtual Room Room { get; set; }
        public virtual AllActors.Doctor DoctorSpecialist { get; set; }
        public virtual AllActors.Patient Patient { get; set; }

        public Surgery(int id)
        {
            Id = id;
        }

        public Surgery()
        {
        }

        public Surgery(int id, bool urgency, string shortDescription, Room room, Model.AllActors.Doctor doctorSpecialist, AllActors.Patient patient, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            Urgency = urgency;
            ShortDescription = shortDescription;
            Id = id;
            Room = room;
            DoctorSpecialist = doctorSpecialist;
            Patient = patient;
        }

        public Surgery(bool urgency, string shortDescription, Room room, Model.AllActors.Doctor doctorSpecialist, AllActors.Patient patient, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            Urgency = urgency;
            ShortDescription = shortDescription;
            Room = room;
            DoctorSpecialist = doctorSpecialist;
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
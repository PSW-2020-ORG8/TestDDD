/***********************************************************************
 * Module:  Hospitalitation.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Doctor.Hospitalitation
 ***********************************************************************/

using HealthClinic.Repository;
using Model.Doctor;
using System;

namespace Model.Term
{
    public class Hospitalitation : Term, IIdentifiable<int>
    {
        public int Id { get; set; }
        public bool Urgency { get; set; }
        public string ShortDescription { get; set; }
        public int RoomId { get; set; }
        public int DoctorId { get; set; }
        public int BedForLayingId { get; set; }
        public virtual Room Room { get; set; }
        public virtual AllActors.Doctor Doctor { get; set; }
        public virtual Bed BedForLaying { get; set; }

        public Hospitalitation(int id)
        {
            Id = id;
        }

        public Hospitalitation()
        {
        }

        public Hospitalitation(int id, bool urgency, string shortDescription, Room room, AllActors.Doctor doctor, Bed bedForLaying, DateTime fromDateTime, DateTime toDateTime) 
            : base(fromDateTime, toDateTime)
        {
            Urgency = urgency;
            ShortDescription = shortDescription;
            Id = id;
            Room = room;
            Doctor = doctor;
            BedForLaying = bedForLaying;
        }

        public Hospitalitation(bool urgency, string shortDescription, Room room, AllActors.Doctor doctor, Bed bedForLaying, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            Urgency = urgency;
            ShortDescription = shortDescription;
            Room = room;
            Doctor = doctor;
            BedForLaying = bedForLaying;
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
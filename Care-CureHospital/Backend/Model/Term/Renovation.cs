/***********************************************************************
 * Module:  Renovation.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Manager.Renovation
 ***********************************************************************/

using HealthClinic.Repository;
using System;

namespace Model.Term
{
    public class Renovation : Term, IIdentifiable<int>
    {
        public int Id { get; set; }
        public string DescriptionOfRenovation { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public Renovation(int id)
        {
            Id = id;
        }

        public Renovation()
        {
        }

        public Renovation(int id, string descriptionOfRenovation, Room room, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            Id = id;
            DescriptionOfRenovation = descriptionOfRenovation;           
            Room = room;
        }

        public Renovation(string descriptionOfRenovation,  Room room, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            DescriptionOfRenovation = descriptionOfRenovation;
            Room = room;
            FromDateTime = fromDateTime;
            ToDateTime = toDateTime;
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
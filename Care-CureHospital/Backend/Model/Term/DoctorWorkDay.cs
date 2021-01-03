/***********************************************************************
 * Module:  Termin.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Term.Termin
 ***********************************************************************/

using HealthClinic.Repository;
using System;
using System.Collections.Generic;

namespace Model.Term
{
    public class DoctorWorkDay : IIdentifiable<int>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public virtual AllActors.Doctor Doctor { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public virtual List<Appointment> ScheduledAppointments { get; set; }

        public DoctorWorkDay()
        {
        }

        public DoctorWorkDay(int id, DateTime date, int doctorId, AllActors.Doctor doctor, int roomId, Room room, List<Appointment> scheduledAppointments)
        {
            Id = id;
            Date = date;
            DoctorId = doctorId;
            Doctor = doctor;
            RoomId = roomId;
            Room = room;
            ScheduledAppointments = scheduledAppointments;
        }

        public DoctorWorkDay(int id, DateTime date, int doctorId, List<Appointment> scheduledAppointments)
        {
            Id = id;
            Date = date;
            DoctorId = doctorId;
            ScheduledAppointments = scheduledAppointments;
        }

        public DoctorWorkDay(int id, DateTime date, int doctorId, Model.AllActors.Doctor doctor, List<Appointment> scheduledAppointments)
        {
            Id = id;
            Date = date;
            DoctorId = doctorId;
            Doctor = doctor;
            ScheduledAppointments = scheduledAppointments;
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

/***********************************************************************
 * Module:  WorkingTimeForDoctor.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Manager.WorkingTimeForDoctor
 ***********************************************************************/

using HealthClinic.Repository;
using Model.Manager;
using System;

namespace Model.Term
{
    public class WorkingTimeForDoctor : Term, IIdentifiable<int>
    {
        public int Id { get; set; }
        public DaysInWeek Day { get; set; }
        public bool DoesWork { get; set; }
        public int DoctorId { get; set; }
        public virtual AllActors.Doctor Doctor { get; set; }

        public WorkingTimeForDoctor(int id)
        {
            Id = id;
        }

        public WorkingTimeForDoctor()
        {
        }

        public WorkingTimeForDoctor(int id, DaysInWeek day, bool doesWork, AllActors.Doctor doctor, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            Day = day;
            DoesWork = doesWork;
            Id = id;
            Doctor = doctor;
        }

        public WorkingTimeForDoctor(DaysInWeek day, bool doesWork, AllActors.Doctor doctor, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            Day = day;
            DoesWork = doesWork;
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
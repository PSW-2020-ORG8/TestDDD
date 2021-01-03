/***********************************************************************
 * Module:  Comment.cs
 * Author:  Hacer
 * Purpose: Definition of the Class Blog.Comment
 ***********************************************************************/

using System;
using Model.AllActors;

namespace Model.BlogAndNotification
{
    public class Comment : Content
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public virtual AllActors.Patient Patient { get; set; }
        public virtual AllActors.Doctor Doctor { get; set; }

        public Comment(int id)
        {
            Id = id;
        }

        public Comment()
        {
        }

        public Comment(int id, AllActors.Patient patient, AllActors.Doctor doctor) : this(id)
        {
            Patient = patient;
            Doctor = doctor;
        }

        public Comment(AllActors.Patient patient, AllActors.Doctor doctor)
        {
            Patient = patient;
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
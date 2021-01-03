using Model.Term;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMap.WPF.ModelWPF
{
    public class WorkDayView
    {
        public int Id { get; set; }
        public string IdOfRoom { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int RoomId { get; set; }
        public string Specialization { get; set; }
        public string DoctorFullName { get; set; }

        public List<Appointment> AvailableAppointments { get; set; }
    }
}

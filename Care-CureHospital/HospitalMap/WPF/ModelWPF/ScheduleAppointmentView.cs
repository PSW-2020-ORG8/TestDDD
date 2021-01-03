using Model.Term;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMap.WPF.ModelWPF
{
    class ScheduleAppointmentView
    {
        public int Id { get; set; }
        public bool Canceled { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public MedicalExamination MedicalExamination { get; set; }
        public int DoctorWorkDayId { get; set; }

        public ScheduleAppointmentView()
        {
        }
    }
}

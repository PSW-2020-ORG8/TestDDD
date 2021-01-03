using HealthClinic.Repository;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.PatientDoctor
{
    public class MedicalExaminationReport : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime PublishingDate { get; set; }
        public int MedicalExaminationId { get; set; }
        public virtual MedicalExamination MedicalExamination { get; set; }

        public MedicalExaminationReport() { }

        public MedicalExaminationReport(int id, string comment, DateTime publishingDate, int medicalExaminationID, MedicalExamination medicalExamination)
        {
            Id = id;
            Comment = comment;
            PublishingDate = publishingDate;
            MedicalExaminationId = medicalExaminationID;
            MedicalExamination = medicalExamination;
        }

        public MedicalExaminationReport(string comment, DateTime publishingDate, int medicalExaminationID, MedicalExamination medicalExamination)
        {
            Comment = comment;
            PublishingDate = publishingDate;
            MedicalExaminationId = medicalExaminationID;
            MedicalExamination = medicalExamination;
        }

        public MedicalExaminationReport(int id, string comment, DateTime publishingDate, int medicalExaminationID)
        {
            Id = id;
            Comment = comment;
            PublishingDate = publishingDate;
            MedicalExaminationId = medicalExaminationID;
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

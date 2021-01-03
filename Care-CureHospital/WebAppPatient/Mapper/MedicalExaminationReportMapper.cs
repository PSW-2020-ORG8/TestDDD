using Backend.Model.PatientDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPatient.Dto;

namespace WebAppPatient.Mapper
{
    public class MedicalExaminationReportMapper
    {
        public static MedicalExaminationReportDto MedicalExaminationReportToMedicalExaminationReportDto(MedicalExaminationReport medicalExaminationReport)
        {
            MedicalExaminationReportDto dto = new MedicalExaminationReportDto();
            dto.Id = medicalExaminationReport.Id;
            dto.Comment = medicalExaminationReport.Comment;
            dto.PublishingDate = medicalExaminationReport.PublishingDate.ToString("dd.MM.yyyy.");
            dto.Doctor = medicalExaminationReport.MedicalExamination.Doctor.Name + " " + medicalExaminationReport.MedicalExamination.Doctor.Surname;
            dto.Room = medicalExaminationReport.MedicalExamination.Room.RoomId;
            return dto;
        }
    }
}

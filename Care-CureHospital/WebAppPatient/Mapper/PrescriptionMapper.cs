using Backend.Model.PatientDoctor;
using Model.DoctorMenager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPatient.Dto;

namespace WebAppPatient.Mapper
{
    public class PrescriptionMapper
    {
        public static PrescriptionDto PrescriptionToPrescriptionDto(Prescription prescription)
        {
            PrescriptionDto dto = new PrescriptionDto();
            dto.Id = prescription.Id;
            dto.Comment = prescription.Comment;
            dto.PublishingDate = prescription.PublishingDate.ToString("dd.MM.yyyy.");
            dto.Doctor = prescription.MedicalExamination.Doctor.Name + " " + prescription.MedicalExamination.Doctor.Surname;
            List<Medicament> medicaments = new List<Medicament>();
            prescription.Medicaments.ToList().ForEach(medicament => medicaments.Add(medicament));
            dto.Medicaments = medicaments;
            return dto;
        }
    }
}

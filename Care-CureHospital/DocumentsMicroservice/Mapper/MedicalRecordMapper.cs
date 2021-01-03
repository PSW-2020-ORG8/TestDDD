using DocumentsMicroservice.Dto;
using Model.AllActors;
using Model.DoctorMenager;
using Model.PatientDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Mapper
{
    public class MedicalRecordMapper
    {
        public static MedicalRecord MedicalRecordDtoToMedicalRecord(MedicalRecordDto dto)
        {
            MedicalRecord medicalRecord = new MedicalRecord(new Patient(), new Anamnesis(), new List<Allergies>(), new List<Medicament>());

            medicalRecord.Id = dto.Id;
            medicalRecord.Patient = dto.Patient;
            medicalRecord.PatientId = medicalRecord.Patient.Id;
            medicalRecord.AnamnesisId = dto.AnamnesisId;
            medicalRecord.Anamnesis = new Anamnesis();
            medicalRecord.Allergies = dto.Allergies;
            medicalRecord.Medicaments = new List<Medicament>();
            medicalRecord.ActiveMedicalRecord = false;

            return medicalRecord;
        }

        public static MedicalRecordDto MedicalRecordToMedicalRecordDto(MedicalRecord medicalRecord)
        {
            MedicalRecordDto dto = new MedicalRecordDto();
            dto.Id = medicalRecord.Id;
            dto.Patient = medicalRecord.Patient;
            dto.PatientId = medicalRecord.PatientId;
            dto.ActiveMedicalRecord = medicalRecord.ActiveMedicalRecord;
            dto.Anamnesis = medicalRecord.Anamnesis;
            dto.Allergies = medicalRecord.Allergies;
            dto.Medicaments = medicalRecord.Medicaments;
            dto.DateOfBirthday = medicalRecord.Patient.DateOfBirth.ToString("dd.MM.yyyy.");
            dto.ProfilePicture = medicalRecord.Patient.Username + ".png";

            return dto;
        }
    }
}

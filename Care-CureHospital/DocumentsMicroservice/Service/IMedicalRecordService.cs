using Model.AllActors;
using Model.PatientDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Service
{
    public interface IMedicalRecordService : IService<MedicalRecord, int>
    {
        public MedicalRecord GetMedicalRecordForPatient(int patientID);
        public MedicalRecord FindPatientMedicalRecordByUsername(string username);
        public void ActivatePatientMedicalRecord(int medicalRecordId);
        public MedicalRecord CreatePatientMedicalRecord(MailAddress email, MedicalRecord medicalRecord);
        public MedicalRecord GetMedicalRecordByPatient(Patient patient);
        public void WritePatientProfilePictureInFile(string patientUsername, string profilePicture);
    }
}

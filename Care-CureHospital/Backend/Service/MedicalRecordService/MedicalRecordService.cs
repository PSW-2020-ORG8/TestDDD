/***********************************************************************
 * Module:  MedicalRecordService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.MedicalRecordService
 ***********************************************************************/

using Backend.Service.UsersServices;
using Model.PatientDoctor;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace Service.MedicalRecordService
{
    public class MedicalRecordService : IService<MedicalRecord, int>
    {
        public IMedicalRecordRepository medicalRecordRepository;
        public IEmailVerificationService emailVerificationService;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository, IEmailVerificationService emailVerificationService)
        {
            this.medicalRecordRepository = medicalRecordRepository;
            this.emailVerificationService = emailVerificationService;
        }

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            this.medicalRecordRepository = medicalRecordRepository;
        }

        public MedicalRecord GetMedicalRecordForPatient(int patientID)
        {
            return medicalRecordRepository.GetAllEntities().ToList().Find(medicalRecord => medicalRecord.PatientId == patientID);
        }

        public MedicalRecord FindPatientMedicalRecordByUsername(string username)
        {
            return medicalRecordRepository.GetAllEntities().ToList().Find(medicalRecord => medicalRecord.Patient.Username.Equals(username));
        }

        /// <summary> This method activates patient medical record after click on email verification link. </summary>
        public void ActivatePatientMedicalRecord(int medicalRecordId)
        {
            MedicalRecord medicalRecord = GetEntity(medicalRecordId);
            medicalRecord.ActiveMedicalRecord = true;
            UpdateEntity(medicalRecord);
        }

        public MedicalRecord CreatePatientMedicalRecord(MailAddress email, MedicalRecord medicalRecord)
        {
            emailVerificationService.SendVerificationEmailLink(email, medicalRecord.Patient.Username);
            return AddEntity(medicalRecord);
        }

        public MedicalRecord GetEntity(int id)
        {
            return medicalRecordRepository.GetEntity(id);
        }

        public IEnumerable<MedicalRecord> GetAllEntities()
        {
            return medicalRecordRepository.GetAllEntities();
        }

        public MedicalRecord AddEntity(MedicalRecord entity)
        {
            return medicalRecordRepository.AddEntity(entity);
        }

        public void UpdateEntity(MedicalRecord entity)
        {
            medicalRecordRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(MedicalRecord entity)
        {
            medicalRecordRepository.DeleteEntity(entity);
        }

        public MedicalRecord GetMedicalRecordByPatient(Model.AllActors.Patient patient)
        {
            return medicalRecordRepository.GetMedicalRecordByPatient(patient);
        }

        public void WritePatientProfilePictureInFile(string patientUsername, string profilePicture)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(profilePicture.Split(",")[1]);
                using (var fs = new FileStream(FindPictureFolderPath(patientUsername), FileMode.Create, FileAccess.Write))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private string FindPictureFolderPath(string patientUsername)
        {
            string pictureFolderPath = Path.Combine("wwwroot", "images\\patientsProfileImages\\");
            string pathForSaving = Path.Combine(Directory.GetCurrentDirectory(), pictureFolderPath);
            return Path.Combine(pathForSaving, patientUsername + ".png");
        }

    }
}
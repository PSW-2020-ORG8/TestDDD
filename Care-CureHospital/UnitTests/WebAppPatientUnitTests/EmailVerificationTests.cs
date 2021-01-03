using Backend.Service.UsersServices;
using Model.AllActors;
using Model.DoctorMenager;
using Model.PatientDoctor;
using Moq;
using Repository.MedicalRecordRepository;
using Service.MedicalRecordService;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace UnitTests.WebAppPatientUnitTests
{
    public class EmailVerificationTests
    {
        [Fact]
        public void Sends_verification_email()
        {
            var mockVerify = new Mock<IEmailVerificationService>();
            MedicalRecordService medicalRecordService = new MedicalRecordService(CreateStubRepository(), mockVerify.Object);

            MedicalRecord medicalRecord = medicalRecordService.CreatePatientMedicalRecord(new MailAddress("pswfirma8@gmail.com"), new MedicalRecord(5, new Patient(5, "misa", "123", "Misa", "Misic", "123123123123", new DateTime(), "066123123", "pswfirma8@gmail.com", new City("Novi Sad", "Mise Dim", new Country("Srbija")), false), new Anamnesis(), new List<Allergies>(), new List<Medicament>()));

            mockVerify.Verify(v => v.SendVerificationEmailLink(new MailAddress(medicalRecord.Patient.EMail), medicalRecord.Patient.Username), Times.Once);
        }

        private static IMedicalRecordRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IMedicalRecordRepository>();

            MedicalRecord medicalRecord = new MedicalRecord(5, new Patient(5, "misa", "123", "Misa", "Misic", "123123123123", new DateTime(), "066123123", "pswfirma8@gmail.com", new City("Novi Sad", "Mise Dim", new Country("Srbija")), false), new Anamnesis(), new List<Allergies>(), new List<Medicament>());

            stubRepository.Setup(m => m.AddEntity(It.IsAny<MedicalRecord>())).Returns(medicalRecord);

            return stubRepository.Object;
        }

    }
}

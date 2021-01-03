using Backend.Service.UsersServices;
using Model.AllActors;
using Model.DoctorMenager;
using Model.PatientDoctor;
using Moq;
using Repository.MedicalRecordRepository;
using Service.MedicalRecordService;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.WebAppPatientUnitTests
{
    public class MedicalRecordTests
    {
        [Fact]
        public void Find_medical_record_for_patient()
        {
            MedicalRecordService medicalRecordService = new MedicalRecordService(CreateStubRepository());

            MedicalRecord medicalRecord = medicalRecordService.GetMedicalRecordForPatient(1);

            Assert.NotNull(medicalRecord);
        }

        [Fact]
        public void Not_found_medical_record_for_patient()
        {
            MedicalRecordService medicalRecordService = new MedicalRecordService(CreateStubRepository());

            MedicalRecord medicalRecord = medicalRecordService.GetMedicalRecordForPatient(10);

            Assert.Null(medicalRecord);
        }

        [Fact]
        public void Register_patient_successfully()
        {
            MedicalRecordService medicalRecordService = new MedicalRecordService(CreateStubRepository());

            MedicalRecord medicalRecord = medicalRecordService.AddEntity(new MedicalRecord(5, new Patient(5, "misa", "123", "Misa", "Misic", "123123123123", new DateTime(), "066123123", "misa@gmail.com", new City("Novi Sad", "Mise Dim", new Country("Srbija")), false), new Anamnesis(), new List<Allergies>(), new List<Medicament>()));

            Assert.NotNull(medicalRecord);
        }

        [Fact]
        public void Validate_medical_record_activation()
        {
            MedicalRecordService medicalRecordService = new MedicalRecordService(CreateStubRepository());

            medicalRecordService.ActivatePatientMedicalRecord(1);
            MedicalRecord medicalRecord = medicalRecordService.GetEntity(1);

            Assert.True(medicalRecord.ActiveMedicalRecord);
        }

        [Fact]
        public void Find_patient_medical_record_by_username()
        {
            MedicalRecordService medicalRecordService = new MedicalRecordService(CreateStubRepository());

            MedicalRecord medicalRecord = medicalRecordService.FindPatientMedicalRecordByUsername("pera");

            Assert.NotNull(medicalRecord);
        }

        [Fact]
        public void Not_found_patient_medical_record_by_username()
        {
            MedicalRecordService medicalRecordService = new MedicalRecordService(CreateStubRepository());

            MedicalRecord medicalRecord = medicalRecordService.FindPatientMedicalRecordByUsername("joca");

            Assert.Null(medicalRecord);
        }

        private static IMedicalRecordRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IMedicalRecordRepository>();

            var medicalRecords = new List<MedicalRecord>();
            medicalRecords.Add(new MedicalRecord(1, 1, new Patient { Username = "pera" }, 1, new List<Allergies>(), new List<Medicament>(), false));
            medicalRecords.Add(new MedicalRecord(2, 2, new Patient { Username = "mika" }, 2, new List<Allergies>(), new List<Medicament>(), true));
            medicalRecords.Add(new MedicalRecord(3, 3, new Patient { Username = "laza" }, 3, new List<Allergies>(), new List<Medicament>(), false));

            stubRepository.Setup(medicalRecordRepository => medicalRecordRepository.GetAllEntities()).Returns(medicalRecords);
            stubRepository.Setup(medicalRecord => medicalRecord.AddEntity(It.IsAny<MedicalRecord>())).Returns(new MedicalRecord(5, new Patient(5, "misa", "123", "Misa", "Misic", "123123123123", new DateTime(), "066123123", "misa@gmail.com", new City("Novi Sad", "Mise Dim", new Country("Srbija")), false), new Anamnesis(), new List<Allergies>(), new List<Medicament>()));
            stubRepository.Setup(medicalRecord => medicalRecord.UpdateEntity(It.IsAny<MedicalRecord>()))
                .Callback((MedicalRecord medicalRecord) => 
                    {
                        MedicalRecord existingMedicalRecord = medicalRecords.Find(m => m.Id == medicalRecord.Id);
                        existingMedicalRecord.ActiveMedicalRecord = true;
                    });
            stubRepository.Setup(medicalRecordRepository => medicalRecordRepository.GetEntity(It.IsAny<int>())).Returns((int id) => medicalRecords.Find(m => m.Id == id));

            return stubRepository.Object;
        }
    }
}

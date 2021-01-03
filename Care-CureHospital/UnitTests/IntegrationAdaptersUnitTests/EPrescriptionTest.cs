using Model.AllActors;
using Model.DoctorMenager;
using System;
using System.Collections.Generic;
using Backend.Repository.DoctorRepository;
using Xunit;
using Backend.Model.PatientDoctor;
using Moq;
using Backend.Service.DoctorService;

namespace UnitTests.IntegrationAdaptersUnitTests
{
    public class EPrescriptionTest
    {
        [Fact]
        public void Find_ePrescription_for_patient()
        {
            EPrescriptionService ePrescriptionService = new EPrescriptionService(CreateStubRepository());

            EPrescription ePrescription = ePrescriptionService.GetEPrescriptionForPatient(5);

            Assert.NotNull(ePrescription);
        }

        [Fact]
        public void Not_found_ePrescription_for_patient()
        {
            EPrescriptionService ePrescriptionService = new EPrescriptionService(CreateStubRepository());

            EPrescription ePrescription = ePrescriptionService.GetEPrescriptionForPatient(7);

            Assert.Null(ePrescription);
        }

        [Fact]
        public void Get_ePrescription()
        {
            EPrescriptionService EPrescriptionService = new EPrescriptionService(CreateStubRepository());

            List<EPrescription> results = (List<EPrescription>)EPrescriptionService.GetAllEntities();

            Assert.NotNull(results);
        }

        [Fact]
        public void Found_prescriptions_with_date_parameter()
        {
            EPrescriptionService service = new EPrescriptionService(CreateStubRepository());

            List<EPrescription> searchResult = service.FindEPrescriptionsForDateParameter(1, "2020-08-12");

            Assert.NotEmpty(searchResult);
        }

        [Fact]
        public void Not_found_prescriptions_with_date_parameter()
        {
            EPrescriptionService service = new EPrescriptionService(CreateStubRepository());

            List<EPrescription> searchResult = service.FindEPrescriptionsForDateParameter(1, "2020-12-23");

            Assert.Empty(searchResult);
        }

        private static IEPrescriptionRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IEPrescriptionRepository>();

            var eprescriptions = new List<EPrescription>();
            List<Patient> patients = new List<Patient>();
            patients.Add(new Patient(1));
            patients.Add(new Patient(2));
            List<Medicament> medicaments = new List<Medicament>();
            medicaments.Add(new Medicament("Brufen"));
            medicaments.Add(new Medicament("Paracetamol"));

            eprescriptions.Add(new EPrescription { Id = 1, PatientId = 1, PatientName = "Petar", Comment = "Redovno koristite prepisane lekove", MedicamentName = "Brufen", PublishingDate = new DateTime(2020, 08, 12, 10, 30, 0) });
            eprescriptions.Add(new EPrescription { Id = 2, PatientId = 2, PatientName = "Mica", Comment = "Svakodnevno koristite prepisani lek", MedicamentName = "Andol", PublishingDate = new DateTime(2020, 12, 23, 10, 30, 0) });
            eprescriptions.Add(new EPrescription { Id = 3, PatientId = 3, PatientName = "Zika", Comment = "Redovno koristite prepisane lekove", MedicamentName = "Analgin", PublishingDate = new DateTime(2020, 10, 05, 10, 30, 0) });
            eprescriptions.Add(new EPrescription { Id = 4, PatientId = 5, PatientName = "Ivan", Comment = "Ne preskacite konzumiranje leka", MedicamentName = "Kanesten", PublishingDate = new DateTime(2020, 11, 30, 10, 30, 0), });
            eprescriptions.Add(new EPrescription { Id = 5, PatientId = 6, PatientName = "Marko", Comment = "Redovno koristite prepisane lekove", MedicamentName = "Vitamin B", PublishingDate = new DateTime(2020, 10, 05, 10, 30, 0) });
          
            stubRepository.Setup(prescriptionRepository => prescriptionRepository.GetAllEntities()).Returns(eprescriptions);

            return stubRepository.Object;
        }
    }
}

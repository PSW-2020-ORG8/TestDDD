using Backend.Model.PatientDoctor;
using Backend.Repository.ExaminationSurgeryRepository;
using Backend.Service.ExaminationSurgeryServices;
using Model.AllActors;
using Model.Doctor;
using Model.DoctorMenager;
using Model.Term;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.WebAppPatientUnitTests
{
    public class PrescriptionTests
    {
        [Fact]
        public void Find_Prescriptions_With_Doctor_Searh_Parameter()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> searchResult = service.FindPrescriptionsForDoctorParameter(1, "Milan");

            Assert.NotEmpty(searchResult);
        }

        [Fact]
        public void Not_Found_Prescriptions_With_Doctor_Searh_Parameter()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> searchResult = service.FindPrescriptionsForDoctorParameter(1, "Milorad");

            Assert.Empty(searchResult);
        }

        [Fact]
        public void Find_Prescriptions_With_Comment_Searh_Parameter()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> searchResult = service.FindPrescriptionsForCommentParameter(1, "Redovno");

            Assert.NotEmpty(searchResult);
        }

        [Fact]
        public void Not_Found_Prescriptions_With_Comment_Searh_Parameter()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> searchResult = service.FindPrescriptionsForCommentParameter(1, "Bolnica");

            Assert.Empty(searchResult);
        }

        [Fact]
        public void Find_Prescriptions_With_Date_Searh_Parameter()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> searchResult = service.FindPrescriptionsForDateParameter(1, "2020-12-23");

            Assert.NotEmpty(searchResult);
        }

        [Fact]
        public void Not_Found_Prescriptions_With_Date_Searh_Parameter()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> searchResult = service.FindPrescriptionsForDateParameter(1, "2021-12-23");

            Assert.Empty(searchResult);
        }

        [Fact]
        public void Find_Prescriptions_With_Medicines_Searh_Parameter()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> searchResult = service.FindPrescriptionsForMedicamentsParameter(1, "Brufen");

            Assert.NotEmpty(searchResult);
        }

        [Fact]
        public void Not_Found_Prescriptions_With_Medicines_Searh_Parameter()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> searchResult = service.FindPrescriptionsForMedicamentsParameter(1, "Kafetin");

            Assert.Empty(searchResult);
        }

        [Fact]
        public void Find_Prescriptions_Using_Simple_Search()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> searchResult = service.FindPrescriptionsUsingSimpleSearch(1, "Milan", "2020-08-12", "lekove", "Brufen");

            Assert.NotEmpty(searchResult);
        }

        [Fact]
        public void Not_Found_Prescriptions_Using_Simple_Search()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> searchResult = service.FindPrescriptionsUsingSimpleSearch(1, "Ivan", "2020-08-12", "lekove", "Brufen"); ;

            Assert.Empty(searchResult);
        }

        [Fact]
        public void Find_Prescriptions_With_Doctor_And_Date_Searh_Parameter()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());
            Dictionary<string, string> parametersForSearch = new Dictionary<string, string>();
            List<string> logicOperators = new List<string>();
            parametersForSearch.Add("Doktoru", "Milan");
            parametersForSearch.Add("Datumu", "2020-10-05");
            logicOperators.Add("I");

            List<Prescription> searchResult = service.FindPrescriptionsUsingAdvancedSearch(1, parametersForSearch, logicOperators);

            searchResult.ShouldNotBeEmpty();
        }

        [Fact]
        public void Find_Prescriptions_With_Comment_Or_Medicaments_Searh_Parameter()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());
            Dictionary<string, string> parametersForSearch = new Dictionary<string, string>();
            List<string> logicOperators = new List<string>();
            parametersForSearch.Add("Sadržaju", "Redovno");
            parametersForSearch.Add("Lekovima", "Brufen");
            logicOperators.Add("ILI");

            List<Prescription> searchResult = service.FindPrescriptionsUsingAdvancedSearch(1, parametersForSearch, logicOperators);

            searchResult.ShouldNotBeEmpty();
        }

        [Fact]
        public void Find_Prescriptions_With_Three_Searh_Parameters()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());
            Dictionary<string, string> parametersForSearch = new Dictionary<string, string>();
            List<string> logicOperators = new List<string>();
            parametersForSearch.Add("Doktoru", "Jovan");
            parametersForSearch.Add("Sadržaju", "Brufen");
            parametersForSearch.Add("Lekovima", "Brufen");
            logicOperators.Add("ILI");
            logicOperators.Add("ILI");

            List<Prescription> searchResult = service.FindPrescriptionsUsingAdvancedSearch(1, parametersForSearch, logicOperators);

            searchResult.ShouldNotBeEmpty();
        }

        [Fact]
        public void Find_Prescriptions_With_Four_Searh_Parameters()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());
            Dictionary<string, string> parametersForSearch = new Dictionary<string, string>();
            List<string> logicOperators = new List<string>();
            parametersForSearch.Add("Doktoru", "Milan");
            parametersForSearch.Add("Datumu", "2020-10-05");
            parametersForSearch.Add("Sadržaju", "Koristite");
            parametersForSearch.Add("Lekovima", "Brufen");
            logicOperators.Add("I");
            logicOperators.Add("I");
            logicOperators.Add("I");

            List<Prescription> searchResult = service.FindPrescriptionsUsingAdvancedSearch(1, parametersForSearch, logicOperators);

            searchResult.ShouldNotBeEmpty();
        }

        private static IPrescriptionRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPrescriptionRepository>();

            var prescriptions = new List<Prescription>();
            List<Medicament> medicaments = new List<Medicament>();
            medicaments.Add(new Medicament("Brufen"));
            medicaments.Add(new Medicament("Paracetamol"));

            prescriptions.Add(new Prescription { Id = 1, Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 08, 12, 10, 30, 0), MedicalExamination = new MedicalExamination(1, false, "Opis", 1, 2, 1, new Room(), new Doctor("pera", "123", "Milan", "Petrovic", "123", new DateTime(), "123", "email", new City(), new Specialitation()), new Patient(1)), Medicaments = medicaments });
            prescriptions.Add(new Prescription { Id = 2, Comment = "Svakodnevno koristite prepisani lek", PublishingDate = new DateTime(2020, 12, 23, 10, 30, 0), MedicalExamination = new MedicalExamination(2, false, "Opis", 1, 2, 1, new Room(), new Doctor("pera", "123", "Jovan", "Simic", "123", new DateTime(), "123", "email", new City(), new Specialitation()), new Patient(1)), Medicaments = medicaments });
            prescriptions.Add(new Prescription { Id = 3, Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 10, 05, 10, 30, 0), MedicalExamination = new MedicalExamination(3, false, "Opis", 1, 2, 1, new Room(), new Doctor("pera", "123", "Milan", "Petrovic", "123", new DateTime(), "123", "email", new City(), new Specialitation()), new Patient(1)), Medicaments = medicaments });
            prescriptions.Add(new Prescription { Id = 4, Comment = "Ne preskacite konzumiranje leka", PublishingDate = new DateTime(2020, 11, 30, 10, 30, 0), MedicalExamination = new MedicalExamination(4, false, "Opis", 1, 2, 1, new Room(), new Doctor("pera", "123", "Milan", "Petrovic", "123", new DateTime(), "123", "email", new City(), new Specialitation()), new Patient(1)), Medicaments = medicaments });
            prescriptions.Add(new Prescription { Id = 5, Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 10, 05, 10, 30, 0), MedicalExamination = new MedicalExamination(5, false, "Opis",1, 2, 1, new Room(), new Doctor("pera", "123", "Jovan", "Simic", "123", new DateTime(), "123", "email", new City(), new Specialitation()), new Patient(1)), Medicaments = medicaments });

            stubRepository.Setup(prescriptionRepository => prescriptionRepository.GetAllEntities()).Returns(prescriptions);

            return stubRepository.Object;
        }
    }
}

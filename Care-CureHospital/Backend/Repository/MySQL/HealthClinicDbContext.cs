using Backend.Model.AllActors;
using Backend.Model.BlogAndNotification;
using Backend.Model.DoctorMenager;
using Backend.Model.PatientDoctor;
using Backend.Model.Pharmacy;
using Microsoft.EntityFrameworkCore;
using Model.AllActors;
using Model.Doctor;
using Model.DoctorMenager;
using Model.Manager;
using Model.Patient;
using Model.PatientDoctor;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Repository.MySQL
{
    public class HealthClinicDbContext : DbContext
    {
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<PatientFeedback> PatientFeedbacks { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Patient> Doctors { get; set; }
        public DbSet<SystemAdministrator> SystemAdministrators { get; set; }
        public DbSet<Specialitation> Specialitations { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<MedicalExamination> MedicalExaminations { get; set; }
        public DbSet<MedicalExaminationReport> MedicalExaminationReports { get; set; }
        public DbSet<MedicalExaminationReport> Prescriptions { get; set; }
        public DbSet<EPrescription> EPrescription { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<InventaryRoom> InventaryRoom { get; set; }
        public DbSet<TypeOfRoom> TypesOfRoom { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Anamnesis> Anamnesies { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<Diagnosis> Diagnosies { get; set; }
        public DbSet<Symptoms> Symptomes { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<DoctorWorkDay> DoctorWorkDays { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Pharmacies> Pharmacies { get; set; }

        public HealthClinicDbContext() : base() { }
        public HealthClinicDbContext(DbContextOptions<HealthClinicDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("* * * * * * * * * * * * *");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseMySql(CreateConnectionStringFromEnvironment());
            }
        }

        private string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "HealthClinicDB";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";
            string sslMode = Environment.GetEnvironmentVariable("DATABASE_SSL_MODE") ?? "None";
            Console.WriteLine(server);
            Console.WriteLine(port);
            Console.WriteLine(user);
            Console.WriteLine(password);
            Console.WriteLine(database);
            return $"server={server};port={port};database={database};user={user};password={password};";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, Name = "Petar", Surname = "Petrovic", ParentName = "Zika", Gender = Gender.Male, IdentityCard = "123123123", HealthInsuranceCard = "32312312312", Jmbg = "13312312312312", BloodGroup = BloodGroup.AbMinus, DateOfBirth = new DateTime(2000, 1, 1, 3, 3, 3), ContactNumber = "063554533", EMail = "pera@gmail.com", Username = "pera", Password = "123", GuestAccount = false, CityId = 1, Blocked = false, Malicious = false, Role = Role.Patient },
                new Patient { Id = 2, Name = "Zika", Surname = "Zikic", ParentName = "Pera", Gender = Gender.Male, IdentityCard = "124123123", HealthInsuranceCard = "712312312312", Jmbg = "12342312312312", BloodGroup = BloodGroup.AbMinus, DateOfBirth = new DateTime(2001, 1, 1, 3, 3, 3), ContactNumber = "0635235333", EMail = "zika@gmail.com", Username = "zika", Password = "123", GuestAccount = false, CityId = 2, Blocked = false, Malicious = false, Role = Role.Patient },
                new Patient { Id = 3, Name = "Mica", Surname = "Micic", ParentName = "Jelena", Gender = Gender.Male, IdentityCard = "163123123", HealthInsuranceCard = "62312312312", Jmbg = "12312512312312", BloodGroup = BloodGroup.Unknown, DateOfBirth = new DateTime(2002, 1, 1, 3, 3, 3), ContactNumber = "0635557673", EMail = "mica@gmail.com", Username = "mica", Password = "123", GuestAccount = false, CityId = 1, Blocked = false, Malicious = false, Role = Role.Patient },
                new Patient { Id = 4, Name = "Luna", Surname = "Lunic", ParentName = "Jovan", Gender = Gender.Female, IdentityCard = "127123123", HealthInsuranceCard = "52312312312", Jmbg = "12312316712312", BloodGroup = BloodGroup.AbMinus, DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "063555356", EMail = "luna@gmail.com", Username = "luna", Password = "123", GuestAccount = false, CityId = 2, Blocked = false, Malicious = false, Role = Role.Patient },
                new Patient { Id = 5, Name = "Ivan", Surname = "Ivanovic", ParentName = "Luka", Gender = Gender.Male, IdentityCard = "127199123", HealthInsuranceCard = "52318812312", Jmbg = "12344316712312", BloodGroup = BloodGroup.AbMinus, DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "063775356", EMail = "ivan@gmail.com", Username = "ivan", Password = "123", GuestAccount = false, CityId = 2, Blocked = false, Malicious = true, Role = Role.Patient },
                new Patient { Id = 6, Name = "Marko", Surname = "Markovic", ParentName = "Jovan", Gender = Gender.Male, IdentityCard = "127123333", HealthInsuranceCard = "52312312311", Jmbg = "12312316712344", BloodGroup = BloodGroup.AbMinus, DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "063555312", EMail = "marko@gmail.com", Username = "marko", Password = "123", GuestAccount = false, CityId = 2, Blocked = false, Malicious = true, Role = Role.Patient }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Username = "milan", Password = "123", Name = "Milan", Surname = "Petrovic", Jmbg = "13312312312312", DateOfBirth = new DateTime(2000, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "milan@gmail.com", CityId = 2, SpecialitationId = 1 },
                new Doctor { Id = 2, Username = "aca", Password = "123", Name = "Aleksandar", Surname = "Aleksic", Jmbg = "13212312312312", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "aca@gmail.com", CityId = 1, SpecialitationId = 1 },
                new Doctor { Id = 3, Username = "jovan", Password = "123", Name = "Jovan", Surname = "Jovic", Jmbg = "13312367312312", DateOfBirth = new DateTime(2005, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "jovan@gmail.com", CityId = 2, SpecialitationId = 2 },
                new Doctor { Id = 4, Username = "nikola", Password = "123", Name = "Nikola", Surname = "Nikic", Jmbg = "13316712312312", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "nikola@gmail.com", CityId = 1, SpecialitationId = 1 },
                new Doctor { Id = 5, Username = "mihajlo", Password = "123", Name = "Mihajlo", Surname = "Mihajlovic", Jmbg = "13312367312312", DateOfBirth = new DateTime(2005, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "mihajlo@gmail.com", CityId = 2, SpecialitationId = 3 },
                new Doctor { Id = 6, Username = "vuk", Password = "123", Name = "Vuk", Surname = "Vukic", Jmbg = "13316712312312", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "vuk@gmail.com", CityId = 1, SpecialitationId = 3 },
                new Doctor { Id = 7, Username = "helena", Password = "123", Name = "Helena", Surname = "Kostic", Jmbg = "13312367312312", DateOfBirth = new DateTime(2005, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "helena@gmail.com", CityId = 2, SpecialitationId = 4 },
                new Doctor { Id = 8, Username = "marija", Password = "123", Name = "Marija", Surname = "Marijic", Jmbg = "13316712312312", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "marija@gmail.com", CityId = 1, SpecialitationId = 4 },
                new Doctor { Id = 9, Username = "tanja", Password = "123", Name = "Tanja", Surname = "Tankosic", Jmbg = "13316712312312", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "tanja@gmail.com", CityId = 1, SpecialitationId = 5 }
            );

            modelBuilder.Entity<SystemAdministrator>().HasData(
               new SystemAdministrator { Id = 1, Username = "admin1", Password = "admin1", Name = "Vladislav", Surname = "Petkovic", Jmbg = "12312316712345", DateOfBirth = new DateTime(1998, 1, 1, 3, 3, 3), ContactNumber = "063775356", EMail = "vladislav@gmail.com", CityId = 1, Role = Role.Admin },
               new SystemAdministrator { Id = 2, Username = "admin2", Password = "admin2", Name = "Dusan", Surname = "Vasiljev", Jmbg = "12312316712345", DateOfBirth = new DateTime(1998, 1, 1, 3, 3, 3), ContactNumber = "063775356", EMail = "dusan@gmail.com", CityId = 1, Role = Role.Admin }
           );

            modelBuilder.Entity<Secretary>().HasData(
                new Secretary { Id = 1, Username = "sekretar1", Password = "123", Name = "Milica", Surname = "Carica", Jmbg = "12312316712345", DateOfBirth = new DateTime(1998, 1, 1, 3, 3, 3), ContactNumber = "063775356", EMail = "milica@gmail.com", CityId = 1 }
            );

            modelBuilder.Entity<Manager>().HasData(
                new Manager { Id = 1, Username = "manager1", Password = "123", Name = "Darja", Surname = "Rusedski", Jmbg = "12317316712344", DateOfBirth = new DateTime(1992, 1, 10, 3, 30, 0), ContactNumber = "063555156", EMail = "darja@gmail.com", CityId = 1 }
                );


            modelBuilder.Entity<Report>().HasData(
                new Report { Id = 1, MedicamentId = 1, MedicamentName = "Brufen", Quantity = 10, FromDate = new DateTime(2019, 5, 1, 6, 30, 0), ToDate = new DateTime(2019, 10, 1, 6, 10, 0) },
                new Report { Id = 2, MedicamentId = 2, MedicamentName = "Panadol", Quantity = 15, FromDate = new DateTime(2020, 10, 30, 10, 30, 0), ToDate = new DateTime(2020, 2, 5, 6, 10, 0) },
                new Report { Id = 3, MedicamentId = 4, MedicamentName = "Vitamin B", Quantity = 120, FromDate = new DateTime(2019, 1, 10, 3, 30, 0), ToDate = new DateTime(2019, 5, 10, 6, 30, 0) },
                new Report { Id = 4, MedicamentId = 3, MedicamentName = "Paracetamol", Quantity = 24, FromDate = new DateTime(2020, 1, 5, 8, 30, 0), ToDate = new DateTime(2020, 12, 10, 6, 30, 0) }
            );

            modelBuilder.Entity<Specialitation>().HasData(
                new Specialitation { Id = 1, SpecialitationForDoctor = "Lekar opste prakse" },
                new Specialitation { Id = 2, SpecialitationForDoctor = "Ortoped" },
                new Specialitation { Id = 3, SpecialitationForDoctor = "Kardiolog" },
                new Specialitation { Id = 4, SpecialitationForDoctor = "Dermatolog" },
                new Specialitation { Id = 5, SpecialitationForDoctor = "Endokrinolog" }
            );

            modelBuilder.Entity<MedicalRecord>().HasData(
                new MedicalRecord { Id = 1, PatientId = 1, AnamnesisId = 1, Allergies = new List<Allergies>(), Medicaments = new List<Medicament>(), ActiveMedicalRecord = true },
                new MedicalRecord { Id = 2, PatientId = 2, AnamnesisId = 1, Allergies = new List<Allergies>(), Medicaments = new List<Medicament>(), ActiveMedicalRecord = true },
                new MedicalRecord { Id = 3, PatientId = 3, AnamnesisId = 1, Allergies = new List<Allergies>(), Medicaments = new List<Medicament>(), ActiveMedicalRecord = true },
                new MedicalRecord { Id = 4, PatientId = 4, AnamnesisId = 1, Allergies = new List<Allergies>(), Medicaments = new List<Medicament>(), ActiveMedicalRecord = true },
                new MedicalRecord { Id = 5, PatientId = 5, AnamnesisId = 1, Allergies = new List<Allergies>(), Medicaments = new List<Medicament>(), ActiveMedicalRecord = true },
                new MedicalRecord { Id = 6, PatientId = 6, AnamnesisId = 1, Allergies = new List<Allergies>(), Medicaments = new List<Medicament>(), ActiveMedicalRecord = true }
            );

            modelBuilder.Entity<MedicalExaminationReport>().HasData(
                new MedicalExaminationReport { Id = 1, Comment = "Pacijent je dobro i nema vecih problema", PublishingDate = new DateTime(2020, 09, 20, 10, 30, 0), MedicalExaminationId = 3 },
                new MedicalExaminationReport { Id = 2, Comment = "Pacijent je veoma dobro i nema vecih problema", PublishingDate = new DateTime(2020, 11, 23, 10, 30, 0), MedicalExaminationId = 4 },
                new MedicalExaminationReport { Id = 3, Comment = "Pacijent ima virus", PublishingDate = new DateTime(2020, 9, 12, 10, 30, 0), MedicalExaminationId = 2 },
                new MedicalExaminationReport { Id = 4, Comment = "Pacijent je lose", PublishingDate = new DateTime(2020, 10, 14, 10, 30, 0), MedicalExaminationId = 2 },
                new MedicalExaminationReport { Id = 5, Comment = "Pacijent ima virus", PublishingDate = new DateTime(2020, 11, 18, 10, 30, 0), MedicalExaminationId = 2 }
            );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription { Id = 1, Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 11, 30, 10, 30, 0), MedicalExaminationId = 4, Medicaments = new List<Medicament>() },
                new Prescription { Id = 2, Comment = "Svakodnevno koristite prepisani lek", PublishingDate = new DateTime(2020, 09, 12, 10, 30, 0), MedicalExaminationId = 3, Medicaments = new List<Medicament>() },
                new Prescription { Id = 3, Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 12, 25, 10, 30, 0), MedicalExaminationId = 2, Medicaments = new List<Medicament>() },
                new Prescription { Id = 4, Comment = "Ne preskacite konzumiranje leka", PublishingDate = new DateTime(2020, 10, 12, 03, 30, 0), MedicalExaminationId = 2, Medicaments = new List<Medicament>() },
                new Prescription { Id = 5, Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 11, 26, 10, 30, 0), MedicalExaminationId = 4, Medicaments = new List<Medicament>() }
            );

            modelBuilder.Entity<EPrescription>().HasData(
                new EPrescription { Id = 1, PatientId = 1, PatientName = "Petar", Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 11, 30, 10, 30, 0), MedicamentName = "Aspirin" },
                new EPrescription { Id = 2, PatientId = 2, PatientName = "Mica", Comment = "Svakodnevno koristite prepisani lek", PublishingDate = new DateTime(2020, 09, 12, 10, 30, 0), MedicamentName = "Brufen" },
                new EPrescription { Id = 3, PatientId = 3, PatientName = "Zika", Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 12, 25, 10, 30, 0), MedicamentName = "Vitamin B" },
                new EPrescription { Id = 4, PatientId = 5, PatientName = "Ivan", Comment = "Ne preskacite konzumiranje leka", PublishingDate = new DateTime(2020, 10, 12, 03, 30, 0), MedicamentName = "Panadol" },
                new EPrescription { Id = 5, PatientId = 6, PatientName = "Marko", Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 11, 26, 10, 30, 0), MedicamentName = "Andol" }
              );

            modelBuilder.Entity<Medicament>().HasData(
                new Medicament { Id = 1, Code = "L123", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 1, PrescriptionId = 1 },
                new Medicament { Id = 2, Code = "L233", Name = "Panadol", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 2, PrescriptionId = 1 },
                new Medicament { Id = 3, Code = "L523", Name = "Paracetamol", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 3, PrescriptionId = 3 },
                new Medicament { Id = 4, Code = "L423", Name = "Vitamin B", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 4, PrescriptionId = 2 },
                new Medicament { Id = 5, Code = "L233", Name = "Panadol", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 14, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 1, PrescriptionId = 2 }
            );

            modelBuilder.Entity<Room>().HasData(
                  new Room { Id = 1, RoomId = "101", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "101", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 2, RoomId = "201", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "201", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 3, RoomId = "301", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "301", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 4, RoomId = "Room 1", TypeOfRoomId = 3, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "R1", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 5, RoomId = "Room 2", TypeOfRoomId = 3, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "R2", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 6, RoomId = "Room 3", TypeOfRoomId = 3, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "R3", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 7, RoomId = "Room 4", TypeOfRoomId = 3, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "R4", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 8, RoomId = "Room 5", TypeOfRoomId = 3, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "R5", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 9, RoomId = "Room 6", TypeOfRoomId = 3, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "R6", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 10, RoomId = "Doctor office 3", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "Dr3", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 11, RoomId = "Doctor office 4", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Dr4", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 12, RoomId = "Doctor office 1", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Dr1A", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 13, RoomId = "Doctor office 2", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Dr2A", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 14, RoomId = "Doctor office 1", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Dr1B", NameOfClinic = "B", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 15, RoomId = "Doctor office 2", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Dr2B", NameOfClinic = "B", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 16, RoomId = "Surgery room 1", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Sr1A", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 17, RoomId = "Surgery room 2", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Sr2A", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 18, RoomId = "Surgery room 3", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Sr3A", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 19, RoomId = "Surgery room 1", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Sr1B", NameOfClinic = "B", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 20, RoomId = "Surgery room 2", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Sr2B", NameOfClinic = "B", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 21, RoomId = "Surgery room 3", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Sr3B", NameOfClinic = "B", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 22, RoomId = "Radiology", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "RadA", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 23, RoomId = "Radiology", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "RadB", NameOfClinic = "B", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 24, RoomId = "Cardiology", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Card", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 25, RoomId = "Patology", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Pat", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 26, RoomId = "Neurology", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Neur", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 27, RoomId = "Pyshiatric", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Psyc", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 28, RoomId = "Hospital A", TypeOfRoomId = 4, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "HospitalA", NameOfClinic = "A", NumberOfFloor = "", BedCapacity = "", AvailableBeds = "", OccupiedBeds = "", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 29, RoomId = "Hospital B", TypeOfRoomId = 4, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "HospitalB", NameOfClinic = "A", NumberOfFloor = "", BedCapacity = "", AvailableBeds = "", OccupiedBeds = "", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 30, RoomId = "Pharmacy", TypeOfRoomId = 4, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "PhA", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "", AvailableBeds = "", OccupiedBeds = "", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 31, RoomId = "Pharmacy", TypeOfRoomId = 4, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "PhB", NameOfClinic = "B", NumberOfFloor = "", BedCapacity = "", AvailableBeds = "", OccupiedBeds = "", StartWorkTime = "00", EndWorkTime = "24" }


             );

            modelBuilder.Entity<InventaryRoom>().HasData(
               new InventaryRoom { Id = 1, Name = "Stolovi", Quantity = 1, RoomId = 1 },
               new InventaryRoom { Id = 2, Name = "Stolice", Quantity = 1, RoomId = 1 },
               new InventaryRoom { Id = 3, Name = "Kreveti", Quantity = 1, RoomId = 2 }
           );

            modelBuilder.Entity<TypeOfRoom>().HasData(
                new TypeOfRoom { Id = 1, NameOfType = "Soba za preglede" },
                new TypeOfRoom { Id = 2, NameOfType = "Soba za operacije" },
                new TypeOfRoom { Id = 3, NameOfType = "Soba za lezanje" },
                new TypeOfRoom { Id = 4, NameOfType = "Ostale prostorije" }
            );

            modelBuilder.Entity<Allergies>().HasData(
                new Allergies { Id = 1, Name = "Penicilin", MedicalRecordId = 1 },
                new Allergies { Id = 2, Name = "Brufen", MedicalRecordId = 3 },
                new Allergies { Id = 3, Name = "Panadol", MedicalRecordId = 2 },
                new Allergies { Id = 4, Name = "Ambrozija", MedicalRecordId = 1 }
            );

            modelBuilder.Entity<Anamnesis>().HasData(
              new Anamnesis { Id = 1, Description = "Pacijent je dobro", Diagnosis = new List<Diagnosis>(), Symptoms = new List<Symptoms>() },
              new Anamnesis { Id = 2, Description = "Pacijent je loše", Diagnosis = new List<Diagnosis>(), Symptoms = new List<Symptoms>() },
              new Anamnesis { Id = 3, Description = "Pacijent je vrlo dobro", Diagnosis = new List<Diagnosis>(), Symptoms = new List<Symptoms>() }
            );

            modelBuilder.Entity<Symptoms>().HasData(
                new Symptoms { Id = 1, Name = "Temperatura", AnamnesisId = 2 },
                new Symptoms { Id = 2, Name = "Kašalj", AnamnesisId = 1 },
                new Symptoms { Id = 3, Name = "Glavobolja", AnamnesisId = 2 }
            );

            modelBuilder.Entity<Diagnosis>().HasData(
                new Diagnosis { Id = 1, Name = "Prehlada", AnamnesisId = 1 },
                new Diagnosis { Id = 2, Name = "Virus", AnamnesisId = 2 },
                new Diagnosis { Id = 3, Name = "Migrena", AnamnesisId = 2 }
            );

            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Beograd", Address = "Brace Jerkovic 1", PostCode = 11000, CountryId = 1 },
                new City { Id = 2, Name = "Novi Sad", Address = "Bulevar Cara Lazara 1", PostCode = 22100, CountryId = 1 }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Srbija" }
            );

            modelBuilder.Entity<PatientFeedback>().HasData(
                new PatientFeedback { Id = 1, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 10, 30, 10, 30, 0), IsForPublishing = true, IsPublished = true, IsAnonymous = false, PatientId = 1 },
                new PatientFeedback { Id = 2, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 8, 15, 9, 17, 0), IsForPublishing = true, IsPublished = true, IsAnonymous = true, PatientId = 2 },
                new PatientFeedback { Id = 3, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 9, 3, 11, 30, 0), IsForPublishing = true, IsPublished = false, IsAnonymous = true, PatientId = 3 },
                new PatientFeedback { Id = 4, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 11, 6, 8, 30, 0), IsForPublishing = false, IsPublished = false, IsAnonymous = false, PatientId = 4 },
                new PatientFeedback { Id = 5, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 10, 18, 7, 30, 0), IsForPublishing = false, IsPublished = false, IsAnonymous = false, PatientId = 2 },
                new PatientFeedback { Id = 6, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 10, 15, 6, 30, 0), IsForPublishing = true, IsPublished = false, IsAnonymous = true, PatientId = 4 }
            );

            modelBuilder.Entity<Survey>().HasData(
                new Survey { Id = 1, Title = "Naslov", PublishingDate = new DateTime(2020, 11, 6, 8, 30, 0), CommentSurvey = "Sve je super u bolnici", MedicalExaminationId = 1, Answers = new List<Answer>() },
                new Survey { Id = 2, Title = "Naslov", PublishingDate = new DateTime(2020, 11, 6, 8, 30, 0), CommentSurvey = "Sve je super u bolnici", MedicalExaminationId = 2, Answers = new List<Answer>() }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, QuestionText = "Ljubaznost doktora prema pacijentu", QuestionType = QuestionType.Doctor },
                new Question { Id = 2, QuestionText = "Posvećenost doktora pacijentu", QuestionType = QuestionType.Doctor },
                new Question { Id = 3, QuestionText = "Pružanje informacija od strane doktora o mom zdravstvenom stanju i mogućnostima lečenja", QuestionType = QuestionType.Doctor },
                new Question { Id = 4, QuestionText = "Ljubaznost medicinskog osoblja prema pacijentu", QuestionType = QuestionType.Staff },
                new Question { Id = 5, QuestionText = "Posvećenost medicinskog osoblja pacijentu", QuestionType = QuestionType.Staff },
                new Question { Id = 6, QuestionText = "Profesionalizam u obavljanju svoji duznosti medicinskog osoblja", QuestionType = QuestionType.Staff },
                new Question { Id = 7, QuestionText = "Ispunjenost vremena zakazanog termina i vreme provedeno u cekonici", QuestionType = QuestionType.Hospital },
                new Question { Id = 8, QuestionText = "Higijena unutar bolnice", QuestionType = QuestionType.Hospital },
                new Question { Id = 9, QuestionText = "Opremljenost bolnice", QuestionType = QuestionType.Hospital }
            );

            modelBuilder.Entity<Answer>().HasData(
               new Answer { Id = 1, Grade = GradeOfQuestion.Fair, QuestionId = 1, SurveyId = 1 },
               new Answer { Id = 2, Grade = GradeOfQuestion.Excellent, QuestionId = 2, SurveyId = 1 },
               new Answer { Id = 3, Grade = GradeOfQuestion.Good, QuestionId = 3, SurveyId = 1 },
               new Answer { Id = 4, Grade = GradeOfQuestion.VeryGood, QuestionId = 4, SurveyId = 1 },
               new Answer { Id = 5, Grade = GradeOfQuestion.Poor, QuestionId = 5, SurveyId = 1 },
               new Answer { Id = 6, Grade = GradeOfQuestion.Excellent, QuestionId = 6, SurveyId = 1 },
               new Answer { Id = 7, Grade = GradeOfQuestion.Fair, QuestionId = 7, SurveyId = 1 },
               new Answer { Id = 8, Grade = GradeOfQuestion.Fair, QuestionId = 8, SurveyId = 1 },
               new Answer { Id = 9, Grade = GradeOfQuestion.VeryGood, QuestionId = 9, SurveyId = 2 },
               new Answer { Id = 10, Grade = GradeOfQuestion.Good, QuestionId = 1, SurveyId = 2 },
               new Answer { Id = 11, Grade = GradeOfQuestion.Excellent, QuestionId = 2, SurveyId = 2 },
               new Answer { Id = 12, Grade = GradeOfQuestion.Excellent, QuestionId = 3, SurveyId = 2 },
               new Answer { Id = 13, Grade = GradeOfQuestion.VeryGood, QuestionId = 4, SurveyId = 2 },
               new Answer { Id = 14, Grade = GradeOfQuestion.Fair, QuestionId = 5, SurveyId = 2 },
               new Answer { Id = 15, Grade = GradeOfQuestion.Good, QuestionId = 6, SurveyId = 2 },
               new Answer { Id = 16, Grade = GradeOfQuestion.Good, QuestionId = 7, SurveyId = 2 },
               new Answer { Id = 17, Grade = GradeOfQuestion.Excellent, QuestionId = 8, SurveyId = 2 },
               new Answer { Id = 18, Grade = GradeOfQuestion.VeryGood, QuestionId = 9, SurveyId = 2 }
           );

            modelBuilder.Entity<DoctorWorkDay>().HasData(
                new DoctorWorkDay { Id = 1, DoctorId = 1, Date = new DateTime(2020, 12, 20), RoomId = 1 },
                new DoctorWorkDay { Id = 2, DoctorId = 2, Date = new DateTime(2020, 12, 18), RoomId = 2 },
                new DoctorWorkDay { Id = 3, DoctorId = 3, Date = new DateTime(2020, 12, 25), RoomId = 2 },
                new DoctorWorkDay { Id = 4, DoctorId = 4, Date = new DateTime(2020, 12, 20), RoomId = 3 },
                new DoctorWorkDay { Id = 5, DoctorId = 2, Date = new DateTime(2020, 12, 21), RoomId = 3 },
                new DoctorWorkDay { Id = 6, DoctorId = 9, Date = new DateTime(2020, 11, 21), RoomId = 1 },
                new DoctorWorkDay { Id = 7, DoctorId = 8, Date = new DateTime(2020, 11, 23), RoomId = 2 },
                new DoctorWorkDay { Id = 8, DoctorId = 7, Date = new DateTime(2020, 11, 28), RoomId = 2 },
                new DoctorWorkDay { Id = 9, DoctorId = 6, Date = new DateTime(2020, 11, 29), RoomId = 3 },
                new DoctorWorkDay { Id = 10, DoctorId = 5, Date = new DateTime(2020, 11, 30), RoomId = 3 },
                 new DoctorWorkDay { Id = 11, DoctorId = 1, Date = new DateTime(2020, 12, 24), RoomId = 10 },
                new DoctorWorkDay { Id = 12, DoctorId = 2, Date = new DateTime(2020, 12, 22), RoomId = 11 },
                new DoctorWorkDay { Id = 13, DoctorId = 1, Date = new DateTime(2020, 12, 28), RoomId = 3 },
                new DoctorWorkDay { Id = 14, DoctorId = 1, Date = new DateTime(2021, 4, 4), RoomId = 1}
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, Canceled = false, CancellationDate = new DateTime(), StartTime = new DateTime(2020, 12, 20, 8, 0, 0), EndTime = new DateTime(2020, 12, 20, 8, 30, 0), DoctorWorkDayId = 1, MedicalExaminationId = 1 },
                new Appointment { Id = 2, Canceled = false, CancellationDate = new DateTime(), StartTime = new DateTime(2020, 12, 18, 8, 30, 0), EndTime = new DateTime(2020, 12, 18, 9, 0, 0), DoctorWorkDayId = 2, MedicalExaminationId = 2 },
                new Appointment { Id = 3, Canceled = true, CancellationDate = new DateTime(2020, 12, 22, 8, 30, 0), StartTime = new DateTime(2020, 12, 25, 8, 30, 0), EndTime = new DateTime(2020, 12, 25, 9, 0, 0), DoctorWorkDayId = 3, MedicalExaminationId = 4 },
                new Appointment { Id = 4, Canceled = false, CancellationDate = new DateTime(), StartTime = new DateTime(2020, 12, 20, 8, 30, 0), EndTime = new DateTime(2020, 12, 20, 9, 0, 0), DoctorWorkDayId = 4, MedicalExaminationId = 6 },
                new Appointment { Id = 5, Canceled = false, CancellationDate = new DateTime(), StartTime = new DateTime(2020, 12, 10, 12, 00, 0), EndTime = new DateTime(2020, 12, 10, 12, 30, 0), DoctorWorkDayId = 4, MedicalExaminationId = 4 },
                new Appointment { Id = 6, Canceled = false, CancellationDate = new DateTime(), StartTime = new DateTime(2020, 12, 09, 15, 30, 0), EndTime = new DateTime(2020, 12, 09, 16, 00, 0), DoctorWorkDayId = 4, MedicalExaminationId = 2 },
                new Appointment { Id = 7, Canceled = false, CancellationDate = new DateTime(), StartTime = new DateTime(2020, 12, 18, 15, 30, 0), EndTime = new DateTime(2020, 12, 18, 16, 0, 0), DoctorWorkDayId = 2, MedicalExaminationId = 5 },
                new Appointment { Id = 8, Canceled = false, CancellationDate = new DateTime(), StartTime = new DateTime(2020, 12, 21, 8, 30, 0), EndTime = new DateTime(2020, 12, 21, 9, 0, 0), DoctorWorkDayId = 5, MedicalExaminationId = 3 },
                new Appointment { Id = 9, Canceled = true, CancellationDate = new DateTime(2020, 11, 18, 8, 0, 0), StartTime = new DateTime(2020, 11, 21, 8, 0, 0), EndTime = new DateTime(2020, 11, 21, 8, 30, 0), DoctorWorkDayId = 6, MedicalExaminationId = 7 },
                new Appointment { Id = 10, Canceled = true, CancellationDate = new DateTime(2020, 11, 20, 8, 0, 0), StartTime = new DateTime(2020, 11, 23, 8, 0, 0), EndTime = new DateTime(2020, 11, 23, 8, 30, 0), DoctorWorkDayId = 7, MedicalExaminationId = 8 },
                new Appointment { Id = 11, Canceled = true, CancellationDate = new DateTime(2020, 11, 25, 8, 0, 0), StartTime = new DateTime(2020, 11, 28, 8, 0, 0), EndTime = new DateTime(2020, 11, 28, 8, 30, 0), DoctorWorkDayId = 8, MedicalExaminationId = 9 },
                new Appointment { Id = 12, Canceled = true, CancellationDate = new DateTime(2020, 11, 26, 8, 0, 0), StartTime = new DateTime(2020, 11, 29, 8, 0, 0), EndTime = new DateTime(2020, 11, 29, 8, 30, 0), DoctorWorkDayId = 9, MedicalExaminationId = 10 },
                new Appointment { Id = 13, Canceled = true, CancellationDate = new DateTime(2020, 11, 27, 8, 0, 0), StartTime = new DateTime(2020, 11, 30, 8, 0, 0), EndTime = new DateTime(2020, 11, 30, 8, 30, 0), DoctorWorkDayId = 10, MedicalExaminationId = 11 },
                new Appointment { Id = 14, Canceled = true, CancellationDate = new DateTime(2020, 11, 18, 8, 0, 0), StartTime = new DateTime(2020, 11, 21, 9, 0, 0), EndTime = new DateTime(2020, 11, 21, 9, 30, 0), DoctorWorkDayId = 6, MedicalExaminationId = 12 },
                new Appointment { Id = 15, Canceled = false, CancellationDate = new DateTime(), StartTime = new DateTime(2021, 4, 4, 9, 0, 0), EndTime = new DateTime(2021, 4, 4, 9, 30, 0), DoctorWorkDayId = 14, MedicalExaminationId = 12 }
            );

            modelBuilder.Entity<MedicalExamination>().HasData(
                new MedicalExamination { Id = 1, SurveyFilled = false, ShortDescription = "Sve je bilo u redu na pregledu", RoomId = 1, DoctorId = 1, PatientId = 2 },
                new MedicalExamination { Id = 2, SurveyFilled = false, ShortDescription = "Pacijent je imao glavobolju", RoomId = 2, DoctorId = 2, PatientId = 1 },
                new MedicalExamination { Id = 3, SurveyFilled = false, ShortDescription = "Sve je bilo u redu na pregledu", RoomId = 3, DoctorId = 2, PatientId = 1 },
                new MedicalExamination { Id = 4, SurveyFilled = false, ShortDescription = "Pacijenta je boleo stomak", RoomId = 2, DoctorId = 3, PatientId = 1 },
                new MedicalExamination { Id = 5, SurveyFilled = false, ShortDescription = "Pacijenta je boleo stomak", RoomId = 2, DoctorId = 2, PatientId = 3 },
                new MedicalExamination { Id = 6, SurveyFilled = false, ShortDescription = "Sve je bilo u redu na pregledu", RoomId = 3, DoctorId = 4, PatientId = 1 },
                new MedicalExamination { Id = 7, SurveyFilled = false, ShortDescription = "Sve je bilo u redu na pregledu", RoomId = 1, DoctorId = 9, PatientId = 5 },
                new MedicalExamination { Id = 8, SurveyFilled = false, ShortDescription = "Pacijenta je boleo stomak", RoomId = 2, DoctorId = 8, PatientId = 5 },
                new MedicalExamination { Id = 9, SurveyFilled = false, ShortDescription = "Pacijenta je boleo stomak", RoomId = 2, DoctorId = 7, PatientId = 5 },
                new MedicalExamination { Id = 10, SurveyFilled = false, ShortDescription = "Sve je bilo u redu na pregledu", RoomId = 3, DoctorId = 6, PatientId = 6 },
                new MedicalExamination { Id = 11, SurveyFilled = false, ShortDescription = "Sve je bilo u redu na pregledu", RoomId = 3, DoctorId = 5, PatientId = 6 },
                new MedicalExamination { Id = 12, SurveyFilled = false, ShortDescription = "Pacijenta je boleo stomak", RoomId = 1, DoctorId = 9, PatientId = 6 },
                new MedicalExamination { Id = 13, SurveyFilled = false, ShortDescription = "Pacijenta je boleo stomak", RoomId = 1, DoctorId = 1, PatientId = 1 }
            );

            modelBuilder.Entity<Pharmacies>().HasData(
                new Pharmacies { Id = 1, Name = "Apoteka1", Key = "1234", Link = "apoteka1.com" },
                new Pharmacies { Id = 2, Name = "Apoteka2", Key = "5678", Link = "apoteka2.com" },
                new Pharmacies { Id = 3, Name = "Apoteka3", Key = "9101112", Link = "apoteka3.com" }
            );
        }
    }
}
using Backend.Repository.UsersRepository;
using Backend.Service.UsersServices;
using Model.AllActors;
using Model.Term;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.HospitalMapUnitTests
{
    public class DoctorWorkDayTests
    {
        [Fact]
        public void Get_doctor_work_day_by_date_and_doctor_id()
        {
            DoctorWorkDayService doctorWorkDayService = new DoctorWorkDayService(CreateDoctorWorkDayStubRepository(), null);

            DoctorWorkDay result = doctorWorkDayService.GetDoctorWorkDayByDateAndDoctorId(new DateTime(2022, 12, 7), 2);

            Assert.NotNull(result);
        }

        [Fact]
        public void Get_doctor_work_day_by_date_and_doctor_id_invalid()
        {
            DoctorWorkDayService doctorWorkDayService = new DoctorWorkDayService(CreateDoctorWorkDayStubRepository(), null);

            DoctorWorkDay result = doctorWorkDayService.GetDoctorWorkDayByDateAndDoctorId(new DateTime(2022, 12, 7), 1);

            Assert.Null(result);
        }

        [Fact]
        public void Get_available_appointments_by_date_and_doctor_id()
        {
            DoctorWorkDayService doctorWorkDayService = new DoctorWorkDayService(CreateDoctorWorkDayStubRepository(), null);

            List<Appointment> result = doctorWorkDayService.GetAvailableAppointmentsByDateAndDoctorId(new DateTime(2022, 12, 5), 1);

            Assert.Equal(22, result.Count);
        }

        [Fact]
        public void Get_available_appointments_by_date_and_doctor_id_invalid()
        {
            DoctorWorkDayService doctorWorkDayService = new DoctorWorkDayService(CreateDoctorWorkDayStubRepository(), null);

            List<Appointment> result = doctorWorkDayService.GetAvailableAppointmentsByDateAndDoctorId(new DateTime(2022, 12, 7), 2);

            Assert.NotEqual(22, result.Count);
        }

        [Fact]
        public void Get_available_appointments_by_date_range_and_doctor_id()
        {
            DoctorWorkDayService doctorWorkDayService = new DoctorWorkDayService(CreateDoctorWorkDayStubRepository(), null);

            Dictionary<int, List<Appointment>> result = doctorWorkDayService.GetAvailableAppointmentsByDateRangeAndDoctorId(new DateTime(2022, 12, 5), new DateTime(2022, 12, 6), 1);
            
            Assert.Equal(46, result[1].Count + result[3].Count);
        }
        
        [Fact]
        public void Get_available_appointments_by_date_range_and_doctor_id_invalid()
        {
            DoctorWorkDayService doctorWorkDayService = new DoctorWorkDayService(CreateDoctorWorkDayStubRepository(), null);

            Dictionary<int, List<Appointment>> result = doctorWorkDayService.GetAvailableAppointmentsByDateRangeAndDoctorId(new DateTime(2022, 12, 5), new DateTime(2022, 12, 7), 2);

            Assert.NotEqual(21, result[2].Count);
        }
        
        [Fact]
        public void Get_available_appointments_including_date_range_priority()
        {
            DoctorService doctorService = new DoctorService(CreateDoctorStubRepository());
            DoctorWorkDayService doctorWorkDayService = new DoctorWorkDayService(CreateDoctorWorkDayStubRepository(), doctorService);

            Dictionary<int, List<Appointment>> result = doctorWorkDayService.GetAvailableAppointmentsByDateRangeAndDoctorIdIncludingPriority(new DateTime(2022, 12, 8), new DateTime(2022, 12, 8), 3, "DateRange");

            Assert.Equal(48, result[4].Count + result[6].Count + result[8].Count);
        }
        
        [Fact]
        public void Get_available_appointments_including_date_range_priority_invalid()
        {
            DoctorService doctorService = new DoctorService(CreateDoctorStubRepository());
            DoctorWorkDayService doctorWorkDayService = new DoctorWorkDayService(CreateDoctorWorkDayStubRepository(), doctorService);

            Dictionary<int, List<Appointment>> result = doctorWorkDayService.GetAvailableAppointmentsByDateRangeAndDoctorIdIncludingPriority(new DateTime(2022, 12, 8), new DateTime(2022, 12, 8), 3, "DateRange");

            Assert.NotEqual(47, result[4].Count + result[6].Count + result[8].Count);
        }
        
        [Fact]
        public void Get_available_appointments_including_doctor_priority()
        {
            DoctorWorkDayService doctorWorkDayService = new DoctorWorkDayService(CreateDoctorWorkDayStubRepository(), null);

            Dictionary<int, List<Appointment>> result = doctorWorkDayService.GetAvailableAppointmentsByDateRangeAndDoctorIdIncludingPriority(new DateTime(2022, 12, 8), new DateTime(2022, 12, 8), 3, "Doctor");

            Assert.Equal(48, result[5].Count + result[6].Count + result[7].Count);
        }
       
        [Fact]
        public void Get_available_appointments_including_doctor_priority_invalid()
        {
            DoctorWorkDayService doctorWorkDayService = new DoctorWorkDayService(CreateDoctorWorkDayStubRepository(), null);

            Dictionary<int, List<Appointment>> result = doctorWorkDayService.GetAvailableAppointmentsByDateRangeAndDoctorIdIncludingPriority(new DateTime(2022, 12, 8), new DateTime(2022, 12, 8), 3, "Doctor");

            Assert.NotEqual(49, result[5].Count + result[6].Count + result[7].Count);
        }

        private static IDoctorWorkDayRepository CreateDoctorWorkDayStubRepository()
        {
            var stubRepository = new Mock<IDoctorWorkDayRepository>();

            var firstDoctorAppointments = new List<Appointment>();
            var secondDoctorAppointments = new List<Appointment>();
            var thirdDoctorAppointments = new List<Appointment>();
            var doctorWorkDays = new List<DoctorWorkDay>();
            firstDoctorAppointments.Add(new Appointment(1, true, new DateTime(2022, 12, 5, 8, 0, 0), new DateTime(2022, 12, 5, 8, 30, 0)));
            firstDoctorAppointments.Add(new Appointment(2, false, new DateTime(2022, 12, 5, 8, 30, 0), new DateTime(2022, 12, 5, 9, 0, 0)));
            firstDoctorAppointments.Add(new Appointment(3, false, new DateTime(2022, 12, 5, 10, 30, 0), new DateTime(2022, 12, 5, 11, 0, 0)));
            secondDoctorAppointments.Add(new Appointment(4, false, new DateTime(2022, 12, 7, 15, 0, 0), new DateTime(2022, 12, 7, 15, 30, 0)));
            secondDoctorAppointments.Add(new Appointment(5, false, new DateTime(2022, 12, 7, 16, 0, 0), new DateTime(2022, 12, 7, 16, 30, 0)));
            secondDoctorAppointments.Add(new Appointment(6, false, new DateTime(2022, 12, 7, 18, 0, 0), new DateTime(2022, 12, 7, 18, 30, 0)));
            secondDoctorAppointments.Add(new Appointment(7, false, new DateTime(2022, 12, 7, 12, 30, 0), new DateTime(2022, 12, 7, 13, 0, 0)));

            DateTime secondStartTime = new DateTime(2022, 12, 8, 8, 0, 0);
            List<Appointment> result = new List<Appointment>();
            for (int i = 0; i < 24; i++)
            {
                thirdDoctorAppointments.Add(new Appointment(8 + i, false, secondStartTime.AddMinutes(30 * i), secondStartTime.AddMinutes(30 * (i + 1))));
            }

            doctorWorkDays.Add(new DoctorWorkDay(1, new DateTime(2022, 12, 5), 1, new Doctor { Id = 1, Name = "Marko", Surname = "Markovic", Specialitation = new Model.Doctor.Specialitation("Kardiolog") }, firstDoctorAppointments));
            doctorWorkDays.Add(new DoctorWorkDay(2, new DateTime(2022, 12, 7), 2, new Doctor { Id = 2, Name = "Pera", Surname = "Peric", Specialitation = new Model.Doctor.Specialitation("Lekar opste prakse") }, secondDoctorAppointments));
            doctorWorkDays.Add(new DoctorWorkDay(3, new DateTime(2022, 12, 6), 1, new Doctor { Id = 1, Name = "Marko", Surname = "Markovic", Specialitation = new Model.Doctor.Specialitation("Kardiolog") }, new List<Appointment>()));
            doctorWorkDays.Add(new DoctorWorkDay(4, new DateTime(2022, 12, 8), 1, new Doctor { Id = 1, Name = "Marko", Surname = "Markovic", Specialitation = new Model.Doctor.Specialitation("Kardiolog") }, new List<Appointment>()));
            doctorWorkDays.Add(new DoctorWorkDay(5, new DateTime(2022, 12, 7), 3, new Doctor { Id = 3, Name = "Mika", Surname = "Markovic", Specialitation = new Model.Doctor.Specialitation("Lekar opste prakse") }, new List<Appointment>()));
            doctorWorkDays.Add(new DoctorWorkDay(6, new DateTime(2022, 12, 8), 3, new Doctor { Id = 3, Name = "Mika", Surname = "Markovic", Specialitation = new Model.Doctor.Specialitation("Lekar opste prakse") }, thirdDoctorAppointments));
            doctorWorkDays.Add(new DoctorWorkDay(7, new DateTime(2022, 12, 9), 3, new Doctor { Id = 3, Name = "Mika", Surname = "Markovic", Specialitation = new Model.Doctor.Specialitation("Lekar opste prakse") }, new List<Appointment>()));
            doctorWorkDays.Add(new DoctorWorkDay(8, new DateTime(2022, 12, 8), 2, new Doctor { Id = 2, Name = "Pera", Surname = "Peric", Specialitation = new Model.Doctor.Specialitation("Lekar opste prakse") }, new List<Appointment>()));

            stubRepository.Setup(doctorWorkDayRepository => doctorWorkDayRepository.GetAllEntities()).Returns(doctorWorkDays);
            return stubRepository.Object;
        }

        private static IDoctorRepository CreateDoctorStubRepository()
        {
            var stubRepository = new Mock<IDoctorRepository>();

            List<Doctor> doctors = new List<Doctor>();
            doctors.Add(new Doctor { Id = 1, Name = "Marko", Surname = "Markovic", Specialitation = new Model.Doctor.Specialitation("Kardiolog") });
            doctors.Add(new Doctor { Id = 2, Name = "Pera", Surname = "Peric", Specialitation = new Model.Doctor.Specialitation("Lekar opste prakse") });
            doctors.Add(new Doctor { Id = 3, Name = "Mika", Surname = "Markovic", Specialitation = new Model.Doctor.Specialitation("Lekar opste prakse") });

            stubRepository.Setup(doctorRepository => doctorRepository.GetAllEntities()).Returns(doctors);
            stubRepository.Setup(doctorRepository => doctorRepository.GetEntity(It.IsAny<int>())).Returns((int id) => doctors.Find(d => d.Id == id));
            return stubRepository.Object;
        }
    }
}
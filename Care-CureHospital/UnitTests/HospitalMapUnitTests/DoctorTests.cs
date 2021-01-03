using Backend.Repository.UsersRepository;
using Backend.Service.UsersServices;
using Model.AllActors;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.HospitalMapUnitTests
{
    public class DoctorTests
    {
        [Fact]
        public void Find_doctors_by_specialization()
        {
            DoctorService doctorService = new DoctorService(CreateDoctorStubRepository());

            List<Doctor> result = doctorService.GetAllDoctorsBySpecialization(1);

            Assert.NotEmpty(result);
        }

        [Fact]
        public void Not_found_doctors_by_specialization()
        {
            DoctorService doctorService = new DoctorService(CreateDoctorStubRepository());

            List<Doctor> result = doctorService.GetAllDoctorsBySpecialization(3);

            Assert.Empty(result);
        }

        private static IDoctorRepository CreateDoctorStubRepository()
        {
            var stubRepository = new Mock<IDoctorRepository>();

            List<Doctor> doctors = new List<Doctor>();
            doctors.Add(new Doctor { Id = 1, Name = "Marko", Surname = "Markovic",  SpecialitationId = 1});
            doctors.Add(new Doctor { Id = 2, Name = "Pera", Surname = "Peric", SpecialitationId = 2 });
            doctors.Add(new Doctor { Id = 3, Name = "Mika", Surname = "Markovic", SpecialitationId = 2 });
            doctors.Add(new Doctor { Id = 4, Name = "Zika", Surname = "Peric", SpecialitationId = 1 });
            doctors.Add(new Doctor { Id = 5, Name = "Nikola", Surname = "Markovic", SpecialitationId = 1 });
            doctors.Add(new Doctor { Id = 6, Name = "Luna", Surname = "Peric", SpecialitationId = 2 });

            stubRepository.Setup(doctorRepository => doctorRepository.GetAllEntities()).Returns(doctors);
            return stubRepository.Object;
        }
    }
}

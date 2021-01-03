using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Backend.Service.PharmaciesService;
using Backend.Model.Pharmacy;
using Backend.Repository.PharmacyRepository;

namespace UnitTests.IntegrationAdaptersUnitTests
{
    public class PharmacyTest
    {
        [Fact]
        public void Get_pharmacies()
        {
            PharmacyService pharmacyService = new PharmacyService(CreateStubRepository());

            List<Pharmacies> results = (List<Pharmacies>)pharmacyService.GetAllEntities();

            Assert.NotNull(results);
        }

        [Fact]
        public void Add_pharmacy()
        {
            PharmacyService pharmacyService = new PharmacyService(CreateStubRepository());

            Pharmacies pharmacy = pharmacyService.AddEntity(new Pharmacies("NekaApoteka","APi1","nekilink1"));

            Assert.NotNull(pharmacy);
        }

        private static IPharmacyRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPharmacyRepository>();

            var pharmacies = new List<Pharmacies>();
            pharmacies.Add(new Pharmacies("Benu1","api2","link2"));
            pharmacies.Add(new Pharmacies("Benu2","api3", "link3"));
  
            stubRepository.Setup(pharmacyRepository => pharmacyRepository.GetAllEntities()).Returns(pharmacies);
            stubRepository.Setup(pharmacy => pharmacy.AddEntity(It.IsAny<Pharmacies>())).Returns(new Pharmacies("Benu1", "api2", "link2"));

            return stubRepository.Object;
        }
    }
}

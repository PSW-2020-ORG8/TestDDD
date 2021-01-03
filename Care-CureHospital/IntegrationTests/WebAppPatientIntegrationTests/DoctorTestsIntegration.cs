using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using System.Net.Http;
using WebAppPatient;
using Xunit;

namespace IntegrationTests.WebAppPatientIntegrationTests
{
    public class DoctorTestsIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public DoctorTestsIntegration(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [MemberData(nameof(DoctorData))]
        public async void Get_All_Doctor_By_Doctor_Specialization_Id(int specializationId, HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            var response = await client.GetAsync("/api/doctor/getAllDoctorBySpecializationId/" + specializationId);

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        [Theory]
        [MemberData(nameof(DoctorSpecializationData))]
        public async void Get_All_Specialization(HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            var response = await client.GetAsync("/api/doctor/getAllSpecialization");

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        public static IEnumerable<object[]> DoctorData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { 1, HttpStatusCode.OK });
            return retVal;
        }

        public static IEnumerable<object[]> DoctorSpecializationData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { HttpStatusCode.OK });
            return retVal;
        }
    }
}

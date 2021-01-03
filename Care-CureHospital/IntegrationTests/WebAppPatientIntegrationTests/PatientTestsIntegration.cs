using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using WebAppPatient;
using Xunit;

namespace IntegrationTests.WebAppPatientIntegrationTests
{
    public class PatientTestsIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public PatientTestsIntegration(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [MemberData(nameof(PatientData))]
        public async void Block_Patient_Status_Code_Test(int patientId, HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            var response = await client.PutAsync("/api/patient/blockMaliciousPatient/" + patientId, new StringContent("5", Encoding.UTF8, "application/json"));

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        public static IEnumerable<object[]> PatientData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { 5, HttpStatusCode.OK });
            return retVal;
        }
    }
}

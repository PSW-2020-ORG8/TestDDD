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
    public class MedicalRecordTestsIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public MedicalRecordTestsIntegration(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [MemberData(nameof(MedicalRecordData))]
        public async void Medical_Record_Status_Code_Test(int patientId, HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            var response = await client.GetAsync("/api/medicalRecord/getForPatient/" + patientId);

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        public static IEnumerable<object[]> MedicalRecordData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { 1, HttpStatusCode.OK });
            retVal.Add(new object[] { 20, HttpStatusCode.NotFound });
            return retVal;
        }
    }
}

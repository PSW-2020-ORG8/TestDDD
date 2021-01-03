using Backend;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace IntegrationTests.IntegrationAdaptersIntegrationTest
{
    public class EPrescriptionTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public EPrescriptionTest(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [MemberData(nameof(EPrescriptionData))]
        public async void Find_EPrescriptions_For_Patient_Id(int patientId, HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/eprescription/getForPatient/" + patientId);

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        public static IEnumerable<object[]> EPrescriptionData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { 1, HttpStatusCode.OK });
            return retVal;
        }
    }
}

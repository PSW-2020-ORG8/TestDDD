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
    public class PrescriptionTestsIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public PrescriptionTestsIntegration(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [MemberData(nameof(PrescriptionData))]
        public async void Find_Prescriptions_With_Doctor_Searh_Parameter(HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/prescription/findPrescriptionsByDoctor?patientId=1&doctor=Aleksandar");

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        public static IEnumerable<object[]> PrescriptionData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { HttpStatusCode.OK });
            return retVal;
        }
    }
}

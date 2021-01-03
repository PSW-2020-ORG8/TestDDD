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
    public class MedicalExaminationReportTestsIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public MedicalExaminationReportTestsIntegration(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [MemberData(nameof(MedicalExaminationReportData))]
        public async void Find_Reports_With_Doctor_Searh_Parameter(HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/medicalExaminationReport/findReportsByDoctor?patientId=1&doctor=Aleksandar");

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        public static IEnumerable<object[]> MedicalExaminationReportData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { HttpStatusCode.OK });
            return retVal;
        }
    }
}

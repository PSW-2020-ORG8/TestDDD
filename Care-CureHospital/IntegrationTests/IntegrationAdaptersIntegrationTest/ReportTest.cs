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
    public class ReportTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public ReportTest(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [MemberData(nameof(ReportData))]
        public async void Get_All_Reports(HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            var response = await client.GetAsync("/api/report");

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        public static IEnumerable<object[]> ReportData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { HttpStatusCode.OK });
            return retVal;
        }
    }
}

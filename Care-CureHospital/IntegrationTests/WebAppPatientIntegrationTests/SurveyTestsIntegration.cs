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
    public class SurveyTestsIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        
        private readonly WebApplicationFactory<Startup> factory;

        public SurveyTestsIntegration(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [MemberData(nameof(SurveyData))]
        public async void Get_survey_results(HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/survey/getSurveyResults");

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        [Theory]
        [MemberData(nameof(SurveyData))]
        public async void Get_survey_results_for_doctors(HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/survey/getSurveyResultsForDoctors");

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        public static IEnumerable<object[]> SurveyData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { HttpStatusCode.OK });
            return retVal;
        }
    }
}

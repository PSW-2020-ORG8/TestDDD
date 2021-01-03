using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.RequestServices
{
    public class UrgentOrderService
    {
        public static IRestResponse<String> SendRequestForOrder()
        {
            var client = new RestSharp.RestClient("http://localhost:8080");
            var request = new RestRequest("/urgentOrder/forMedicament");
            var response = client.Get<String>(request);
            Console.WriteLine("Status: " + response.StatusCode.ToString());
            String result = response.Data;
            return response;
        }
    }
}

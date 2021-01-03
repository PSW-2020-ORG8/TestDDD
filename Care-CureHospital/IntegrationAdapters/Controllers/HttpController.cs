using System;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpController : ControllerBase
    {
         [HttpPost]
         public IActionResult SendFile()
         {
             StringBuilder builder = new StringBuilder();
             builder.Append("About medication consumption:");
             String medRep = builder.ToString();
             var test = "Files\\Report.json";
             System.IO.File.WriteAllText(test, medRep);
             try
             {
                 WebClient client = new WebClient();
                 Uri uriString = new Uri(@"http://localhost:8080/http/fileDown");
                 client.Credentials = CredentialCache.DefaultCredentials;
                 client.UploadFile(uriString, "POST", test);
                 client.Dispose();
                 return Ok(JsonConvert.SerializeObject(test));
             }
             catch (Exception e)
             {
             }
             return Ok();
         }
    }
}

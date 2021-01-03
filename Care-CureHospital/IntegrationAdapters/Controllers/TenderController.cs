using Backend;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController:ControllerBase
    {
        public TenderController() { }

        [HttpGet] //tender
        public IActionResult PublishTender()
        {
            App.Instance().TenderService.SendNotification();
            return Ok();
        }
    }
}

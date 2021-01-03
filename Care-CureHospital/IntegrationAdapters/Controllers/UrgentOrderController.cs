using Backend.Service.RequestServices;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrgentOrderController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMedicament()
        {
            return Ok(UrgentOrderService.SendRequestForOrder());
        }
    }
}

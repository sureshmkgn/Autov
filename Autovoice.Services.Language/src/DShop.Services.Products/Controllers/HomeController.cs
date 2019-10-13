using Microsoft.AspNetCore.Mvc;

namespace Autovoice.Services.Products.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("DShop Products Service");
    }
}
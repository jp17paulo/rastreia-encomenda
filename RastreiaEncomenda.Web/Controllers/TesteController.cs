using Microsoft.AspNetCore.Mvc;

namespace RastreiaEncomenda.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Olá API!");
        }
    }
}

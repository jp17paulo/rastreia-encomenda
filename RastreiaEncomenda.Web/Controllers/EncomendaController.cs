using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RastreiaEncomenda.Web.Controllers
{
    [ApiController]
    public class EncomendaController : ControllerBase
    {
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> ObtemInformacao()
        {
            return Ok(new {
                Codigo = "ON4676363876BR",
                Sro = "Objeto Entregue ao Destinatário"
            });
        }
    }
}

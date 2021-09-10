using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RastreiaEncomenda.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncomendaController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ObtemInformacao()
        {
            return Ok(new {
                Codigo = "ON4676363876BR",
                Sro = "Objeto Entregue ao Destinatário"
            });
        }
    }
}

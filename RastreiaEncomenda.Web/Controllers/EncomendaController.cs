using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RastreiaEncomenda.Web.Controllers
{

    [ApiController]
    public class EncomendaController : ControllerBase
    {
        [HttpGet]
        [Route("api/[controller]")]
                                                //api/encomenda?codigo=OP862398045B&sro="Objeto entregue ao destinatário"
        public async Task<IActionResult> ObtemInformacao(string codigo, string sro)
        {
            await Task.Delay(1);
            return Ok(new {
                Codigo = codigo,
                Sro = sro

            });
        }

       
    }
}

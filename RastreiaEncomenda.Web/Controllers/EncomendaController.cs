using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RastreiaEncomenda.Web.Servicos.Interfaces;
using Microsoft.Playwright;
using System.Collections.Generic;

namespace RastreiaEncomenda.Web.Controllers
{

    [ApiController]
    public class EncomendaController : ControllerBase
    {
        public readonly IEncomendaServico _encomendaServico;

        public EncomendaController(IEncomendaServico encomendaServico)
        {
            _encomendaServico = encomendaServico;
        }

        [HttpGet]
        [Route("api/v2/[controller]")]
        public async Task<IActionResult> ConsultaStatusEncomenda(string codigo)
        {
            var resultado = await _encomendaServico.ObtemStatusEncomenda(codigo);
            return Ok(resultado);
        }

       
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> ObtemInformacao(string codigo)
        {
                                            //api/encomenda?codigo=OP862398045BR
            var resultado = await _encomendaServico.ObtemStatusEncomenda(codigo);
            return Ok(resultado);

        }

    }

}
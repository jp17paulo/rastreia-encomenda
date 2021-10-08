using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RastreiaEncomenda.Web.Servicos.Interfaces;
using Microsoft.Playwright;

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

        //api/encomenda?codigo=OP862398045BR
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> ObtemInformacao(string codigo)
        {
            string lista = "";

            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });

            var context = await browser.NewContextAsync();

            // Open new page
            var page = await context.NewPageAsync();

            // Go to https://www2.correios.com.br/sistemas/rastreamento/default.cfm
            await page.GotoAsync("https://www2.correios.com.br/sistemas/rastreamento/default.cfm");

            // Click textarea[name="objetos"]
            await page.ClickAsync("textarea[name=\"objetos\"]");

            // Fill textarea[name="objetos"]
            await page.FillAsync("textarea[name=\"objetos\"]", "OP862398045BR");

            // Click text=Buscar
            await page.ClickAsync("text=Buscar");

           var tabela = await page.QuerySelectorAllAsync("table.listEvent");

            foreach(var linha in tabela)
            {
                var tabelaDataDoEvento = await linha.QuerySelectorAsync("td.sroDtEvent");
                var dataEvento = tabelaDataDoEvento.InnerTextAsync();
                lista += dataEvento.Result.Replace("\n"," ") + " ";

                var tabelaDescricao = await linha.QuerySelectorAsync("td.sroLbEvent");
                var descricao = await tabelaDescricao.InnerTextAsync();
                lista += descricao.Replace("\n", " ") + " ";
            }

            return Ok(lista);

        }

    }

}
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RastreiaEncomenda.Web.Servicos.Interfaces;

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
            string url = "https://www2.correios.com.br/sistemas/rastreamento/default.cfm";

            ChromeDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(url);
            //driver.Url = url;
            //driver.Manage().Window.Maximize();

            await Task.Delay(1);

            var pesquisaEl = driver.FindElement(By.Id("objetos"));
            pesquisaEl.SendKeys(codigo);

            var buscarEl = driver.FindElement(By.Id("btnPesq"));
            buscarEl.Click();



            var dataCidadeAtual = driver.FindElement(By.ClassName("sroDtEvent")).Text;
            var status          =  driver.FindElement(By.ClassName("sroLbEvent")).Text;


            var htmlDocument = new HtmlAgilityPack.HtmlDocument();

            driver.Close();

            await Task.Delay(1);

            //TODO
            //foreach (HtmlNode node in htmlDocument.GetElementbyId("ver-rastro-unico").ChildNodes)
            //{
            //    if (node.Attributes.Count > 0)
            //    {
            //        List<data> _data = new List<data>();
            //        _data.Add(new data()
            //        {
            //            DataPostagem = node.Attributes["step"].Value,

            //        });

            //        json = JsonConvert.SerializeObject(_data.ToArray());
            //    }

            //}

            return Ok(new
            {
                DataPostagem = dataCidadeAtual,
                Status = status
            });

        }

        public class Data
        {
            public string DataPostagem { get; set; }
            public string StatusEntrega { get; set; }
        }

    }
}

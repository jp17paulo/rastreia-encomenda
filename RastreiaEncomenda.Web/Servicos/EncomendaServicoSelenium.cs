using System.Collections.Generic;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RastreiaEncomenda.Web.Servicos.Interfaces;
using RastreiaEncomenda.Web.ViewModels;

namespace RastreiaEncomenda.Web.Servicos
{
    public class EncomendaServicoSelenium : IEncomendaServico
    {
        public async Task<ConsultaStatusEncomendaViewModel> ObtemStatusEncomenda(string codigo)
        {
            //aqui vai a lógica usando o Selenium
            var list = new List<dynamic>();

            string url = "https://www2.correios.com.br/sistemas/rastreamento/default.cfm";

            ChromeDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(url);
            //driver.Url = url;
            //driver.Manage().Window.Maximize();

            var pesquisaEl =  driver.FindElement(By.Id("objetos"));
            pesquisaEl.SendKeys(codigo);

            var buscarEl = driver.FindElement(By.Id("btnPesq"));
            buscarEl.Click();

            var datasCidadesAtuais = driver.FindElements(By.ClassName("sroDtEvent"));
            var status = driver.FindElements(By.ClassName("sroLbEvent"));
            var i = datasCidadesAtuais.Count;

            foreach (var node in datasCidadesAtuais)
            {
                list.Add(new {
                    Data = node.Text.Replace("\r", " ").Replace("\n", " ") + " ",
                    Status = status[i].Text.Replace("\r", " ").Replace("\n", " ") + " "
                });
                i++;
            }


            return new ConsultaStatusEncomendaViewModel(codigo, list);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Playwright;
using RastreiaEncomenda.Web.Servicos.Interfaces;
using RastreiaEncomenda.Web.ViewModels;

namespace RastreiaEncomenda.Web.Servicos
{
    public class EncomendaServicoPlaywright : IEncomendaServico
    {
        public async Task<ConsultaStatusEncomendaViewModel> ObtemStatusEncomenda(string codigo)
        {
            var list = new List<dynamic>();

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
                var tabelaDescricao = await linha.QuerySelectorAsync("td.sroLbEvent");
                
                list.Add(new {
                    Data = tabelaDataDoEvento.InnerTextAsync().Result.Replace("\n"," ") + " ",
                    Status = tabelaDescricao.InnerTextAsync().Result.Replace("\n"," ") + " "
                });
            }

            return new ConsultaStatusEncomendaViewModel(codigo, list);
        }
    }
}
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
            // using var playwright = await Playwright.CreateAsync();
            // await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            // var page = await browser.NewPageAsync();
            // await page.GotoAsync("https://rspiolirf.netlify.com");
            // await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot.png" });
            await Task.Delay(1);
            return new ConsultaStatusEncomendaViewModel(codigo, "Entregue via Playwright");
        }
    }
}
using System.Threading.Tasks;
using RastreiaEncomenda.Web.Servicos.Interfaces;
using RastreiaEncomenda.Web.ViewModels;

namespace RastreiaEncomenda.Web.Servicos
{
    public class EncomendaServicoPlaywright : IEncomendaServico
    {
        public async Task<ConsultaStatusEncomendaViewModel> ObtemStatusEncomenda(string codigo)
        {
            // aqui vai a lógica usando o Playwright
            await Task.Delay(1);
            return new ConsultaStatusEncomendaViewModel("ON77334347", "Entregue via Playwright");
        }
    }
}
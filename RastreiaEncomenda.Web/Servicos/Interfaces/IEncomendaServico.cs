using System.Threading.Tasks;
using RastreiaEncomenda.Web.ViewModels;

namespace RastreiaEncomenda.Web.Servicos.Interfaces
{
    public interface IEncomendaServico
    {
        Task<ConsultaStatusEncomendaViewModel> ObtemStatusEncomenda(string codigo);
    }
}
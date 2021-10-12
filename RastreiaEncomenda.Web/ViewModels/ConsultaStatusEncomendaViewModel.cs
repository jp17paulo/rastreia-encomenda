using System.Collections.Generic;

namespace RastreiaEncomenda.Web.ViewModels
{
    public record ConsultaStatusEncomendaViewModel(string codigo, List<dynamic> status);
}
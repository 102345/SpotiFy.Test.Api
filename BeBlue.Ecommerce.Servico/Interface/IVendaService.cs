using BeBlue.Ecommerce.Domain.Models;
using System.Collections.Generic;

namespace BeBlue.Ecommerce.Servico.Interface
{
    public interface IVendaService
    {
        bool GravarVenda(List<Venda> vendas);
        List<Venda> BuscarVenda(string idVenda);
        List<Venda> ListarPorData(string dataini, string datafim);
    }
}

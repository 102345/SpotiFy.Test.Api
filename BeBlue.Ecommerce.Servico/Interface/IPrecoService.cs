using BeBlue.Ecommerce.Domain.Models;
using System.Collections.Generic;

namespace BeBlue.Ecommerce.Servico.Interface
{
    public interface IPrecoService
    {
        void GravarPrecoAlbum();
        List<Preco> ListaPrecos();
        decimal BuscarPreco(string keyDisc);

    }
}

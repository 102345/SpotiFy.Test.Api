using BeBlue.Ecommerce.Domain.Models;
using System.Collections.Generic;

namespace BeBlue.Ecommerce.Servico.Interface
{
    public interface IAlbumService
    {
        List<Album> ListarAlbums(Constants.Enumeradores.Genero genero);
        Album BuscarAlbum(int id);
    }
}

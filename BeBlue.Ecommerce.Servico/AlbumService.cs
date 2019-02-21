using BeBlue.Ecommerce.Data.Repositories;
using BeBlue.Ecommerce.Domain.Models;
using BeBlue.Ecommerce.Servico.Interface;
using System.Linq;
using System.Collections.Generic;

namespace BeBlue.Ecommerce.Servico
{
    public class AlbumService : IAlbumService
    {
        private readonly AlbumRepository _albumRepository = new AlbumRepository();

        public Album BuscarAlbum(int id)
        {
            return _albumRepository.GetById(id);
        }


        public Album BuscarAlbum(string keyDisc)
        {
            return _albumRepository.GetList(x => x.KeyDisc == keyDisc).Single();
        }


        public List<Album> ListarAlbums(Constants.Enumeradores.Genero genero)
        {
            string descgenero = string.Empty;

            switch (genero)
            {
                case Constants.Enumeradores.Genero.CLASSIC:
                    descgenero = "CLASSIC";
                    break;
                case Constants.Enumeradores.Genero.MPB:
                    descgenero = "MPB";
                    break;
                case Constants.Enumeradores.Genero.POP:
                    descgenero = "POP";
                    break;
                case Constants.Enumeradores.Genero.ROCK:
                    descgenero = "ROCK";
                    break;
                default:
                    break;
            }



            return _albumRepository.GetList(g => g.Genre == descgenero).OrderBy(g => g.Name).ToList();
        }

        
    }
}

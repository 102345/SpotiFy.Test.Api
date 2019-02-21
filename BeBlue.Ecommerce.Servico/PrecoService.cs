using BeBlue.Ecommerce.Data.Repositories;
using BeBlue.Ecommerce.Domain.Models;
using BeBlue.Ecommerce.Servico.Interface;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BeBlue.Ecommerce.Servico
{
    public class PrecoService : IPrecoService
    {
        private readonly AlbumRepository _albumRepository = new AlbumRepository();
        private readonly PrecoRepository _precoRepository = new PrecoRepository();



        public async void GravarPrecoAlbum()
        {
            List<Album> albumsMPB =  await Spotify.Web.Api.AlbumService.GetAlbumsAsync(Spotify.Web.Api.Constants.Constants.Genero.MPB, "50");
            List<Album> albumsPOP =  await Spotify.Web.Api.AlbumService.GetAlbumsAsync(Spotify.Web.Api.Constants.Constants.Genero.POP, "50");
            List<Album> albumsROCK = await Spotify.Web.Api.AlbumService.GetAlbumsAsync(Spotify.Web.Api.Constants.Constants.Genero.ROCK, "50");
            List<Album> albumsCLASSIC = await Spotify.Web.Api.AlbumService.GetAlbumsAsync(Spotify.Web.Api.Constants.Constants.Genero.CLASSIC, "50");

            this.GravarAlbum(albumsMPB);
            this.GravarAlbum(albumsPOP);
            this.GravarAlbum(albumsROCK);
            this.GravarAlbum(albumsCLASSIC);
            this.AtribuirPrecos();

        }

        private void GravarAlbum(List<Album> albums)
        {
            foreach (var item in albums)
            {
                var album = new Album();
                album.KeyDisc = item.KeyDisc;
                album.Name = item.Name;
                album.Genre = item.Genre;
                album.Type = item.Type;

                _albumRepository.Insert(album);

            }

        }


        private void AtribuirPrecos()
        {
            var albums = _albumRepository.GetAll();

            foreach (var album in albums)
            {
                var preco = new Preco();
                preco.KeyDisc = album.KeyDisc;
                preco.Valor = new Random().Next(10, 100);

                _precoRepository.Insert(preco);
            }
        }

        public List<Preco> ListaPrecos()
        {
            return _precoRepository.GetAll().ToList();
        }

        public decimal BuscarPreco(string keyDisc)
        {
            decimal ret = 0;

            var preco= _precoRepository.GetList(x => x.KeyDisc == keyDisc).Single();

            if (preco != null) ret = preco.Valor;

            return ret;
        }
    }
}

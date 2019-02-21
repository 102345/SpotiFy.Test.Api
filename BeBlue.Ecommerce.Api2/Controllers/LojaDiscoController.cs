using BeBlue.Ecommerce.Servico.Interface;
using BeBlue.Ecommerce.Domain.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using System.Collections.Generic;
using BeBlue.Ecommerce.Servico.Constants;
using BeBlue.Ecommerce.Api2.ViewModels;
using AutoMapper;
using BeBlue.Ecommerce.Api2.Controllers;

namespace BeBlue.Ecommerce.Api.Controllers
{
    public class LojaDiscoController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly IPrecoService _precoService;
        private readonly IVendaService _vendaService;

        public LojaDiscoController(IAlbumService albumService, IPrecoService precoService, IVendaService vendaService)
        {
            _albumService = albumService;
            _precoService = precoService;
            _vendaService = vendaService;

            var precos = _precoService.ListaPrecos();

            if (precos.Count() == 0) _precoService.GravarPrecoAlbum();


        }

        /// <summary>
        /// Lista as vendas realizadas em um periodo
        /// </summary>
        /// <param name="dataIni">string - data inicial</param>
        /// <param name="dataFim">string - data final</param>
        /// <returns>Lista de objetos Venda</returns>
        /// <remarks>
        /// as datas devem ser informadas no formato : dd-mm-yyyy
        /// </remarks>
        [HttpGet]
        [Route("api/v1/LojaDisco/ListarVendas/{dataIni}/{dataFim}")]
        public HttpResponseMessage ListarVendas(string dataIni, string dataFim)
        {
            try
            {
                var vendas = _vendaService.ListarPorData(dataIni, dataFim);

                JsonResult.Status = true;
                JsonResult.Object = vendas;
                JsonResult.Message = "Lista de vendas gerada com  sucesso";
                return Request.CreateResponse(HttpStatusCode.OK, JsonResult);
            }
            catch (Exception ex)
            {

                JsonResult.Status = false;
                JsonResult.Message = ex.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, JsonResult);
            }
        }


        /// <summary>
        /// Busca a venda especifica através de sua chave idVenda
        /// </summary>
        /// <param name="id">string - identificador da venda </param>
        /// <returns>- Objeto Venda</returns>
        /// <remarks>
        /// O id informado tem que ser o idVenda - Ex : idVenda = 9aca589e-1fec-4686-b4a1-bf72fffaf66e
        /// </remarks>
        [HttpGet]
        [Route("api/v1/LojaDisco/BuscarVenda/{id}")]
        public HttpResponseMessage BuscarVenda(string id)
        {
            try
            {
                var vendas = _vendaService.BuscarVenda(id);

                JsonResult.Status = true;
                JsonResult.Object = vendas;
                JsonResult.Message = "Venda localizada com  sucesso";
                return Request.CreateResponse(HttpStatusCode.OK, JsonResult);
            }
            catch (Exception ex)
            {

                JsonResult.Status = false;
                JsonResult.Message = ex.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, JsonResult);
            }



        }



        /// <summary>
        /// Busca um disco específico na loja
        /// </summary>
        /// <param name="id">int - id (identificador do  disco)</param>
        /// <returns>Objeto Album</returns>
        /// <remarks>
        /// O id informado é o id da chave de tabela
        /// </remarks>

        [HttpGet]
        [Route("api/v1/LojaDisco/BuscarDisco/{id}")]
        public HttpResponseMessage BuscarDisco(int id)
        {
            try
            {
                var album = _albumService.BuscarAlbum(id);

                JsonResult.Status = true;
                JsonResult.Object = album;
                JsonResult.Message = "Disco localizado com  sucesso";
                return Request.CreateResponse(HttpStatusCode.OK, JsonResult);
            }
            catch (Exception ex)
            {

                JsonResult.Status = false;
                JsonResult.Message = ex.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, JsonResult);
            }



        }


        /// <summary>
        /// Busca a lista de discos de acordo com o gênero musical 
        /// </summary>
        /// <param name="id"> int - identificador do tipo de gênero musical</param>
        /// <returns>Lista de objetos Album</returns>
        /// <remarks>
        /// id : 1 - MPB, 2 - POP , 3 - CLASSIC , 4 - ROCK
        /// </remarks>
        [HttpGet]
        [Route("api/v1/LojaDisco/ListarDiscos/{id}")]
        public HttpResponseMessage ListarDiscos(int id)
        {
            try
            {
                var albums = new List<Album>();

                if (id == 1)
                {
                    albums = _albumService.ListarAlbums(Enumeradores.Genero.MPB);

                }
                else if (id == 2)
                {
                    albums = _albumService.ListarAlbums(Enumeradores.Genero.POP);
                }
                else if (id == 3)
                {
                    albums = _albumService.ListarAlbums(Enumeradores.Genero.CLASSIC);

                }
                else if (id == 4)
                {
                    albums = _albumService.ListarAlbums(Enumeradores.Genero.ROCK);
                }


                JsonResult.Status = true;
                JsonResult.Object = albums;
                JsonResult.Message = "Listado com sucesso";
                return Request.CreateResponse(HttpStatusCode.OK, JsonResult);
            }
            catch (Exception ex)
            {

                JsonResult.Status = false;
                JsonResult.Message = ex.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, JsonResult);
            }


        }



        /// <summary>
        /// Grava uma venda de um conjunto de discos
        /// </summary>
        /// <param name="vendaViewModel">objeto ViewModel</param>
        /// <returns>string - Mensagem da operação de gravação</returns>
        [HttpPost]
        [Route("api/v1/LojaDisco/GravarVendas/")]
        public HttpResponseMessage GravarVenda([FromBody]List<VendaViewModel> vendaViewModel)
        {


            try
            {
                var vendas = Mapper.Map<List<VendaViewModel>, List<Venda>>(vendaViewModel);

                bool ret = _vendaService.GravarVenda(vendas);


                JsonResult.Status = true;
                JsonResult.Object = null;
                JsonResult.Message = "Venda gravada com sucesso";
                return Request.CreateResponse(HttpStatusCode.OK, JsonResult);
            }
            catch (Exception ex)
            {
                JsonResult.Status = false;
                JsonResult.Message = ex.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, JsonResult);
            }
        }

    }
}

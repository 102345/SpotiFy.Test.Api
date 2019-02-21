using BeBlue.Ecommerce.Data.Repositories;
using BeBlue.Ecommerce.Domain.Models;
using BeBlue.Ecommerce.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeBlue.Ecommerce.Servico
{
    public class VendaService : IVendaService
    {
        private readonly VendaRepository _vendaRepository = new VendaRepository();
        private readonly CashbackService _cashbackService = new CashbackService();
        private readonly AlbumService _albumService = new AlbumService();
        private readonly PrecoService _precoService = new PrecoService();

        public bool GravarVenda(List<Venda> vendas)
        {
           

            bool ret = true;
            try
            {
                var idVenda = Guid.NewGuid().ToString();

                foreach (var venda in vendas)
                {
                    var vendaGrav = new Venda();

                    decimal preco = _precoService.BuscarPreco(venda.KeyDisc);

                    vendaGrav.IdVenda = idVenda;
                    vendaGrav.DataVenda = DateTime.Today;
                    vendaGrav.KeyDisc = venda.KeyDisc;
                    vendaGrav.Quantidade = venda.Quantidade;
                    vendaGrav.ValorVenda = preco;
                    vendaGrav.ValorCashBack = this.CalcularCashBack(venda.KeyDisc, preco);
                    vendaGrav.ValorVendaTotal = 0;
                    vendaGrav.ValorCashBackTotal = 0;

                    _vendaRepository.Insert(vendaGrav);
                }

                AtualizarVenda(idVenda);

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = false;
                throw;
            }

            return ret;
           

        }


        private void AtualizarVenda(string idVenda)
        {
            List<Venda> vendas = _vendaRepository.GetList(x => x.IdVenda == idVenda).ToList();

            foreach (var venda in vendas)
            {
                Venda vendaGrav = new Venda();

                vendaGrav.Id = venda.Id;
                vendaGrav.IdVenda = venda.IdVenda;
                vendaGrav.KeyDisc = venda.KeyDisc;
                vendaGrav.Quantidade = venda.Quantidade;
                vendaGrav.ValorCashBack = venda.ValorCashBack;
                vendaGrav.ValorVenda = venda.ValorVenda;
                vendaGrav.ValorCashBackTotal = this.CalcularValorTotalCashBack(idVenda);
                vendaGrav.ValorVendaTotal = this.CalcularValorTotalVenda(idVenda);
                vendaGrav.DataVenda = venda.DataVenda;

                _vendaRepository.Update(vendaGrav);
            }

        }



        private decimal CalcularValorTotalVenda(string idVenda)
        {

            var vendas = _vendaRepository.GetList(x => x.IdVenda == idVenda).ToList();

            decimal totalVenda = vendas.GroupBy(g => g.IdVenda).Select(x => x.Sum(item => (item.ValorVenda)*(item.Quantidade))).Single();

            return totalVenda;

        }

        private decimal CalcularValorTotalCashBack(string idVenda)
        {
            var vendas = _vendaRepository.GetList(x => x.IdVenda == idVenda).ToList();

            decimal totalVenda = vendas.GroupBy(g => g.IdVenda).Select(x => x.Sum(item => (item.ValorCashBack) * (item.Quantidade))).Single();

            return totalVenda;

        }




        private decimal CalcularCashBack(string keyDisc , decimal preco)
        {
            var album = _albumService.BuscarAlbum(keyDisc);

            int diaSemana = (int) DateTime.Today.DayOfWeek;

            if (diaSemana == 0) diaSemana = 7;

            decimal valorCashBack = _cashbackService.BuscarDesconto(album.Genre, diaSemana);

            decimal desconto = Math.Round((preco * valorCashBack / 100), 2);

            return desconto;
        }

        public List<Venda> BuscarVenda(string idVenda)
        {
            return _vendaRepository.GetList(x => x.IdVenda == idVenda).ToList();
        }

        public List<Venda> ListarPorData(string dataini, string datafim)
        {
            DateTime dtIni = Convert.ToDateTime(dataini);
            DateTime dtFim = Convert.ToDateTime(datafim);

            return _vendaRepository.GetList(x => x.DataVenda >= dtIni && x.DataVenda <= dtFim).OrderByDescending(x => x.DataVenda).ToList();
        }
    }
}

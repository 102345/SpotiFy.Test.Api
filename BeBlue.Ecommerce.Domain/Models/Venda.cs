using System;

namespace BeBlue.Ecommerce.Domain.Models
{
    public class Venda : BaseEntity
    {
        public decimal ValorVenda { get; set; }
        public decimal ValorCashBack { get; set; }
        public string KeyDisc { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataVenda { get; set; }
        public string IdVenda { get; set; }
        public decimal ValorVendaTotal { get; set; }
        public decimal ValorCashBackTotal { get; set; }
    }
}

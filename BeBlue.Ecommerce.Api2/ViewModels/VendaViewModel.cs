namespace BeBlue.Ecommerce.Api2.ViewModels
{
    public class VendaViewModel
    {
        public int id { get; set; }
        public int IdVenda { get; set; }
        public string KeyDisc { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorCashBack { get; set; }
        public decimal ValorVendaTotal { get; set; }
        public decimal ValorCashBackTotal { get; set; }
        public string DataVenda { get; set; }
    }
}
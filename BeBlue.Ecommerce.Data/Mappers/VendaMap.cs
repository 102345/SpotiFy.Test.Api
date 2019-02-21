using BeBlue.Ecommerce.Domain.Models;
using Dapper.FluentMap.Dommel.Mapping;

namespace BeBlue.Ecommerce.Data.Mappers
{
    public class VendaMap : DommelEntityMap<Venda>
    {
        public VendaMap()
        {
            ToTable("Venda");
            Map(x => x.Id).ToColumn("id").IsKey();
            Map(x => x.KeyDisc).ToColumn("KeyDisc");
            Map(x => x.ValorVenda).ToColumn("ValorVenda");
            Map(x => x.ValorCashBack).ToColumn("ValorCashBack");
            Map(x => x.Quantidade).ToColumn("Quantidade");
            Map(x => x.DataVenda).ToColumn("DataVenda");
            Map(x => x.IdVenda).ToColumn("IdVenda");
            Map(x => x.ValorVendaTotal).ToColumn("ValorVendaTotal");
            Map(x => x.ValorCashBackTotal).ToColumn("ValorCashBackTotal");
        }
    }
}

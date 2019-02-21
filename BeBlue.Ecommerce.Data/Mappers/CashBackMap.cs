using BeBlue.Ecommerce.Domain.Models;
using Dapper.FluentMap.Dommel.Mapping;

namespace BeBlue.Ecommerce.Data.Mappers
{
    public class CashbackMap : DommelEntityMap<Cashback>
    {
        public CashbackMap()
        {
            ToTable("CashBack");
            Map(x => x.Id).ToColumn("id").IsKey();
            Map(x => x.Genero).ToColumn("Genero");
            Map(x => x.DiaSemana).ToColumn("DiaSemana");
            Map(x => x.Percentual).ToColumn("Percentual");
            
        }

       
    }
}

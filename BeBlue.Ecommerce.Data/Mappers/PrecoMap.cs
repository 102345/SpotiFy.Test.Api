using BeBlue.Ecommerce.Domain.Models;
using Dapper.FluentMap.Dommel.Mapping;

namespace BeBlue.Ecommerce.Data.Mappers
{
    public class PrecoMap: DommelEntityMap<Preco>
    {
        public PrecoMap()
        {
            ToTable("Preco");
            Map(x => x.Id).ToColumn("id").IsKey();
            Map(x => x.KeyDisc).ToColumn("KeyDisc");
            Map(x => x.Valor).ToColumn("Valor");

        }

      
    }
}

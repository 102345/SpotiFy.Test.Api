using BeBlue.Ecommerce.Domain.Models;
using Dapper.FluentMap.Dommel.Mapping;


namespace BeBlue.Ecommerce.Data.Mappers
{
     public class AlbumMap : DommelEntityMap<Album>
    {
        public AlbumMap()
        {
            ToTable("Album");
            Map(x => x.Id).ToColumn("id").IsKey();
            Map(x => x.KeyDisc).ToColumn("KeyDisc");
            Map(x => x.Name).ToColumn("Name");
            Map(x => x.Genre).ToColumn("Genre");
        }
    }
}

using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using BeBlue.Ecommerce.Data.Mappers;

namespace BeBlue.Ecommerce.Data
{
    public static class RegisterMappings
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new AlbumMap());
                config.ForDommel();
            });

            FluentMapper.Initialize(config =>
            {
                config.AddMap(new CashbackMap());
                config.ForDommel();
            });

            FluentMapper.Initialize(config =>
            {
                config.AddMap(new PrecoMap());
                config.ForDommel();
            });

            FluentMapper.Initialize(config =>
            {
                config.AddMap(new VendaMap());
                config.ForDommel();
            });


        }
    }
}

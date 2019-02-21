using BeBlue.Ecommerce.Domain.Models;
using Newtonsoft.Json;
using Spotify.Web.Api.Contract;
using Spotify.Web.Api.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spotify.Web.Api
{
    public class AlbumService
    {

        public static async Task<List<Album>> GetAlbumsAsync(Constants.Constants.Genero genero,string limit)
        {
            string token = Authentication.GetAccessToken();

            string descGenero = string.Empty;

            if(genero == Constants.Constants.Genero.CLASSIC)
            {
                descGenero = "CLASSIC";
            }
            else if( genero == Constants.Constants.Genero.MPB)
            {

                descGenero = "MPB";
            }
            else if(genero == Constants.Constants.Genero.POP)
            {
                descGenero = "POP";
            }
            else if(genero == Constants.Constants.Genero.ROCK)
            {
                descGenero = "ROCK";
            }

            string url = string.Format("https://api.spotify.com/v1/search?q={0}&type=album&market=BR&limit={1}&offset=5",descGenero,limit);


            var json = await HttpHelper.GetAsynsc(url,token);


            var obj = JsonConvert.DeserializeObject<AlbumsContract>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
          
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,

              
            });

            var items = obj.albums.items;

            var albums = new List<Album>();

           

            foreach (var item in items)
            {
                var album = new Album();

                album.KeyDisc = item.id;
                album.Name = item.name;
                album.Type = item.type;
                album.Genre = descGenero;

                albums.Add(album);
               
            }

            

            return albums;
        }

    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Web.Api.Helpers
{
    public static class HttpHelper
    {
        public static async Task<string> GetAsynsc(string url, string token, bool includeBearer = true)
        {
            HttpClient client = new HttpClient();
            if (includeBearer)
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            else
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            var httpResponse = await client.GetAsync(url);
            return await httpResponse.Content.ReadAsStringAsync();
        }


       


    }
}

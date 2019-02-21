using Newtonsoft.Json;
using Spotify.Web.Api.Models;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Spotify.Web.Api
{
    public static class Authentication
    {
        const string clientid = "511172867cd54b5ca850f90c3358f0a6";
        const string clientsecret = "029b70fc653e4a6c987b936c9c5cfa4b";

        public static string GetAccessToken()
        {
            SpotifyToken token = new SpotifyToken();
            string url5 = "https://accounts.spotify.com/api/token";

           
          
            var encode_clientid_clientsecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", clientid, clientsecret)));


            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url5);


            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization: Basic " + encode_clientid_clientsecret);


            var request = ("grant_type=client_credentials");
            byte[] req_bytes = Encoding.ASCII.GetBytes(request);
            webRequest.ContentLength = req_bytes.Length;


            Stream strm = webRequest.GetRequestStream();
            strm.Write(req_bytes, 0, req_bytes.Length);
            strm.Close();


            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            String json = "";
            using (Stream respStr = resp.GetResponseStream())
            {
                using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                {
                    json = rdr.ReadToEnd();
                    rdr.Close();
                }
            }
            token = JsonConvert.DeserializeObject<SpotifyToken>(json);
            return token.access_token;
        }

    }
}

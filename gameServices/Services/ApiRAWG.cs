using gameServices.Extensions;
using gameServices.Models;
using System.Text;
using System.Text.Json;


namespace gameServices.Services
{
    public class ApiRAWG : IApiRAWG
    {
        const string typeobject = "api/games";

        static HttpClient client = new HttpClient();
        private string ApiUrl { get; }
        private string ApiKey { get; }


        public ApiRAWG(string url, string key)
        {
            ApiUrl = url;
            ApiKey = key;
        }
        public string makeUrl(string methode = null, string type = null, string searchName = null, int? searchId = null, int? page = null, string language = "fr-FR", string time = null)
        {
            StringBuilder strb = new StringBuilder();

            strb.Append(ApiUrl);

            //Header
            if (!string.IsNullOrEmpty(methode))
            {
                strb.Append($"/{methode}");
            }
            if (!string.IsNullOrEmpty(type))
            {
                strb.Append($"/{type}");
            }
            if (!string.IsNullOrEmpty(time))
            {
                strb.Append($"/{time}");
            }
            if (searchId.HasValue)
            {
                strb.Append($"/{searchId.Value}");
            }
            if (!string.IsNullOrEmpty(searchName))
            {
                strb.Append($"{searchName}");
            }
            
            strb.Append($"?key={ApiKey}");


            return strb.ToString();
        }

        public async Task<Game> getGameByID(int id)
        {
   
            Game game = new Game();
           try
            {
                var url = makeUrl(type: typeobject, searchId: id);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonresult = await response.Content.ReadFromJsonAsync<JsonElement>();
                     game = jsonresult.ToObject<Game>();

                }
              }
            catch (Exception ex)
              {
              }
          
             return game;
        }

        public async Task<Game> searchGame(string searchName, int page = 0)
        {

            Game game = new Game();
            try
            {
                var url = makeUrl(methode: "api/games/", searchName: searchName);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonresult = await response.Content.ReadFromJsonAsync<JsonElement>();
                    game = jsonresult.ToObject<Game>();

                }
            }
            catch (Exception ex)
            {
            }

            return game;
        }
        public string GetToken()
        {
            return ApiKey;
        }
    }
}
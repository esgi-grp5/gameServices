using gameServices.Extensions;
using gameServices.Models;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

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

            //Parameter

           /* if (page.HasValue)
            {
                if (page > 0)
                {
                    strb.Append($"&page={page.Value}");
                }
            }
            if (!string.IsNullOrEmpty(language))
            {
                strb.Append($"&language={language}");
            }*/

            return strb.ToString();
        }

        public async Task<List<Game>> searchGame(string searchName, int page = 0)
        {
            List<Game> game = new List<Game>();
            try
            {

                var url = makeUrl(methode: "api/games/", searchName: searchName);

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonresult = await response.Content.ReadFromJsonAsync<TmdbApiObject>();

                    foreach (var item in jsonresult.results)
                    {
                        game.Add(item.ToObject<Game>());
                    }
                }
            }
            catch (Exception ex)
            {
                var test = ex.Message;
            }
            return game;

        }
        public async Task<Game> getGameByID(int id)
        {
           // string strgame;
            Game game = new Game();
           try
            {
                var url = makeUrl(type: typeobject, searchId: id);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonresult = await response.Content.ReadFromJsonAsync<JsonElement>();
                     game = jsonresult.ToObject<Game>();
                      // strgame = Convert.ToString(jsonresult);

                  //  var resultO = JsonConvert.DeserializeObject<Game>(strgame);
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
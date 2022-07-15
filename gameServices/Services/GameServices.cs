
using gameServices.Models;


namespace gameServices.Services
{
    public class GameServices : IGameServices
    {

        private IApiRAWG _apiServices;

        public GameServices(IApiRAWG ApiService)
        {
            _apiServices = ApiService;
        }

        public async Task<List<Game>> getGame(string searchName)
        {
            var game = new List<Game>();

            var apiGame = await _apiServices.searchGame(searchName);
            if (apiGame != null)
            {
                return apiGame;
            }

            return game;
        }
    }
}
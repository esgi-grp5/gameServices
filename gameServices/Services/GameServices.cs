
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

        public async Task<MyGame> getGameByName(string searchName)
        {
            var game = new MyGame();

            var apiGame = await _apiServices.searchGame(searchName);
            if (apiGame != null)
            {
                game = new MyGame(apiGame);
                return game;
            }

            return game;
        }
        public async Task<MyGame> getGameById(int id)
        {
            var game = new MyGame();

            var apiGame = await _apiServices.getGameByID(id);
            if (apiGame != null)
            {
                game = new MyGame(apiGame);
                return game;
            }

            return game;
        }
    }
}
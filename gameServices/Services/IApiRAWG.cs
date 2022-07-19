using gameServices.Models;

namespace gameServices.Services
{
    public interface IApiRAWG
    {
        //Task<List<Game>> searchGame(string searchName, int page = 0);
        Task<Game> searchGame(string searchName, int page = 0);

        Task<Game> getGameByID(int id);

        string GetToken(); //Private
    }
}

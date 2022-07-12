using gameServices.Models;

namespace gameServices.Services
{
    public interface IApiIGDB
    {
        Task<List<Game>> searchGame(string searchName, int page = 0);

        string GetToken(); //Private
    }
}

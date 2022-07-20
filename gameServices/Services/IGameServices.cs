
using gameServices.Models;

namespace gameServices.Services
{
    public interface IGameServices
    {
        Task<MyGame> getGameByName(string searchName);
        Task<MyGame> getGameById(int id);
    }
}

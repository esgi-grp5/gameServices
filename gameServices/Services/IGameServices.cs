
using gameServices.Models;

namespace gameServices.Services
{
    public interface IGameServices
    {
        Task<List<Game>> getGame(string searchName);
    }
}

using Microsoft.AspNetCore.Mvc;
using gameServices.Services;
using System.Text.Json;
using System.Text.Json.Serialization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace gameServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiqueController : ControllerBase

    {
        public IGameServices gameServices { get; set; }
        public string GameName { get; private set; }

        public GameController(IGameServices GameServices)
        {
            gameServices = GameServices;
        }

        [HttpGet("{GameName}")]
        public async Task<string> Get(string GameName)
        {
            var result = await gameServices.getGame(GameName);
            return JsonSerializer.Serialize(result);
        }


        [HttpGet("TEST")]
        public string Get()
        {
            return "I am Alive !";



        }
    }
}

namespace gameServices.Models
{
    public class MyGame
    {
        public int idGame { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string background_image { get; set; }

        public MyGame()
        {
        }

        public MyGame(Game apigame)
        {
            idGame = apigame.id;    
            slug = apigame.slug;
            name = apigame.name;
            background_image = apigame.background_image;

        }   
    }
}

namespace gameServices.Models
{
    public class MyGame
    {
        public int idGame { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string background_image { get; set; }
        public List<Tag> similar_games { get; set; }
        public List<Genre> genres { get; set; }
        public MyGame()
        {
        }

        public MyGame(Game apigame)
        {
            idGame = apigame.id;    
            slug = apigame.slug;
            name = apigame.name;
            background_image = apigame.background_image;

            similar_games = new List<Tag>();
            genres = new List<Genre>();
            if (apigame.tags != null && apigame.tags.Count() > 1)
            {
                foreach (var item in apigame.tags)
                {
                    if (item.id > 1000)
                        similar_games.Add(item);
                }
            }
            if (apigame.genres != null && apigame.genres.Count() > 1)
            {
                foreach (var item in apigame.genres)
                {
                     genres.Add(item);
                }
            }
        }   
    }
}

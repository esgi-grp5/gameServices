namespace gameServices.Models
{
    public class Tag
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string language { get; set; }
        public int games_count { get; set; }
        public string image_background { get; set; }
    }
    public class Genre
    {
      //  public int id { get; set; }
        public string name { get; set; }
       // public string slug { get; set; }
       // public int games_count { get; set; }
       // public string image_background { get; set; }
    }

    public class Game
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string name_original { get; set; }
        public string description { get; set; }
        public string background_image { get; set; }
        public List<Tag> tags { get; set; }
        public List<Genre> genres { get; set; }
        public int playtime { get; set; }
        public int screenshots_count { get; set; }
        public int movies_count { get; set; }
        public int creators_count { get; set; }
        public int achievements_count { get; set; }
 
    }

}

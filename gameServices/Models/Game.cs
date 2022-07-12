namespace gameServices.Models
{

    public class Image
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public string Url { get; set; } = default!;
    }

    public class Game : Image
    {
        public int id { get; set; }
        public string typePlateform { get; set; }
        public string title { get; set; }

    }

}

using AspNetCoreVideo.Models;

namespace AspNetCoreVideo.Entities
{
    public class Video
    {
        public int Id { get; set; }

        public string Title { get; set; }

//        public int GenreId { get; set; }
        public Genres Genre { get; set; }
    }
}
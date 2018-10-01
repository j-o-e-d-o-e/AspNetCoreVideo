using System.Collections.Generic;
using System.Linq;
using AspNetCoreVideo.Entities;
using AspNetCoreVideo.Models;

namespace AspNetCoreVideo.Services
{
    public class MockVideoData : IVideoData
    {
        private readonly IEnumerable<Video> _videos;

        public MockVideoData()
        {
            _videos = new List<Video>
            {
                new Video() {Id = 1, Genre = Genres.Comedy, Title = "Shrek"},
                new Video() {Id = 2, Genre = Genres.Action, Title = "Despicable Me"},
                new Video() {Id = 3, Genre = Genres.Animated, Title = "Megamind"}
            };
        }

        public IEnumerable<Video> GetAll()
        {
            return _videos;
        }

        public Video Get(int id)
        {
            return _videos.FirstOrDefault(video => video.Id.Equals(id));
        }
    }
}
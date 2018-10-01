using System.Collections.Generic;
using AspNetCoreVideo.Data;
using AspNetCoreVideo.Entities;

namespace AspNetCoreVideo.Services
{
    public class SqlVideoData : IVideoData
    {
        private VideoDbContext _db;

        public SqlVideoData(VideoDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Video> GetAll()
        {
            return _db.Videos;
        }

        public Video Get(int id)
        {
            return _db.Find<Video>(id);
        }

        public void Add(Video newVideo)
        {
            _db.Add(newVideo);
            _db.SaveChanges();
        }
    }
}
using BloggAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BloggAPI
{
    public class Database
    {
        private IMongoDatabase GetDb()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BloggsDB");

            return db;
        }

        public async Task<List<Blogg>> GetBloggs()
        {
            var bloggs = await GetDb().GetCollection<Blogg>("Bloggs")
                .Find(b=>true)
                .ToListAsync();
            return bloggs;
        }
        public async Task<Blogg> GetBlogg (string id)
        {
            ObjectId _id = new ObjectId(id);
            var blogg = await GetDb().GetCollection<Blogg>("Bloggs")
                .Find(b => b.Id == _id)
                .SingleOrDefaultAsync();

            return blogg;
        }

        public async Task Saveblogg (string title, string summary, string content)
        {
            var blogg = new Blogg()
            {
                Title = title,
                Summary = summary,
                Content = content
            };

            await GetDb().GetCollection<Blogg>("Bloggs")
                .InsertOneAsync(blogg);
        }

        public async Task DeleteBlogg (string id)
        {
            ObjectId _id =new ObjectId(id);

            await GetDb().GetCollection<Blogg>("Bloggs")
                .DeleteOneAsync(b => b.Id == _id);
        }

        public async Task UpdateBlogg(string id, string title, string summary, string content)
        {
            ObjectId _id = new ObjectId (id);

            var update = Builders<Blogg>.Update
                .Set(b => b.Title, title);
            await GetDb().GetCollection<Blogg>("Bloggs")
                .UpdateOneAsync(b=> b.Id == _id, update);
        }
       

    }
}

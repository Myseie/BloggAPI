using MongoDB.Bson;

namespace BloggAPI.Models
{
    public class Blogg
    {
        public ObjectId Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

    }
}

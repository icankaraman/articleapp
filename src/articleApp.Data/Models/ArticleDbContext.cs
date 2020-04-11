using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace articleApp.Data.Models
{
    public class ArticleDbContext
    {
        private readonly IMongoDatabase _database = null;

        public ArticleDbContext(IOptions<ConnectionSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);

        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }

        public IMongoCollection<User> User
        {
            get
            {
                return _database.GetCollection<User>("User");
            }
        }

        public IMongoCollection<Article> Article
        {
            get
            {
                return _database.GetCollection<Article>("Article");
            }
        }
        public IMongoCollection<Category> Category
        {
            get
            {
                return _database.GetCollection<Category>("Category");
            }
        }
    }
}
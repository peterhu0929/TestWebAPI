using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace TestWebAPI.Models
{
    public class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        string connectionString =
  @"mongodb://angular-tri:BgoQgavrKYsD34H1009QjoSXA2ETiqgvZBWKnp0MqtNurKOnKGmqHAWHiK8sThwX3BKuQffl5m1uWC0tbWDB5A==@angular-tri.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

        string defaultDBstring = "mongodb://localhost:27017";

        public DataAccess()
        {
            _client = new MongoClient(connectionString);
            _server = _client.GetServer();
            _db = _server.GetDatabase("testDB");

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
        }

        public IEnumerable<User> GetUsers()
        {
            return _db.GetCollection<User>("Users").FindAll();
        }

        public User GetUser(ObjectId id)
        {
            var res = Query<User>.EQ(p => p.Id, id);
            return _db.GetCollection<User>("Users").FindOne(res);
        }

        public User CreateUser(User user)
        {
            _db.GetCollection<User>("Users").Save(user);
            return user;
        }

        public bool UpdateUser(ObjectId id, User user)
        {
            user.Id = id;
            var res = Query<User>.EQ(u => u.Id, id);
            var operation = Update<User>.Replace(user);
            var result = _db.GetCollection<User>("Users").Update(res, operation);
            return !result.HasLastErrorMessage;
        }
        public bool RemoveUser(ObjectId id)
        {
            var res = Query<User>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<User>("Users").Remove(res);
            return !operation.HasLastErrorMessage;
        }
    }
}

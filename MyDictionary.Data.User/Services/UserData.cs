using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyDictionary.Data.Users.Interfaces;
using MyDictionary.Model.Common.UserDatabase;
using MyDictionary.Model.Users.Request;

namespace MyDictionary.Data.Users.Services
{
    public class UserData : IUserData
    {
        private readonly IMongoCollection<User> _userCollection;
        public UserData(IOptions<UserDatabaseSettings> userDatabasesettings)
        {
            var client = new MongoClient(userDatabasesettings.Value.ConnectionString);
            var database = client.GetDatabase(userDatabasesettings.Value.DatabaseName);
            _userCollection = database.GetCollection<User>(userDatabasesettings.Value.DatabaseName);
        }
        public async Task<User> GetAsync(string? ID, string? UserID, CancellationToken token)
        {
            if (!string.IsNullOrEmpty(ID))
                return await _userCollection.Find(x => x.ID == ID).FirstOrDefaultAsync(cancellationToken: token);
            else if (!string.IsNullOrEmpty(UserID))
                return await _userCollection.Find(x => x.UserID == UserID).FirstOrDefaultAsync(cancellationToken: token);
            else
                throw new ArgumentException("ID or UserID is required");
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userCollection.Find(_ => true).ToListAsync();
        }

        public async Task CreateAsync(User request, CancellationToken token)
        {
            await _userCollection.InsertOneAsync(request, cancellationToken: token);
        }

        public async Task UpdateAsync(User request, CancellationToken token)
        {
            await _userCollection.ReplaceOneAsync(x => x.ID == request.ID, request, cancellationToken: token);
        }

        public async Task DeleteAsync(string ID, CancellationToken token)
        {
            await _userCollection.DeleteOneAsync(x => x.ID == ID, cancellationToken: token);
        }
    }
}

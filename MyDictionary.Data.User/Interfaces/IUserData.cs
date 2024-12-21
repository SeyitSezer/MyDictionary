using MyDictionary.Model.Users.Request;

namespace MyDictionary.Data.Users.Interfaces
{
    public interface IUserData
    {
        public Task<User> GetAsync(string? ID, string? UserID, CancellationToken token);
        public Task CreateAsync(User request, CancellationToken token);
        public Task UpdateAsync(User request, CancellationToken token);
        public Task DeleteAsync(string ID, CancellationToken token);
        public Task<List<User>> GetAllAsync();
    }
}

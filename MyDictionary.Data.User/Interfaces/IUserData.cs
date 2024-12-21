using MyDictionary.Model.User.Request;

namespace MyDictionary.Data.User.Interfaces
{
    public interface IUserData
    {
        public Task<UserRequest> GetUser(int ID, CancellationToken token);
        public Task<UserRequest> SaveUser(UserRequest request, CancellationToken token);
    }
}

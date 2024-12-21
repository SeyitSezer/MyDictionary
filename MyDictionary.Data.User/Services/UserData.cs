using MyDictionary.Data.User.Interfaces;
using MyDictionary.Model.User.Request;

namespace MyDictionary.Data.User.Services
{
    public class UserData : IUserData
    {
        public Task<UserRequest> GetUser(int ID, CancellationToken token)
        {

            return Task.FromResult(new UserRequest() { UserID = "1", UserName ="Admin" });
        }

        public Task<UserRequest> SaveUser(UserRequest request, CancellationToken token)
        {
            return Task.FromResult(new UserRequest()
            {
                UserID = "1",
                UserName = "Admin"
            });
        }
    }
}

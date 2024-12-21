using MediatR;
using MyDictionary.Data.Users.Interfaces;
using MyDictionary.Model.Common;
using MyDictionary.Model.Users.Request;

namespace MyDictionary.Business.Users.Queries
{
    public class GetAllUsers(IUserData userData) : IRequestHandler<GetAllUser, CommonResponse<List<User>>>
    {
        private readonly IUserData _userData = userData;

        public async Task<CommonResponse<List<User>>> Handle(GetAllUser request, CancellationToken cancellationToken)
        {
            var resp = new CommonResponse<List<User>>();
            try
            {
                var user = await _userData.GetAllAsync();
                resp.SetData(user);
            }
            catch (Exception ex)
            {
                resp.SetException(ex);
            }
            return resp;
        }
    }
}

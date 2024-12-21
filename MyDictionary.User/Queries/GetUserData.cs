using MediatR;
using MyDictionary.Data.Users.Interfaces;
using MyDictionary.Model.Common;
using MyDictionary.Model.Users.Request;

namespace MyDictionary.Business.Users.Queries
{
    public class GetUserData(IUserData userData) : IRequestHandler<Model.Users.Request.GetUser, CommonResponse<Model.Users.Request.User>>
    {
        private readonly IUserData _userData = userData;
        public async Task<CommonResponse<User>> Handle(GetUser request, CancellationToken cancellationToken)
        {
            var resp = new CommonResponse<Model.Users.Request.User>();
            try
            {
                var user = await _userData.GetAsync(request.ID, request.UserID, cancellationToken);
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

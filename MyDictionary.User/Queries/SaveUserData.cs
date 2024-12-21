using MediatR;
using MyDictionary.Data.Users.Interfaces;
using MyDictionary.Model.Common;

namespace MyDictionary.Business.Users.Queries
{
    public class SaveUserData(IUserData userData) : IRequestHandler<Model.Users.Request.User, CommonResponse<Model.Users.Request.User>>
    {
        private readonly IUserData _userData = userData;

        public async Task<CommonResponse<Model.Users.Request.User>> Handle(Model.Users.Request.User request, CancellationToken cancellationToken)
        {
            var resp = new CommonResponse<Model.Users.Request.User>();
            try
            {
                if (string.IsNullOrEmpty(request.ID))
                    await _userData.CreateAsync(request, cancellationToken);
                else
                    await _userData.UpdateAsync(request, cancellationToken);
                var user = await _userData.GetAsync(null, request.UserID, cancellationToken);
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

using MediatR;
using MyDictionary.Data.User.Interfaces;
using MyDictionary.Model.Common;
using MyDictionary.Model.User.Request;

namespace MyDictionary.Business.User.Queries
{
    public class SaveUser(IUserData customerData) : IRequestHandler<UserRequest, CommonResponse<UserRequest>>
    {
        private readonly IUserData _customerData = customerData;

        public async Task<CommonResponse<UserRequest>> Handle(UserRequest request, CancellationToken cancellationToken)
        {
            CommonResponse<UserRequest> response = new();
            return response;
        }
    }
}

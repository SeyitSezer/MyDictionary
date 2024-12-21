using MediatR;
using MyDictionary.Model.Common;

namespace MyDictionary.Model.Users.Request
{
    public class GetAllUser : IRequest<CommonResponse<List<User>>>
    {
        
    }
}

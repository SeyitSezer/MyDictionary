using MediatR;
using MyDictionary.Model.Common;

namespace MyDictionary.Model.Users.Request
{
    public class GetUser : IRequest<CommonResponse<User>>
    {
        public string? ID { get; set; }
        public string? UserID { get; set; }
    }
}

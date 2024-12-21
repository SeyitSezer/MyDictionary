using MediatR;
using MyDictionary.Model.Common;

namespace MyDictionary.Model.User.Request
{
    public class UserRequest : IRequest<CommonResponse<UserRequest>>
    {
        public string? ID { get; set; }
        public string? Nationality { get; set; }
        public required string UserID { get; set; }
        public required string UserName { get; set; }
        public string? ReferenceUserID { get; set; }
        public string? ClanID { get; set; }
        public int? Level { get; set; }
        public double? Balance { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string? GSMNumber { get; set; }
        public string? EmailAddress { get; set; }
    }
}

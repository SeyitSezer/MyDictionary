using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MyDictionary.Model.Common;

namespace MyDictionary.Model.Users.Request
{
    public class User : IRequest<CommonResponse<User>>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ID { get; set; }
        public string? Nationality { get; set; }
        public required string UserID { get; set; }
        public required string UserName { get; set; }
        public string? ReferenceUserID { get; set; }
        public string? ClanID { get; set; }
        public int? Level { get; set; }
        public double? Balance { get; set; }
        public bool? IsActive { get; set; }
        public string? GSMNumber { get; set; }
        public string? EmailAddress { get; set; }
        public DateTime? RegisterDate { get; set; } = DateTime.Now;
        public DateTime LastLoginDate { get; set; } = DateTime.Now;
    }
}

using MediatR;
using MyDictionary.Enums;
using MyDictionary.Model.Common;
using MyDictionary.Model.Customer.Response;

namespace MyDictionary.Model.Customer.Request
{
    public class CustomerRequest : IRequest<CommonResponse<CustomerResponse>>
    {
        public string? Nationality {  get; set; }
        public string? NationalID { get; set; }
        public required string Name { get; set; }
        public string? Surname {  get; set; }
        public DateTime BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? IdentityCardSeries {  get; set; }
        public string? IdentityCardSerialNumber {  get; set; }
        public string? MothersName { get; set; }
        public string? FathersName { get; set; }
        public Gender Gender { get; set; }
        public string? GSMNumber { get; set; }
        public string? EmailAddress { get; set; }
    }
}

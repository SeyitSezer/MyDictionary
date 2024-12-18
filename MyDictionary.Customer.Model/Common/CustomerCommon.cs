using MyDictionary.Enums;

namespace MyDictionary.Model.Customer.Common
{
    public class CustomerCommon
    {
        public int Id { get; set; }
        public string? Nationality { get; set; }
        public string? NationalID { get; set; }
        public required string Name { get; set; }
        public string? Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? IdentityCardSeries { get; set; }
        public string? IdentityCardSerialNumber { get; set; }
        public string? MothersName { get; set; }
        public string? FathersName { get; set; }
        public Gender Gender { get; set; }
        public string? GSMNumber { get; set; }
        public string? EmailAddress { get; set; }
    }
}

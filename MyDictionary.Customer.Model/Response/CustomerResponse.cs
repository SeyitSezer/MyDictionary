namespace MyDictionary.Model.Customer.Response
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Surname { get; set; }
    }
}

using MyDictionary.Data.Customer.Interfaces;
using MyDictionary.Model.Customer.Common;
using MyDictionary.Model.Customer.Request;
using MyDictionary.Model.Customer.Response;

namespace MyDictionary.Data.Customer.Services
{
    public class CustomerData : ICustomerData
    {
        public Task<CustomerCommon> GetCustomer(int ID, CancellationToken token)
        {

            return Task.FromResult(new CustomerCommon()
            {
                Id = 1,
                Nationality = "Türkiye",
                NationalID = "11111111110",
                Name = "Ahmet",
                Surname = "Mehmet",
                BirthDate = Convert.ToDateTime("2000-02-25"),
                BirthPlace = "İstanbul",
                GSMNumber = "0501 234 56 78",
                EmailAddress = "test@gmail.com",
                Gender = Enums.Gender.Male,
                MothersName = "Emine",
                FathersName = "Ali",
                IdentityCardSerialNumber = "123456",
                IdentityCardSeries = "A13"
            });
        }

        public Task<CustomerResponse> SaveCustomer(CustomerRequest request, CancellationToken token)
        {
            return Task.FromResult(new CustomerResponse()
            {
                Id = 1,
                Name = "Ahmet",
                Surname = "Mehmet",
            });
        }
    }
}

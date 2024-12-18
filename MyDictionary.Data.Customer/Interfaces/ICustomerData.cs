using MyDictionary.Model.Customer.Common;
using MyDictionary.Model.Customer.Request;
using MyDictionary.Model.Customer.Response;

namespace MyDictionary.Data.Customer.Interfaces
{
    public interface ICustomerData
    {
        public Task<CustomerCommon> GetCustomer(int ID, CancellationToken token);
        public Task<CustomerResponse> SaveCustomer(CustomerRequest request, CancellationToken token);
    }
}

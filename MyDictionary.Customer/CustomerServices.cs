using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyDictionary.Business.Customer.Queries;
using MyDictionary.Data.Customer.Interfaces;
using MyDictionary.Data.Customer.Services;
using MyDictionary.Model.Common;
using MyDictionary.Model.Customer.Request;
using MyDictionary.Model.Customer.Response;

namespace MyDictionary.Business.Customer
{
    public class CustomerServices
    {
        public static IServiceCollection AddCustomerServices(IServiceCollection services)
        {

            services.AddSingleton<ICustomerData, CustomerData>();
            return services.AddSingleton<IRequestHandler<CustomerRequest, CommonResponse<CustomerResponse>>, SaveCustomer>();
        }
    }
}

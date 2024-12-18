using MediatR;
using MyDictionary.Data.Customer.Interfaces;
using MyDictionary.Model.Common;
using MyDictionary.Model.Customer.Request;
using MyDictionary.Model.Customer.Response;

namespace MyDictionary.Business.Customer.Queries
{
    public class SaveCustomer(ICustomerData customerData) : IRequestHandler<CustomerRequest, CommonResponse<CustomerResponse>>
    {
        private readonly ICustomerData _customerData = customerData;

        public async Task<CommonResponse<CustomerResponse>> Handle(CustomerRequest request, CancellationToken cancellationToken)
        {
            CommonResponse<CustomerResponse> response = new();
            if (request.Nationality == "Türkiye" && !string.IsNullOrEmpty(request.NationalID) && request.NationalID.Length != 11)
            {
                response.IsSuccess = false;
                response.Status = -1;
                response.StatusDesciption = "Validation Error";
                response.Message = "NationalID is not valid!";
            }
            else
            {
                response.IsSuccess = true;
                response.Status = 0;
                response.Data = _customerData.SaveCustomer(request, cancellationToken).Result;
            }
            return response;
        }
    }
}

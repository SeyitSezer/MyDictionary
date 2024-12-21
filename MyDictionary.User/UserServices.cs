using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyDictionary.Business.User.Queries;
using MyDictionary.Data.User.Interfaces;
using MyDictionary.Data.User.Services;
using MyDictionary.Model.Common;
using MyDictionary.Model.User.Request;

namespace MyDictionary.Business.User
{
    public class UserServices
    {
        public static IServiceCollection AddUserServices(IServiceCollection services)
        {

            services.AddSingleton<IUserData, UserData>();
            return services.AddSingleton<IRequestHandler<UserRequest, CommonResponse<UserRequest>>, SaveUser>();
        }
    }
}

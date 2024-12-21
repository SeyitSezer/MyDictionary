using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyDictionary.Business.Users.Queries;
using MyDictionary.Data.Users.Interfaces;
using MyDictionary.Data.Users.Services;
using MyDictionary.Model.Common;
using MyDictionary.Model.Users.Request;

namespace MyDictionary.Business.Users
{
    public class UserServices(IUserData userdata)
    {
        private readonly IUserData userdata = userdata;

        public static IServiceCollection AddUserServices(IServiceCollection services)
        {

            services.AddSingleton<IUserData, UserData>();
            return services.AddSingleton<IRequestHandler<User, CommonResponse<User>>, SaveUserData>();
        }
    }
}

using MyDictionary.Business.User;
using MyDictionary.Data.User.Interfaces;
using MyDictionary.Data.User.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
IConfiguration configuration = builder.Configuration;

string? redisConnStr = $"{configuration.GetSection("Redis").GetValue<string>("Host")}:{configuration.GetSection("Redis").GetValue<string>("Port")}";
if (!string.IsNullOrEmpty(redisConnStr))
{
    var options = new ConfigurationOptions
    {
        EndPoints = { redisConnStr},
        AbortOnConnectFail = false,
        AsyncTimeout = 1000,
        SyncTimeout = 1000,
        AllowAdmin = true,
    };
    var redisConn = ConnectionMultiplexer.Connect(options);
    builder.Services.AddSingleton<IConnectionMultiplexer>(redisConn);
}

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
UserServices.AddUserServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

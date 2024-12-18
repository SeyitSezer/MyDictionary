using Microsoft.Extensions.Configuration;
using MyDictionary.Redis.Interfaces;
using StackExchange.Redis;

namespace MyDictionary.Redis.Services
{
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer _redisConnection;
        private readonly IConfiguration _configuration;
        private readonly int _deflifeTime;

        public RedisService(IConnectionMultiplexer redisConnection, IConfiguration configuration)
        {
            _redisConnection = redisConnection;
            _configuration = configuration;
            _deflifeTime = Convert.ToInt32(_configuration.GetSection("Redis:LifeTime").Value);
        }
        public string? GetValue(string key)
        {
            IDatabase _redis = _redisConnection.GetDatabase();
            return _redis.StringGet(key);
        }

        public async Task<string?> GetValueAsync(string key)
        {
            IDatabase _redis = _redisConnection.GetDatabase();
            return await _redis.StringGetAsync(key);
        }

        public bool SetValue(string key, string value, int lifeTime = -1)
        {
            IDatabase _redis = _redisConnection.GetDatabase();
            if (lifeTime == 0)
            {
                return _redis.StringSet(key, value);
            }
            else
            {
                return _redis.StringSet(key, value, TimeSpan.FromMinutes(lifeTime == -1 ? _deflifeTime : lifeTime));
            }
        }

        public async Task<bool> SetValueAsync(string key, string value, int lifeTime = -1)
        {
            IDatabase _redis = _redisConnection.GetDatabase();
            if (lifeTime == 0)
            {
                return await _redis.StringSetAsync(key, value);
            }
            else
            {
                return await _redis.StringSetAsync(key, value, TimeSpan.FromMinutes(lifeTime == -1 ? _deflifeTime : lifeTime));
            }
        }

        public bool Delete(string key)
        {
            IDatabase _redis = _redisConnection.GetDatabase();
            return _redis.KeyDelete(key);
        }

        public async Task<bool> DeleteAsync(string key)
        {
            IDatabase _redis = _redisConnection.GetDatabase();
            return await _redis.KeyDeleteAsync(key);
        }

        public bool ClearAll()
        {
            try
            {
                IDatabase _redis = _redisConnection.GetDatabase();
                var redisEndpoints = _redisConnection.GetEndPoints(true);
                foreach (var redisEndpoint in redisEndpoints)
                {
                    var redisServer = _redisConnection.GetServer(redisEndpoint);
                    redisServer.FlushAllDatabases();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> ClearAllAsync()
        {
            try
            {
                var redisEndpoints = _redisConnection.GetEndPoints(true);
                foreach (var redisEndpoint in redisEndpoints)
                {
                    var redisServer = _redisConnection.GetServer(redisEndpoint);
                    await redisServer.FlushAllDatabasesAsync();
                }
                return true;
            }
            catch //(Exception ex)
            {
                return false;
            }
        }
    }
}

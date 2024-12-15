using MyDictionary.Redis.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary.Redis.Services
{
    public class RedisService(IConnectionMultiplexer redisConnection) : IRedisService
    {
        private readonly IConnectionMultiplexer _redisConnection = redisConnection;

        public string? GetValue(string key)
        {
            IDatabase _redis = redisConnection.GetDatabase();
            return _redis.StringGet(key);
        }

        public async Task<string?> GetValueAsync(string key)
        {
            IDatabase _redis = redisConnection.GetDatabase();
            return await _redis.StringGetAsync(key);
        }

        public bool SetValue(string key, string value)
        {
            IDatabase _redis = redisConnection.GetDatabase();
            return _redis.StringSet(key, value);
        }

        public async Task<bool> SetValueAsync(string key, string value)
        {
            IDatabase _redis = redisConnection.GetDatabase();
            return await _redis.StringSetAsync(key, value);
        }

        public bool Delete(string key)
        {
            IDatabase _redis = redisConnection.GetDatabase();
            return _redis.KeyDelete(key);
        }

        public async Task<bool> DeleteAsync(string key)
        {
            IDatabase _redis = redisConnection.GetDatabase();
            return await _redis.KeyDeleteAsync(key);
        }

        public bool ClearAll()
        {
            try
            {
                IDatabase _redis = redisConnection.GetDatabase();
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
                IDatabase _redis = redisConnection.GetDatabase();
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

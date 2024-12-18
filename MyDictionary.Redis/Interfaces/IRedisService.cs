﻿namespace MyDictionary.Redis.Interfaces
{
    public interface IRedisService
    {
        string? GetValue(string key);
        Task<string?> GetValueAsync(string key);
        bool SetValue(string key, string value, int lifeTime = -1);
        Task<bool> SetValueAsync(string key, string value, int lifeTime = -1);
        bool Delete(string key);
        Task<bool> DeleteAsync(string key);
        bool ClearAll();
        Task<bool> ClearAllAsync();
    }
}

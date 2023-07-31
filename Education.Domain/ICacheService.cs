using System;

namespace Education.Domain
{
    public interface ICacheService
    {
        T Get<T>(string key);
        void Add(string key, object data, TimeSpan expireTime);
        void Remove(string key);
        void Clear();
        bool Any(string key);
    }
}

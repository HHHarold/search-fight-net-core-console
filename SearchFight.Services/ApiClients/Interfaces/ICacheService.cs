﻿namespace SearchFight.Services.ApiClients.Interfaces
{
    public interface ICacheService
    {
        T Get<T>(string cacheKey) where T : class;
        void Set(string cacheKey, object item);
    }
}

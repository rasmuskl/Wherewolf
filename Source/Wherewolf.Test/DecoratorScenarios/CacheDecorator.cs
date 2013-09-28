using System;
using System.Collections.Generic;
using System.Linq;
using Wherewolf;

namespace WhereWolf.Test.DecoratorScenarios
{
    /// <summary>
    /// Caches query results and serves them dependent on 
    /// queries implementing a specific interface.
    /// </summary>
    public class CacheDecorator : IExecutionDecorator
    {
        private readonly Dictionary<string, object> _simpleCache = new Dictionary<string, object>(); 

        public TResult Execute<TResult>(Func<TResult> queryFunc, object query)
        {
            var cachedQuery = query as ICachedQuery;

            if (cachedQuery == null)
            {
                return queryFunc();
            }

            var cacheKey = cachedQuery.CacheKey;

            object result;
            if (_simpleCache.TryGetValue(cacheKey, out result))
            {
                return (TResult)result;
            }

            var queryResult = queryFunc();

            _simpleCache[cacheKey] = queryResult;
            return queryResult;
        }
    }

    public interface ICachedQuery
    {
        string CacheKey { get; }
    }
}
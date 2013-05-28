using System;
using System.Linq;
using System.Collections.Generic;

namespace Wherewolf
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly IResolver _resolver;

        public QueryExecutor(IResolver resolver)
        {
            _resolver = resolver;
        }

        public TResult Execute<TResult>(IQuery<TResult> query)
        {
            return query.Execute();
        }

        public TResult Execute<TResult, TDep1>(IQuery<TResult, TDep1> query)
        {
            return query.Execute(_resolver.Resolve<TDep1>());
        }

        public TResult Execute<TResult, TDep1, TDep2>(IQuery<TResult, TDep1, TDep2> query)
        {
            return query.Execute(_resolver.Resolve<TDep1>(), _resolver.Resolve<TDep2>());
        }

        public TResult Execute<TResult, TDep1, TDep2, TDep3>(IQuery<TResult, TDep1, TDep2, TDep3> query)
        {
            return query.Execute(_resolver.Resolve<TDep1>(), _resolver.Resolve<TDep2>(), _resolver.Resolve<TDep3>());
        }
    }
}
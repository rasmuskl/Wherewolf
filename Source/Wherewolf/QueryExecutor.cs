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
            return WrapQuery(query.Execute);
        }

        public TResult Execute<TResult, TDep1>(IQuery<TResult, TDep1> query)
        {
            return WrapQuery(() => query.Execute(_resolver.Resolve<TDep1>()));
        }

        public TResult Execute<TResult, TDep1, TDep2>(IQuery<TResult, TDep1, TDep2> query)
        {
            return WrapQuery(() => query.Execute(_resolver.Resolve<TDep1>(), _resolver.Resolve<TDep2>()));
        }

        public TResult Execute<TResult, TDep1, TDep2, TDep3>(IQuery<TResult, TDep1, TDep2, TDep3> query)
        {
            return WrapQuery(() => query.Execute(_resolver.Resolve<TDep1>(), _resolver.Resolve<TDep2>(), _resolver.Resolve<TDep3>()));
        }

        public TResult Execute<TResult, TDep1, TDep2, TDep3, TDep4>(IQuery<TResult, TDep1, TDep2, TDep3, TDep4> query)
        {
            return WrapQuery(() => query.Execute(_resolver.Resolve<TDep1>(), _resolver.Resolve<TDep2>(), _resolver.Resolve<TDep3>(), _resolver.Resolve<TDep4>()));
        }

        public TResult Execute<TResult, TDep1, TDep2, TDep3, TDep4, TDep5>(IQuery<TResult, TDep1, TDep2, TDep3, TDep4, TDep5> query)
        {
            return WrapQuery(() => query.Execute(_resolver.Resolve<TDep1>(), _resolver.Resolve<TDep2>(), _resolver.Resolve<TDep3>(), _resolver.Resolve<TDep4>(), _resolver.Resolve<TDep5>()));
        }
        
        public TResult Execute<TResult, TDep1, TDep2, TDep3, TDep4, TDep5, TDep6>(IQuery<TResult, TDep1, TDep2, TDep3, TDep4, TDep5, TDep6> query)
        {
            return WrapQuery(() => query.Execute(_resolver.Resolve<TDep1>(), _resolver.Resolve<TDep2>(), _resolver.Resolve<TDep3>(), _resolver.Resolve<TDep4>(), _resolver.Resolve<TDep5>(), _resolver.Resolve<TDep6>()));
        }

        private TResult WrapQuery<TResult>(Func<TResult> func)
        {
            return func();
        }
    }
}
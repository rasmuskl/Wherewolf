using System;
using System.Linq;
using System.Collections.Generic;

namespace Wherewolf
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly IResolver _resolver;
        private readonly IExecutionDecorator[] _executionDecorators;

        public QueryExecutor(IResolver resolver, IExecutionDecorator[] executionDecorators)
        {
            _resolver = resolver;
            _executionDecorators = executionDecorators;
        }

        public TResult Execute<TResult>(IQuery<TResult> query)
        {
            return WrapQuery(query, query.Execute);
        }

        public TResult Execute<TResult, TDep1>(IQuery<TResult, TDep1> query)
        {
            return WrapQuery(query, () => query.Execute(_resolver.Resolve<TDep1>()));
        }

        public TResult Execute<TResult, TDep1, TDep2>(IQuery<TResult, TDep1, TDep2> query)
        {
            return WrapQuery(query, () => query.Execute(_resolver.Resolve<TDep1>(), _resolver.Resolve<TDep2>()));
        }

        public TResult Execute<TResult, TDep1, TDep2, TDep3>(IQuery<TResult, TDep1, TDep2, TDep3> query)
        {
            return WrapQuery(query, () => query.Execute(_resolver.Resolve<TDep1>(), _resolver.Resolve<TDep2>(), _resolver.Resolve<TDep3>()));
        }

        public TResult Execute<TResult, TDep1, TDep2, TDep3, TDep4>(IQuery<TResult, TDep1, TDep2, TDep3, TDep4> query)
        {
            return WrapQuery(query, () => query.Execute(_resolver.Resolve<TDep1>(), _resolver.Resolve<TDep2>(), _resolver.Resolve<TDep3>(), _resolver.Resolve<TDep4>()));
        }

        public TResult Execute<TResult, TDep1, TDep2, TDep3, TDep4, TDep5>(IQuery<TResult, TDep1, TDep2, TDep3, TDep4, TDep5> query)
        {
            return WrapQuery(query, () => query.Execute(_resolver.Resolve<TDep1>(), _resolver.Resolve<TDep2>(), _resolver.Resolve<TDep3>(), _resolver.Resolve<TDep4>(), _resolver.Resolve<TDep5>()));
        }
        
        public TResult Execute<TResult, TDep1, TDep2, TDep3, TDep4, TDep5, TDep6>(IQuery<TResult, TDep1, TDep2, TDep3, TDep4, TDep5, TDep6> query)
        {
            return WrapQuery(query, () => query.Execute(_resolver.Resolve<TDep1>(), _resolver.Resolve<TDep2>(), _resolver.Resolve<TDep3>(), _resolver.Resolve<TDep4>(), _resolver.Resolve<TDep5>(), _resolver.Resolve<TDep6>()));
        }

        private TResult WrapQuery<TResult>(object query, Func<TResult> queryFunc)
        {
            for (var i = _executionDecorators.Length - 1; i >= 0; i--)
            {
                var executionDecorator = _executionDecorators[i];
                Func<TResult> prevFunc = queryFunc;
                Func<TResult> nextFunc = () => executionDecorator.Execute(prevFunc, query);
                queryFunc = nextFunc;
            }

            return queryFunc();
        }
    }
}
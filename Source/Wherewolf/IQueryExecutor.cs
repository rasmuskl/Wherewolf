using System.Linq;
using System.Collections.Generic;
using System;

namespace Wherewolf
{
    public interface IQueryExecutor
    {
        TResult Execute<TResult>(IQuery<TResult> query);
        TResult Execute<TResult, TDep1>(IQuery<TResult, TDep1> query);
        TResult Execute<TResult, TDep1, TDep2>(IQuery<TResult, TDep1, TDep2> query);
        TResult Execute<TResult, TDep1, TDep2, TDep3>(IQuery<TResult, TDep1, TDep2, TDep3> query);
    }
}
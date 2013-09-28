using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Wherewolf;

namespace WhereWolf.Test.DecoratorScenarios
{
    /// <summary>
    /// Logs the performance of a query and records it's type.
    /// Is not interested in the result of the query.
    /// </summary>
    public class PerformanceLogDecorator : IExecutionDecorator
    {
        public TResult Execute<TResult>(Func<TResult> queryFunc, object query)
        {
            var stopwatch = Stopwatch.StartNew();

            var queryResult = queryFunc();

            stopwatch.Stop();

            return queryResult;
        }
    }
}
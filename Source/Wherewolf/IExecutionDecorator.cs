using System;

namespace Wherewolf
{
    public interface IExecutionDecorator
    {
        TResult Execute<TResult>(Func<TResult> queryFunc, object query);
    }
}
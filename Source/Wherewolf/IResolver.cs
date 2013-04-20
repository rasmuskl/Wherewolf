using System.Linq;
using System.Collections.Generic;
using System;

namespace Wherewolf
{
    public interface IResolver
    {
        T Resolve<T>();
    }
}
using System.Linq;
using System.Collections.Generic;
using System;

namespace WhereWolf.Core
{
    public interface IResolver
    {
        T Resolve<T>();
    }
}
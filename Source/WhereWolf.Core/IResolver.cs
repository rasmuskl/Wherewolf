using System.Linq;
using System.Collections.Generic;
using System;

namespace Wherewolf.Core
{
    public interface IResolver
    {
        T Resolve<T>();
    }
}
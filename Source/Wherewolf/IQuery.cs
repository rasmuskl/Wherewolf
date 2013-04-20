﻿using System.Linq;
using System.Collections.Generic;
using System;

namespace Wherewolf
{
    public interface IQuery<out TReturn>
    {
        TReturn Execute();
    }

    public interface IQuery<out TReturn, in TDep1>
    {
        TReturn Execute(TDep1 dep1);
    }

    public interface IQuery<out TReturn, in TDep1, in TDep2>
    {
        TReturn Execute(TDep1 dep1, TDep2 dep2);
    }

    public interface IQuery<out TReturn, in TDep1, in TDep2, in TDep3>
    {
        TReturn Execute(TDep1 dep1, TDep2 dep2, TDep3 dep3);
    }
}
using Rolfin.Result.MetaResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rolfin.Result.Paged
{
    public interface IPagedResult<T>
    { 
        IEnumerable<T> List { get; }
        PageInfo PageInfo { get; }
        bool HasRecords();
    }
}

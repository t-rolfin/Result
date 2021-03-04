using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result
{
    public interface IMetaResult
    {
        int Code { get; }
        string Name { get; }
        string Message { get; }
    }
}

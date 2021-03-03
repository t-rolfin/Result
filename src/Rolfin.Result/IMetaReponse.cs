using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result
{
    public interface IMetaResponse
    {
        int Code { get; }
        string Name { get; }
        string Message { get; }
    }
}

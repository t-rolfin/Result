using System;

namespace Rolfin.Result
{
    public interface IResult<T>
    {
        T Value { get; }
    }
}
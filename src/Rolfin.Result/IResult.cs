using System;

namespace Rolfin.Result
{
    public interface IResult<T> : IValue<T>
    { }

    public interface IValue<out T>
    {
        T Value { get; }
    }
}
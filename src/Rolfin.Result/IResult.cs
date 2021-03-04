using System;

namespace Rolfin.Result
{
    public interface IResult<T>
    {
        Type GetValueType { get; }
        bool IsSuccess { get; }

        [Obsolete]
        string Message { get; }
        IMetaResult MetaResult { get; }
        T Value { get; }
    }
}
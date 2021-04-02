using Rolfin.Result.MetaResults;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Rolfin.Result
{

    public class Result : Result<string>
    {
        public Result() : base() { }

        public Result(string result)
        : base(result) { }
    }

    public partial class Result<T> : BaseResult<Result<T>>, IResult<T>
    {
        internal Result(T value, IMetaResult metaResult)
        {
            this.Value = value;
            base.MetaResult = metaResult;
        }

        public Result() : base() { }

        public Result(T value) : base()
        {
            this.Value = value;
        }


        public T Value { get; protected set; }


        public static implicit operator T(Result<T> result)
            => result.Value;

        public static implicit operator Result<T>(T value)
        {
            if(value is Result<T> result)
            {
                IMetaResult meta = result.IsSuccess ? new Ok() : default;
                T resultValue = result.IsSuccess ? result.Value : default;

                return new Result<T>(resultValue, meta);
            }

            return Success(value);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            if (obj is IMetaResult && obj.GetType() == this.MetaResult.GetType())
                return true;

            var metaResult = obj.GetType()
                .GetProperty("MetaResult")
                .GetValue(obj);

            return metaResult.GetType() == this?.MetaResult.GetType()
                ? true
                : false;
        }

        public override int GetHashCode()
        {
            return MetaResult.GetHashCode() ^ Value.GetHashCode();
        }


        public override Type GetValueType()
            => typeof(T);
    }
}

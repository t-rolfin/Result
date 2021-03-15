using Rolfin.Result.MetaResults;
using System;
using System.Collections.Generic;
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

            if (obj == null)
                return false;

            if (typeof(IMetaResult).IsAssignableFrom(obj.GetType()) 
                && obj.GetType() == this.MetaResult.GetType())
            {
                return true;
            }

            if(obj.GetType() == typeof(Result<T>))
            {
                var otherObj = (Result<T>)obj;

                if (otherObj?.MetaResult.GetType() != this?.MetaResult.GetType())
                    return false;

                return otherObj.MetaResult.Code == this.MetaResult.Code;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.MetaResult.GetHashCode() ^ Value.GetHashCode();
        }

        public static bool operator ==(Result<T> lr, Result<T> rr)
        {
            if(ReferenceEquals(lr, null) && ReferenceEquals(rr, null))
                return true;

            if (ReferenceEquals(lr, rr))
                return true;

            return false;
        }

        public static bool operator !=(Result<T> lr, Result<T> rr)
        {
            return !(lr == rr);
        }


        public override Type GetValueType()
            => typeof(T);
    }
}

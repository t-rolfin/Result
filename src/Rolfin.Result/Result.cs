using Rolfin.Result.MetaResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result
{

    public class Result : Result<string>
    {
        public Result() { }

        public Result(string result)
        : base(result) { }
    }

    public class Result<T> : BaseResult<Result<T>>, IResult<T>
    {
        public Result() { }

        public Result(T result)
        {
            this.Value = result;
        }


        public T Value { get; protected set; }


        public static implicit operator T(Result<T> result)
            => result.Value;
        public static implicit operator Result<T>(T value)
            => Success<T>(value);


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


        public static Result<T> Success()
        {
            return new Result<T>()
            {
                IsSuccess = true,
                Value = default(T)
            };
        }

        public static Result<T> Success(T result)
        {
            return new Result<T>(result) { IsSuccess = true };
        }

        public static Result<R> Success<R>(R result)
        {
            return new Result<R>(result) { IsSuccess = true };
        }

        public static Result<T> Invalid()
        {
            return new Result<T>()
            {
                IsSuccess = false,
                Value = default(T),
                MetaResult = new NotFound()
            };
        }

        [Obsolete("Soon this will be not longer available, can use instead Invalid() with With() method which gets message as parameter.")]
        public static Result<T> Invalid(string message)
        {
            return new Result<T>()
            {
                IsSuccess = false,
                MetaResult = new NotFound { Message = message }
            };
        }

        public static Result<R> Invalid<R>(R result)
        {
            return new Result<R>(result) 
            { 
                IsSuccess = false,
                MetaResult = new NotFound()
            };
        }

    }
}

using Rolfin.Result.MetaResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result
{
    public partial class Result<T>
    {
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result
{

    public class Result : Result<string>
    { }

    public class Result<T> : IResult<T>
    {
        public Result() { }
        public Result(T result)
        {
            this.Value = result;
        }


        private bool isSuccess { get; set; }


        public T Value { get; private set; }

        public bool IsSuccess
            => isSuccess;


        public static Result<T> Success()
        {
            return new Result<T>() { isSuccess = true };
        }

        public static Result<T> Success(T result)
        {
            return new Result<T>(result) { isSuccess = true };
        }

        public static Result<T> Invalid(T message)
        {
            return new Result<T>(message);
        }

        public static Result<T> Invalid()
        {
            return new Result<T>() { isSuccess = false };
        }

    }
}

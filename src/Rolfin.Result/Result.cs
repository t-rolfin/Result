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

        public Result(string message)
        {
            this.Message = message;
        }

        private bool isSuccess { get; set; }


        public T Value { get; private set; }
        public string Message { get; private set; }

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

        public static Result<R> Success<R>(R result)
        {
            return new Result<R>(result) { isSuccess = true };
        }

        public static Result<T> Invalid(string message)
        {
            return new Result<T>(message) { isSuccess = false };
        }

        public static Result<R> Invalid<R>(R result)
        {
            return new Result<R>(result) { isSuccess = false };
        }

        public static Result<T> Invalid()
        {
            return new Result<T>() { isSuccess = false };
        }

    }
}

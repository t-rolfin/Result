﻿using Rolfin.Result.MetaResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result
{

    public class Result : Result<string>
    { }

    public class Result<T> : BaseResult<T>, IResult<T>
    {
        public Result() { }
        public Result(T result)
        {
            this.Value = result;
        }


        public T Value { get; protected set; }


        public static Result<T> Success()
        {
            return new Result<T>()
            {
                isSuccess = true,
                Value = default(T)
            };
        }

        public static Result<T> Success(T result)
        {
            return new Result<T>(result) { isSuccess = true };
        }

        public static Result<R> Success<R>(R result)
        {
            return new Result<R>(result) { isSuccess = true };
        }

        public static Result<T> Invalid()
        {
            return new Result<T>()
            {
                isSuccess = false,
                Value = default(T)
            };
        }

        public static Result<T> Invalid(string message)
        {
            return new Result<T>()
            {
                isSuccess = false,
                MetaResult = new Custom { Message = message }
            };
        }

        public static Result<R> Invalid<R>(R result)
        {
            return new Result<R>(result) { isSuccess = false };
        }

    }
}

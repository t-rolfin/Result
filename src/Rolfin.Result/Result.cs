using Rolfin.Result.MetaResponses;
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

        private bool isSuccess;


        public T Value { get; protected set; }

        [Obsolete("You can use 'MetaResponse' to customize you messages.")]
        public string Message { get; protected set; }

        public IMetaResponse MetaResponse { get; protected set; }


        public Type GetValueType
            => typeof(T);

        public bool IsSuccess
            => isSuccess;

        /// <summary>
        /// This helps you to customize your MetaResponse 
        /// with your own massage, code, and name response
        /// </summary>
        /// <typeparam name="CType"> Type of custom MetaResponse </typeparam>
        /// <param name="metaResponse"> Insance of your custom MetaResponse </param>
        /// <returns> Result<T> with you custom MetaResponse </returns>
        public Result<T> With<CType>()
            where CType : IMetaResponse
        {
            this.MetaResponse = Activator.CreateInstance<CType>(); ;
            return this;
        }


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
                Message = message,
                MetaResponse = new Custom{ Message = message }
            };
        }

        public static Result<R> Invalid<R>(R result)
        {
            return new Result<R>(result) { isSuccess = false };
        }

    }
}

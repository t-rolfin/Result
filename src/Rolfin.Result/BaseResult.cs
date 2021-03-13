using Rolfin.Result.MetaResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result
{
    public abstract class BaseResult<T>
        where T : BaseResult<T>
    {
        private bool isSuccess;
        public bool IsSuccess
        {
            get { return IsSuccess; }
            protected set { isSuccess = value; }
        }


        public IMetaResult MetaResult { get; protected set; }
            = new Ok();


        public abstract Type GetValueType();


        /// <summary>
        /// This helps to customize your MetaResponse 
        /// with your own massage, code, and name response
        /// </summary>
        /// <typeparam name="CType"> Type of custom MetaResponse </typeparam>
        /// <param name="metaResponse"></param>
        /// <returns></returns>
        public T With<CType>()
            where CType : IMetaResult
        {
            this.MetaResult = Activator.CreateInstance<CType>();
            return (T)this;
        }

        public T With<CType>(string message)
            where CType : IMetaResult
        {
            this.MetaResult = Activator.CreateInstance<CType>();

            if (!string.IsNullOrWhiteSpace(message))
                this.MetaResult.Message = message;

            return (T)this;
        }

        /// <summary>
        /// This helps to replace default message with a custom one.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public T With(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
                this.MetaResult.Message = message;

            return (T)this;
        }
    }
}

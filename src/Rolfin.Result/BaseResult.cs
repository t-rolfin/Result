using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result
{
    public abstract class BaseResult<T>
    {
        private bool isSuccess;
        public bool IsSuccess
        {
            get { return IsSuccess; }
            protected set { isSuccess = value; }
        }


        public IMetaResult MetaResult { get; protected set; }


        public Type GetValueType
            => typeof(T);

        /// <summary>
        /// This helps you to customize your MetaResponse 
        /// with your own massage, code, and name response
        /// </summary>
        /// <typeparam name="CType"> Type of custom MetaResponse </typeparam>
        /// <param name="metaResponse"> Insance of your custom MetaResponse </param>
        /// <returns> Result<T> with you custom MetaResponse </returns>
        public virtual BaseResult<T> With<CType>()
            where CType : IMetaResult
        {
            this.MetaResult = Activator.CreateInstance<CType>();
            return this;
        }
    }
}

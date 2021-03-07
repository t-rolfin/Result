using Rolfin.Result.MetaResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rolfin.Result.Paged
{
    public class PagedResult<T> : BaseResult<T>, IPagedResult<T>
    {
        public PagedResult() 
        { 
            List = null;
            PageInfo = default;
            MetaResult = new Custom();
        }
        public PagedResult(PageInfo pageInfo, IEnumerable<T> list)
        {
            List = list;
            PageInfo = pageInfo;
            MetaResult = new Custom();
        }


        public IEnumerable<T> List { get; private set; }
        public PageInfo PageInfo { get; private set; }


        public bool HasRecords()
            => List is null 
                ? false 
                : List.ToList().Count == 0 
                    ? false 
                    : true;


        public static PagedResult<T> Success(PageInfo pageInfo, IEnumerable<T> list)
        {
            return new PagedResult<T>(pageInfo, list)
            {
                IsSuccess = true,
                MetaResult = new Ok()
            };
        }

        public static PagedResult<T> Invalid()
        {
            return new PagedResult<T>()
            {
                IsSuccess = false,
                List = null,
                PageInfo = default,
                MetaResult = new NotFound()
            };
        }

        public static PagedResult<T> Invalid(string message)
        {
            return new PagedResult<T>()
            {
                IsSuccess = false,
                List = null,
                PageInfo = default,
                MetaResult = new Custom { Message = message }
            };
        }

    }
}

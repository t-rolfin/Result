using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result.Paged
{
    public class PageInfo
    {
        public PageInfo() { }

        public PageInfo(int pageNumber, int pageSize, int totalPages, int totalRecords)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = totalPages;
            TotalRecords = totalRecords;
        }

        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalRecords { get; private set; }


        public PageInfo SetPageNumber(int pageNumber)
        {
            this.PageNumber = pageNumber;
            return this;
        }

        public PageInfo SetPageSize(int pageSize)
        {
            this.PageSize = pageSize;
            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result.MetaResults
{
    public class NotFound : IMetaResult
    {
        public int Code => 404;
        public string Name => "NotFound";
        public string Message { get; set; } = "No items found!";
    }
}

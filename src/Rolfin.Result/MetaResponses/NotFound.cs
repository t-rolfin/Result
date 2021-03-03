using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result.MetaResponses
{
    public class NotFound : IMetaResponse
    {
        public int Code => 404;
        public string Name => "NotFound";
        public string Message => "No items found!";
    }
}

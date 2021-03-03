using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result.MetaResponses
{
    internal class Custom : IMetaResponse
    {
        public int Code => 0;

        public string Name => "Custom message.";

        public string Message { get; set; }
    }
}

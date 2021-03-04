using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result.MetaResults
{
    internal class Custom : IMetaResult
    {
        public int Code => 0;

        public string Name => "Custom message.";

        public string Message { get; set; }
    }
}

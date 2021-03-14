using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result.MetaResults
{
    public class Ok : IMetaResult
    {
        public int Code => 200;
        public string Name => "Ok";
        public string Message { get; set; } = "The request was processed with success!";
    }
}

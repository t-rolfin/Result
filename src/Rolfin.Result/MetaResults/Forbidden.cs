using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result.MetaResults
{
    public class Forbidden : IMetaResult
    {
        public int Code => 403;
        public string Name => "Forbidden";
        public string Message => "You are not allowed to access this information.";
    }
}

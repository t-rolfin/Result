using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result.MetaResponses
{
    public class Ok : IMetaResponse
    {
        public int Code => 200;
        public string Name => "Ok";
        public string Message => "The request was processed with success!";
    }
}

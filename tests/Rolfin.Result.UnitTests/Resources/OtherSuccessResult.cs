using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result.UnitTests.Resources
{
    public class OtherSuccessResult : IMetaResult
    {
        public int Code => 202;

        public string Name => "Custom success result.";

        public string Message { get; set; } = "Other custom success result.";
    }
}

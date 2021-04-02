using System;
using System.Collections.Generic;
using System.Text;

namespace Rolfin.Result.UnitTests.Resources
{
    internal class CustomMetaResult : IMetaResult
    {
        public int Code => 22;
        public string Name => "No items available!";
        public string Message { get; set; } = "You don't have items in your feed.";
    }
}

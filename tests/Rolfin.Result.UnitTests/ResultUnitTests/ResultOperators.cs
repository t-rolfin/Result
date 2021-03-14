using Rolfin.Result.MetaResults;
using Rolfin.Result.UnitTests.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Rolfin.Result.UnitTests.ResultUnitTests
{
    public class ResultOperators
    {

        [Fact]
        public void ShouldReturnTheValueOfResult()
        {
            var result = Result<CustomMetaResult>.Success(new CustomMetaResult());
            CustomMetaResult value = result;

            Assert.IsType<CustomMetaResult>(value);
        }

        [Fact]
        public void ShouldReturnASuccessResult()
        {
            CustomMetaResult value = new CustomMetaResult();
            Result<CustomMetaResult> result = value;

            Assert.IsType<Result<CustomMetaResult>>(result);
            Assert.Equal(new Ok().Code, result.MetaResult.Code);
        }

    }
}

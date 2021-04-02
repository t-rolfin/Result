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

        [Fact]
        public void Reference_ShouldReturnFalse_WhenUseEqualsWithTwoDifferentResults()
        {
            var result1 = Result<object>.Invalid();
            var result2 = Result<object>.Success();

            var equality = result1 == result2;

            Assert.False(equality);
        }

        [Fact]
        public void Reference_ShouldReturnFalse_WhenChangeTheTypeOfOneResult()
        {
            var result1 = Result<object>.Invalid();
            var result2 = Result<object>.Success();
            result2.With<NotFound>();

            var equality = result1 == result2;

            Assert.False(equality);
        }

        [Fact]
        public void Reference_ShouldReturnFalse_WhenResultsHasNotSameReference()
        {
            var result1 = Result<object>.Success();
            var result2 = Result<object>.Success();

            var equality = result1 == result2;

            Assert.False(equality);
        }

        [Fact]
        public void Reference_ShouldReturnTrue_WhenResultHasSameReference()
        {
            var result = Result<object>.Success();
            var result1 = result;

            bool equality = result == result1;

            Assert.True(equality);
        }

        [Fact]
        public void Reference_ShouldReturnTrue_WhenComapareTwoNullResults()
        {
            Result<object> result1 = null;
            var result2 = result1;

            bool equality = result1 == result2;

            Assert.True(equality);
        }

        [Fact]
        public void Reference_ShouldReturnFalse_WhenOneOfResultIsNull()
        {
            var result = Result<object>.Success();
            Result<object> result1 = null;

            bool equality = result1 == result;

            Assert.False(equality);
        }

        [Fact]
        public void Content_ShouldReturnFalse_WhenResultsHasTheDifferentMetaResult()
        {
            var result = Result<object>.Success();
            var result1 = Result<object>.Invalid();

            Assert.False(result.Equals(result1));
        }

        [Fact]
        public void Content_ShouldReturnTrue_WhenResultsHasSameMetaResult()
        {
            var result = Result<object>.Success();
            var result1 = Result<object>.Success();

            Assert.True(result.Equals(result1));
        }

        [Fact]
        public void Content_ShouldReturnFalse_WhenOneOfResultsIsNull()
        {
            var result = Result<object>.Success();
            Result<object> result1 = null;

            Assert.False(result.Equals(result1));
        }

        [Fact]
        public void Content_ShouldReturnTrue_WhenPassSameTypeOfCustomMetaResultAsArgumentIntoEqualsMethos()
        {
            var result = Result<object>.Success();

            Assert.True(result.Equals(new Ok()));
        }

        [Fact]
        public void Content_ShouldReturnTrue_WhenResultTypeIsDifferent_ButMetaResultAreTheSameType()
        {
            var result = Result<object>.Success();
            var result1 = Result<int>.Success();

            Assert.True(result.Equals(result1));
        }

        [Fact]
        public void Content_ShouldReturnFalse_WhenHaveDifferentTypesAndMetaResults()
        {
            var result = Result<object>.Success();
            var result1 = Result<string>.Invalid();

            Assert.False(result.Equals(result1));
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenCompareASuccessResultWithOtherSuccesResultWithCustomMetaResult()
        {
            var result = Result<object>.Success();
            var customResult = Result<string>.Invalid().With<OtherSuccessResult>();

            Assert.False(result.Equals(customResult));
        }
    }
}

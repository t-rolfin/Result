using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Rolfin.Result;
using Rolfin.Result.MetaResults;
using Rolfin.Result.UnitTests.Resources;

namespace Rolfin.Result.UnitTests.ResultUnitTests
{
    public class ResultConstructor
    {
        [Fact]
        public void Result_ShouldReturnStringMessage_WhenProvideStringValueIntoConstructor()
        {
            string expectedResult = "Test message.";

            //Result is an inplementation of Result<string>
            var result = new Result(expectedResult);

            Assert.Equal(expectedResult, result.Value);
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void GenericResult_ShouldReturnStringMessage_WhenProvideStringValueIntoConstructor()
        {
            
            string expectedResult = "Other test message.";

            var result = new Result<string>(expectedResult);

            Assert.Equal(expectedResult, result.Value);
        }

        [Fact]
        public void GenericResult_ShouldReturnObject_WhenSetGenericTypeAsObject()
        {
            object expectedObject = new object();

            var result = new Result<object>(expectedObject);

            Assert.Equal(expectedObject, result.Value);
        }

        [Fact]
        public void GeneticResult_ShouldReturnNull_WhenPassNullValue()
        {
            var result = new Result<object>(null);

            Assert.Null(result.Value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(123)]
        [InlineData("test value")]
        public void GenericResult_ShouldReturnOk_WhenGiveAValue(object value)
        {
            var result = new Result<object>(value);

            Assert.True(result.Equals(new Ok()));
            Assert.Equal(value, result.Value);
        }

        [Fact]
        public void GenericResult_ShouldReturnCustomMessage_WithBaseTypeOfMetaResult()
        {
            string expectedMessage = "Expected message.";
            var result = Result<object>.Invalid().With(expectedMessage);

            Assert.Equal(expectedMessage, result.MetaResult.Message);
            Assert.Equal(new NotFound().GetType(), result.MetaResult.GetType());
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public void GenericResult_ShouldCustomizeMetaResult_WhenGiveDefaultCustomMetaResult()
        {
            NotFound expectedResult = new NotFound();

            var result = new Result<object>().With<NotFound>();

            Assert.True(result.Equals(expectedResult));
        }

        [Fact]
        public void GenericResult_ShouldReturnNotFound_WhenInvalidFactoryCall()
        {
            NotFound expectedResult = new NotFound();

            var result = Result<object>.Invalid();

            Assert.True(result.Equals(expectedResult));
        }

        [Fact]
        public void GenericResult_ShouldReturnCustomMetaResult_WhenGiveMyCustomMetaResult()
        {
            CustomMetaResult expectedMetaResult = new CustomMetaResult();

            var result = Result<object>.Invalid()
                .With<CustomMetaResult>();

            Assert.True(result.Equals(expectedMetaResult));
        }

        [Fact]
        public void GenericResult_ShouldReturnCustomInvaldResult_WhenCallInvalidWithMessage()
        {
            string expectedMessage = "Custom invalid message.";

            var result = Result<object>.Invalid(expectedMessage);

            Assert.Equal(expectedMessage, result.MetaResult.Message);
            Assert.True(result.Equals(new NotFound()));
        }

        [Fact]
        public void Result_ShouldReturnInvalidCustomResultType_WhenCallInvalidWhitCustomType()
        {
            NotFound expectedResult = new NotFound();

            var result = Result<Ok>.Invalid(new CustomMetaResult());

            Assert.Equal(typeof(CustomMetaResult), result.GetValueType());
            Assert.True(result.Equals(expectedResult));
        }

        [Fact]
        public void GenericResult_ShouldReturnOkMetaData_WhenSuccessFactoryCall()
        {
            Ok expectedResult = new Ok();

            var result = Result<object>.Success();

            Assert.True(result.Equals(expectedResult));
        }

        [Fact]
        public void GenericResult_ShouldReturnOkWithCustomValue_WhenCallSuccessWithParameter()
        {
            Ok expectedResult = new Ok();
            object expectedObject = new object();

            var result = Result<object>.Success(expectedObject);

            Assert.True(result.Equals(expectedResult));
            Assert.Equal(expectedObject, result.Value);
        }

        [Fact]
        public void Result_ShouldReturnSuccessCustomResultType_WhenCallSuccessWhitCustomType()
        {
            Ok expectedResult = new Ok();

            var result = Result.Success(new CustomMetaResult());

            Assert.Equal(typeof(CustomMetaResult), result.GetValueType());
            Assert.True(result.Equals(expectedResult));
        }

        [Fact]
        public void Result_ShouldReturnCustomMetaResultMessage_WhenUseWithMethodWithMessageParameter()
        {
            string expectedMessage = "New Ok message.";

            var result = Result<object>.Success()
                .With<Ok>(expectedMessage);

            Assert.Equal(expectedMessage, result.MetaResult.Message);
        }

    }
}

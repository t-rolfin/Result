using Rolfin.Result.MetaResults;
using Rolfin.Result.Paged;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Rolfin.Result.UnitTests.ResultUnitTests
{
    public class PagedResultConstructor
    {
        private readonly IEnumerable<object> testList;
        private readonly IEnumerable<object> emptyTestList;
        private readonly PageInfo testPagedInfo;

        public PagedResultConstructor()
        {
            testList = new List<object>() { new object() };
            emptyTestList = new List<object>();
            testPagedInfo = new PageInfo(1, 10, 99, 999);
        }


        [Fact]
        public void ShouldReturnDefaultValues_WhenCreateWithNoParametersConstructor()
        {
            var pagedResult = new PagedResult<object>();

            Assert.Null(pagedResult.List);
            Assert.Equal(default(PageInfo), pagedResult.PageInfo);
            Assert.Equal(new Ok().Code ,pagedResult.MetaResult.Code);
        }

        [Fact]
        public void ShouldSetValues_WhenCreateAnInstanceWithParameterConstructor()
        {
            var pagedResult = new PagedResult<object>(testPagedInfo, testList);

            Assert.NotNull(pagedResult.List);
            Assert.NotNull(pagedResult.PageInfo);
            Assert.Equal(new Ok().Code, pagedResult.MetaResult.Code);
        }

        [Fact]
        public void ShouldReturnTrue_IfListHasItems_WhenCallHasRecords()
        {
            var pagedResult = new PagedResult<object>(testPagedInfo, testList);
            var hasRecords = pagedResult.HasRecords();

            Assert.True(hasRecords);
        }

        [Fact]
        public void ShouldReturnFalse_IfListHasNoRecords_WhenCallHasRecords()
        {
            var pagedResult = new PagedResult<object>(testPagedInfo, emptyTestList);
            var hasRecords = pagedResult.HasRecords();

            Assert.False(hasRecords);
        }

        [Fact]
        public void ShouldReturnFalse_IfListHasNoRecords_WhenCreateResultWithInvalidMethod()
        {
            var pagedResult = PagedResult<object>.Invalid();
            var hasRecords = pagedResult.HasRecords();

            Assert.False(hasRecords);
            Assert.Null(pagedResult.List);
            Assert.Null(pagedResult.PageInfo);
            Assert.Equal(new NotFound().Code, pagedResult.MetaResult.Code);
        }

        [Fact]
        public void ShouldHaveCustomMessage_WhenCreateWithInvalidMethodWithMessage()
        {
            var expectedMessage = "Test message";
            var pagedResult = PagedResult<object>.Invalid(expectedMessage);

            Assert.Equal(expectedMessage, pagedResult.MetaResult.Message);
        }

        [Fact]
        public void ShouldReturnOkMetaResult_WhenUseSuccessMethod()
        {
            var pagedResult = PagedResult<object>.Success(testPagedInfo, testList);

            Assert.Equal(new Ok().Code, pagedResult.MetaResult.Code);
        }

        [Fact]
        public void ShouldReturnCustomMetaResult_WhenUseWithMethod()
        {
            var pagedResult = PagedResult<object>.Success(testPagedInfo, testList)
                .With<Forbidden>();

            Assert.Equal(new Forbidden().Code, pagedResult.MetaResult.Code);
        }
    }
}

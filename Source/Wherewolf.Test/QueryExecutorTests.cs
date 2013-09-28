using System;
using System.Linq;
using System.Collections.Generic;
using NSubstitute;
using Wherewolf;
using Xunit;

namespace WhereWolf.Test
{
    public class QueryExecutorTests
    {
        private readonly IResolver _resolverMock;
        private readonly QueryExecutor _queryExecutor;

        public QueryExecutorTests()
        {
            _resolverMock = Substitute.For<IResolver>();
            _queryExecutor = new QueryExecutor(_resolverMock, new IExecutionDecorator[0]);
        }

        [Fact]
        public void Execute_0_Dependencies()
        {
            var queryMock = Substitute.For<IQuery<int>>();

            _queryExecutor.Execute(queryMock);

            queryMock.Received().Execute();
        }

        [Fact]
        public void Execute_1_Dependencies()
        {
            _resolverMock.Resolve<string>().Returns("str-dep-1");
            var queryMock = Substitute.For<IQuery<int, string>>();

            _queryExecutor.Execute(queryMock);

            queryMock.Received().Execute("str-dep-1");
        }

        [Fact]
        public void Execute_2_Dependencies()
        {
            _resolverMock.Resolve<string>().Returns("str-dep-1");
            _resolverMock.Resolve<long>().Returns(42);
            var queryMock = Substitute.For<IQuery<int, string, long>>();

            _queryExecutor.Execute(queryMock);

            queryMock.Received().Execute("str-dep-1", 42);
        }

        [Fact]
        public void Execute_3_Dependencies()
        {
            _resolverMock.Resolve<string>().Returns("str-dep-1");
            _resolverMock.Resolve<long>().Returns(42);
            _resolverMock.Resolve<int>().Returns(12);
            
            var queryMock = Substitute.For<IQuery<int, string, long, int>>();

            _queryExecutor.Execute(queryMock);

            queryMock.Received().Execute("str-dep-1", 42, 12);
        }

        [Fact]
        public void Execute_4_Dependencies()
        {
            _resolverMock.Resolve<string>().Returns("str-dep-1");
            _resolverMock.Resolve<long>().Returns(42);
            _resolverMock.Resolve<int>().Returns(12);
            
            var dep4 = new FlagsAttribute();
            _resolverMock.Resolve<FlagsAttribute>().Returns(dep4);
            
            var queryMock = Substitute.For<IQuery<int, string, long, int, FlagsAttribute>>();

            _queryExecutor.Execute(queryMock);

            queryMock.Received().Execute("str-dep-1", 42, 12, dep4);
        }

        [Fact]
        public void Execute_5_Dependencies()
        {
            _resolverMock.Resolve<string>().Returns("str-dep-1");
            _resolverMock.Resolve<long>().Returns(42);
            _resolverMock.Resolve<int>().Returns(12);
            
            var dep4 = new FlagsAttribute();
            _resolverMock.Resolve<FlagsAttribute>().Returns(dep4);

            var dep5 = new SystemException();
            _resolverMock.Resolve<SystemException>().Returns(dep5);
            
            var queryMock = Substitute.For<IQuery<int, string, long, int, FlagsAttribute, SystemException>>();

            _queryExecutor.Execute(queryMock);

            queryMock.Received().Execute("str-dep-1", 42, 12, dep4, dep5);
        }

        [Fact]
        public void Execute_6_Dependencies()
        {
            _resolverMock.Resolve<string>().Returns("str-dep-1");
            _resolverMock.Resolve<long>().Returns(42);
            _resolverMock.Resolve<int>().Returns(12);
            
            var dep4 = new FlagsAttribute();
            _resolverMock.Resolve<FlagsAttribute>().Returns(dep4);

            var dep5 = new SystemException();
            _resolverMock.Resolve<SystemException>().Returns(dep5);

            var dep6 = new TimeSpan();
            _resolverMock.Resolve<TimeSpan>().Returns(dep6);
            
            var queryMock = Substitute.For<IQuery<int, string, long, int, FlagsAttribute, SystemException, TimeSpan>>();

            _queryExecutor.Execute(queryMock);

            queryMock.Received().Execute("str-dep-1", 42, 12, dep4, dep5, dep6);
        }
    }

}
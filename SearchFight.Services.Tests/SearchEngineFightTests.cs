using FluentAssertions;
using NUnit.Framework;
using SearchFight.Services.Tests.ServiceMockBuilders;
using System.Collections.Generic;

namespace SearchFight.Services.Tests
{
    public class SearchEngineFightTests
    {
        private SearchEngineFight _service;
        private SearchEngineResultServiceBuilder _searchEngineResultServiceBuilder;

        [SetUp]
        public void Setup()
        {
            _searchEngineResultServiceBuilder = new SearchEngineResultServiceBuilder();
            _service = new SearchEngineFight(_searchEngineResultServiceBuilder.Build());
        }

        [Test]
        public void GetResult_validValue_ReturnsSearchFightResult()
        {
            //Arrange
            _searchEngineResultServiceBuilder.WithGetSearchEngineMatchResults();

            //Action
            var result = _service.GetResult(new List<string> { "searchValue" });

            //Assert
            result.Should().NotBeNull();
        }
    }
}

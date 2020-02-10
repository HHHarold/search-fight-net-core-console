using FluentAssertions;
using NUnit.Framework;
using SearchFight.Services.Tests.ServiceMapperMockBuilder;
using SearchFight.Services.Tests.ServiceMockBuilders;

namespace SearchFight.Services.Tests
{
    public class SearchEngineResultServiceTests
    {
        private SearchEngineResultService _service;
        private SearchEngineServiceBuilder _searchEngineServiceBuilder;
        private SearchEngineMatchResultServiceMapperBuilder _searchEngineMatchResultServiceMapperBuilder;

        [SetUp]
        public void Setup()
        {
            _searchEngineServiceBuilder = new SearchEngineServiceBuilder();
            _searchEngineMatchResultServiceMapperBuilder = new SearchEngineMatchResultServiceMapperBuilder();
            _service = new SearchEngineResultService(_searchEngineServiceBuilder.Build(), _searchEngineMatchResultServiceMapperBuilder.Build());
        }

        [Test]
        public void GetSearchEngineMatchResults_ValidValue_ReturnsSearchEngineMatchResultList()
        {
            //Arrange
            _searchEngineMatchResultServiceMapperBuilder.WithMapFromBingSearchEngineResponse()
                .WithMapFromGoogleSearchEngineResponse();
            _searchEngineServiceBuilder.WithGetBingResult().WithGetGoogleResult();

            //Action
            var result = _service.GetSearchEngineMatchResults("searchValue");

            //Assert
            result.Count.Should().BeGreaterThan(0);
            
        }

    }
}

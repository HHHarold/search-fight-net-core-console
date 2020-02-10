using FluentAssertions;
using NUnit.Framework;
using SearchFight.Services.Tests.ApiClientMockBuilders;

namespace SearchFight.Services.Tests
{
    public class SearchEngineServiceTest
    {
        private SearchEngineService _service;
        private BingSearchEngineClientBuilder _bingSearchEngineClientBuilder;
        private GoogleSearchEngineClientBuilder _googleSearchEngineClientBuilder;

        [SetUp]
        public void Setup()
        {
            _bingSearchEngineClientBuilder = new BingSearchEngineClientBuilder();
            _googleSearchEngineClientBuilder = new GoogleSearchEngineClientBuilder();
            _service = new SearchEngineService(_bingSearchEngineClientBuilder.Build(), _googleSearchEngineClientBuilder.Build());
        }

        [Test]
        public void GetBingResult_ValidValue_ReturnBingSearchEngineResponse()
        {
            //Arrange
            _bingSearchEngineClientBuilder.WithSearch();

            //Action
            var result = _service.GetBingResult("SearchValue");

            //Assert
            result.Should().NotBeNull();
        }

        [Test]
        public void GetGoogleResult_ValidValue_GoogleSearchEngineResponse()
        {
            //Arrange
            _googleSearchEngineClientBuilder.WithSearch();

            //Action
            var result = _service.GetGoogleResult("SearchValue");

            //Assert
            result.Should().NotBeNull();
        }
    }
}
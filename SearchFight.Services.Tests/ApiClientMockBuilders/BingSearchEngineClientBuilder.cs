using Moq;
using SearchFight.Models.RestApiResponses;
using SearchFight.Services.ApiClients.Interfaces;

namespace SearchFight.Services.Tests.ApiClientMockBuilders
{
    public class BingSearchEngineClientBuilder
    {
        private readonly Mock<IBingSearchEngineClient> _bingSearchEngineClientBuilder;

        public BingSearchEngineClientBuilder()
        {
            _bingSearchEngineClientBuilder = new Mock<IBingSearchEngineClient>();
        }

        public BingSearchEngineClientBuilder WithSearch()
        {
            _bingSearchEngineClientBuilder.Setup(x => x.Search(It.IsAny<string>()))
                .Returns(new BingSearchEngineResponse());

            return this;
        }

        public IBingSearchEngineClient Build()
        {
            return _bingSearchEngineClientBuilder.Object;
        }
    }
}

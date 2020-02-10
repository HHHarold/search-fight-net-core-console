using Moq;
using SearchFight.Models.RestApiResponses;
using SearchFight.Services.ApiClients.Interfaces;

namespace SearchFight.Services.Tests.ApiClientMockBuilders
{
    public class GoogleSearchEngineClientBuilder
    {
        private readonly Mock<IGoogleSearchEngineClient> _googleSearchEngineClient;

        public GoogleSearchEngineClientBuilder()
        {
            _googleSearchEngineClient = new Mock<IGoogleSearchEngineClient>();
        }

        public GoogleSearchEngineClientBuilder WithSearch()
        {
            _googleSearchEngineClient.Setup(x => x.Search(It.IsAny<string>()))
                .Returns(new GoogleSearchEngineResponse());

            return this;
        }

        public IGoogleSearchEngineClient Build()
        {
            return _googleSearchEngineClient.Object;
        }
    }
}

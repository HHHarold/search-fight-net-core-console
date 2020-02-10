using Moq;
using SearchFight.IServices;
using SearchFight.Models.RestApiResponses;

namespace SearchFight.Services.Tests.ServiceMockBuilders
{
    public class SearchEngineServiceBuilder
    {
        private readonly Mock<ISearchEngineService> _searchEngineService;

        public SearchEngineServiceBuilder()
        {
            _searchEngineService = new Mock<ISearchEngineService>();
        }

        public SearchEngineServiceBuilder WithGetBingResult()
        {
            _searchEngineService.Setup(x => x.GetBingResult(It.IsAny<string>()))
                .Returns(new BingSearchEngineResponse());

            return this;
        }

        public SearchEngineServiceBuilder WithGetGoogleResult()
        {
            _searchEngineService.Setup(x => x.GetGoogleResult(It.IsAny<string>()))
                .Returns(new GoogleSearchEngineResponse());

            return this;
        }

        public ISearchEngineService Build()
        {
            return _searchEngineService.Object;
        }
    }
}

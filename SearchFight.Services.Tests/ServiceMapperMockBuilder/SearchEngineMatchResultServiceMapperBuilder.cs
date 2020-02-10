using Moq;
using SearchFight.Models;
using SearchFight.Models.RestApiResponses;
using SearchFight.Services.ServiceMappers.Interfaces;

namespace SearchFight.Services.Tests.ServiceMapperMockBuilder
{
    public class SearchEngineMatchResultServiceMapperBuilder
    {
        private readonly Mock<ISearchEngineResultServiceMapper> _searchEngineResultServiceMapper;

        public SearchEngineMatchResultServiceMapperBuilder()
        {
            _searchEngineResultServiceMapper = new Mock<ISearchEngineResultServiceMapper>();
        }

        public SearchEngineMatchResultServiceMapperBuilder WithMapFromBingSearchEngineResponse()
        {
            _searchEngineResultServiceMapper.Setup(x => x.MapFromBingSearchEngineResponse(It.IsAny<BingSearchEngineResponse>()))
                .Returns((BingSearchEngineResponse entity) => new SearchEngineMatchResult
                {
                    SearchEngineId = (int)SearchEngineEnums.Bing,
                    SearchEngineName = "Bing",
                    TotalNumberMatches = entity?.WebPages?.TotalEstimatedMatches
                });

            return this;
        }

        public SearchEngineMatchResultServiceMapperBuilder WithMapFromGoogleSearchEngineResponse()
        {
            _searchEngineResultServiceMapper.Setup(x => x.MapFromGoogleSearchEngineResponse(It.IsAny<GoogleSearchEngineResponse>()))
                .Returns((GoogleSearchEngineResponse entity) => new SearchEngineMatchResult
                {
                    SearchEngineId = (int)SearchEngineEnums.Google,
                    SearchEngineName = "Bing",
                    TotalNumberMatches = entity?.SearchInformation?.TotalResults
                });

            return this;
        }

        public ISearchEngineResultServiceMapper Build()
        {
            return _searchEngineResultServiceMapper.Object;
        }
    }
}

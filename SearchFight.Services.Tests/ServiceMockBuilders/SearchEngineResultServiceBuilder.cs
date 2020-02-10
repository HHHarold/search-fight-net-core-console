using Moq;
using SearchFight.IServices;
using SearchFight.Models;
using System.Collections.Generic;

namespace SearchFight.Services.Tests.ServiceMockBuilders
{
    public class SearchEngineResultServiceBuilder
    {
        private readonly Mock<ISearchEngineResultService> _searchEngineResultService;

        public SearchEngineResultServiceBuilder()
        {
            _searchEngineResultService = new Mock<ISearchEngineResultService>();
        }

        public SearchEngineResultServiceBuilder WithGetSearchEngineMatchResults()
        {
            _searchEngineResultService.Setup(x => x.GetSearchEngineMatchResults(It.IsAny<string>()))
                .Returns(new List<SearchEngineMatchResult>()
                {
                    new SearchEngineMatchResult
                    {
                        SearchEngineId = (int)SearchEngineEnums.Bing,
                        SearchEngineName = "Google",
                        TotalNumberMatches = 10000
                    },
                    new SearchEngineMatchResult
                    {
                        SearchEngineId = (int)SearchEngineEnums.Google,
                        SearchEngineName = "Bing",
                        TotalNumberMatches = 20000
                    }
                });

            return this;
        }

        public ISearchEngineResultService Build()
        {
            return _searchEngineResultService.Object;
        }
    }
}

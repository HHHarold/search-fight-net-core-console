using SearchFight.Models;
using SearchFight.Models.RestApiResponses;
using SearchFight.Services.ServiceMappers.Interfaces;

namespace SearchFight.Services.ServiceMappers
{
    public class SearchEngineMatchResultServiceMapper : ISearchEngineResultServiceMapper
    {

        public SearchEngineMatchResult MapFromBingSearchEngineResponse(BingSearchEngineResponse entity)
        {
            return new SearchEngineMatchResult
            {
                SearchEngineId = (int)SearchEngineEnums.Bing,
                SearchEngineName = "Bing",
                TotalNumberMatches = entity?.WebPages?.TotalEstimatedMatches
            };
        }

        public SearchEngineMatchResult MapFromGoogleSearchEngineResponse(GoogleSearchEngineResponse entity)
        {
            return new SearchEngineMatchResult
            {
                SearchEngineId = (int)SearchEngineEnums.Google,
                SearchEngineName = "Google",
                TotalNumberMatches = entity?.SearchInformation?.TotalResults
            };
        }
    }
}

using SearchFight.Models;
using SearchFight.Models.RestApiResponses;

namespace SearchFight.Services.ServiceMappers.Interfaces
{
    public interface ISearchEngineResultServiceMapper
    {
        SearchEngineMatchResult MapFromBingSearchEngineResponse(BingSearchEngineResponse entity);
        SearchEngineMatchResult MapFromGoogleSearchEngineResponse(GoogleSearchEngineResponse entity);
    }
}

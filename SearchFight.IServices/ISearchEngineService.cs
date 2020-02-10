using SearchFight.Models.RestApiResponses;

namespace SearchFight.IServices
{
    public interface ISearchEngineService
    {
        BingSearchEngineResponse GetBingResult(string searchValue);
        GoogleSearchEngineResponse GetGoogleResult(string searchValue);
    }
}

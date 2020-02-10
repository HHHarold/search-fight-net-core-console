using SearchFight.IServices;
using SearchFight.Models.RestApiResponses;
using SearchFight.Services.ApiClients.Interfaces;

namespace SearchFight.Services
{
    public class SearchEngineService : ISearchEngineService
    {
        private readonly IBingSearchEngineClient _bingSearchEngineClient;
        private readonly IGoogleSearchEngineClient _googleSearchEngineClient;

        public SearchEngineService(IBingSearchEngineClient bingSearchEngineClient,
            IGoogleSearchEngineClient googleSearchEngineClient)
        {
            _bingSearchEngineClient = bingSearchEngineClient;
            _googleSearchEngineClient = googleSearchEngineClient;
        }

        public BingSearchEngineResponse GetBingResult(string searchValue)
        {
            return _bingSearchEngineClient.Search(searchValue);
        }

        public GoogleSearchEngineResponse GetGoogleResult(string searchValue)
        {
            return _googleSearchEngineClient.Search(searchValue);
        }
    }
}

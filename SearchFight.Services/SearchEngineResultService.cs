using SearchFight.IServices;
using SearchFight.Models;
using SearchFight.Services.ServiceMappers.Interfaces;
using System.Collections.Generic;

namespace SearchFight.Services
{
    public class SearchEngineResultService : ISearchEngineResultService
    {
        private readonly ISearchEngineService _searchEngineService;
        private readonly ISearchEngineResultServiceMapper _mapper;

        public SearchEngineResultService(ISearchEngineService searchEngineService,
            ISearchEngineResultServiceMapper searchEngineResultServiceMapper)
        {
            _searchEngineService = searchEngineService;
            _mapper = searchEngineResultServiceMapper;
        }

        public IList<SearchEngineMatchResult> GetSearchEngineMatchResults(string searchValue)
        {
            var searchEngineResults = new List<SearchEngineMatchResult>();

            var bingSearchEngineResult = _searchEngineService.GetBingResult(searchValue);
            searchEngineResults.Add(_mapper.MapFromBingSearchEngineResponse(bingSearchEngineResult));            

            var googleSearchEngineResult = _searchEngineService.GetGoogleResult(searchValue);
            searchEngineResults.Add(_mapper.MapFromGoogleSearchEngineResponse(googleSearchEngineResult));

            return searchEngineResults;
        }
    }
}

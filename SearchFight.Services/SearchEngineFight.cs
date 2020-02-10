using SearchFight.IServices;
using SearchFight.Models;
using System.Collections.Generic;
using System.Linq;

namespace SearchFight.Services
{
    public class SearchEngineFight : ISearchEngineFight
    {
        private readonly ISearchEngineResultService _searchEngineResultService;

        public SearchEngineFight(ISearchEngineResultService searchEngineResultService)
        {
            _searchEngineResultService = searchEngineResultService;
        }

        public SearchFightResult GetResult(IList<string> values)
        {
            var searchFightResult = new SearchFightResult
            {
                SearchEngineValueResults = SearchValues(values)
            };
            searchFightResult.GoogleWinner = GetWinnerBySearchEngine(SearchEngineEnums.Google, searchFightResult);
            searchFightResult.BingWinner = GetWinnerBySearchEngine(SearchEngineEnums.Bing, searchFightResult);
            GetTotalWinner(searchFightResult);

            return searchFightResult;
        }

        private IList<SearchEngineValueResult> SearchValues(IList<string> values)
        {
            var searchEngineValueResults = new List<SearchEngineValueResult>();
            SearchEngineValueResult searchEngineValueResult;

            for (int i = 0; i < values.Count; i++)
            {
                searchEngineValueResult = new SearchEngineValueResult
                {
                    Value = values[i],
                    SearchEngineMatchResults = _searchEngineResultService.GetSearchEngineMatchResults(values[i])
                };

                searchEngineValueResults.Add(searchEngineValueResult);
            }

            return searchEngineValueResults;
        }
        
        private string GetWinnerBySearchEngine(SearchEngineEnums searchEngine, SearchFightResult searchFightResult)
        {
            var maxBingResult = searchFightResult.SearchEngineValueResults[0];

            for (int i = 1; i < searchFightResult.SearchEngineValueResults.Count; i++)
            {
                for (int j = 0; j < searchFightResult.SearchEngineValueResults[i].SearchEngineMatchResults.Count; j++)
                {
                    if (searchFightResult.SearchEngineValueResults[i].SearchEngineMatchResults[j].SearchEngineId == (int)searchEngine)
                    {
                        if (searchFightResult.SearchEngineValueResults[i].SearchEngineMatchResults[j].TotalNumberMatches > GetMatchBySearchEngine(searchEngine, maxBingResult.SearchEngineMatchResults).TotalNumberMatches)
                        {
                            maxBingResult = searchFightResult.SearchEngineValueResults[i];
                        }
                    }
                }
            }

            return maxBingResult.Value;
        }

        private SearchEngineMatchResult GetMatchBySearchEngine(SearchEngineEnums searchEngine, IList<SearchEngineMatchResult> searchEngineMatchResults)
        {
            return searchEngineMatchResults.Where(x => x.SearchEngineId == (int)searchEngine).ToList()[0];
        }

        private void GetTotalWinner(SearchFightResult searchFightResult)
        {
            var totalWinner = searchFightResult.SearchEngineValueResults[0];

            for (int i = 1; i < searchFightResult.SearchEngineValueResults.Count; i++)
            {
                if(searchFightResult.SearchEngineValueResults[i].TotalMatches > totalWinner.TotalMatches)
                {
                    totalWinner = searchFightResult.SearchEngineValueResults[i];
                }
            }

            searchFightResult.TotalWinner = totalWinner.Value;
        }
    }
}

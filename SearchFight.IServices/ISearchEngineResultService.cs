using SearchFight.Models;
using System.Collections.Generic;

namespace SearchFight.IServices
{
    public interface ISearchEngineResultService
    {
        IList<SearchEngineMatchResult> GetSearchEngineMatchResults(string searchValue);
    }
}

using System.Collections.Generic;
using System.Linq;

namespace SearchFight.Models
{
    public class SearchEngineValueResult
    {
        public SearchEngineValueResult()
        {
            SearchEngineMatchResults = new List<SearchEngineMatchResult>();
        }

        public string Value { get; set; }
        public long? TotalMatches => SearchEngineMatchResults.Select(x => x.TotalNumberMatches).Sum();
        public IList<SearchEngineMatchResult> SearchEngineMatchResults { get; set; }
    }
}

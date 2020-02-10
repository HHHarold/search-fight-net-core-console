using System.Collections.Generic;

namespace SearchFight.Models
{
    public class SearchFightResult
    {
        public SearchFightResult()
        {
            SearchEngineValueResults = new List<SearchEngineValueResult>();
        }

        public string GoogleWinner { get; set; }
        public string BingWinner { get; set; }
        public string TotalWinner { get; set; }
        public IList<SearchEngineValueResult> SearchEngineValueResults { get; set; }
    }
}

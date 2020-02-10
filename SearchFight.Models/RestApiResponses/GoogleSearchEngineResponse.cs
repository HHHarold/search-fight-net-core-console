namespace SearchFight.Models.RestApiResponses
{
    public class GoogleSearchEngineResponse
    {
        public SearchInformation SearchInformation { get; set; }
    }

    public class SearchInformation
    {
        public long TotalResults { get; set; }
    }
}

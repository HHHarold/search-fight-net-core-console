namespace SearchFight.Models.RestApiResponses
{
    public class BingSearchEngineResponse
    {
        public WebPages WebPages { get; set; }
    }

    public class WebPages
    {
        public long TotalEstimatedMatches { get; set; }
    }
}

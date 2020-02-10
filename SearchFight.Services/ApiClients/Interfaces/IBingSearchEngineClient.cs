using SearchFight.Models.RestApiResponses;

namespace SearchFight.Services.ApiClients.Interfaces
{
    public interface IBingSearchEngineClient
    {
        BingSearchEngineResponse Search(string value);
    }
}

using SearchFight.Models.RestApiResponses;

namespace SearchFight.Services.ApiClients.Interfaces
{
    public interface IGoogleSearchEngineClient
    {
        public GoogleSearchEngineResponse Search(string value);
    }
}

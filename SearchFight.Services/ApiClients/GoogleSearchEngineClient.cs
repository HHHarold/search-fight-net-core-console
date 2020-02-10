using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Deserializers;
using SearchFight.Models.RestApiResponses;
using SearchFight.Services.ApiClients.Interfaces;

namespace SearchFight.Services.ApiClients
{
    public class GoogleSearchEngineClient : BaseClient, IGoogleSearchEngineClient
    {
        private readonly IConfiguration _configuration;
        public GoogleSearchEngineClient(ICacheService cache, ILoggerFactory logger, IDeserializer serializer, IConfiguration configuration)
        : base(cache, logger, serializer, "https://www.googleapis.com")
        {
            _configuration = configuration;
        }

        public GoogleSearchEngineResponse Search(string value)
        {
            RestRequest request = new RestRequest($"/customsearch/v1", Method.GET);
            request.AddQueryParameter("key", _configuration["googleKey"]);
            request.AddQueryParameter("cx", _configuration["googleCx"]);
            request.AddQueryParameter("q", value);

            return GetFromCache<GoogleSearchEngineResponse>(request, value + "bingSearchEngine");
        }
    }
}

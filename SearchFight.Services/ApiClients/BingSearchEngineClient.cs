using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Deserializers;
using SearchFight.Models.RestApiResponses;
using SearchFight.Services.ApiClients.Interfaces;

namespace SearchFight.Services.ApiClients
{
    public class BingSearchEngineClient : BaseClient, IBingSearchEngineClient
    {
        private readonly IConfiguration _configuration;
        public BingSearchEngineClient(ICacheService cache, ILoggerFactory logger, IDeserializer serializer, IConfiguration configuration)
        : base(cache, logger, serializer, "https://bingwebsearchharold.cognitiveservices.azure.com") 
        {
            _configuration = configuration;
        }

        public BingSearchEngineResponse Search(string value)
        {
            RestRequest request = new RestRequest($"/bing/v7.0/search", Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", _configuration["bingOcpApimSubscriptionKey"]);
            request.AddQueryParameter("q", value);

            return GetFromCache<BingSearchEngineResponse>(request, value + "bingSearchEngine");
        }
    }
}

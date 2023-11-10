using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Verivox.Application.Interfaces;
using Verivox.Domain.Convertors;
using Verivox.Domain.Entities;

namespace Verivox.Shared;

public class TariffProvider : ITariffProvider
{
    private readonly string _baseUrl;
    private readonly HttpClient _httpClient;

    public TariffProvider(
        IHttpClientFactory clientFactory,
        IConfiguration configuration)
    {
        _httpClient = clientFactory.CreateClient();
        _baseUrl = configuration.GetSection("TariffProviderUrl").Value;
    }

    public async Task<List<ElectricityProduct>> GetProducts()
    {
        var response = await _httpClient.GetAsync(_baseUrl);

        response.EnsureSuccessStatusCode();

        var data = await response.Content.ReadAsStringAsync();

        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects,
            Converters = new List<JsonConverter> { new ProductConvertor() }
        };

        var result = JsonConvert.DeserializeObject<List<ElectricityProduct>>(data, settings);

        return result;
    }
}
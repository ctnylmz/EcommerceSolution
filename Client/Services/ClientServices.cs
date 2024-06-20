using Shareds.Contracts;
using Shareds.Models;
using Shareds.Response;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client.Services
{
    public class ClientServices : IProduct
    {
        private readonly HttpClient _httpClient;

        public ClientServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private const string BaseUrl = "api/product";
        private static string SerializieObj(object modelObject)
            => JsonSerializer.Serialize(modelObject,JsonOptions());
        private static T DeserializeJsonString<T>(string jsonString) => JsonSerializer.Deserialize<T>(jsonString,JsonOptions())!;
        private static StringContent GenerateStringContent(string serializedObj)
            => new(serializedObj, Encoding.UTF8, "application/json");
        private static IList<T> DeserializeJsonStringList<T>(string jsonString) => JsonSerializer.Deserialize<IList<T>>(jsonString, JsonOptions())!;
        private static JsonSerializerOptions JsonOptions()
        {
            return new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip,
            };
        }



        public async Task<ServiceResponse> AddProduct(Product model)
        {
            var response = await _httpClient.PostAsync(BaseUrl, GenerateStringContent(SerializieObj(model)));

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse(false, "Error occured. Try agin Latter...");
            }
            var apiResponse = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<ServiceResponse>(apiResponse);
        }

   

        public async Task<List<Product>> GetAllProduct(bool featuredProducts)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}?featured={featuredProducts}");

            if (!response.IsSuccessStatusCode) return null!;

            var result = await response.Content.ReadAsStringAsync();
            return [.. DeserializeJsonStringList<Product>(result)];


        }

    }
}
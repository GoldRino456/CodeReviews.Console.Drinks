using RestSharp;
using Newtonsoft.Json;
using DrinksInfo.Models;


namespace DrinksInfo
{
    internal class CocktailApiClient
    {
        public static CocktailApiClient Instance { get; } = new();
        private readonly RestClientOptions _options;
        private readonly RestClient _client;

        private CocktailApiClient()
        {
            _options = new RestClientOptions("https://www.thecocktaildb.com/api/json/v1/1/");
            _client = new RestClient(_options); 
        }

        public async Task<List<Category>?> GetCategoryList()
        {
            var request = new RestRequest("list.php?c=list");
            var response = await _client.ExecuteAsync(request);
            return ProcessResponse<Categories>(response).CategoriesList;
        }

        public async Task<List<Drink>?> GetDrinksByCategory(Category category)
        {
            var request = new RestRequest($"filter.php?c={category.StrCategory}");
            var response = await _client.ExecuteAsync(request);
            return ProcessResponse<Drinks>(response).DrinksList;
        }

        public async Task<List<DrinkData>?> GetDrinkDataContainer(Drink drink)
        {
            var request = new RestRequest($"lookup.php?i={drink.IdDrink}");
            var response = await _client.ExecuteAsync(request);
            return ProcessResponse<DrinkDataContainer>(response).DrinkDataList;
        }

        private static T? ProcessResponse<T>(RestResponse response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string raw = response.Content;
                return JsonConvert.DeserializeObject<T>(raw);
            }

            return default;
        }
    }
}

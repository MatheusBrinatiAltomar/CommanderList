using System.Text.Json;
using MagicCardInfo.Domain.Models;
using MagicCardInfo.Domain.Services;

namespace MagicCardInfo.Infrastructure.Services
{
    public class ScryfallService : IScryfallService
    {
        private readonly HttpClient _httpClient;

        public ScryfallService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Card>> GetCardsAsync()
        {
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("MagicCardInfo/1.0");
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // The search is limited to Legendary Creature cards that exist in paper and are not double-faced cards
            // which is another way to search for cards that can be your Commander in the Commander Format
            string? nextPageUrl = "https://api.scryfall.com/cards/search?q=t%3Alegendary+t%3Acreature+game%3Apaper+layout%3Anormal";
            var allCards = new List<Card>();

            while (!string.IsNullOrEmpty(nextPageUrl))
            {
                var response = await _httpClient.GetAsync(nextPageUrl);
                if (!response.IsSuccessStatusCode)
                    break;

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ScryfallResponse>(json);

                if (result?.Data != null)
                {
                    allCards.AddRange(result.Data);
                }

                nextPageUrl = result?.NextPage;
            }

            return allCards.OrderBy(c => c.Name).ToList();
        }
    }
}

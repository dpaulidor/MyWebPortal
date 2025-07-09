// Services/CoinGeckoService.cs
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MonPortailWeb.Models; // Pour utiliser notre classe CoinGeckoPriceResponse
using System; // Pour Uri et Exception
using System.Collections.Generic; // Pour Dictionary
using System.Linq; // Pour LINQ

namespace MonPortailWeb.Services
{
    public class CoinGeckoService
    {
        private readonly HttpClient _httpClient;

        public CoinGeckoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.coingecko.com/api/v3/"); // L'URL de base de l'API CoinGecko
        }

        // Méthode asynchrone pour obtenir le prix d'une crypto-monnaie
        // ids: l'identifiant de la crypto (ex: "bitcoin", "ethereum")
        // vsCurrencies: la devise de comparaison (ex: "usd", "eur")
        public async Task<Dictionary<string, decimal>?> GetCryptoPriceAsync(string cryptoId, string vsCurrency)
        {
            if (string.IsNullOrWhiteSpace(cryptoId) || string.IsNullOrWhiteSpace(vsCurrency))
            {
                return null;
            }

            try
            {
                // Construire l'URL de la requête
                // Exemple: https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=usd
                var response = await _httpClient.GetAsync($"simple/price?ids={cryptoId.ToLower()}&vs_currencies={vsCurrency.ToLower()}");

                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Désérialiser la réponse en CoinGeckoPriceResponse
                var priceResponse = JsonSerializer.Deserialize<CoinGeckoPriceResponse>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                // Vérifier si des données ont été retournées
                if (priceResponse?.CryptoPrices == null || !priceResponse.CryptoPrices.Any())
                {
                    Console.WriteLine($"CoinGecko API returned no data for {cryptoId} in {vsCurrency}. Response: {jsonResponse}");
                    return null;
                }

                // Extraire le dictionnaire de prix pour la crypto-monnaie demandée
                if (priceResponse.CryptoPrices.TryGetValue(cryptoId.ToLower(), out var cryptoData))
                {
                    // cryptoData est un 'object', il faut le re-désérialiser en Dictionary<string, decimal>
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var prices = JsonSerializer.Deserialize<Dictionary<string, decimal>>(cryptoData.ToString()!, options);
                    return prices;
                }

                return null;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erreur de requête HTTP lors de l'appel à CoinGecko : {e.Message}");
                return null;
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Erreur de désérialisation JSON lors de l'appel à CoinGecko : {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Une erreur inattendue est survenue lors de l'appel à CoinGecko : {e.Message}");
                return null;
            }
        }
    }
}

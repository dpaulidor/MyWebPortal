// Services/IpInfoService.cs
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MonPortailWeb.Models; // Pour utiliser notre classe IpInfoResponse
using System; // Pour la classe Uri et Exception

namespace MonPortailWeb.Services
{
    public class IpInfoService
    {
        private readonly HttpClient _httpClient;

        public IpInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // L'URL de base de l'API IPinfo.io
            _httpClient.BaseAddress = new Uri("https://ipinfo.io/");
        }

        // Méthode asynchrone pour obtenir les informations IP
        public async Task<IpInfoResponse?> GetIpInfoAsync(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
            {
                return null;
            }

            try
            {
                // Construire l'URL de la requête avec l'adresse IP et le chemin /geo
                // Exemple: https://ipinfo.io/8.8.8.8/geo
                var response = await _httpClient.GetAsync($"{ipAddress}/geo");

                response.EnsureSuccessStatusCode(); // Lance une exception pour les codes d'erreur HTTP

                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Désérialiser la chaîne JSON en objet IpInfoResponse
                var ipInfoResponse = JsonSerializer.Deserialize<IpInfoResponse>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return ipInfoResponse;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erreur de requête HTTP lors de l'appel à IPinfo.io : {e.Message}");
                return null;
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Erreur de désérialisation JSON lors de l'appel à IPinfo.io : {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Une erreur inattendue est survenue lors de l'appel à IPinfo.io : {e.Message}");
                return null;
            }
        }
    }
}

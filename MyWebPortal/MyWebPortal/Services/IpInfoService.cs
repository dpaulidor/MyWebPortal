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

        // M�thode asynchrone pour obtenir les informations IP
        public async Task<IpInfoResponse?> GetIpInfoAsync(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
            {
                return null;
            }

            try
            {
                // Construire l'URL de la requ�te avec l'adresse IP et le chemin /geo
                // Exemple: https://ipinfo.io/8.8.8.8/geo
                var response = await _httpClient.GetAsync($"{ipAddress}/geo");

                response.EnsureSuccessStatusCode(); // Lance une exception pour les codes d'erreur HTTP

                var jsonResponse = await response.Content.ReadAsStringAsync();

                // D�s�rialiser la cha�ne JSON en objet IpInfoResponse
                var ipInfoResponse = JsonSerializer.Deserialize<IpInfoResponse>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return ipInfoResponse;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erreur de requ�te HTTP lors de l'appel � IPinfo.io : {e.Message}");
                return null;
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Erreur de d�s�rialisation JSON lors de l'appel � IPinfo.io : {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Une erreur inattendue est survenue lors de l'appel � IPinfo.io : {e.Message}");
                return null;
            }
        }
    }
}

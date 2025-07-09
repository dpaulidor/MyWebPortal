
// Services/AgifyService.cs
using System.Net.Http; // Nécessaire pour HttpClient
using System.Text.Json; // Nécessaire pour JsonSerializer
using System.Threading.Tasks; // Nécessaire pour les opérations asynchrones (async/await)
using MonPortailWeb.Models; // Pour pouvoir utiliser notre classe AgifyResponse
using System; // Pour la classe Uri et Exception

namespace MonPortailWeb.Services
{
    public class AgifyService
    {
        private readonly HttpClient _httpClient; // Déclare une instance de HttpClient

        // Constructeur : HttpClient est injecté ici par le système d'injection de dépendances d'ASP.NET Core
        public AgifyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // Définit l'adresse de base de l'API Agify.io pour toutes les requêtes de ce client
            _httpClient.BaseAddress = new Uri("https://api.agify.io/");
        }

        // Méthode asynchrone pour obtenir l'âge estimé par nom
        public async Task<AgifyResponse?> GetAgeByNameAsync(string name) // Ajoutez le '?' après AgifyResponse
        {
            // Vérifie si le nom est vide ou nul
            if (string.IsNullOrWhiteSpace(name))
            {
                return null; // Retourne null si aucun nom n'est fourni
            }

            try
            {
                // Effectue une requête GET à l'API. L'URL complète sera "https://api.agify.io/?name=..."
                var response = await _httpClient.GetAsync($"?name={name}");

                // Lance une exception si le code de statut HTTP n'indique pas le succès (ex: 404, 500)
                response.EnsureSuccessStatusCode();

                // Lit le contenu de la réponse HTTP sous forme de chaîne de caractères (JSON)
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Désérialise la chaîne JSON en un objet AgifyResponse.
                // PropertyNameCaseInsensitive = true permet de faire correspondre "name" (JSON) à "Name" (C#)
                var agifyResponse = JsonSerializer.Deserialize<AgifyResponse>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return agifyResponse;
            }
            catch (HttpRequestException e)
            {
                // Gère les erreurs liées à la requête HTTP (ex: pas de connexion internet, serveur API injoignable)
                Console.WriteLine($"Erreur de requête HTTP lors de l'appel à Agify.io : {e.Message}");
                return null; // Retourne null en cas d'erreur
            }
            catch (JsonException e)
            {
                // Gère les erreurs de désérialisation JSON (ex: la réponse de l'API n'est pas un JSON valide)
                Console.WriteLine($"Erreur de désérialisation JSON lors de l'appel à Agify.io : {e.Message}");
                return null; // Retourne null en cas d'erreur
            }
            catch (Exception e)
            {
                // Gère toute autre exception inattendue
                Console.WriteLine($"Une erreur inattendue est survenue lors de l'appel à Agify.io : {e.Message}");
                return null; // Retourne null en cas d'erreur
            }
        }
    }
}



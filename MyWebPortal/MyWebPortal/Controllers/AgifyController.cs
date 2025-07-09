
// Controllers/AgifyController.cs
using Microsoft.AspNetCore.Mvc; // Nécessaire pour Controller, IActionResult
using MonPortailWeb.Models; // Pour utiliser AgifyResponse
using MonPortailWeb.Services; // Pour utiliser AgifyService
using System.Threading.Tasks; // Pour les opérations asynchrones

namespace MonPortailWeb.Controllers
{
    public class AgifyController : Controller
    {
        private readonly AgifyService _agifyService; // Déclare une instance de notre service

        // Constructeur : AgifyService est injecté ici par le système d'injection de dépendances
        public AgifyController(AgifyService agifyService)
        {
            _agifyService = agifyService;
        }

        // Action pour afficher le formulaire de saisie du nom (requête GET)
        // [HttpGet] indique que cette action répond aux requêtes GET
        // [Route("/Agify")] définit une URL propre pour cette action
        [HttpGet]
        [Route("/Agify")]
        public IActionResult Index()
        {
            // Retourne la vue associée à cette action (Views/Agify/Index.cshtml)
            return View();
        }

        // Action pour traiter la soumission du formulaire (requête POST)
        // [HttpPost] indique que cette action répond aux requêtes POST
        // [Route("/Agify")] utilise la même URL que le GET, mais pour une méthode HTTP différente
        [HttpPost]
        [Route("/Agify")]
        public async Task<IActionResult> Index(string name) // Le paramètre 'name' sera automatiquement lié depuis le formulaire
        {
            // Vérifie si le nom est vide ou nul. Si oui, ajoute une erreur au ModelState
            if (string.IsNullOrWhiteSpace(name))
            {
                ModelState.AddModelError("name", "Veuillez entrer un nom.");
                return View(); // Retourne la vue avec l'erreur affichée
            }

            // Appelle notre service pour obtenir l'âge estimé
            var agifyResponse = await _agifyService.GetAgeByNameAsync(name);

            // Gère le cas où le service n'a pas pu récupérer les données (retourne null)
            if (agifyResponse == null)
            {
                ModelState.AddModelError("", "Impossible de récupérer les données pour ce nom. Veuillez réessayer.");
                return View(); // Retourne la vue avec l'erreur générale
            }

            // Si tout est bon, passe l'objet agifyResponse à la vue
            return View(agifyResponse);
        }
    }
}


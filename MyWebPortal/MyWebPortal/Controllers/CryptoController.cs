// Controllers/CryptoController.cs
using Microsoft.AspNetCore.Mvc;
using MonPortailWeb.Services;
using System.Threading.Tasks;
using System.Collections.Generic; // Pour Dictionary

namespace MonPortailWeb.Controllers
{
    public class CryptoController : Controller
    {
        private readonly CoinGeckoService _coinGeckoService;

        public CryptoController(CoinGeckoService coinGeckoService)
        {
            _coinGeckoService = coinGeckoService;
        }

        [HttpGet]
        [Route("/Crypto")]
        public IActionResult Index()
        {
            // Initialiser avec des valeurs par défaut pour les champs de saisie
            var model = new CryptoSearchModel { CryptoId = "bitcoin", VsCurrency = "usd" };
            return View(model);
        }

        [HttpPost]
        [Route("/Crypto")]
        public async Task<IActionResult> Index(CryptoSearchModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // CoinGecko utilise des IDs en minuscules (ex: "bitcoin", pas "Bitcoin")
            // et des devises en minuscules (ex: "usd", pas "USD")
            var prices = await _coinGeckoService.GetCryptoPriceAsync(model.CryptoId, model.VsCurrency);

            if (prices == null || !prices.Any())
            {
                ModelState.AddModelError("", $"Impossible de récupérer le prix pour '{model.CryptoId}' en '{model.VsCurrency}'. Vérifiez les identifiants ou réessayez plus tard.");
                return View(model);
            }

            // Passer les résultats à la vue via le modèle
            model.Prices = prices;
            return View(model);
        }
    }

    // <<< ASSUREZ-VOUS QUE CETTE CLASSE EST BIEN ICI, À L'INTÉRIEUR DE CryptoController
    public class CryptoSearchModel
    {
        public string CryptoId { get; set; } = "bitcoin"; // Valeur par défaut
        public string VsCurrency { get; set; } = "usd"; // Valeur par défaut
        public Dictionary<string, decimal>? Prices { get; set; } // Pour stocker les résultats de l'API
    }
}

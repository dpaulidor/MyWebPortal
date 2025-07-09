// Controllers/IpInfoController.cs
using Microsoft.AspNetCore.Mvc;
using MonPortailWeb.Models;
using MonPortailWeb.Services;
using System.Threading.Tasks;
using System.Net; // Pour la classe IPAddress

namespace MonPortailWeb.Controllers
{
    public class IpInfoController : Controller
    {
        private readonly IpInfoService _ipInfoService;

        public IpInfoController(IpInfoService ipInfoService)
        {
            _ipInfoService = ipInfoService;
        }

        [HttpGet]
        [Route("/IpInfo")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/IpInfo")]
        public async Task<IActionResult> Index(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
            {
                ModelState.AddModelError("ipAddress", "Veuillez entrer une adresse IP.");
                return View();
            }

            // Validation basique de l'adresse IP
            if (!IPAddress.TryParse(ipAddress, out _))
            {
                ModelState.AddModelError("ipAddress", "L'adresse IP entr�e n'est pas valide.");
                return View();
            }

            var ipInfoResponse = await _ipInfoService.GetIpInfoAsync(ipAddress);

            if (ipInfoResponse == null || ipInfoResponse.Ip == null) // V�rifier aussi si l'IP retourn�e est nulle, indiquant un probl�me
            {
                ModelState.AddModelError("", "Impossible de r�cup�rer les informations pour cette adresse IP. Veuillez r�essayer.");
                return View();
            }

            return View(ipInfoResponse);
        }
    }
}

// Models/CoinGeckoPriceResponse.cs
using System.Collections.Generic; // Nécessaire pour Dictionary
using System.Text.Json.Serialization; // Nécessaire pour JsonExtensionData

namespace MonPortailWeb.Models
{
    // Ce modèle est conçu pour capturer la réponse dynamique de l'API CoinGecko
    // pour l'endpoint /simple/price
    public class CoinGeckoPriceResponse
    {
        // JsonExtensionData permet de capturer les propriétés JSON qui ne sont pas
        // explicitement définies comme des propriétés dans la classe.
        // Ici, cela capturera les noms des crypto-monnaies (ex: "bitcoin", "ethereum")
        // et leurs valeurs associées (un autre dictionnaire de devises et prix).
        [JsonExtensionData]
        public Dictionary<string, object>? CryptoPrices { get; set; }
        // Nous utiliserons 'object' ici car la désérialisation directe en
        // Dictionary<string, decimal> peut être complexe avec JsonExtensionData.
        // Nous ferons la conversion manuellement dans le service.
    }
}

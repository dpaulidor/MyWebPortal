// Models/IpInfoResponse.cs
namespace MonPortailWeb.Models
{
    public class IpInfoResponse
    {
        public string? Ip { get; set; }
        public string? Hostname { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public string? Loc { get; set; } // Latitude,Longitude
        public string? Org { get; set; }
        public string? Postal { get; set; }
        public string? Timezone { get; set; }
        public string? Readme { get; set; } // Lien vers la documentation ou message
    }
}

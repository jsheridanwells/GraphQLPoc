using Newtonsoft.Json;

namespace GQL.UserService.Config
{
    [JsonObject("tokenSettings")]
    public class TokenSettings
    {
        [JsonProperty("secret")]
        public string Secret { get; set; }
        [JsonProperty("issuer")]
        public string Issuer { get; set; }
        [JsonProperty("accessExpiration")]
        public int AccessExpiration { get; set; }
        [JsonProperty("refreshExpiration")]
        public int RefreshExpiration { get; set; }
    }
}

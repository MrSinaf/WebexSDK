using Newtonsoft.Json;

namespace WebexSDK.Models
{
	public class AccessToken
	{
		[JsonProperty("access_token")] public string Token { get; set; }
		[JsonProperty("expires_in")] public int ExpireIn { get; set; }
		[JsonProperty("scope")] public string Scope { get; set; }
		[JsonProperty("token_type")] public string Type { get; set; }
		[JsonProperty("refresh_token")] public string RefreshToken { get; set; }
		[JsonProperty("refresh_token_expires_in")] public int RefreshTokenExpireIn { get; set; }
	}
}
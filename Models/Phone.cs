using Newtonsoft.Json;

namespace WebexSDK.Models
{
	public sealed class PhoneNumber
	{
		[JsonProperty("type")] public PhoneNumberType Type { get; set; }
		[JsonProperty("value")] public string Number { get; set; }
		[JsonProperty("primary")] public bool Pimary { get; set; }
	}
}
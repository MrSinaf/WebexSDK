using Newtonsoft.Json;

namespace WebexSDK.Models
{
	public class Endpoint
	{
		[JsonProperty("id")] public string Id { get; set; }
		[JsonProperty("name")] public string Name { get; set; }
		[JsonProperty("type")] public DeviceType Type { get; set; }
	}
}
using Newtonsoft.Json;

namespace WebexSDK.Models
{
	public class RemoteParty
	{
		[JsonProperty("callType")] public string CallType { get; set; }
		[JsonProperty("name")] public string Name { get; set; }
		[JsonProperty("number")] public string Number { get; set; }
		[JsonProperty("personId")] public string PersonId { get; set; }
		[JsonProperty("placeId")] public string PlaceId { get; set; }
		[JsonProperty("privacyEnabled")] public bool IsPrivacy { get; set; }
	}
}

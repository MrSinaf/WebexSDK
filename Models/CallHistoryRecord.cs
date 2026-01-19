using System;
using Newtonsoft.Json;

namespace WebexSDK.Models
{
	public class CallHistoryRecord
	{
		[JsonProperty("number")] public string number { get; set; }
		[JsonProperty("time")] public DateTimeOffset time { get; set; }
		[JsonProperty("type")] public CallType type { get; set; }
		[JsonProperty("privacyEnabled")] public bool withPrivacy { get; set; }
	}
}
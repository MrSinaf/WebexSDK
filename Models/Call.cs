using System;
using Newtonsoft.Json;

namespace WebexSDK.Models
{
	public class Call
	{
		[JsonProperty("id")] public string Id { get; set; }
		[JsonProperty("callSessionId")] public string CallSessionId { get; set; }
		[JsonProperty("created")] public DateTime Created { get; set; }
		[JsonProperty("answered")] public DateTime Answered { get; set; }
		[JsonProperty("muted")] public bool Muted { get; set; }
		[JsonProperty("remoteParty")] public RemoteParty RemoteParty { get; set; }
		[JsonProperty("personality")] public CallPersonality Personality { get; set; }
		[JsonProperty("state")] public CallState State { get; set; }
	}
}
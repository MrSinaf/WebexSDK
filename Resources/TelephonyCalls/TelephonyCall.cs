using System;
using Newtonsoft.Json;
using WebexSDK.Models;

namespace WebexSDK.TelephonyCalls
{
	public class TelephonyCall
	{
		[JsonProperty("eventType")] public TelephonyCallEventType Type { get; set; }
		[JsonProperty("eventTimestamp")] public DateTime EventDate { get; set; }
		[JsonProperty("callId")] public string CallId { get; set; }
		[JsonProperty("callSessionId")] public string CallSessionId { get; set; }
		[JsonProperty("personality")] public CallPersonality Personality { get; set; }
		[JsonProperty("state")] public CallState State { get; set; }
		[JsonProperty("muteCapable")] public bool MuteCapable { get; set; }
		[JsonProperty("muted")] public bool Muted { get; set; }
		[JsonProperty("remoteParty")] public RemoteParty Remote { get; set; }
		
		[JsonProperty("created")] public DateTime Created { get; set; }
		[JsonProperty("answered")] public DateTime? Answered { get; set; }
		[JsonProperty("disconnected")] public DateTime? Disconnected { get; set; }
	}
}
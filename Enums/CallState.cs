using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebexSDK
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum CallState
	{
		[EnumMember(Value = "connecting")] Connecting,
		[EnumMember(Value = "alerting")] Alerting,
		[EnumMember(Value = "connected")] Connected,
		[EnumMember(Value = "held")] Held,
		[EnumMember(Value = "remoteHeld")] RemoteHeld,
		[EnumMember(Value = "disconnected")] Disconnected
	}
}
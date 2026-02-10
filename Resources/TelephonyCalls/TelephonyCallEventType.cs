using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebexSDK.TelephonyCalls
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum TelephonyCallEventType
	{
		[EnumMember(Value = "originated")] Originated,
		[EnumMember(Value = "originating")] Originating,
		[EnumMember(Value = "received")] Received,
		[EnumMember(Value = "answered")] Answered,
		[EnumMember(Value = "updated")] Updated,
		[EnumMember(Value = "disconnected")] Disconnected,
		[EnumMember(Value = "held")] Held,
		[EnumMember(Value = "resumed")] Resumed,
	}
}
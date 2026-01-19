using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebexSDK
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum CallType
	{
		[EnumMember(Value = "placed")] Placed, 
		[EnumMember(Value = "missed")] Missed, 
		[EnumMember(Value = "received")] Received
	}
}

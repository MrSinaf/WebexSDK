using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebexSDK
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum CallPersonality
	{
		[EnumMember(Value = "originator")] Originator, 
		[EnumMember(Value = "terminator")] Terminator, 
		[EnumMember(Value = "clickToDial")] ClickToDial
	}
}
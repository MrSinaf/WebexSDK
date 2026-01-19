using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebexSDK
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum WebhookStatus
	{
		[EnumMember(Value = "active")] Active,
		[EnumMember(Value = "inactive")] Inactive
	}
}
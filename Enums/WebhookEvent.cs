using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebexSDK
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum WebhookEvent
	{
		[EnumMember(Value = "created")] Created,
		[EnumMember(Value = "updated")] Updated,
		[EnumMember(Value = "deleted")] Deleted,
		[EnumMember(Value = "started")] Started,
		[EnumMember(Value = "ended")] Ended,
		[EnumMember(Value = "joined")] Joined,
		[EnumMember(Value = "left")] Left,
		[EnumMember(Value = "migrated")] Migrated,
		[EnumMember(Value = "authorized")] Authorized,
		[EnumMember(Value = "deauthorized")] Deauthorized,
		[EnumMember(Value = "statusChanged")] StatusChanged
	}
}
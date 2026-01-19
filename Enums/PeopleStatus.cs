using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebexSDK
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum PeopleStatus
	{
		[EnumMember(Value = "active")] Active, 
		[EnumMember(Value = "call")] Call,
		[EnumMember(Value = "DoNotDisturb")] DoNotDisturb, 
		[EnumMember(Value = "inactive")] Inactive, 
		[EnumMember(Value = "meeting")] Meeting, 
		[EnumMember(Value = "OutOfOffice")] OutOfOffice, 
		[EnumMember(Value = "pending")] Pending,
		[EnumMember(Value = "presenting")] Presenting, 
		[EnumMember(Value = "unknown")] Unknown
	}
}
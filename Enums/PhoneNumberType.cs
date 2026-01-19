using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebexSDK
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum PhoneNumberType
	{
		[EnumMember(Value = "work")] Work,
		[EnumMember(Value = "work_extension")] WorkExtension,
		[EnumMember(Value = "mobile")] Mobile, 
		[EnumMember(Value = "fax")] Fax
	}
}

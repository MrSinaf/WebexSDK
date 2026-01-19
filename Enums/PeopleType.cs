using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebexSDK
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum PeopleType
	{
		[EnumMember(Value = "person")] Person, 
		[EnumMember(Value = "bot")] Bot, 
		[EnumMember(Value = "appUser")] AppUser
	}
}
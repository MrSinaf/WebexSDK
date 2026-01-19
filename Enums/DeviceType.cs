using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebexSDK
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum DeviceType
	{
		[EnumMember(Value = "DEVICE")] Device,
		[EnumMember(Value = "APPLICATION")] Application
	}
}
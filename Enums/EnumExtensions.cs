using Newtonsoft.Json;

namespace WebexSDK
{
	public static class EnumExtensions
	{
		public static string ToApiString(this object enumValue)
			=> enumValue == null ? null : JsonConvert.SerializeObject(enumValue).Replace("\"", "");
		
		public static T FromApiString<T>(this string enumString)
			=> string.IsNullOrEmpty(enumString)
					? default
					: JsonConvert.DeserializeObject<T>(enumString);
	}
}
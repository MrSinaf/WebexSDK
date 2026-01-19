using Newtonsoft.Json;

namespace WebexSDK
{
	public static class EnumExtensions
	{
		public static string ToApiString(this object enumValue)
		{
			if (enumValue == null) return null;
			return JsonConvert.SerializeObject(enumValue).Replace("\"", "");
		}
	}
}
using System;
using Newtonsoft.Json;

namespace WebexSDK.Models
{
	public sealed class People
	{
		[JsonProperty("id")] public string Id { get; set; }
		[JsonProperty("emails")] public string[] Emails { get; set; }
		[JsonProperty("phoneNumbers")] public PhoneNumber[] Phones { get; set; }
		[JsonProperty("displayName")] public string DisplayName { get; set; }
		[JsonProperty("nickName")] public string NickName { get; set; }
		[JsonProperty("firstName")] public string FirstName { get; set; }
		[JsonProperty("lastName")] public string LastName { get; set; }
		[JsonProperty("userName")] public string UserName { get; set; }
		[JsonProperty("avatar")] public string Avatar { get; set; }
		[JsonProperty("orgId")] public string OrgId { get; set; }
		[JsonProperty("created")] public DateTime Created { get; set; }
		[JsonProperty("lastModified")] public DateTime LastModified { get; set; }
		[JsonProperty("lastActivity")] public DateTime LastActivity { get; set; }
		[JsonProperty("status")] public PeopleStatus Status { get; set; }
		[JsonProperty("type")] public PeopleType Type { get; set; }
	}
}
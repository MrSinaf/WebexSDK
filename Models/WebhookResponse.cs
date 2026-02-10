using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebexSDK.Models
{
	public class WebhookResponse
	{
		[JsonProperty("id")] public string Id { get; set; }
		[JsonProperty("name")] public string Name { get; set; }
		[JsonProperty("targetUrl")] public string TargetUrl { get; set; }
		[JsonProperty("resource")] public WebhookResource Resource { get; set; }
		[JsonProperty("event")] public WebhookEvent Event { get; set; }
		[JsonProperty("orgId")] public string OrgId { get; set; }
		[JsonProperty("createdBy")] public string CreatedBy { get; set; }
		[JsonProperty("appId")] public string AppId { get; set; }
		[JsonProperty("ownedBy")] public string OwnedBy { get; set; }
		[JsonProperty("status")] public WebhookStatus Status { get; set; }
		[JsonProperty("created")] public DateTime Created { get; set; }
		[JsonProperty("actorId")] public string ActorId { get; set; }
		[JsonProperty("data")] public JObject Data { get; set; }
	}
}
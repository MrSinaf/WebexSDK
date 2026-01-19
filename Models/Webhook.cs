using System;
using Newtonsoft.Json;

namespace WebexSDK.Models
{
	public class Webhook
	{
		[JsonProperty("created")] public DateTime Created { get; set; }
		[JsonProperty("event")] public WebhookEvent Event { get; set; }
		[JsonProperty("filter")] public string Filter { get; set; }
		[JsonProperty("id")] public string Id { get; set; }
		[JsonProperty("name")] public string Name { get; set; }
		[JsonProperty("ownedBy")] public string OwnedBy { get; set; }
		[JsonProperty("resource")] public WebhookResource Resource { get; set; }
		[JsonProperty("secret")] public string Secret { get; set; }
		[JsonProperty("status")] public WebhookStatus Status { get; set; }
		[JsonProperty("targeturl")] public string TargetUrl { get; set; }
	}
}
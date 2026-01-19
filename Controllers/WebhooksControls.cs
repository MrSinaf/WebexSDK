using System.Threading.Tasks;
using WebexSDK.Models;

namespace WebexSDK.Controllers
{
	public class WebhooksControls
	{
		private readonly WebexClient client;
		
		public WebhooksControls(WebexClient client)
			=> this.client = client;
		
		public async Task<Webhook[]> GetList(int? max = null, string ownedBy = null)
		{
			var param = max != null ? $"max={max}" : "";
			param += ownedBy != null ? $"&ownedBy={ownedBy}" : "";
			return await client.RequestArray<Webhook>("webhooks?" + param);
		}
		
		public async Task<Webhook> Create(
			string name,
			string targetUrl,
			WebhookResource resource,
			WebhookEvent @event,
			string filter = null,
			string secret = null,
			string ownedBy = null
		)
			=> await client.Send<Webhook>(
				"webhooks",
				new { name, targetUrl, resource, @event, filter, secret, ownedBy }
			);
		
		public async Task Delete(string id)
			=> await client.Delete("webhooks/" + id);
	}
}
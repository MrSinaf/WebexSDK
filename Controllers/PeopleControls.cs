using System.Threading.Tasks;
using WebexSDK.Models;

namespace WebexSDK.Controllers
{
	public class PeopleControls
	{
		public readonly WebexClient client;
		
		public PeopleControls(WebexClient client)
			=> this.client = client;
		
		public async Task<People> GetMyOwnDetails()
			=> await client.Request<People>("people/me");
		
		public async Task<EndPointInformation> GetPreferredAnswerEndpoint(string personId)
			=> await client.Request<EndPointInformation>(
				$"telephony/config/people/{personId}/preferredAnswerEndpoint"
			);
	}
	
	public class EndPointInformation
	{
		public EndPointInformation(string preferredAnswerEndpointId, Endpoint[] endpoints)
		{
			this.preferredAnswerEndpointId = preferredAnswerEndpointId;
			this.endpoints = endpoints;
		}
		
		public string preferredAnswerEndpointId { get; }
		public Endpoint[] endpoints { get; }
	}
}
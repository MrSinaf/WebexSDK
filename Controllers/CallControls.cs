using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebexSDK.Models;

namespace WebexSDK.Controllers
{
	public class CallControls
	{
		private readonly WebexClient client;
		
		public CallControls(WebexClient client)
			=> this.client = client;
		
		public async Task<DialResponse> LocalDial(string destination)
		{
			Process.Start(
				new ProcessStartInfo
				{
						FileName = "tel:" + destination,
						UseShellExecute = true,
				}
			);
			var attemps = 10;
			
			while (attemps-- > 0)
			{
				Console.WriteLine($"Attemps restants : {attemps}");
				await Task.Delay(500);
				var call = (await ListCalls()).FirstOrDefault();
				if (call == null)
					continue;
				
				return new DialResponse(call.Id, call.CallSessionId);
			}
			
			return null;
		}
		
		public async Task<DialResponse> Dial(string destination, string endpointId = null)
			=> await client.Send<DialResponse>(
				"telephony/calls/dial",
				new { destination, endpointId }
			);
		
		public async Task<bool> Hangup(string callId)
			=> await client.Send("telephony/calls/hangup", new { callId });
		
		public async Task Answer(string callId, string endpointId)
			=> await client.Send("telephony/calls/answer", new { callId, endpointId });
		
		public async Task Mute(string callId)
			=> await client.Send("telephony/calls/mute", new { callId });
		
		public async Task Unmute(string callId)
			=> await client.Send("telephony/calls/unmute", new { callId });
		
		public async Task<bool> Transfer(string callId, string destination)
			=> await client.Send("telephony/calls/transfer", new { callId1 = callId, destination });
		
		public async Task<bool> Hold(string callId)
			=> await client.Send("telephony/calls/hold", new { callId });
		
		public async Task<bool> Resume(string callId)
			=> await client.Send("telephony/calls/resume", new { callId });
		
		public async Task<bool> TransferInCallId(string callId, string targetCallId)
			=> await client.Send(
				"telephony/calls/transfer",
				new { callId1 = callId, callId2 = targetCallId }
			);
		
		public async Task<CallHistoryRecord[]> ListCallHistory(CallType? type = null)
		{
			var param = type != null ? $"?type={type.ToApiString()}" : "";
			return await client.RequestArray<CallHistoryRecord>($"telephony/calls/history{param}");
		}
		
		public async Task<Call[]> ListCalls()
			=> await client.RequestArray<Call>("telephony/calls");
	}
	
	public class DialResponse
	{
		public DialResponse(string callId, string callSessionId)
		{
			this.callId = callId;
			this.callSessionId = callSessionId;
		}
		
		public string callId { get; }
		public string callSessionId { get; }
	}
}
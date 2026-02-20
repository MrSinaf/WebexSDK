using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebexSDK.Models;
using WebexSDK.TelephonyCalls;

namespace WebexSDK.Controllers
{
	public class ClientSocketControls
	{
		public event Action onConnectionChanged = delegate { };
		
		private readonly CancellationTokenSource cts = new CancellationTokenSource();
		private bool _isConnected;
		
		public bool IsConnected
		{
			get => _isConnected;
			private set
			{
				if (_isConnected != value)
				{
					_isConnected = value;
					onConnectionChanged();
				}
			}
		}
		
		public void Connect(Uri url) => Task.Run(async () =>
			{
				if (url.Scheme != "wss" && url.Scheme != "ws")
					throw new ArgumentException(
						$"WebSocket url must be wss or ws scheme, but was {url.Scheme} ヽ（≧□≦）ノ"
					);
				
				var tk = cts.Token;
				using (var client = new ClientWebSocket())
				{
					var buffer = new byte[4096];
					await client.ConnectAsync(url, tk);
					IsConnected = true;
					try
					{
						while (client.State == WebSocketState.Open && !tk.IsCancellationRequested)
						{
							var result = await client.ReceiveAsync(
								new ArraySegment<byte>(buffer),
								tk
							);
							
							if (result.MessageType == WebSocketMessageType.Close)
							{
								await client.CloseAsync(
									WebSocketCloseStatus.NormalClosure,
									"Bye!",
									tk
								);
								break;
							}
							
							var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
							Console.WriteLine(message);
							ComputeMessage(JsonConvert.DeserializeObject<WebhookResponse>(message));
						}
					}
					catch (Exception)
					{
						IsConnected = false;
					}
				}
			}
		);
		
		private void ComputeMessage(WebhookResponse response)
		{
			switch (response.Resource)
			{
				case WebhookResource.AttachmentActions:
					break;
				case WebhookResource.DataSources:
					break;
				case WebhookResource.Memberships:
					break;
				case WebhookResource.Messages:
					break;
				case WebhookResource.Rooms:
					break;
				case WebhookResource.Meetings:
					break;
				case WebhookResource.Recordings:
					break;
				case WebhookResource.ConvergedRecordings:
					break;
				case WebhookResource.MeetingParticipant:
					break;
				case WebhookResource.MeetingTranscripts:
					break;
				case WebhookResource.TelephonyCalls:
					TelephonyCallService.EventUserReceived(response.Data.ToObject<TelephonyCall>());
					break;
				case WebhookResource.TelephonyConference:
					break;
				case WebhookResource.TelephoneMwi:
					break;
				case WebhookResource.UcCounters:
					break;
				case WebhookResource.ServiceApp:
					break;
				case WebhookResource.AdminBatchJobs:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
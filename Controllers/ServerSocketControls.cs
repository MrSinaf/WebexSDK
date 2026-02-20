using System;
using WebexSDK.Models;
using WebexSDK.TelephonyCalls;

namespace WebexSDK.Controllers
{
	public class ServerSocketControls
	{
		public void ComputeMessage(WebhookResponse response)
		{
			var actorId = response.ActorId;
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
					TelephonyCallService.EventServerReceived(
						actorId,
						response.Data.ToObject<TelephonyCall>()
					);
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
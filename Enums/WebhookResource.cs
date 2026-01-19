using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebexSDK
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum WebhookResource {
		[EnumMember(Value = "attachmentActions")] AttachmentActions,
		[EnumMember(Value = "dataSources")] DataSources,
		[EnumMember(Value = "memberships")] Memberships,
		[EnumMember(Value = "messages")] Messages,
		[EnumMember(Value = "rooms")] Rooms,
		[EnumMember(Value = "meetings")] Meetings,
		[EnumMember(Value = "recordings")] Recordings,
		[EnumMember(Value = "convergedRecordings")] ConvergedRecordings,
		[EnumMember(Value = "meetingParticipant")] MeetingParticipant,
		[EnumMember(Value = "meetingTranscripts")] MeetingTranscripts,
		[EnumMember(Value = "telephony_calls")] TelephonyCalls,
		[EnumMember(Value = "telephony_conference")] TelephonyConference,
		[EnumMember(Value = "telephone_mwi")] TelephoneMwi,
		[EnumMember(Value = "uc_counters")] UcCounters,
		[EnumMember(Value = "serviceApp")] ServiceApp,
		[EnumMember(Value = "adminBatchJobs")] AdminBatchJobs
		
	}
}
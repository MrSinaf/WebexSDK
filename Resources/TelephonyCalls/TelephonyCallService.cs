using System;

namespace WebexSDK.TelephonyCalls
{
	public static class TelephonyCallService
	{
		public static event Action<TelephonyCall> onCallUserOriginating = delegate { };
		public static event Action<TelephonyCall> onCallUserOriginated = delegate { };
		public static event Action<TelephonyCall> onCallUserReceived = delegate { };
		public static event Action<TelephonyCall> onCallUserAnswered = delegate { };
		public static event Action<TelephonyCall> onCallUserDisconnect = delegate { };
		public static event Action<TelephonyCall> onCallUserUpdated = delegate { };
		public static event Action<TelephonyCall> onCallUserHeld = delegate { };
		public static event Action<TelephonyCall> onCallUserResumed = delegate { };
		
		
		public static event Action<string, TelephonyCall> onCallServerOriginating = delegate { };
		public static event Action<string, TelephonyCall> onCallServerOriginated = delegate { };
		public static event Action<string, TelephonyCall> onCallServerReceived = delegate { };
		public static event Action<string, TelephonyCall> onCallServerAnswered = delegate { };
		public static event Action<string, TelephonyCall> onCallServerDisconnect = delegate { };
		public static event Action<string, TelephonyCall> onCallServerUpdated = delegate { };
		public static event Action<string, TelephonyCall> onCallServerHeld = delegate { };
		public static event Action<string, TelephonyCall> onCallServerResumed = delegate { };
		
		internal static void EventUserReceived(TelephonyCall call)
		{
			switch (call.Type)
			{
				case TelephonyCallEventType.Originated:
					onCallUserOriginated(call);
					break;
				case TelephonyCallEventType.Received:
					onCallUserReceived(call);
					break;
				case TelephonyCallEventType.Answered:
					onCallUserAnswered(call);
					break;
				case TelephonyCallEventType.Disconnected:
					onCallUserDisconnect(call);
					break;
				case TelephonyCallEventType.Updated:
					onCallUserUpdated(call);
					break;
				case TelephonyCallEventType.Held:
					onCallUserHeld(call);
					break;
				case TelephonyCallEventType.Resumed:
					onCallUserResumed(call);
					break;
				case TelephonyCallEventType.Originating:
					onCallUserOriginating(call);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		
		internal static void EventServerReceived(string id, TelephonyCall call)
		{
			switch (call.Type)
			{
				case TelephonyCallEventType.Originated:
					onCallServerOriginated(id, call);
					break;
				case TelephonyCallEventType.Received:
					onCallServerReceived(id, call);
					break;
				case TelephonyCallEventType.Answered:
					onCallServerAnswered(id, call);
					break;
				case TelephonyCallEventType.Disconnected:
					onCallServerDisconnect(id, call);
					break;
				case TelephonyCallEventType.Updated:
					onCallServerUpdated(id, call);
					break;
				case TelephonyCallEventType.Held:
					onCallServerHeld(id, call);
					break;
				case TelephonyCallEventType.Resumed:
					onCallServerResumed(id, call);
					break;
				case TelephonyCallEventType.Originating:
					onCallServerOriginating(id, call);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
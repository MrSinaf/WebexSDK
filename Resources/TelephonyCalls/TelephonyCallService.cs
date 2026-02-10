using System;

namespace WebexSDK.TelephonyCalls
{
	public static class TelephonyCallService
	{
		public static event Action<TelephonyCall> onCallOriginating = delegate { };
		public static event Action<TelephonyCall> onCallOriginated = delegate { };
		public static event Action<TelephonyCall> onCallReceived = delegate { };
		public static event Action<TelephonyCall> onCallAnswered = delegate { };
		public static event Action<TelephonyCall> onCallDisconnect = delegate { };
		public static event Action<TelephonyCall> onCallUpdated = delegate { };
		public static event Action<TelephonyCall> onCallHeld = delegate { };
		public static event Action<TelephonyCall> onCallResumed = delegate { };
		
		internal static void EventReceived(TelephonyCall call)
		{
			Console.WriteLine($"Call event received: {call.Type}");
			switch (call.Type)
			{
				case TelephonyCallEventType.Originated:
					onCallOriginated(call);
					break;
				case TelephonyCallEventType.Received:
					onCallReceived(call);
					break;
				case TelephonyCallEventType.Answered:
					onCallAnswered(call);
					break;
				case TelephonyCallEventType.Disconnected:
					onCallDisconnect(call);
					break;
				case TelephonyCallEventType.Updated:
					onCallUpdated(call);
					break;
				case TelephonyCallEventType.Held:
					onCallHeld(call);
					break;
				case TelephonyCallEventType.Resumed:
					onCallResumed(call);
					break;
				case TelephonyCallEventType.Originating:
					onCallOriginating(call);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
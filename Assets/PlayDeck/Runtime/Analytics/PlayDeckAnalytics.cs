using System.Runtime.InteropServices;
using Newtonsoft.Json;
using UnityEngine;

namespace PlayDeck.Runtime.Analytics
{
	public class PlayDeckAnalytics
	{
		#region Request

		public void GameEnd()
		{
			Debug.Log($"[PlayDeckBridge]: GameEnd");
			PlayDeckBridge_PostMessage_GameEnd();
		}

		public void SendGameProgress(AnalyticsGameProgress analyticsGameProgress)
		{
			var json = JsonConvert.SerializeObject(analyticsGameProgress);
			Debug.Log($"[PlayDeckBridge]: SendGameProgress {json}");
			PlayDeckBridge_PostMessage_SendGameProgress(json);
		}

		public void SendAnalyticsNewSession()
		{
			Debug.Log($"[PlayDeckBridge]: SendAnalyticsNewSession");
			PlayDeckBridge_PostMessage_SendAnalyticsNewSession();
		}

		public void SendAnalytics(AnalyticsEvent analyticsEvent)
		{
			var json = JsonConvert.SerializeObject(analyticsEvent);
			Debug.Log($"[PlayDeckBridge]: SendAnalytics {json}");
			PlayDeckBridge_PostMessage_SendAnalytics(json);
		}

		#endregion

		#region NativeMethods

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_GameEnd();

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_SendGameProgress(string data);

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_SendAnalytics(string data);

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_SendAnalyticsNewSession();

		#endregion
	}
}
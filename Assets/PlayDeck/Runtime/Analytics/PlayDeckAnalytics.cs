using System.Runtime.InteropServices;

namespace PlayDeck.Runtime.Analytics
{
	public class PlayDeckAnalytics
	{
		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_GameEnd();

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_SendGameProgress(string data);

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_SendAnalytics(string data);

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_SendAnalyticsNewSession();
	}
}
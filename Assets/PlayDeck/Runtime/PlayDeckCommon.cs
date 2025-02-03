using System.Runtime.InteropServices;

namespace PlayDeck.Runtime
{
	public class PlayDeckCommon
	{
		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage(string method);

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_IntValue(string method, int value);

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_StringValue(string method, string value);

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_SetData(string key, string value);

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_GetData(string key);

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_GetPlaydeckState();
	}
}
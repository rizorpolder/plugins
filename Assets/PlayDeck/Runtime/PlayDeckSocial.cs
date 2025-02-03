using System.Runtime.InteropServices;

namespace PlayDeck.Runtime
{
	public class PlayDeckSocial
	{
		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_CustomShare(string data);

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_GetShareLink(string data);

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_OpenTelegramLink(string data);

	}
}
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using PlayDeck.Runtime.Common;
using UnityEngine;

namespace PlayDeck.Runtime.Social
{
	public class PlayDeckSocial : PlayDeckCommon
	{
		private System.Action<string> _getShareLinkCallback;

		#region Requests

		public void CustomShare(Dictionary<string, string> @params)
		{
			var json = JsonConvert.SerializeObject(@params);

			Debug.Log($"[PlayDeckBridge]: CustomShare {json}");
			PlayDeckBridge_PostMessage_CustomShare(json);
		}

		public void GetShareLink(Dictionary<string, string> @params, System.Action<string> callback)
		{
			var json = JsonConvert.SerializeObject(@params);

			Debug.Log($"[PlayDeckBridge]: GetShareLink {json}");
			PlayDeckBridge_PostMessage_GetShareLink(json);

			_getShareLinkCallback = callback;
		}

		public void OpenTelegramLink(string link)
		{

            Debug.Log($"[PlayDeckBridge]: OpenTelegramLink {link}");
            PlayDeckBridge_PostMessage_OpenTelegramLink(link);
		}

		#endregion

		#region Response

		private void GetShareLinkHandler(string shareLink)
		{
			_getShareLinkCallback?.Invoke(shareLink);
		}

		#endregion

		#region NativeMethods

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_CustomShare(string data);

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_GetShareLink(string data);

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_OpenTelegramLink(string data);

		#endregion
	}
}
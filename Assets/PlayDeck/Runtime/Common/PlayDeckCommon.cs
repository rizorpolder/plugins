using System.Runtime.InteropServices;
using Newtonsoft.Json;
using UnityEngine;

namespace PlayDeck.Runtime.Common
{
	public class PlayDeckCommon
	{
		public const string GET_USER_PROFILE = "getUserProfile";

		private System.Action<UserData> _getUserCallback;
		private System.Action<string> _getDataCallback;
		private System.Action<bool> _getPlaydeckStateCallback;

		#region Request

		public void GetData(string key, System.Action<string> callback)
		{
			_getDataCallback = callback;

			Debug.Log($"[PlayDeckBridge]: GetData {key}");

			PlayDeckBridge_PostMessage_GetData(key);
		}

		public void SetData(string key, string data)
		{
			Debug.Log($"[PlayDeckBridge]: SetData [{key}]: {data}");
			PlayDeckBridge_PostMessage_SetData(key, data);
		}

		public void GetUserProfile(System.Action<UserData> callback)
		{
			_getUserCallback = callback;

			PlayDeckBridge_PostMessage(GET_USER_PROFILE);
		}

		public void GetPlaydeckState(System.Action<bool> callback)
		{

            Debug.Log($"[PlayDeckBridge]: GetPlaydeckState");
            PlayDeckBridge_PostMessage_GetPlaydeckState();

            _getPlaydeckStateCallback = callback;
		}

		#endregion

		#region Response

		private void GetUserHandler(string userJson)
		{
			var converted = JsonConvert.DeserializeObject<UserData>(userJson);
			_getUserCallback?.Invoke(converted);
		}

		private void GetDataHandler(string dataJson)
		{
			_getDataCallback?.Invoke(dataJson);
		}
		private void GetPlaydeckStateHandler(int state)
		{
			_getPlaydeckStateCallback?.Invoke(state != 0);
		}
		#endregion

		#region NativeMethods

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

		#endregion
	}
}
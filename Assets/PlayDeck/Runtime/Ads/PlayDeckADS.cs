using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace PlayDeck.Runtime.Ads
{
	public class PlayDeckAds
	{
		private Action<string> _rewardedAdCallback;
		private Action<string> _errAdCallback;
		private Action<string> _skipAdCallback;
		private Action<string> _notFoundAdCallback;
		private Action<string> _startAdCallback;

		#region Request

		public void ShowAd(Action<string> rewardedAdCallback,
			Action<string> errAdCallback,
			Action<string> skipAdCallback,
			Action<string> notFoundAdCallback,
			Action<string> startAdCallback)
		{
			Debug.Log($"[PlayDeckBridge]: ShowAd");

			_rewardedAdCallback = rewardedAdCallback;
			_errAdCallback = errAdCallback;
			_skipAdCallback = skipAdCallback;
			_notFoundAdCallback = notFoundAdCallback;
			_startAdCallback = startAdCallback;
			PlayDeckBridge_PostMessage_ShowAd();
		}

		#endregion

		#region Responce

		//called from js
		private void RewardedAdHandler(string data)
		{
			_rewardedAdCallback?.Invoke(data);
		}

		//called from js

		private void ErrAdHandler(string data)
		{
			_errAdCallback?.Invoke(data);
		}
		//called from js

		private void SkipAdHandler(string data)
		{
			_skipAdCallback?.Invoke(data);
		}
		//called from js

		private void NotFoundAdHandler(string data)
		{
			_notFoundAdCallback?.Invoke(data);
		}
		//called from js

		private void StartAdHandler(string data)
		{
			_startAdCallback?.Invoke(data);
		}

		#endregion

		#region NativeMethods

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_ShowAd();

		#endregion
	}
}
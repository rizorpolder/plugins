using System;
using System.Runtime.InteropServices;
using PlayDeck.Runtime.Common;
using UnityEngine;

namespace PlayDeck.Runtime.Ads
{
	public class PlayDeckAds : PlayDeckCommon
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

		private void RewardedAdHandler(string data)
		{
			_rewardedAdCallback?.Invoke(data);
		}

		private void ErrAdHandler(string data)
		{
			_errAdCallback?.Invoke(data);
		}

		private void SkipAdHandler(string data)
		{
			_skipAdCallback?.Invoke(data);
		}

		private void NotFoundAdHandler(string data)
		{
			_notFoundAdCallback?.Invoke(data);
		}

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
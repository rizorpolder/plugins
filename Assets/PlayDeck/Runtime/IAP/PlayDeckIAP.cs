using System.Runtime.InteropServices;
using Newtonsoft.Json;
using PlayDeck.Runtime.Common;
using UnityEngine;

namespace PlayDeck.Runtime.IAP
{
	public class PlayDeckIAP : PlayDeckCommon
	{
		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_RequestPayment(string data);

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_GetPaymentInfo(string data);

		private System.Action<PaymentResponseData> _paymentRequestCallback;
		private System.Action<GetPaymentInfoResponseData> _getPaymentInfoRequestCallback;

		#region Request
		public void RequestPayment(PaymentRequestData requestData, System.Action<PaymentResponseData> callback)
		{
			_paymentRequestCallback = callback;
			var json = JsonConvert.SerializeObject(requestData);
			Debug.Log($"[PlayDeckBridge]: RequestPayment {json}");
			PlayDeckBridge_PostMessage_RequestPayment(json);
		}

		public void GetPaymentInfo(GetPaymentInfoRequestData requestData,
			System.Action<GetPaymentInfoResponseData> callback)
		{
			_getPaymentInfoRequestCallback = callback;

			var json = JsonConvert.SerializeObject(requestData);
			Debug.Log($"[PlayDeckBridge]: GetPaymentInfo {json}");
			PlayDeckBridge_PostMessage_GetPaymentInfo(json);
		}
		#endregion




		#region Response
		public void InvoiceClosedHandler(string value)
		{
			Debug.LogAssertionFormat($"InvoiceClosed {value}");
		}

		private void GetPaymentInfoHandler(string getPaymentInfoJson)
		{
			var converted = JsonConvert.DeserializeObject<GetPaymentInfoResponseData>(getPaymentInfoJson);
			_getPaymentInfoRequestCallback?.Invoke(converted);
		}

		private void RequestPaymentHandler(string paymentRequestJson)
		{
			var converted = JsonConvert.DeserializeObject<PaymentResponseData>(paymentRequestJson);
			_paymentRequestCallback?.Invoke(converted);
		}

		#endregion
	}
}
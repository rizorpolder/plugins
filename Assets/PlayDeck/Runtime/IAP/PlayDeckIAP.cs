using System.Runtime.InteropServices;
using IAP.Core.Runtime;
using Newtonsoft.Json;

namespace PlayDeck.Runtime.IAP
{
	public class PlayDeckIAP : IIAPService
	{
		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_RequestPayment(string data);

		[DllImport("__Internal")]
		private static extern void PlayDeckBridge_PostMessage_GetPaymentInfo(string data);

		private System.Action<PaymentResponseData> _paymentRequestCallback;



		public bool IsPurchaseInProcess { get; }

		public bool IsInitialized()
		{
			throw new System.NotImplementedException();
		}

		public void Purchase(string productId)
		{
			throw new System.NotImplementedException();
		}

		public void ConfirmPurchaseReceiving(string productId)
		{
			throw new System.NotImplementedException();
		}

		private void RequestPaymentHandler(string paymentRequestJson)
		{
			var converted = JsonConvert.DeserializeObject<PaymentResponseData>(paymentRequestJson);
			_paymentResponseJson = converted;
			_paymentRequestCallback?.Invoke(converted);
		}

	}
}
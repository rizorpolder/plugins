using System;

namespace IAP.PlayDeck.Runtime
{
	/// <summary>
	/// Represents the response data for a payment request.
	/// </summary>
	[Serializable]
	public class PaymentResponseData
	{
		/// <summary>
		/// The URL for the purchase via Telegram.
		/// </summary>
		public string url;
	}
}
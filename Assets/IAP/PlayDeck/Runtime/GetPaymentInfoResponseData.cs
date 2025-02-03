using System;

namespace IAP.PlayDeck.Runtime
{
	/// <summary>
	/// Represents the response data for concrete payment.
	/// </summary>
	[Serializable]
	public class GetPaymentInfoResponseData
	{
		/// <summary>
		/// The URL for the purchase via Telegram.
		/// </summary>
		public bool paid;

		public long telegramId;

		public long dateTime;
	}
}
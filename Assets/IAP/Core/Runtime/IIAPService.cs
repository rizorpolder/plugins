namespace IAP.Core.Runtime
{
	public interface IIAPService
	{
		public bool IsPurchaseInProcess { get; }

		public bool IsInitialized();

		public void Purchase(string productId);
		public void ConfirmPurchaseReceiving(string productId);
	}
}
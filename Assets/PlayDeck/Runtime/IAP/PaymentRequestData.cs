using System;

[Serializable]
public class PaymentRequestData
{
	/// <value>
	/// The amount is represented as an integer.
	/// </value>
	public int amount;

	/// <value>
	/// The description of the payment order.
	/// </value>
	public string description;

	/// <value>
	/// A unique order identifier in your system, which you can use to check in postback that payment was successful.
	/// </value>
	public string externalId;

	/// <value>
	/// The photo URL is an optional field.
	/// </value>
	public string photoUrl;
}
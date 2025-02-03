using System;

[Serializable]
public class GetPaymentInfoRequestData
{
	/// <value>
	/// A unique order identifier in your system, which you can use to check in postback that payment was successful.
	/// </value>
	public string externalId;
}
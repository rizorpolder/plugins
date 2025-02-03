using System;
using System.Collections.Generic;

namespace PlayDeck.Runtime.Analytics
{
	/// <summary>
	/// Represents an analytics event.
	/// </summary>
	[Serializable]
	public class AnalyticsEvent
	{
		/// <summary>
		/// The name of the event.
		/// </summary>
		public string name;

		/// <summary>
		/// The type of the event.
		/// </summary>
		public string type;

		/// <summary>
		/// A dictionary of user properties associated with the event.
		/// </summary>
		public Dictionary<string, string> user_properties;

		/// <summary>
		/// A dictionary of event properties associated with the event.
		/// </summary>
		public Dictionary<string, string> event_properties;
	}
}
using System;
using System.Collections.Generic;

namespace Analytics.PlayDeck.Runtime
{
	/// <summary>
	/// Represents an achievement to be sent in the game progress analytics event.
	/// </summary>
	[Serializable]
	public class AnalyticsAchievement
	{
		/// <summary>
		/// The name of the achievement.
		/// </summary>
		public string name;

		/// <summary>
		/// The description of the achievement.
		/// </summary>
		public string description;

		/// <summary>
		/// The points awarded for achieving the achievement.
		/// </summary>
		public int points;

		/// <summary>
		/// The value associated with the achievement.
		/// </summary>
		public int value;

		/// <summary>
		/// Additional data related to the achievement.
		/// </summary>
		public Dictionary<string, object> additional_data;
	}
}
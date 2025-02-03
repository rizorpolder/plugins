using System;
using System.Collections.Generic;

namespace Analytics.PlayDeck.Runtime
{
	/// <summary>
	/// Represents the overall game progress data to be sent in the analytics event.
	/// </summary>
	[Serializable]
	public class AnalyticsGameProgress
	{
		/// <summary>
		/// A list of achievements to be included in the game progress analytics event.
		/// </summary>
		public List<AnalyticsAchievement> achievements;

		/// <summary>
		/// The player's progress data to be included in the game progress analytics event.
		/// </summary>
		public AnalyticsProgress progress;
	}
}
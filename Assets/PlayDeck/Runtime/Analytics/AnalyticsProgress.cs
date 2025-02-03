using System;

namespace PlayDeck.Runtime.Analytics
{
	/// <summary>
	/// Represents the player's progress to be sent in the game progress analytics event.
	/// </summary>
	[Serializable]
	public class AnalyticsProgress
	{
		/// <summary>
		/// The current level of the player's progress.
		/// </summary>
		public int level;

		/// <summary>
		/// The current experience points of the player's progress.
		/// </summary>
		public int xp;
	}
}
using System;
using System.Collections.Generic;

namespace Common.PlayDeck
{
	[Serializable]
	public class UserData
	{
		public string avatar;
		public string username;
		public string firstName;
		public string lastName;
		public long telegramId;
		public string locale;
		public string token;
		public string sessionId;
		public ulong currentGameStarted;

		public Dictionary<string, string> @params;
	}
}
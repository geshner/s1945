#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace s1945
{
	static class Program
	{
		private static Game1 game;

		[STAThread]
		static void Main ()
		{
			game = new Game1 ();
			game.Run ();
		}
	}
}

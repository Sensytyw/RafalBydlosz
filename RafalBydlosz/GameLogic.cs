using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RafalBydlosz
{
	public class GameLogic
	{
		public string CurrentPlayer { get; set; } = X;
		private const string X = "X";
		private const string O = "O";


		public void SetNextPlayer()
		{
			if(CurrentPlayer == X)
			{
				CurrentPlayer = O;

			}

			else
			{
				CurrentPlayer = X;
			}
		}

	}
}

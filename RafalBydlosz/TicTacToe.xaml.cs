using System;
using System.Windows;
using System.Windows.Controls;

namespace RafalBydlosz
{
	/// <summary>
	/// Interaction logic for TicTacToe.xaml
	/// </summary>
	public partial class TicTacToe : Window
	{
		GameLogic _GameLogic = new GameLogic();

		public TicTacToe()
		{
			InitializeComponent();
		}

		private void XO_Button_Click(object sender, RoutedEventArgs e)
		{
			var space = (Button) sender;
			if (!String.IsNullOrWhiteSpace(space.Content?.ToString())) return;
			space.Content = _GameLogic.CurrentPlayer;

			var coordinates = space.Tag.ToString().Split(',');
			var xValue = int.Parse(coordinates[0]);
			var yValue = int.Parse(coordinates[1]);

			var buttonPosition = new Position()
			{ x=xValue, y=yValue};

			_GameLogic.UpdateBoard(buttonPosition, _GameLogic.CurrentPlayer);
			if(_GameLogic.PlayerWin())
			{
				WinScreen.Text = $"{_GameLogic.CurrentPlayer} WINS :)";
				WinScreen.Visibility = Visibility.Visible;
			}

			_GameLogic.SetNextPlayer();
		}

		private void NewGame_Click(object sender, RoutedEventArgs e)
		{
			foreach( var control in gridBoard.Children)
			{
				if(control is Button)
				{
					((Button)control).Content = String.Empty;
				}
			}

			_GameLogic = new GameLogic();
			WinScreen.Visibility = Visibility.Collapsed;
		}
	}
}

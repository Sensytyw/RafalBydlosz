using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RafalBydlosz
{
	/// <summary>
	/// Interaction logic for TicTacToe.xaml
	/// </summary>
	public partial class TicTacToe : Window
	{
		public TicTacToe()
		{
			InitializeComponent();
		}

		GameLogic _GameLogic = new GameLogic();

		private void XO_Button_Click(object sender, RoutedEventArgs e)
		{
			var space = (Button) sender;
			if (!String.IsNullOrWhiteSpace(space.Content?.ToString())) return;
			space.Content = _GameLogic.CurrentPlayer;

			_GameLogic.SetNextPlayer();
		}

		private void NewGame_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}

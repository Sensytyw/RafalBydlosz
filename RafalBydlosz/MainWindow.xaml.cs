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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RafalBydlosz
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();


		}

		private void ButtonClear_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ResultText.Text = string.Empty;
			var button = sender as Button;
			var currentNumber = button.Name[button.Name.Length - 1];
			CurrentOperationText.Text += currentNumber;

		}

		private void ButtonResult_Click(object sender, RoutedEventArgs e)
		{
			var operation = CurrentOperationText.Text;

			CurrentOperationText.Text = String.Empty;
		}

		private void ButtonMinus_Click(object sender, RoutedEventArgs e)
		{
			CurrentOperationText.Text += "-";
		}

		private void ButtonAdd_Click(object sender, RoutedEventArgs e)
		{
			CurrentOperationText.Text += "+";
		}

		private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
		{
			CurrentOperationText.Text += "*";
		}

		private void ButtonDivide_Click(object sender, RoutedEventArgs e)
		{
			CurrentOperationText.Text += "/";
		}
	}

}

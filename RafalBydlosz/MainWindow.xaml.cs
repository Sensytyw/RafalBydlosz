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
		double first;
		double second;
		char op;
		public MainWindow()
		{
			InitializeComponent();


		}

		private void ButtonClear_Click(object sender, RoutedEventArgs e)
		{
			ResultText.Clear();
		
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button btn = (Button)sender;
			ResultText.Text += btn.Content.ToString();
			second = float.Parse(ResultText.Text);
		}

		private void ButtonResult_Click(object sender, RoutedEventArgs e)
		{
			second = float.Parse(ResultText.Text);
			double result = 0;

			if (op =='+')
			{
				result = first + second;
				first = result;
			}
			else if (op == '-')
			{
				result = first - second;
				first = result;
			}
			else if (op == '*')
			{
				result = first * second;
				first = result;
			}
			else if (op == '/')
			{
				if (second != 0)
				{
					result = first / second;
					first = result;
				}
			}
			if (ResultText.Text == "0")
			{
				ResultText.Clear();
			}
			ResultText.Text = result.ToString();
		}

		private void ButtonMinus_Click(object sender, RoutedEventArgs e)
		{
			first = float.Parse(ResultText.Text);
			op = '-';
			ResultText.Clear();
		}

		private void ButtonAdd_Click(object sender, RoutedEventArgs e)
		{
			first = float.Parse(ResultText.Text);
			op = '+';
			ResultText.Clear();
		}

		private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
		{
			first = float.Parse(ResultText.Text);
			op = '*';
			ResultText.Clear();
		}

		private void ButtonDivide_Click(object sender, RoutedEventArgs e)
		{
			first = float.Parse(ResultText.Text);
			op = '/';
			ResultText.Clear();
		}
	}

}

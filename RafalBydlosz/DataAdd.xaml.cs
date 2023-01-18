using System.Windows;

namespace RafalBydlosz
{
	/// <summary>
	/// Logika interakcji dla klasy DataAdd.xaml
	/// </summary>
	public partial class DataAdd : Window
	{
		public bool IsOkPressed { get; set; }
		public DataAdd()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			IsOkPressed = true;
			this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			IsOkPressed = false;
			this.Close();
		}
	}
}

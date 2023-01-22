using System.Collections.Generic;
using System.Windows;
using System.IO;

namespace Library
{
	/// <summary>
	/// Interaction logic for OrderBooks.xaml
	/// </summary>
	public partial class OrderBooks : Window
	{
		List<Books> listOfBooks = new List<Books>();

		public OrderBooks()
		{
			InitializeComponent();
			//if (File.Exists("test.xml"))
			//{
			//	listOfBooks = SerializationBooks.DeserializeToObject<List<Books>>("test.xml");
			//}

			//else
			{
				listOfBooks.Add(new Books("1", "Great Shark", "1234567891", "Adventure"));
				listOfBooks.Add(new Books("2", "Big Thumb", "2314567981", "Comdey"));
				listOfBooks.Add(new Books("3", "New Orlean", "2068931230", "Drama"));
				dataGridBooks.ItemsSource = listOfBooks;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			AddBooks okno = new AddBooks();
			Books ksiazka = new Books();
			okno.DataContext = ksiazka;
			okno.ShowDialog();
			if (okno.IsOkPressed)
			{
				listOfBooks.Add(ksiazka);
				dataGridBooks.Items.Refresh();
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			if (dataGridBooks.SelectedItem != null)
			{
				AddBooks okno = new AddBooks();
				Books ksiazka = new Books((Books)dataGridBooks.SelectedItem);
				okno.DataContext = ksiazka;
				okno.ShowDialog();
				if (okno.IsOkPressed)
				{
					int index = listOfBooks.IndexOf((Books)dataGridBooks.SelectedItem);
					listOfBooks[index] = ksiazka;
					dataGridBooks.Items.Refresh();
				}
			}
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			SerializationBooks.SerializeToXml<List<Books>>(listOfBooks, "test.xml");
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{

		}
	}
}

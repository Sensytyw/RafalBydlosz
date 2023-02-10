using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace RafalBydlosz
{
	/// <summary>
	/// Logika interakcji dla klasy DataPeople.xaml
	/// </summary>
	public partial class DataPeople : Window
	{
		List<People> listOfPeoples = new List<People>();

		public DataPeople()
		{
			InitializeComponent();
			if (File.Exists("test.xml"))
			{
				listOfPeoples = Serialization.DeserializeToObject<List<People>>("C:\\Users\\Rafal\\Desktop\\Serializacja\\test.xml");
			}

			else
			{
				listOfPeoples.Add(new People("Jan", "Nowak", "1234567891"));
				listOfPeoples.Add(new People("Andrzej", "Kowalczuk", "2314567981"));
				listOfPeoples.Add(new People("Mariusz", "Brun", "2068931230"));
				dataGridPeople.ItemsSource = listOfPeoples;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			DataAdd okno = new DataAdd();
			People osoba = new People();
			okno.DataContext = osoba;
			okno.ShowDialog();
			if (okno.IsOkPressed)
			{
				listOfPeoples.Add(osoba);
				dataGridPeople.Items.Refresh();
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			if (dataGridPeople.SelectedItem != null)
			{
				DataAdd okno = new DataAdd();
				People osoba = new People((People)dataGridPeople.SelectedItem);
				okno.DataContext = osoba;
				okno.ShowDialog();
				if (okno.IsOkPressed)
				{
					int index = listOfPeoples.IndexOf((People)dataGridPeople.SelectedItem);
					listOfPeoples[index] = osoba;
					dataGridPeople.Items.Refresh();
				}
			}
		}
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Serialization.SerializeToXml<List<People>>(listOfPeoples, "C:\\Users\\Rafal\\Desktop\\Serializacja\\test.xml");
		}
	}
}

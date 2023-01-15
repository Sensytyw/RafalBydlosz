using System;
using System.Collections.Generic;
using System.IO;
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
	/// Logika interakcji dla klasy DataPeople.xaml
	/// </summary>
	public partial class DataPeople : Window
	{
		List<People> listOfPeoples = new List<People>();

		public DataPeople()
		{
			InitializeComponent();
			if (File.Exists("C:\\Users\\Rafal\\Desktop\\Serializacja\\test.xml"))
			{
				listOfPeoples = Serialization.DeserializeToObject<List<People>>("C:\\Users\\Rafal\\Desktop\\Serializacja\\test.xml");
			}

			else
			{
				listOfPeoples.Add(new People("aaaa", "bbbb", "123456789"));
				listOfPeoples.Add(new People("aaaa", "bbbb", "123456789"));
				listOfPeoples.Add(new People("aaaa", "bbbb", "123456789"));
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

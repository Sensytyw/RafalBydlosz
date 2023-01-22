using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;

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
			LoadGrid();
		}
		public static class Globals
			{
				public static SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=LibraryProject;Integrated Security=True");
			}

		public void LoadGrid()
		{
			SqlCommand cmd = new SqlCommand("select * from Books", Globals.con);
			DataTable dt = new DataTable();
			Globals.con.Open();
			SqlDataReader sdr = cmd.ExecuteReader();
			dt.Load(sdr);
			Globals.con.Close();
			dataGridBooks.ItemsSource = dt.DefaultView;
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

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{

		}

	}
}

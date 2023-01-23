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

		private void ButtonAdd(object sender, RoutedEventArgs e)
		{
			AddBooks okno = new AddBooks();
			okno.Button_Ad.Visibility = Visibility.Visible;
			Books ksiazka = new Books();
			okno.DataContext = ksiazka;
			okno.ShowDialog();
			if (okno.IsOkPressed)
			{
				listOfBooks.Add(ksiazka);
				dataGridBooks.Items.Refresh();
			}
		}

		private void ButtonEddit(object sender, RoutedEventArgs e)
		{
			AddBooks aB = new AddBooks();
			aB.Button_Ed.Visibility = Visibility.Visible;
			aB.ShowDialog();
		}

		private void ButtonRemove(object sender, RoutedEventArgs e)
		{
			Globals.con.Open();
			SqlCommand cmd = new SqlCommand("delete from Books where BookId =" + remove_row.Text + " ", Globals.con);
			try 
			{ 
				cmd.ExecuteNonQuery();
				MessageBox.Show("Record has been removed","Removed", MessageBoxButton.OK, MessageBoxImage.Information);
				Globals.con.Close();
				AddBooks addBooks = new AddBooks();
				addBooks.clearData();
				LoadGrid();
				Globals.con.Close();

			}
			catch (SqlException ex)
			{
				MessageBox.Show("Not removed" + ex.Message);
			}
			finally
			{
				Globals.con.Close();
			}
		}

	}
}

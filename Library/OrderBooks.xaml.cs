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
			AddBooks ab = new AddBooks();
			Globals.con.Open();
			SqlCommand cmd = new SqlCommand("update Books set Name= '"+ ab.name_txt.Text + "'," +
				"Genre= '"+ ab.genre_txt.Text + "',Cover= '"+ ab.cover_txt.Text + "'" +
				",Language= '"+ ab.language_txt.Text + "',Type= '"+ ab.type_txt.Text + "'", Globals.con);
			try
			{
				cmd.ExecuteNonQuery();
				MessageBox.Show("Record has been Edited successfully", "Edited", MessageBoxButton.OK, MessageBoxImage.Information);
				Globals.con.Close();
				AddBooks addBooks = new AddBooks();
				addBooks.clearData();
				LoadGrid();
				Globals.con.Close();

			}
			catch (SqlException ex)
			{
				MessageBox.Show("Not edited" + ex.Message);
			}
			finally
			{
				Globals.con.Close();
				ab.clearData();
				LoadGrid();
			}

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

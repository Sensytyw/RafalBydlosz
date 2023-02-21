using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using static Library.OrderBooks;

namespace Library
{

	public partial class AddBooks : Window
	{
		public bool IsOkPressed { get; set; }
		public AddBooks()
		{
			InitializeComponent();
		}

		public bool isValid()
		{
			if (name_txt.Text == string.Empty)
			{
				MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}

			if (genre_txt.Text == string.Empty)
			{
				MessageBox.Show("Genre is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}

			if (cover_txt.Text == string.Empty)
			{
				MessageBox.Show("Cover is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}

			if (language_txt.Text == string.Empty)
			{
				MessageBox.Show("Language is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}

			if (type_txt.Text == string.Empty)
			{
				MessageBox.Show("Type is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}

			return true;
		}

		public void clearData()
		{
			name_txt.Clear();
			genre_txt.Clear();
			cover_txt.Clear();
			language_txt.Clear();
			type_txt.Clear();
			id_row.Clear();
		}

		public void Button_Add(object sender, RoutedEventArgs e)
		{
			try
			{
				if (isValid())
				{
					SqlCommand cmd = new SqlCommand("INSERT INTO Books VALUES (@Name, @Genre, @Cover, @Language, @Type)", OrderBooks.Globals.con);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@Name", name_txt.Text);
					cmd.Parameters.AddWithValue("@Genre", genre_txt.Text);
					cmd.Parameters.AddWithValue("@Cover", cover_txt.Text);
					cmd.Parameters.AddWithValue("@Language", language_txt.Text);
					cmd.Parameters.AddWithValue("@Type", type_txt.Text);
					OrderBooks.Globals.con.Open();
					cmd.ExecuteNonQuery();
					OrderBooks.Globals.con.Close();
					OrderBooks orderBooks = new OrderBooks();
					orderBooks.LoadGrid();
					MessageBox.Show("Succesfully registered", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
					clearData();
					orderBooks.dataGridBooks.Items.Refresh();
				}
			}
			catch(SqlException ex)
			{
				MessageBox.Show(ex.Message);
			}

			OrderBooks oB = new OrderBooks();
			oB.Show();
			IsOkPressed = true;
			this.Close();
		}

		public void Button_Cancel_Add(object sender, RoutedEventArgs e)
		{
			OrderBooks oB = new OrderBooks();
			oB.Show();
			IsOkPressed = false;
			this.Close();
		}

		public void Button_Cancel_Edit(object sender, RoutedEventArgs e)
		{
			OrderBooks oB = new OrderBooks();
			oB.Show();
			IsOkPressed = false;
			this.Close();
		}

		private void Button_Clear(object sender, RoutedEventArgs e)
		{
			clearData();
		}

		public void Button_Eddit(object sender, RoutedEventArgs e)
		{
			OrderBooks.Globals.con.Open();
			SqlCommand cmd = new SqlCommand("UPDATE Books SET Name = '" + name_txt.Text + "'," +
				"Genre= '" + genre_txt.Text + "',Cover= '" + cover_txt.Text + "'" +
				",Language= '" + language_txt.Text + "',Type= '" + type_txt.Text + "' WHERE BookId ='" + id_row.Text + "'", OrderBooks.Globals.con);
			try
			{
				cmd.ExecuteNonQuery();
				MessageBox.Show("Record has been Edited successfully", "Edited", MessageBoxButton.OK, MessageBoxImage.Information);
				OrderBooks.Globals.con.Close();
				OrderBooks oB = new OrderBooks();
				clearData();
				oB.LoadGrid();
				OrderBooks.Globals.con.Close();

			}

			catch (SqlException ex)
			{
				MessageBox.Show("Not edited" + ex.Message);
			}

			finally
			{
				OrderBooks oB = new OrderBooks();
				OrderBooks.Globals.con.Close();
				clearData();
				oB.LoadGrid();	
				oB.Show();
				Close();
			}
		}

		private void Button_Remove(object sender, RoutedEventArgs e)
		{
			Globals.con.Open();
			SqlCommand cmd = new SqlCommand("delete from Books where BookId =" + id_row.Text + " ", Globals.con);
			try
			{
				cmd.ExecuteNonQuery();
				MessageBox.Show("Record has been removed", "Removed", MessageBoxButton.OK, MessageBoxImage.Information);
				Globals.con.Close();
				OrderBooks oB4 = new OrderBooks();
				clearData();
				oB4.LoadGrid();
				Globals.con.Close();

			}

			catch (SqlException ex)
			{
				MessageBox.Show("Not removed " + ex.Message);
			}

			finally
			{
				Globals.con.Close();
			}
		}
	}
}

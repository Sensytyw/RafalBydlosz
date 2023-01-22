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


namespace Library
{
	/// <summary>
	/// Interaction logic for AddBooks.xaml
	/// </summary>
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

			if (date_txt.Text == string.Empty)
			{
				MessageBox.Show("Date is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
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
			date_txt.Clear();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (isValid())
				{
					SqlCommand cmd = new SqlCommand("INSERT INTO Books VALUES (@Name, @Genre, @Cover, @Language, @Type, @Date)", OrderBooks.Globals.con);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@Name", name_txt.Text);
					cmd.Parameters.AddWithValue("@Genre", genre_txt.Text);
					cmd.Parameters.AddWithValue("@Cover", cover_txt.Text);
					cmd.Parameters.AddWithValue("@Language", language_txt.Text);
					cmd.Parameters.AddWithValue("@Type", type_txt.Text);
					cmd.Parameters.AddWithValue("@Date", date_txt.Text);
					OrderBooks.Globals.con.Open();
					cmd.ExecuteNonQuery();
					OrderBooks.Globals.con.Close();
					OrderBooks orderBooks = new OrderBooks();
					orderBooks.LoadGrid();
					MessageBox.Show("Succesfully registered", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
					clearData();
				}
			}
			catch(SqlException ex)
			{
				MessageBox.Show(ex.Message);
			}

			IsOkPressed = true;
			this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			IsOkPressed = false;
			this.Close();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			clearData();
		}
	}
}

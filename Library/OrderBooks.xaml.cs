using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System;
using System.Globalization;
using System.Windows.Media;
using System.Windows.Controls;

namespace Library
{
	/// <summary>
	/// Interaction logic for OrderBooks.xaml
	/// </summary>
	public partial class OrderBooks : Window, INotifyPropertyChanged
	{
		#region OrderBooks
		public OrderBooks()
		{
			InitializeComponent();
			LoadGrid();
		}
		#endregion

		#region Property Changed Block
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion

		#region Global connection
		public static class Globals
			{
				public static SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=LibraryProject;Integrated Security=True");
			}
		#endregion

		#region LoadGrid
		public void LoadGrid()
		{
			SqlCommand cmd = new SqlCommand("select * from Books", Globals.con);
			Globals.con.Open();
			SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable("Books");
			dataAdapter.Fill(dt);
			SqlDataReader sdr = cmd.ExecuteReader();
			//dt.Load(sdr);
			Globals.con.Close();
			dataGridBooks.ItemsSource = dt.DefaultView;
		}
		#endregion

		#region Buttons
		private void ButtonAdd(object sender, RoutedEventArgs e)
		{
			AddBooks abWindow = new AddBooks();
			abWindow.Button_Ad.Visibility = Visibility.Visible;
			abWindow.CancelAdd.Visibility = Visibility.Visible;
			Books book = new Books();
			abWindow.DataContext = book;
			abWindow.Show();
			Close();
		}

		#endregion

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public void dataGridBooks_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			AddBooks aB = new AddBooks();
			DataGrid dg = sender as DataGrid;
			DataRowView dr = dg.SelectedItem as DataRowView;
			if (dr != null)
			{
				aB.id_row.Text = dr["BookId"].ToString();
				aB.CancelEdit.Visibility = Visibility.Visible;
				aB.Button_Ed.Visibility = Visibility.Visible;
				aB.name_txt.Text = dr["Name"].ToString();
				aB.genre_txt.Text = dr["Genre"].ToString();
				aB.cover_txt.Text = dr["Cover"].ToString();
				aB.language_txt.Text = dr["Language"].ToString();
				aB.type_txt.Text = dr["Type"].ToString();
				aB.Show();
				aB.Button_Ad.Visibility = Visibility.Visible;
				aB.CancelAdd.Visibility = Visibility.Visible;
				Close();
			}
		}
	}
}

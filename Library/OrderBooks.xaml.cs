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

namespace Library
{
	/// <summary>
	/// Interaction logic for OrderBooks.xaml
	/// </summary>
	public partial class OrderBooks : Window, INotifyPropertyChanged
	{
		//public Themes Background { get; private set; }
		
		//public void SetBackground(Brush brushColor)
		//{
		//	Themes background = new Themes();
		//	background.Color=brushColor;
		//}

		#region OrderBooks
		//Themes _background = new Themes();
		public OrderBooks()
		{
			InitializeComponent();
			LoadGrid();
			//DataContext= _background;
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
			DataTable dt = new DataTable();
			Globals.con.Open();
			SqlDataReader sdr = cmd.ExecuteReader();
			dt.Load(sdr);
			Globals.con.Close();
			dataGridBooks.ItemsSource = dt.DefaultView;
		}
		#endregion

		#region Buttons
		private void ButtonAdd(object sender, RoutedEventArgs e)
		{
			AddBooks okno = new AddBooks();
			okno.Button_Ad.Visibility = Visibility.Visible;
			Books ksiazka = new Books();
			okno.DataContext = ksiazka;
			okno.ShowDialog();
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
			SqlCommand cmd = new SqlCommand("delete from Books where BookId =" + id_row.Text + " ", Globals.con);
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
		#endregion Add

		private void ThemeClick_Dark(object sender, RoutedEventArgs e)
		{
			//SetBackground(Brushes.Black);
		}
		private void ThemeClick_Light(object sender, RoutedEventArgs e)
		{
			//SetBackground(Brushes.White);
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

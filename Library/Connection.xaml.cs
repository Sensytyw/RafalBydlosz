using System;
using System.Data.SqlClient;
using System.Windows;

namespace Library
{
	/// <summary>
	/// Logika interakcji dla klasy Connection.xaml
	/// </summary>
	public partial class Connection : Window
	{
		public Connection()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string connetionString;
			SqlConnection cnn;
			connetionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=LibraryProject;Integrated Security=True";
			cnn = new SqlConnection(connetionString);
			cnn.Open();
			MessageBox.Show("Connection Open  !");

			SqlCommand command;
			SqlDataAdapter adapter = new SqlDataAdapter();
			SqlDataReader dataReader;
			String sql,sql2, Output = "";

			sql2 = "Insert into Books (BookId,Name) values(1, ' " + "Witcher" + "')";
			sql = "Select BookId, Name from Books";
			command = new SqlCommand(sql, cnn);

			adapter.InsertCommand = new SqlCommand(sql2, cnn);
			adapter.InsertCommand.ExecuteNonQuery();

			dataReader = command.ExecuteReader();

			while (dataReader.Read())
			{
				Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
			}

			MessageBox.Show(Output);

			dataReader.Close();
			command.Dispose();
			cnn.Close();
		}
	}
}

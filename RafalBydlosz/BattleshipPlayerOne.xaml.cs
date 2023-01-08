using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;


namespace RafalBydlosz
{
	public partial class BattleshipPlayerOne : Window
	{
		static int[] tab = new int[100];
		static int[] tab2 = new int[100];
		BattleshipLogic game = new BattleshipLogic(tab, tab2);
		BattleshipPlayerTwo window = new BattleshipPlayerTwo();
		public BattleshipPlayerOne()
		{
			InitializeComponent();
			CrBtn();
			P1.DataContext = game;
			window.DataContext = game;
			window.Show();
			counter.Content = 15;
		}

		int setCounter = 0;
		int shootsHit = 0;
		void setButton_Click(object sender, RoutedEventArgs e)
		{
			Button btn = (Button)sender;

			if (((BattleshipLogic)P1.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 0)
			{
				if (setCounter == 15) return;
				((BattleshipLogic)P1.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())]++;
				setCounter++;
				counter.Content = 15 - setCounter;
			}
			else if (((BattleshipLogic)P1.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 1)
			{
				((BattleshipLogic)P1.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())]--;
				setCounter--;
				counter.Content = 15 - setCounter;
			}
		}

		void shootButton_Click(object sender, RoutedEventArgs e)
		{
			Button btn = (Button)sender;
			if (((BattleshipLogic)P1.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 0)
			{
				((BattleshipLogic)P1.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] += 2;

			}
			if (((BattleshipLogic)P1.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 1)
			{
				((BattleshipLogic)P1.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] += 2;
				shootsHit++;
				if (game.CheckWin(shootsHit))
				{
					MessageBox.Show("Player One wins!");
				};
			}
		}
		private void CrBtn()
		{
			int x = 0;
			int y = 0;
			for (int k = 0; k < 2; k++)
			{
				switch (k)
				{
					//shooting
					case 0:
						for (int i = 1; i < 11; i++)
						{
							for (int j = 1; j < 11; j++)
							{
								Button button = new Button();
								button.Tag = $"{x}";
								Grid.SetColumn(button, i);
								Grid.SetRow(button, j);
								shoot.Children.Add(button);
								button.Click += new RoutedEventHandler(shootButton_Click);
								YesNoToBooleanConverter2 yesNoToBooleanConverter2 = new YesNoToBooleanConverter2();
								Binding bind = new Binding
								{
									Path = new PropertyPath(Convert.ToString($"PersonIdTwo[{x}]")),
									Mode = BindingMode.TwoWay,
									Converter = yesNoToBooleanConverter2,
									UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
								};
								button.SetBinding(Button.BackgroundProperty, bind);
								x++;

							}
						}
						break;
					//placing
					case 1:
						for (int i = 1; i < 11; i++)
						{
							for (int j = 1; j < 11; j++)
							{
								Button button = new Button();
								button.Tag = $"{y}";
								Grid.SetColumn(button, i);
								Grid.SetRow(button, j);
								set.Children.Add(button);
								button.Click += new RoutedEventHandler(setButton_Click);
								YesNoToBooleanConverter yesNoToBooleanConverter = new YesNoToBooleanConverter();
								Binding bind = new Binding
								{
									Path = new PropertyPath(Convert.ToString($"PersonIdOne[{y}]")),
									Mode = BindingMode.TwoWay,
									Converter = yesNoToBooleanConverter,
									UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
								};
								button.SetBinding(Button.BackgroundProperty, bind);
								y++;

							}
						}
						break;
				}
			}


		}
		public class YesNoToBooleanConverter : IValueConverter
		{
			public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
			{
				switch (value)
				{
					case 3:
						return new SolidColorBrush(Colors.Red);
					case 2:
						return new SolidColorBrush(Colors.Yellow);
					case 1:
						return new SolidColorBrush(Colors.Gray);
					case 0:
						return new SolidColorBrush(Colors.Transparent);
				}
				return false;
			}

			public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
			{
				// if (value is Colors)
				{
					//if ((Colors)value == Colors.Red)
					//    return 4;
					//else
					//    return 0;
				}
				return 0;
			}
		}
		public class YesNoToBooleanConverter2 : IValueConverter
		{
			public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
			{
				switch (value)
				{
					case 3:
						return new SolidColorBrush(Colors.Red);
					case 2:
						return new SolidColorBrush(Colors.Yellow);
					case 1:
						return new SolidColorBrush(Colors.Transparent);
					case 0:
						return new SolidColorBrush(Colors.Transparent);
				}
				return false;
			}
			public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
			{
				// if (value is Colors)
				{
					//if ((Colors)value == Colors.Red)
					//    return 4;
					//else
					//    return 0;
				}
				return 0;
			}
		}
		private void restart_Click(object sender, RoutedEventArgs e)
		{
			InitializeComponent();
			int[] tab1 = new int[100];
			int[] tab3 = new int[100];
			BattleshipLogic gra = new BattleshipLogic(tab1, tab3);
			P1.DataContext = gra;
			window.DataContext = gra;
			counter.Content = 15;
			setCounter = 0;
			shootsHit = 0;
			window.setCounter = 0;
			window.shootsHit = 0;
			window.counter.Content = 15;
		}

	}
}

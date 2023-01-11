using System;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static RafalBydlosz.BattleshipPlayerOne;

namespace RafalBydlosz
{
	public partial class BattleshipPlayerTwo : Window
	{
		public BattleshipPlayerTwo()
		{
			InitializeComponent();
			CrBtn();
			counter2.Content = 15;
			setCounter = 0;
			shootsHit = 0;
		}

		static int[] tab = new int[100];
		static int[] tab2 = new int[100];
		BattleshipLogic game = new BattleshipLogic(tab, tab2);
		public int setCounter = 0;
		public int shootsHit = 0;

		void setButton_Click(object sender, RoutedEventArgs e)
		{
			Button btn = (Button)sender;
			if (((BattleshipLogic)P1.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 0)
			{
				if (setCounter == 15) return;
				((BattleshipLogic)P1.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())]++;
				setCounter++;
				counter2.Content = 15 - setCounter;
			}

			else if (((BattleshipLogic)P1.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 1)
			{
				((BattleshipLogic)P1.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())]--;
				setCounter--;
				counter2.Content = 15 - setCounter;
			}
		}

		void shootButton_Click(object sender, RoutedEventArgs e)
		{
			Button btn = (Button)sender;
			if (((BattleshipLogic)P1.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 0)
			{
				((BattleshipLogic)P1.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] += 2;

			}

			if (((BattleshipLogic)P1.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 1)
			{
				((BattleshipLogic)P1.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] += 2;
				shootsHit++;

				if (game.CheckWin(shootsHit))
				{
					MessageBox.Show("Player Two wins!!!");
				};
			}
		}

		public void CrBtn()
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
									Path = new PropertyPath(Convert.ToString($"PersonIdOne[{x}]")),
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
									Path = new PropertyPath(Convert.ToString($"PersonIdTwo[{y}]")),
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
	}
}

//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Media;
//using System.Runtime.CompilerServices;

//namespace Library
//{
//	public class Themes : INotifyPropertyChanged
//	{
//		public event PropertyChangedEventHandler PropertyChanged;
//		protected void OnPropertyChanged(string name)
//		{
//			if (PropertyChanged != null)
//			{
//				PropertyChanged(this, new PropertyChangedEventArgs(name));
//			}
//		}
//		private Brush _color;

//		public Brush Color
//		{
//			get
//			{
//				if (_color == null)

//					return Brushes.White;

//				return _color;

//			}

//			set
//			{
//				_color = value;
//				OnPropertyChanged("Color");
//			}
//		}
//	}
//}

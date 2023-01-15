using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RafalBydlosz
{
	public class People
	{
		public string name { get; set; }
		public string surName { get; set; }
		public string pesel { get; set; }

		public People()
		{

		}
		public People(string name, string surName, string pesel)
		{
			this.name = name;
			this.surName = surName;
			this.pesel = pesel;
		}

		public People(People osoba)
		{
			this.name = osoba.name;
			this.surName = osoba.surName;
			this.pesel = osoba.pesel;
		}

	}

}

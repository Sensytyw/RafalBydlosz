using System.Xml.Serialization;

namespace RafalBydlosz
{
	[XmlRoot(ElementName = "People")]
	public class People
	{
		[XmlAttribute("Name")]
		public string name { get; set; }
		[XmlAttribute("SurName")]
		public string surName { get; set; }
		[XmlAttribute("Pesel")]
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

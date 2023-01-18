using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Library
{
	[XmlRoot(ElementName = "Books")]

	public class Books
	{
			[XmlAttribute("Id")]
			public string id { get; set; }
			[XmlAttribute("Name")]
			public string name { get; set; }
			[XmlAttribute("Number")]
			public string number { get; set; }
			[XmlAttribute("Genre")]
			public string genre { get; set; }

		public Books()
			{

			}
			public Books(string id, string name, string number, string genre)
			{
				this.id = id;
				this.name = name;
				this.number = number;
				this.genre = genre;
			}

			public Books(Books book)
			{
				this.id = book.id;
				this.name = book.name;
				this.number = book.number;
			}

		

	}
}


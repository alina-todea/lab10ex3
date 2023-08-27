using System;
using System.Net;
using System.Xml.Linq;

namespace Lab10ex3.Models
{
	public class Tag
	{
        /*
		 * • Id(unic)
• Cod de bare (sub forma unui Guid)
• Pret : double
• NavigationProperty / FK- ce lipseste?
		 * */

        public int Id { get; set; }
        public Guid Barcode { get; set; }
       // public double Price { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public Tag()
		{
            this.Barcode = Guid.NewGuid();
        }
        public override string ToString()
       => $"{Id}|{Product.Price}|{Barcode}";
    }
}


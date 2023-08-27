using System;
namespace Lab10ex3.Models
{
	public class Product
	{
        /*
		 * • Id (unic)
• Nume : string • Stoc: int
• Producator
• Eticheta
• NavigationProperty- ce lipseste?
		 * */

        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }


        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

        public Tag Tag { get; set; }



        public override string ToString()
      => $"{Id}|{Name}|{Price}|{Stock}";
    }
}


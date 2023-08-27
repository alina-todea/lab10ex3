using System;
using System.Runtime.ConstrainedExecution;

namespace Lab10ex3.Models
{
	public class Producer
	{
        /*
		 * • Id(unic)
• Nume
• Adresa : string • CUI : string
		 * */

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Cui { get; set; }

        public List<Product> Products { get; set; }

        /*public Producer()
		{
		}*/

        
    }
}


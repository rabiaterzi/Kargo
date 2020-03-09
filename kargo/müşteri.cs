using System;
using System.Collections.Generic;
using System.Text;

namespace kargo
{
	class müşteri 
	{
		public string AdSoyad { get; set; }
        public string Adres { get; set; }
		public ulong iletisimNo { get; set; }
		private ulong TCno;
		public ulong tcno
		{
			get 
            { 
	            return TCno; 
            }
			set 
            { 
	            if(value.ToString().Length==11)
				{
					TCno = value;
				}
				else
				{
					do
					{
						Console.WriteLine("TC no 11 haneli olmalıdır !!!");
						Console.Write("TC numarası:");
						ulong tcno = Convert.ToUInt64(Console.ReadLine());
						if(tcno.ToString().Length==11)
						{							
							break;
						}
					} while (tcno.ToString().Length!=11);
					
				}
		    }
		}
	}
}

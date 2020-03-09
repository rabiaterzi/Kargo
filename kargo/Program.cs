using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace kargo
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("-------MENÜ-------\n\n" +
				              "1-Firma siparişi \n" +
	                          "2-Özel kargo gönderimi ");
			
            int secim=Convert.ToInt32(Console.ReadLine());
			int secim2;
			ArrayList array = new ArrayList();
			ArrayList array2 = new ArrayList();
			Queue<string> gönderen = new Queue<string>();			
			Queue<string> gönderen2 = new Queue<string>();			
			if (secim==1)
			{
				do
				{
					Console.Clear();
					Console.Write("Firma adı:");
					string firmaad = Convert.ToString(Console.ReadLine());
					kargoşirketi ks = new kargoşirketi();
					ks.FirmaAdı = firmaad;
                    array.Add(firmaad);

					Console.Write("Sipariş Adı:");
					string siparisadı = Convert.ToString(Console.ReadLine());
					ks.SiparisAdı = siparisadı;

					Console.Write("Sipariş numarası:");
					long siparisno = Convert.ToUInt32(Console.ReadLine());
					ks.SiparisNo = siparisno;
					gönderen.Enqueue(Convert.ToString( siparisno));
					
					Console.WriteLine("\nYeni ürün eklemek için 1'e, ilerlemek için herhangi bir sayıya basın.");
					int ürün2 = Convert.ToInt32(Console.ReadLine());
					int ürün4;
					if (ürün2 == 1)
					{
						do
						{
							array2.Add(firmaad);
							Console.Write("Sipariş adı:");
							string ürün3 = Convert.ToString(Console.ReadLine());
							ks.SiparisAdı = ürün3;
							
							Console.Write("Sipariş numarası:");
							long ürün5 = Convert.ToUInt32(Console.ReadLine());
							ks.SiparisNo = ürün5;
							gönderen2.Enqueue(Convert.ToString(ürün5));
							Console.WriteLine("\nYeni ürün eklemek için 1'e, ilerlemek için herhangi bir sayıya basın.");
							ürün4 = Convert.ToInt32(Console.ReadLine());
						} while (ürün4 == 1);
					}
					Console.Clear();
					Console.WriteLine("\t---ALICI BİLGİLERİ---\n");					
					müşteri müsteri = new müşteri();
                    Console.Write("Ad , Soy ad:");
					string adsoyad = Convert.ToString(Console.ReadLine());
					müsteri.AdSoyad = adsoyad;
					gönderen.Enqueue(adsoyad);

					Console.Write("TC numarası:");
					ulong tcno = Convert.ToUInt64(Console.ReadLine());
					müsteri.tcno = tcno;

					Console.Write("İletişim numarası:");
					ulong iletisimno = Convert.ToUInt64(Console.ReadLine());
					müsteri.iletisimNo = iletisimno; 
	                
	                Console.Write("Adres:");
					string adres = Convert.ToString(Console.ReadLine());
					müsteri.Adres = adres;
					gönderen.Enqueue(adres); 

					Console.WriteLine("\nYeni kargo eklemek için 1'e ilerlemek için herhangi bir sayıya basın");
					secim2 = Convert.ToInt32(Console.ReadLine());
				} while (secim2 == 1);
				Console.Clear();
			
				for (int i = 0; i < array.Count; i++)
				{
					Thread.Sleep(2000);
                    Console.WriteLine(gönderen.Dequeue() + " sipariş numaralı kargo , bölge şubesine ulaşmıştır.");
					for (int a = 0; a < array2.Count; a++)
					{                           
						if (array2[a] == array[i])
						{
								Console.WriteLine(gönderen2.Dequeue() + " sipariş numaralı kargo , bölge şubesine ulaşmıştır.");
						}														
					}	                
			        Thread.Sleep(3000);
				    Console.WriteLine(gönderen.Dequeue() + " isimli alıcıya kargo takip numarası atılmıştır.");
				    Thread.Sleep(3000);
			        Console.WriteLine("Kargo dağıtıma çıkmıştır.");
				    Thread.Sleep(3000);
		            Console.WriteLine("Kargo " + gönderen.Dequeue() + " adresine teslim edilmiştir.");
				    Thread.Sleep(3000);
					Console.Clear(); 
	            }				    
	        }
						
			else if(secim==2)
			{
				Console.Clear();				
				do
				{
					Console.Clear();
	                Console.WriteLine("\t---GÖNDERİCİ BİLGİLERİNİ GİRİNİZ--- \n");
					Console.Write("Ad - Soy Ad:");
					string adsoya = Convert.ToString(Console.ReadLine());
					gönderici ks = new gönderici();
					ks.AdSoyad = adsoya;
					array.Add(adsoya);

					Console.Write("TC numarası:");
					ulong tcnom = Convert.ToUInt64(Console.ReadLine());
					ks.tcno = tcnom;

					Console.Write("İletişim numarası:");
					ulong iletisim = Convert.ToUInt64(Console.ReadLine());
					ks.iletisimNo = iletisim;

					Console.Write("Ürün adı:");
					string urun = Convert.ToString(Console.ReadLine());
					ks.urunadı = urun;
	                gönderen.Enqueue(urun);
					Console.WriteLine("\nYeni ürün eklemek için 1'e, ilerlemek için herhangi bir sayıya basın.");
					int ürün2 = Convert.ToInt32(Console.ReadLine());	 
					int ürün4;
					if(ürün2==1)
					{
	                  do
	   				  {
						array2.Add(adsoya);           
						Console.Write("Ürün adı:");
						string ürün3 = Convert.ToString(Console.ReadLine());
						ks.urunadı = ürün3;
						gönderen2.Enqueue(ürün3);
						Console.WriteLine("\nYeni ürün eklemek için 1'e, ilerlemek için herhangi bir sayıya basın.");
					    ürün4 = Convert.ToInt32(Console.ReadLine());
					  }while (ürün4 == 1);
					}
					
					Console.Clear();				
					Console.WriteLine("\t---ALICI BİLGİLERİ---\n");
					müşteri müsteri = new müşteri();
					Console.Write("Ad , Soy ad:");
					string adsoyad = Convert.ToString(Console.ReadLine());
					müsteri.AdSoyad = adsoyad;
					gönderen.Enqueue(adsoyad);

					Console.Write("İletişim numarası:");
					ulong iletisimno = Convert.ToUInt64(Console.ReadLine());
					müsteri.iletisimNo = iletisimno;

					Console.Write("Adres:");
					string adres = Convert.ToString(Console.ReadLine());
					müsteri.Adres = adres;
					gönderen.Enqueue(adres);

					Console.WriteLine("\nYeni kargo eklemek için 1'e ilerlemek için herhangi bir sayıya basın");
					secim2 = Convert.ToInt32(Console.ReadLine());
					
				} while (secim2 == 1);
				Console.Clear();
				
				for (int i=0;i<array.Count;i++)
				{
					Thread.Sleep(2000);
					Console.WriteLine(gönderen.Dequeue() + " isimli kargonuz dağıtıma çıkmıştır.");
					for (int a=0;a<array2.Count;a++)
					{                      
						if(array2[a]==array[i])
						{                                
						    Console.WriteLine(gönderen2.Dequeue() + " isimli kargonuz dağıtıma çıkmıştır.");
						}                            							        
					} 	                
	                Thread.Sleep(3000);
				    Console.WriteLine(gönderen.Dequeue() + " isimli alıcıya kargo takip numarası atılmıştır.");
				    Thread.Sleep(3000);
					Console.WriteLine("Kargo "+gönderen.Dequeue()+" adresine teslim edilmiştir.");
					Thread.Sleep(3000);
					Console.Clear();                       
				}	                					        	                			
			}
		}
	}
}

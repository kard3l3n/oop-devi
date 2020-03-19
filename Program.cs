/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ
** NESNEYE DAYALI PROGRAMLAMA DERSİ
** 2019-2020 BAHAR DÖNEMİ
**
** ÖDEV NUMARASI..........:1
** ÖĞRENCİ ADI............:Kardelen 
** ÖĞRENCİ SOYADI.........:Özdemir
** ÖĞRENCİ NUMARASI.......:B191200403
** DERSİN ALINDIĞI GRUP...:A
****************************************************************************/

using System;
using System.Collections.Generic;

namespace KutuphaneYonetimi
{
	//Kitap bilgileri için sınıf tanımlıyoruz
	class Kitap
	{
		public int kitap_Id;
		public string kitap_Adı;
		public int kitap_Fiyatı;
		public int Kitap_Adeti;
		public int x;
	}
	//Ödünç alma işlemleri için sınıfı tanımlıyoruz
	class Odunc_Alma_Islemleri
	{
		public int kullanıcı_Id;
		public string kullanıcı_Adı;
		public string kullanıcı_Adresi;
		public int oduncKitap_Id;
		public DateTime odunc_Alma_Tarihi;
		public int odunc_Alınan_Adet;
	}

	class Program
	{
		static List<Kitap> kitapList = new List<Kitap>();
		static List<Odunc_Alma_Islemleri> oduncList = new List<Odunc_Alma_Islemleri>();
		static Kitap kitap = new Kitap();
		static Odunc_Alma_Islemleri Odunc = new Odunc_Alma_Islemleri();

		//Şifre doğrulama ve Menü
		static void Main(string[] args)
		{
			Console.WriteLine("-------------Kütüphane Yönetim Sistemi--------------");
			Console.Write("Hoşgeldin !!!\nLütfen şifrenizi giriniz :");
			string sifre = Console.ReadLine();

			//sifre=kardelen girildi mi diye kontrol ediyor.Eğer şifre doğru değilse menu kısmına giremeyecek
			if (sifre == "kardelen")
			{
				bool menu = true;
				while (menu)
				{
					Console.WriteLine("\nMenu\n" +
					"1)Kitap ekle\n" +
					"2)Kitap sil\n" +
					"3)Kitap ara\n" +
					"4)Ödünç kitap al\n" +
					"5)Kitabı iade et\n" +
					"6)Sistemden Çıkış\n\n");
					Console.Write("Menüden seçiminizi yapınız: ");

					int seçenek = int.Parse(Console.ReadLine());

					//1'i seçerse kitap ekleme işlemini yapabilecek
					if (seçenek == 1)
					{
						KitapEkle();
					}

					//2'i seçerse kitap silme işlemini yapabilecek
					else if (seçenek == 2)
					{
						KitapSil();
					}

					//3'ü seçerse kitap ekleme aratma işlemini yapabilecek
					else if (seçenek == 3)
					{
						KitapAra();
					}

					//4'ü seçerse ödünç verme işlemini yapabilecek
					else if (seçenek == 4)
					{
						OduncAlınan();
					}

					//5'i seçerse iade alabilecek
					else if (seçenek == 5)
					{
						İadeEdilen();

					}

					//6'i seçerse sistemden çıkış yapacak
					else if (seçenek == 6)
					{
						Console.WriteLine("Teşekkürler");
						menu = false;
						break;
					}

					//1'den 6'ya kadar olan sayılardan başka bir sayı seçtiğinde bu yazıyla karşılaşacak
					else
					{
						Console.WriteLine("Geçersiz seçenek\nyeniden deneyin !!!");
					}
				}
			}
			else
			{
				Console.WriteLine("Geçersiz Şifre");
			}
			Console.ReadLine();
		}

		//Kitaplık veritabanına kitap ayrıntıları eklemek için
		public static void KitapEkle()
		{
			Kitap kitap = new Kitap();
			Console.WriteLine("Kitap id:{0}", kitap.kitap_Id = kitapList.Count + 1);
			Console.Write("kitabın adı:");
			kitap.kitap_Adı = Console.ReadLine();
			Console.Write("kitabın fiyatı:");
			kitap.kitap_Fiyatı = int.Parse(Console.ReadLine());
			Console.Write("Kitap adeti:");
			kitap.x = kitap.Kitap_Adeti = int.Parse(Console.ReadLine());
			kitapList.Add(kitap);
		}

		//Kitap ayrıntılarını Kütüphane veritabanından silmek için 
		public static void KitapSil()
		{
			Kitap kitap = new Kitap();
			Console.Write("Silinecek kitabın id'sini giriniz : ");

			int Sil = int.Parse(Console.ReadLine());

			//Eğer Listede o Id ye ait kitap mevcutsa silme işlemini yapacak
			if (kitapList.Exists(x => x.kitap_Id == Sil))
			{
				kitapList.RemoveAt(Sil - 1);
				Console.WriteLine("Kitap id = {0} silindi", Sil);
			}
			else
			{
				Console.WriteLine("Geçersiz Kitap id'si");
			}

			kitapList.Add(kitap);
		}

		//Kitap id'sini kullanarak Kitaplık veritabanından kitabın ayrıntılarını arayabilmek için
		public static void KitapAra()
		{
			Kitap kitap = new Kitap();
			Console.Write("Kitap id'sine göre ara :");
			int bul = int.Parse(Console.ReadLine());

			//o Id'ye ait kitap listede varsa o kitabı bulup, kitaba ait bilgileri yazdıracak
			if (kitapList.Exists(x => x.kitap_Id == bul))
			{
				foreach (Kitap aramaId in kitapList)
				{
					if (aramaId.kitap_Id == bul)
					{
						Console.WriteLine("Kitap id :{0}\n" +
						"kitap adı :{1}\n" +
						"kitap fiyatı :{2}\n" +
						"kitap adeti :{3}", aramaId.kitap_Id, aramaId.kitap_Adı, aramaId.kitap_Fiyatı, aramaId.Kitap_Adeti);
					}
				}
			}
			else
			{
				Console.WriteLine("kitap id {0} bulunamadı", bul);
			}
		}

		//Kütüphaneden ödünç kitap almak için
		public static void OduncAlınan()
		{
			Kitap book = new Kitap();
			Odunc_Alma_Islemleri odunc = new Odunc_Alma_Islemleri();
			Console.WriteLine("Kullanıcı id : {0}", (odunc.kullanıcı_Id = oduncList.Count + 1));
			Console.Write("Ad :");

			odunc.kullanıcı_Adı = Console.ReadLine();

			Console.Write("kitap id :");
			odunc.oduncKitap_Id = int.Parse(Console.ReadLine());
			Console.Write("kitap adeti : ");
			odunc.odunc_Alınan_Adet = int.Parse(Console.ReadLine());
			Console.Write("Adres :");
			odunc.kullanıcı_Adresi = Console.ReadLine();
			odunc.odunc_Alma_Tarihi = DateTime.Now;
			Console.WriteLine("Date - {0} and Time - {1}", odunc.odunc_Alma_Tarihi.ToShortDateString(), odunc.odunc_Alma_Tarihi.ToShortTimeString());

			//verilen Id'nin mevcut olup olmadığını kontrol ediyor
			if (kitapList.Exists(x => x.kitap_Id == odunc.oduncKitap_Id))
			{
				foreach (Kitap aramaId in kitapList)
				{
					if (aramaId.Kitap_Adeti >= aramaId.Kitap_Adeti - odunc.odunc_Alınan_Adet && aramaId.Kitap_Adeti - odunc.odunc_Alınan_Adet >= 0)
					{
						//ödünç alınan kitabı toplam adetten çıkartıp bunu sisteme işleme işlemini yapıyor
						if (aramaId.kitap_Id == odunc.oduncKitap_Id)
						{
							aramaId.Kitap_Adeti = aramaId.Kitap_Adeti - odunc.odunc_Alınan_Adet;
							break;
						}
					}
					else
					{
						Console.WriteLine("yalnızca {0} adet kitap bulundu", aramaId.Kitap_Adeti);
						break;
					}
				}
			}
			else
			{
				Console.WriteLine("kitap id= {0} bulunamadı", odunc.oduncKitap_Id);
			}
			oduncList.Add(odunc);
		}

		//Ödünç alınan kitabı kütüphaneye iade etme işlemleri için
		public static void İadeEdilen()
		{
			Kitap kitap = new Kitap();
			Console.WriteLine("Diğer detayları giriniz :");

			Console.Write("kitap id : ");
			int iadeId = int.Parse(Console.ReadLine());

			Console.Write("Kitap adeti:");
			int iadeAdet = int.Parse(Console.ReadLine());

			//kitabın Id'sinin sistemde mevcut olup olmadığı kontrol ediliyor.
			if (kitapList.Exists(y => y.kitap_Id == iadeId))
			{
				foreach (Kitap İadeEdilenKitabıEkle in kitapList)
				{
					if (İadeEdilenKitabıEkle.x >= iadeAdet + İadeEdilenKitabıEkle.Kitap_Adeti)
					{
						// iade edilen kitap sisteme geri işleniyor
						if (İadeEdilenKitabıEkle.kitap_Id == iadeId)
						{
							İadeEdilenKitabıEkle.Kitap_Adeti = İadeEdilenKitabıEkle.Kitap_Adeti + iadeAdet;
							Console.WriteLine("iade işlemi başarıyla tamamlandı...");
							break;
						}
					}
					else
					{
						Console.WriteLine("İade işlemi gerçekleştirilemedi...");
						break;
					}
				}
			}
			else
			{
				Console.WriteLine("kitap id {0} bulunamadı", iadeId);
			}
		}
	}
}
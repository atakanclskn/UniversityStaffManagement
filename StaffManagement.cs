using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityStaffManagement
{
    internal class StaffManagement
    {
        public static List<Personel> personeller = new List<Personel>();

        public static void VarsayilanPersonelleriEkle()
        {
            personeller.Add(new Professor { Ad = "Emel", Soyad = "KURUOĞLU KANDEMİR", DersSaati = 10 });
            personeller.Add(new Docent { Ad = "Muhammet", Soyad = "DAMAR", DersSaati = 5 });
            personeller.Add(new Docent { Ad = "Zeynep Nihan", Soyad = "BERBERLER", DersSaati = 6 });
            personeller.Add(new DrOgrUyesi { Ad = "Barış Tekin", Soyad = "TEZEL", DersSaati = 6 });
            personeller.Add(new DrOgrUyesi { Ad = "Erdem", Soyad = "ALKIM", DersSaati = 4 });
            personeller.Add(new DrOgrUyesi { Ad = "Kadriye Filiz", Soyad = "BALBAL", DersSaati = 5 });
            personeller.Add(new ArasGor { Ad = "Onur Mert", Soyad = "ÇELDİR" });
            personeller.Add(new ArasGor { Ad = "Süheyla", Soyad = "UYGUR" });
            personeller.Add(new TeknikPersonel { Ad = "Engin", Soyad = "ERDOĞAN" });
            personeller.Add(new Memur { Ad = "Murat", Soyad = "KORKMAZ" });
            personeller.Add(new Memur { Ad = "Şebnem", Soyad = "KAYA" });

        }

        public static void Menu()
            {
                string[] options = {
            "Personelleri Listele",
            "Yeni Personel Ekle",
            "Personel Sil",
            "Geri Dön"
            };

            int secili = 0;

            while (true)
            {
                Console.Clear();
                string baslik = "===== PERSONEL İŞLEMLERİ =====";
                int ekranGenislik = Console.WindowWidth;
                int baslikKonum = (ekranGenislik - baslik.Length) / 2;

                Console.SetCursorPosition(baslikKonum, Console.CursorTop);
                Console.WriteLine(baslik);
                Console.WriteLine();

                for (int i = 0; i < options.Length; i++)
                {
                    string secenek = options[i];
                    int konum = (ekranGenislik - secenek.Length) / 2;

                    Console.SetCursorPosition(konum, Console.CursorTop);
                    if (i == secili)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(secenek);
                    Console.ResetColor();
                }

                ConsoleKeyInfo tus = Console.ReadKey(true);
                switch (tus.Key)
                {
                    case ConsoleKey.UpArrow:
                        secili = (secili == 0) ? options.Length - 1 : secili - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        secili = (secili + 1) % options.Length;
                        break;
                    case ConsoleKey.Enter:
                        switch (secili)
                        {
                            case 0: Listele(); break;
                            case 1: Ekle(); break;
                            case 2: Sil(); break;
                            case 3: return;
                        }
                        break;
                }
            }
        }

        public static void Listele()
        {
            Console.Clear();
            Console.WriteLine("Personel Listesi\n");

            Console.WriteLine("Akademik Personeller\n");
            Console.WriteLine("{0,-25} {1,-25} {2,-10}", "Ünvan", "Ad Soyad", "Ders Saati");
            Console.WriteLine(new string('-', 65));

            foreach (var p in personeller)
            {
                if (p is Professor)
                    Console.WriteLine("{0,-25} {1,-25} {2,-10}", "Prof. Dr.", p.Ad + " " + p.Soyad, ((Professor)p).DersSaati);
                else if (p is Docent)
                    Console.WriteLine("{0,-25} {1,-25} {2,-10}", "Doç. Dr.", p.Ad + " " + p.Soyad, ((Docent)p).DersSaati);
                else if (p is DrOgrUyesi)
                    Console.WriteLine("{0,-25} {1,-25} {2,-10}", "Dr. Öğr. Üyesi", p.Ad + " " + p.Soyad, ((DrOgrUyesi)p).DersSaati);
                else if (p is ArasGor)
                    Console.WriteLine("{0,-25} {1,-25} {2,-10}", "Araş. Gör.", p.Ad + " " + p.Soyad, "-");
            }

            Console.WriteLine("\nİdari Personeller\n");
            Console.WriteLine("{0,-25} {1,-25}", "Ünvan", "Ad Soyad");
            Console.WriteLine(new string('-', 50));

            foreach (var p in personeller)
            {
                if (p is Memur)
                    Console.WriteLine("{0,-25} {1,-25}", "Memur", p.Ad + " " + p.Soyad);
                else if (p is TeknikPersonel)
                    Console.WriteLine("{0,-25} {1,-25}", "Teknik Personel", p.Ad + " " + p.Soyad);
            }

            Console.WriteLine("\nÖnceki menüye dönmek için ENTER...");
            Console.ReadLine();
        }

        public static void Ekle()
        {
            Console.Clear();
            Console.WriteLine("Yeni personel ekleniyor...");
            Console.WriteLine("Tür: 1-Professor, 2-Docent, 3-DrOgrUyesi, 4-ArasGor, 5-Memur, 6-TeknikPersonel");
            string tur = Console.ReadLine();

            Console.Write("Ad: ");
            string ad = Console.ReadLine();
            Console.Write("Soyad: ");
            string soyad = Console.ReadLine();

            int dersSaati = 0;
            if (tur == "1" || tur == "2" || tur == "3")
            {
                Console.Write("Ders Saati: ");
                int.TryParse(Console.ReadLine(), out dersSaati);
            }

            Personel yeni = null;
            switch (tur)
            {
                case "1": yeni = new Professor { Ad = ad, Soyad = soyad, DersSaati = dersSaati }; break;
                case "2": yeni = new Docent { Ad = ad, Soyad = soyad, DersSaati = dersSaati }; break;
                case "3": yeni = new DrOgrUyesi { Ad = ad, Soyad = soyad, DersSaati = dersSaati }; break;
                case "4": yeni = new ArasGor { Ad = ad, Soyad = soyad }; break;
                case "5": yeni = new Memur { Ad = ad, Soyad = soyad }; break;
                case "6": yeni = new TeknikPersonel { Ad = ad, Soyad = soyad }; break;
            }

            if (yeni != null)
            {
                personeller.Add(yeni);
                Console.WriteLine("Personel eklendi.");
            }
            else
            {
                Console.WriteLine("Geçersiz tür.");
            }
            Console.WriteLine("Önceki menüye dönmek için ENTER...");
            Console.ReadLine();
        }

        public static void Sil()
        {
            Console.Clear();
            Console.WriteLine("--- Personel Sil ---");
            for (int i = 0; i < personeller.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {personeller[i]}");
            }
            Console.Write("Silmek istediğiniz personelin numarası: ");
            if (int.TryParse(Console.ReadLine(), out int secim) && secim > 0 && secim <= personeller.Count)
            {
                Console.WriteLine($"{personeller[secim - 1]} silindi.");
                personeller.RemoveAt(secim - 1);
                
            }
            else
            {
                Console.WriteLine("Geçersiz seçim.");
            }
            Console.WriteLine("Önceki menüye dönmek için ENTER...");
            Console.ReadLine();
        }

    }
}
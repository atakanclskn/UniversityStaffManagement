using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityStaffManagement
{
    public static class SalaryManager
    {
        public static void Menu()
        {
            string[] options = {
                "Maaşları Göster",
                "Zam Yap",
                "Geri Dön"
            };

            int selected = 0;

            while (true)
            {
                Console.Clear();
                string title = "===== MAAŞ İŞLEMLERİ =====";
                int width = Console.WindowWidth;
                int titlePos = (width - title.Length) / 2;

                Console.SetCursorPosition(titlePos, Console.CursorTop);
                Console.WriteLine(title);
                Console.WriteLine();

                for (int i = 0; i < options.Length; i++)
                {
                    string option = options[i];
                    int optionPos = (width - option.Length) / 2;

                    Console.SetCursorPosition(optionPos, Console.CursorTop);
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(option);
                    Console.ResetColor();
                }

                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                    selected = (selected == 0) ? options.Length - 1 : selected - 1;
                else if (key == ConsoleKey.DownArrow)
                    selected = (selected + 1) % options.Length;
                else if (key == ConsoleKey.Enter)
                {
                    switch (selected)
                    {
                        case 0: ShowSalaries(); break;
                        case 1: ApplyRaise(); break;
                        case 2: return;
                    }
                }
            }
        }

        public static void ShowSalaries()
        {
            Console.Clear();
            Console.WriteLine("Akademik Personeller");
            Console.WriteLine("{0,-25} {1,-25} {2,15}", "Unvan", "Ad Soyad", "Maaş (TL)");
            Console.WriteLine(new string('-', 70));

            foreach (var p in StaffManagement.personeller)
            {
                if (p is Professor || p is Docent || p is DrOgrUyesi || p is ArasGor)
                {
                    string unvan = p is Professor ? "Prof. Dr."
                                : p is Docent ? "Doç. Dr."
                                : p is DrOgrUyesi ? "Dr. Öğr. Üyesi"
                                : "Araş. Gör.";
                    string adSoyad = p.Ad + " " + p.Soyad;
                    decimal maas = p.MaasHesapla();
                    Console.WriteLine("{0,-25} {1,-25} {2,15:N0}", unvan, adSoyad, maas);
                }
            }
            Console.WriteLine();
            Console.WriteLine("İdari Personeller");
            Console.WriteLine("{0,-25} {1,-25} {2,15}", "Unvan", "Ad Soyad", "Maaş (TL)");
            Console.WriteLine(new string('-', 70));

            foreach (var p in StaffManagement.personeller)
            {
                if (p is Memur || p is TeknikPersonel)
                {
                    string unvan = p is Memur ? "Memur" : "Teknik Personel";
                    string adSoyad = p.Ad + " " + p.Soyad;
                    decimal maas = p.MaasHesapla();
                    Console.WriteLine("{0,-25} {1,-25} {2,15:N0}", unvan, adSoyad, maas);
                }
            }
            Console.WriteLine("Önceki menüye dönmek için ENTER...");
            Console.ReadLine();
        }

        public static void ApplyRaise()
        {
            foreach (var p in StaffManagement.personeller)
            {
                if (p is IZamYap z)
                {
                    z.ZamYap();
                }
            }
            Console.WriteLine("Zamlar uygulandı.\nDevam etmek için ENTER...");
            Console.ReadLine();
        }
    }
}

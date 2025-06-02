using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityStaffManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StaffManagement.VarsayilanPersonelleriEkle();
            ShowMenu();
        }

        static void ShowMenu()
        {
            string[] options =
            {
                "Personel İşlemleri",
                "Maaş İşlemleri",
                "12 Aylık Simülasyon",
                "Çıkış"
            };

            int selected = 0;

            while (true)
            {
                Console.Clear();
                int width = Console.WindowWidth;
                int left = (width - 40) / 2;

                Console.SetCursorPosition(left, 1);
                Console.WriteLine("╔═══════════════════════════════════════╗");
                Console.SetCursorPosition(left, 2);
                Console.WriteLine("║  ÜNİVERSİTE PERSONEL YÖNETİM SİSTEMİ  ║");
                Console.SetCursorPosition(left, 3);
                Console.WriteLine("╚═══════════════════════════════════════╝");

                for (int i = 0; i < options.Length; i++)
                {
                    Console.SetCursorPosition(left, 5 + i);
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"> {options[i]}".PadRight(40));
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("  " + options[i]);
                    }
                }

                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                    selected = (selected == 0) ? options.Length - 1 : selected - 1;
                else if (key == ConsoleKey.DownArrow)
                    selected = (selected + 1) % options.Length;
                else if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    switch (selected)
                    {
                        case 0: StaffManagement.Menu(); break;
                        case 1: SalaryManager.Menu(); break;
                        case 2: Simulation.Run(); break;
                        case 3: return;
                    }
                }
            }
        }
    }
}

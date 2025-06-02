using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityStaffManagement
{
    public static class Simulation
    {
        private static int yilSayaci = 0;

        public static void Run()
        {
            Console.Clear();
            Console.WriteLine($"=== {yilSayaci}. Yıl: 12 Aylık Personel Gider Simülasyonu ===\n");

            decimal toplamYillikGider = 0;

            for (int ay = 0; ay <= 12; ay++)
            {
                Console.Write(new string(' ', 25));
                Console.WriteLine($"--- {yilSayaci}. Yıl - {ay}. Ay ---");
                Console.WriteLine();
                Console.WriteLine("{0,-25} {1,-25} {2,15}", "Unvan", "Ad Soyad", "Maaş (TL)");
                Console.WriteLine(new string('-', 70));

                if (ay == 6)
                {
                    string[] spinner = { "|", "/", "-", "\\" };
                    Console.Write("Haziran zammı ");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(spinner[i % 4]);
                        System.Threading.Thread.Sleep(150);
                        Console.Write("\b");
                    }
                    Console.WriteLine("uygulandı.");
                    SalaryManager.ApplyRaise();
                    Console.WriteLine();
                }

                decimal aylikToplam = 0;
                foreach (var p in StaffManagement.personeller)
                {
                    string unvan = p is Professor ? "Prof. Dr."
                                : p is Docent ? "Doç. Dr."
                                : p is DrOgrUyesi ? "Dr. Öğr. Üyesi"
                                : p is ArasGor ? "Araş. Gör."
                                : p is Memur ? "Memur"
                                : p is TeknikPersonel ? "Teknik Personel"
                                : "";

                    string adSoyad = p.Ad + " " + p.Soyad;
                    decimal maas = p.MaasHesapla();
                    aylikToplam += maas;
                    Console.WriteLine("{0,-25} {1,-25} {2,15:N0}", unvan, adSoyad, maas);
                }

                toplamYillikGider += aylikToplam;
                Console.WriteLine(); // boşluk bırak
                Console.WriteLine("{0,-25} {1,-25} {2,15:N0}\n", "", "Toplam Gider:", aylikToplam);
            }

            Console.WriteLine($"{yilSayaci}. Yıl Toplam Personel Gideri: {toplamYillikGider:N0} TL");
            Console.WriteLine("\nAna menüye dönmek için ENTER'a basın...");
            Console.ReadLine();
            yilSayaci++;
        }
    }
}

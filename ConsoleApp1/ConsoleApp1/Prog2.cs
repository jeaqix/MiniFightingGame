using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame
{
    class Prog2
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Karakter Deniz = new Karakter("Deniz", "K234", 100);
            Dusman Goblin = new Dusman("Goblin", "K231", 100);

            bool oyunDevam = true;

            while (oyunDevam)
            {
                Console.WriteLine("=== OYUN MENÜSÜ ===");
                Console.WriteLine("1 - Saldır");
                Console.WriteLine("2 - İyileş");
                Console.WriteLine("3 - Çıkış");
                Console.Write("Seçiminiz: ");
                Console.WriteLine($"Durum: {Deniz.CharName} HP: {Deniz.CharHp}, Goblin HP: {Goblin.DusmanHp}");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                    {
                    int dmg = rnd.Next(1, 21); // 1 ile 20 arasında rastgele hasar miktarı
                    Deniz.HasarVer(Goblin, dmg);
                    Console.WriteLine($"Goblin'in kalan HP'si: {Goblin.DusmanHp}");
                    int goblinDmg = rnd.Next(1, 21);
                    Goblin.HasarVer(Deniz, goblinDmg);
                    Console.WriteLine($"Deniz'in kalan HP'si: {Deniz.CharHp}");

                    if (Goblin.DusmanHp <= 0)
                    {
                    Console.WriteLine("Oyunu kazandınız!");
                    oyunDevam = false;
                    }
                    else if (Deniz.CharHp <= 0)
                    {
                    Console.WriteLine("Oyunu kaybettiniz!");
                    oyunDevam = false;
                    }
                    break; // Case sonunda break olmalı
                    }

                    case "2":   
                    int healAmount = rnd.Next(1, 5); // 1 ile 5 arasında rastgele iyileşme miktarı
                    Deniz.Iyiles(healAmount);
                    Console.WriteLine($"İyileşme miktarı: {healAmount} Şu anda {Deniz.CharName}in Canı {Deniz.CharHp}");
                    break;
                    case "3":
                    oyunDevam = false; // Döngüyü bitir
                    Console.WriteLine("Oyundan çıkılıyor...");
                        break;
                    default:
                    Console.WriteLine("Geçersiz seçim!");
                    break;
                }
            }

        }
    }
}

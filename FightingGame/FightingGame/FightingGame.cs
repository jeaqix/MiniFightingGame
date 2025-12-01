using System;
using System.Collections.Generic;
namespace FightingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random rnd = new Random();
            int beklemeSuresi = 0;
            Karakter Deniz = new Karakter("Deniz", 100, "A1");
            Dusman Goblin = new Dusman("Goblin", 100, "Goblin");
            Console.WriteLine("⚔️ Oyun Başlıyor...");
            bool oyunDevam = true;
            while (oyunDevam)
            {
                Console.WriteLine("\n=== OYUN MENÜSÜ ===");
                Console.WriteLine("1 - Saldır ⚔️");
                Console.WriteLine("2 - İyileş 💖");
                Console.WriteLine("3 - Çıkış 🚪");
                Console.WriteLine($"Durum -> {Deniz.Isim}: {Deniz.Can} HP | {Goblin.Isim}: {Goblin.Can} HP");
                if (beklemeSuresi > 0) Console.WriteLine($"⚠️ İyileşme Bekleme Süresi: {beklemeSuresi} tur");
                Console.Write("Seçiminiz: ");
                ConsoleKeyInfo tusBilgisi = Console.ReadKey(false);
                string secim = tusBilgisi.KeyChar.ToString();
                Console.WriteLine();
                switch (secim)
                {
                    case "1":
                        int dmg = rnd.Next(1, 21);
                        int critChance = rnd.Next(1, 101);
                        if (critChance >= 80)
                        {
                            Console.WriteLine("\n🔥 KRİTİK VURUŞ! Hasar ikiye katlandı! 🔥");
                            Deniz.Saldir(Goblin, dmg * 2);
                        }
                        else
                        {
                            Deniz.Saldir(Goblin, dmg);
                        }
                        if (Goblin.Can > 0)
                        {
                            int goblinDmg = rnd.Next(1, 15);
                            Goblin.Saldir(Deniz, goblinDmg);
                            if (beklemeSuresi > 0) --beklemeSuresi;
                        }
                        if (Goblin.Can <= 0)
                        {
                            Console.WriteLine("\n🏆 TEBRİKLER! Goblin'i yendiniz!");
                            oyunDevam = false;
                        }
                        else if (Deniz.Can <= 0)
                        {
                            Console.WriteLine("\n💀 ÖLDÜNÜZ! Oyun Bitti.");
                            oyunDevam = false;
                        }
                        break;
                    case "2":
                        if (beklemeSuresi <= 0)
                        {
                            int healAmount = rnd.Next(5, 15);
                            Deniz.Iyiles(healAmount);
                            beklemeSuresi = 3; 
                        }
                        else
                        {
                            Console.WriteLine("\n❌ İyileşme bekleme süresinde! Tur kaybetmedin, tekrar seç.");
                        }
                        break;
                    case "3":
                        oyunDevam = false;
                        Console.WriteLine("Oyundan çıkılıyor...");
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim! Lütfen 1, 2 veya 3'e basın.");
                        break;
                }
            }
            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
    public class Canli
    {
        public string Isim { get; set; }
        public int Can { get; set; }
        public int MaxCan { get; set; } = 100;
        public Canli(string isim, int can)
        {
            Isim = isim;
            Can = can;
        }
        public void HasarAl(int hasar)
        {
            Can -= hasar;
            if (Can < 0) Can = 0;
            Console.WriteLine($"> {Isim} {hasar} hasar aldı. (Kalan Can: {Can})");
        }
        public void Iyiles(int iyiles)
        {
            Can += iyiles;
            if (Can > MaxCan) Can = MaxCan;
            Console.WriteLine($"> ✨ Hızlıca iyileştin! Düşman sana vuramadı. {Isim} {iyiles} HP kazandı. (Güncel Can: {Can})");
        }
        public void Saldir(Canli hedef, int hasar)
        {
            Console.WriteLine($"\n{Isim}, {hedef.Isim} hedefine saldırıyor!");
            hedef.HasarAl(hasar);
        }
    }
    public class Karakter : Canli
    {
        public string OyuncuId { get; set; }
        public Karakter(string isim, int can, string id) : base(isim, can)
        {
            OyuncuId = id;
        }
    }

    public class Dusman : Canli
    {
        public string DusmanTuru { get; set; }
        public Dusman(string isim, int can, string tur) : base(isim, can)
        {
            DusmanTuru = tur;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame
{


    class Karakter // Karakter sınıfını oluşturduk
    {
        public string CharName { get; set; } //Karakterin ismini tutan variable
        public string CharId { get; set; } //Karakterin ID'sini tutan variable
        public int CharHp { get; set; } //Karakterin canını tutan variable

        public Karakter(string name, string id, int hp) // Constructor
        {
            CharName = name; // Değer atamaları
            CharId = id;
            CharHp = hp;
        }
        public int Iyiles(int heal) // İyileşme metodu
        {
            CharHp += heal;
            if (CharHp > 100) CharHp = 100; // HP'nin 100'ü geçmemesi için
            return CharHp; // artık kalan HP'yi döndürüyor
        }
        public int HasarAl(int dmg)
        {
            CharHp -= dmg;
            if (CharHp < 0) CharHp = 0;
            else if (CharHp > 100) CharHp = 100; // HP'nin 100'ü geçmemesi için
            return CharHp; // artık kalan HP'yi döndürüyor
        }
        public int HasarVer(Dusman hedef, int dmg)
        {
            return hedef.HasarAl(dmg);
        }
    }
    class Dusman // Dusman sınıfını oluşturduk
    {
        public string DusmanName { get; set; } //Dusmanın ismini tutan variable
        public string DusmanId { get; set; } //Dusmanın ID'sini tutan variable
        public int DusmanHp { get; set; } //Dusmanın canını tutan variable

        public Dusman(string name, string id, int hp) // Constructor
        {
            DusmanName = name; // Değer atamaları
            DusmanId = id;
            DusmanHp = hp;
        }
        public int HasarAl(int dmg) // Hasar alma metodu
        {
            DusmanHp -= dmg;
            if (DusmanHp < 0) DusmanHp = 0;
            return DusmanHp;
        }
        public int HasarVer(Karakter hedef, int dmg)
        {
            return hedef.HasarAl(dmg);
        }


    }
}


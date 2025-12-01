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
            int healCooldown = 0;
            Character player = new Character("Raphael", 100, "A1");
            Opponent enemy = new Opponent("Goblin", 100, "Goblin");
            Console.WriteLine("⚔️ Game is Starting...");
            bool gameIsRunning = true;
            while (gameIsRunning)
            {
                Console.WriteLine("\n=== GAME MENU ===");
                Console.WriteLine("1 - Attack ⚔️");
                Console.WriteLine("2 - Heal 💖");
                Console.WriteLine("3 - Leave 🚪");
                Console.WriteLine($"Status -> {player.Name}: {player.HealthPoint} HP | {enemy.Name}: {enemy.HealthPoint} HP");
                if (healCooldown > 0) Console.WriteLine($"⚠️ Heal cooldown: {healCooldown} turns remaining.");
                Console.Write("Your Choice: ");
                ConsoleKeyInfo keyStrokeInfo = Console.ReadKey(false);
                string choice = keyStrokeInfo.KeyChar.ToString();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        int dmg = rnd.Next(1, 21);
                        int critChance = rnd.Next(1, 101);
                        if (critChance >= 80)                         {
                            Console.WriteLine("\n🔥 CRITICAL HIT! Damage doubled! 🔥");
                            player.Attack(enemy, dmg * 2);
                        }
                        else
                        {
                            player.Attack(enemy, dmg);
                        }
                        if (enemy.HealthPoint > 0)
                        {
                            int enemyDmg = rnd.Next(1, 15);
                            enemy.Attack(player, enemyDmg);
                            if (healCooldown > 0) --healCooldown;
                        }
                        if (enemy.HealthPoint <= 0)
                        {
                            Console.WriteLine($"\n🏆 CONGRATULATIONS! You defeated the {enemy.Name}!");
                            gameIsRunning = false;
                        }
                        else if (player.HealthPoint <= 0)
                        {
                            Console.WriteLine("\n💀 GAME OVER! You died.");
                            gameIsRunning = false;
                        }
                        break;

                    case "2":
                        if (healCooldown <= 0)
                        {
                            int healAmount = rnd.Next(5, 15);
                            player.Heal(healAmount);
                            healCooldown = 3;
                        }
                        else
                        {
                            Console.WriteLine("\n❌ You cannot heal yet! Cooldown is active.");
                        }
                        break;
                    case "3":
                        gameIsRunning = false;
                        Console.WriteLine("Exiting game...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please press 1, 2, or 3.");
                        break;
                }
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
    public class Being
    {
        public string Name { get; set; }
        public int HealthPoint { get; set; }
        public int MaxHealthPoint { get; set; } = 100;
        public Being(string name, int healthPoint)
        {
            Name = name;
            HealthPoint = healthPoint;
        }

        public void TakeDamage(int damage)
        {
            HealthPoint -= damage;
            if (HealthPoint < 0) HealthPoint = 0;
            Console.WriteLine($"> {Name} took {damage} damage. (Current HP: {HealthPoint})");
        }

        public void Heal(int healAmount)
        {
            HealthPoint += healAmount;
            if (HealthPoint > MaxHealthPoint) HealthPoint = MaxHealthPoint;

            Console.WriteLine($"> ✨ Quick Heal! Enemy missed. {Name} gained {healAmount} HP. (Current HP: {HealthPoint})");
        }

        public void Attack(Being target, int damage)
        {
            Console.WriteLine($"\n{Name} is attacking {target.Name}!");
            target.TakeDamage(damage);
        }
    }

    public class Character : Being
    {
        public string CharacterID { get; set; }

        public Character(string name, int healthPoint, string id) : base(name, healthPoint)
        {
            CharacterID = id;
        }
    }

    public class Opponent : Being
    {
        public string OpponentType { get; set; }

        public Opponent(string name, int healthPoint, string type) : base(name, healthPoint)
        {
            OpponentType = type;
        }
    }
}
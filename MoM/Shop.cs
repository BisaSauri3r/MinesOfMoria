using System;
using System.Collections.Generic;
using System.Text;

namespace MoM
{
    class Shop
    {
        public static void LoadShop(Player p)
        {
            RunShop(p);
        }

        public static void RunShop(Player p)
        {
            int potionP;
            int armorP;
            int weaponP;
            int difP;
            while (true)
            {
                potionP = 20 + 10 * p.mods;
                armorP = 100 * (p.armorValue + 1);
                weaponP = 100 * p.weaponValue;
                difP = 300 + 100 * p.mods;

                Console.Clear();
                Console.WriteLine("   Gandalfs Items     ");
                Console.WriteLine("======================");
                Console.WriteLine("(W)eapon :         " + weaponP + " Energie");
                Console.WriteLine("(A)rmor :          " + armorP + " Energie");
                Console.WriteLine("(P)otion :         " + potionP + " Energie");
                Console.WriteLine("(D)ifficulty Mod : " + difP + " Energie");
                Console.WriteLine("=======================");
                Console.WriteLine("(E)xit");
                Console.WriteLine("(Q)uit");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Stats");
                Console.WriteLine("======================");
                Console.WriteLine("Current Health: " + p.health);
                Console.WriteLine("Energy: " + p.coins);
                Console.WriteLine("Weapon Strength: " + p.weaponValue);
                Console.WriteLine("Armor Toughness: " + p.armorValue);
                Console.WriteLine("Potions: " + p.potions);
                Console.WriteLine("Difficulty Mods: " + p.mods);

                Console.WriteLine("XP:");
                Console.Write("[");
                Program.ProgressBar("+", " ", ((decimal)p.xp / (decimal)p.getLevelUpValue()), 25);
                Console.WriteLine("]");

                Console.WriteLine("Level: " + p.level);
                Console.WriteLine("======================");

                string input = Console.ReadLine().ToLower();
                if (input == "p" || input == "potion")
                {
                    TryBuy("potion", potionP, p);
                }
                else if (input == "w" || input == "weapon")
                {
                    TryBuy("weapon", weaponP, p);
                }
                else if (input == "a" || input == "armor")
                {
                    TryBuy("armor", armorP, p);
                }
                else if (input == "d" || input == "difficulty mod")
                {
                    TryBuy("dif", difP, p);
                }
                else if (input == "q" || input == "quit")
                {
                    Quit();
                }
                else if (input == "e" || input == "exit")
                {
                    break;
                }
            }
        }
        public static void TryBuy(string item, int cost, Player p)
        {
            if (p.coins >= cost)
            {
                if (item == "potion")
                    p.potions++;
                else if (item == "weapon")
                    p.weaponValue++;
                else if (item == "armmor")
                    p.armorValue++;
                else if (item == "dif")
                    p.mods++;

                p.coins -= cost;
            }
            else
            {
                Console.WriteLine("Du hast nicht genug Energie um dieses Item benutzen zu können!");
                Console.ReadKey();
            }
        }
        static void Quit()
        {
            Environment.Exit(0);
        }
    }

}

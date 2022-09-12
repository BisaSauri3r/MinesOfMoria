using System;
using System.Collections.Generic;
using System.Text;

namespace MoM
{
    [Serializable]
    class Player
    {
        Random rand = new Random();

        public string name;
        public int id;
        public int coins = 0;
        public int level = 1;
        public int xp = 0;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int potions = 5;
        public int weaponValue = 1;

        public int mods = 0;

        public enum playerClass { Aragorn, Legolas, Gimli };
        public playerClass currentClass = playerClass.Gimli;

        public int getHealth()
        {
            int upper = (2 * mods + 5);
            int lower = (mods + 2);
            return rand.Next(lower, upper);
        }
        public int getPower()
        {
            int upper = (2 * mods + 2);
            int lower = (mods + 1);
            return rand.Next(lower, upper);
        }
        public int GetCoins()
        {
            int upper = (15 * mods + 50);
            int lower = (10 * mods + 10);
            return rand.Next(lower, upper);
        }

        public int GetXP()
        {
            int upper = (60 * mods + 400);
            int lower = (15 * mods + 10);
            return rand.Next(lower, upper);
        }

        public int getLevelUpValue()
        {
            return 100 * level + 400;
        }

        public bool canLevelUp()
        {
            if (xp >= getLevelUpValue())
                return true;
            else return false;
        }

        public void LevelUp()
        {
            while (canLevelUp())
            {
                xp -= getLevelUpValue();
                level++;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Program.Print("Gut gemacht! Du hast Level " + level + " erreicht!");
            Console.ResetColor();
        }
    }
}


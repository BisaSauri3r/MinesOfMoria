using System;
using System.Collections.Generic;
using System.Text;

namespace MoM
{
    class Encounters
    {
        static Random rand = new Random();

        // Encounters
        public static void Orc()
        {
            Console.Clear();
            Print("Ihr biegt um die nächste Ecke.");
            Print("Der Feind wartet bereits auf euch...");
            Console.ReadKey();
            Combat(false, "Orc", 4, 6);
        }
        public static void Goblin()
        {
            Console.Clear();
                Print("Im nächsten Gang erwartet euch ein weiteres Ungeheuer...");
                Console.ReadKey();
                Combat(true, "", 3, 4);
        }

        public static void Orc2()
        {
            Console.Clear();
            Print("Obwohl die Hobbits bereits müde und langsam werden, ermutigt ihr sie zum Weiterlaufen.");
            Print("Doch der Feind ist bereits dort...");
            Console.ReadKey();
            Combat(false, "Orc", 2, 3);
        }
        
        

        public static void Balrog()
        {
            {
                Console.Clear();
                Print("Ihr seid zur Brücke von Khazad-dûm gelangt. Nur ein Balrog, Diener Morgoths, steht zwischen euch und dem Osttor von Moria.");
                Console.ReadKey();
                Combat(true, "", 0, 0);
                Console.ReadKey();
            }
        }

        public static void Troll()
        {
            Console.Clear();
            Print("Ihr lauft einen dunklen Flur entlang. Nur Gandalfs Zauberstarb spendet Licht.");
            Print("Als ihr Balins Grab erreicht, die Trommeln tief in Moria hört und die Horden der Orcs näherkommen, bleibt euch nur die Wahl:");
            Print("Ihr müsst einen der vier Gänge nehmen, die von den Orcs wegführen. Die Gänge sind mit Runen beschriftet: r, b, a, d.");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("(Gebe eine Rune ein, um fortzufahren.)");
            Console.ResetColor();
            string rune = Console.ReadLine();
            Console.Clear();
                switch (rune)
                {
                    case "r":
                        Print("Mit mehr Glück als Verstand tastet ihr euch einer Wand entlang auf die andere Seite des Ganges. Zu eurer Rechten erstreckt sich ein endloser Schlund, der in das Innere des Berges führt.");
                        Print("Dein Instinkt hat euch gerettet.");
                        break;
                    case "b":
                        Print("Ein Uruk-Hai lauert euch auf. Tapfer kämpfst du, um den Ringträger und seine Gemeinschaft zu beschützen.");
                        {
                            // Death Code
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Print("Während der Uruk-Hai bedrohlich über dir steht, schwinkt sein Schwert auf dich nieder. Du wurdest vom mächtigen Uruk-Hai erschlagen!");
                            Console.ResetColor();
                            Console.ReadKey();
                            System.Environment.Exit(0);
                        }
                        Console.ReadKey();
                        break;
                    case "a":
                    case "d":
                        Print("Dein Mut rettet die Gemeinschaft. Mutig läufst du voran und erledigst viele Orcs auf den Weg zur anderen Seite des Ganges!");
                        break;
                                      }
                        Console.ReadKey();
                
            }

            public static void Troll2()
            {
                Console.Clear();
                Print("Der Troll kommt näher!");
                Print("Ihr steht an einer Weggabelung, die Zwerge haben sie mit Runen versehen:");
                Print("Ihr müsst einen der vier Gänge nehmen, die von den Orcs und dem Troll wegführen. Die Gänge sind mit Runen beschriftet: r, b, a, d.");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("(Gebe eine Rune ein, um fortzufahren.)");
                Console.ResetColor();
                string rune = Console.ReadLine();
                Console.Clear();
                switch (rune)
                    {
                        case "a":
                            Print("Mit mehr Glück als Verstand tastet ihr euch einer Wand entlang auf die andere Seite des Ganges. Zu eurer Rechten erstreckt sich ein endloser Schlund, der in das Innere des Berges führt.");
                            Print("Dein Instinkt hat euch gerettet.");
                            break;
                        case "d":
                            Print("Ein Uruk-Hai lauert euch auf.");
                            {
                                // Death Code
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Print("Tapfer kämpfst du, um den Ringträger und seine Gemeinschaft zu beschützen, doch du fällst ehrenhaft.");
                                Console.ResetColor();
                                Console.ReadKey();
                                System.Environment.Exit(0);
                            }
                            Console.ReadKey();
                            break;
                        case "r":
                        case "b":
                            Print("Dein Mut rettet die Gemeinschaft. Mutig läufst du voran und erledigst viele Orcs auf den Weg zur anderen Seite des Ganges!");
                            break;
                    
                
                            
                }
                Console.ReadKey();
            }

            // Encounter Tools
            public static void RandomEncounter()
            {
                switch (rand.Next(0, 3))
                {
                    case 0:
                        Orc();
                        break;
                    case 1:
                        Goblin();
                        break;
                    case 2:
                        Troll();
                        break;
                }
            }
        
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {
                n = GetName();
                p = Program.currentPlayer.getPower();
                h = Program.currentPlayer.getHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("|   (R)un   (H)eal  |");
                Console.WriteLine("=====================");
                Console.WriteLine(" Potions: " + Program.currentPlayer.potions + "  Health:  " + Program.currentPlayer.health);
                string input = Console.ReadLine();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    // Attack
                    Console.WriteLine("Die Waffe bereit, holst du zum Angriff aus, doch der " + n + " trifft dich, während du voranstürmst.");
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4) + ((Program.currentPlayer.currentClass == Player.playerClass.Gimli) ? 2 : 0);
                    Console.WriteLine("Du verlierst " + damage + " Gesundheit und verursachst " + attack + " Schaden");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    // Defend
                    Console.WriteLine("Als du vor dem " + n + " fliehst, trifft dich sein Schlag in den Rücken und du fällst zu Boden.");
                    int damage = (p / 4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) / 2;
                    Console.WriteLine("Du verlierst " + damage + " Gesundheit und verursachst " + attack + " Schaden");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }

                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    // Run
                    if (Program.currentPlayer.currentClass != Player.playerClass.Legolas && rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("Als du vor dem " + n + " fliehst, trifft dich sein Schlag in den Rücken und du fällst zu Boden.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("Du verlierst " + damage + " Gesundheit und kannst nicht entkommen.");
                        Program.currentPlayer.health -= damage;
                    }
                    else
                    {
                        Console.WriteLine("Du benutzt deine abgefahrenen Kampfkünste und weichst dem " + n + " aus. Du entkommst erfolgreich!");
                        Console.ReadKey();
                        Shop.LoadShop(Program.currentPlayer);
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    // Heal 
                    if (Program.currentPlayer.potions == 0)
                    {
                        Console.WriteLine("Als du verzweifelst nach einem Athelas in deiner Tasche greifst, ertastest du lediglich Lembas.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("Der " + n + " schlägt mit einem mächtigen Schlag zu und du verlierst " + damage + " Gesundheit.");
                    }
                    else
                    {
                        Console.WriteLine("Du greifst in deine Tasche und holst eine Athelas-Pflanze. Du nimmst einen großes Stück zu dir.");
                        int potionV = 5 + ((Program.currentPlayer.currentClass == Player.playerClass.Aragorn) ? +4 : 0);
                        Console.WriteLine("Du erhältst " + potionV + " Gesundheit");
                        Program.currentPlayer.health += potionV;
                        Program.currentPlayer.potions--;
                        Console.WriteLine("Während du beschäftigt bist, kommt  der " + n + " näher und schlägt zu.");
                        int damage = (p / 2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("Du verlierst " + damage + " Gesundheit");
                    }
                }
                if (Program.currentPlayer.health <= 0)
                {
                    // Death Code
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Print("Während der " + n + " bedrohlich über dir steht, schwinkt sein Schwert auf dich nieder. Du wurdest vom mächtigen " + n + " erschlagen!");
                    Console.ResetColor();
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            }
            int c = Program.currentPlayer.GetCoins();
            int x = Program.currentPlayer.GetXP();
            Console.WriteLine("Als du siegreich über dem " + n + " stehst, löst sich dessen Körper in " + c + " Energie auf! Du erhältst " + x + " XP!");
            Program.currentPlayer.coins += c;
            Program.currentPlayer.xp += x;

            if (Program.currentPlayer.canLevelUp())
                Program.currentPlayer.LevelUp();

            Console.ReadKey();
        }

        static string GetName()
        {
            switch (rand.Next(0, 4))
            {
                case 0:
                    return "Orc";
                case 1:
                    return "Balrog";
                case 2:
                    return "Goblin";
                case 3:
                    return "Uruk-Hai";
            }
            return "Balrog";
        }

        static void Print(string text, int speed = 20)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
            Console.WriteLine();
        }



    }


    }

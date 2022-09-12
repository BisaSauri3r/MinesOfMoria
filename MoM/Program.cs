using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MoM
{
    class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;

        public static void Main(string[] args)
        {
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
            // Spiel starten
            Player p = new Player();
            Print("Die Minen von Moria!");
            Print("Wähle einen Charakter: Aragorn, Legolas, Gimli");
            string name = Console.ReadLine();

            // Charakter wählen
            bool flag = false;
            while (flag == false)
            {
                flag = true;
                if (name == "Aragorn")
                    p.currentClass = Player.playerClass.Aragorn;
                else if (name == "Legolas")
                    p.currentClass = Player.playerClass.Legolas;
                else if (name == "Gimli")
                    p.currentClass = Player.playerClass.Gimli;
                else
                {
                    Console.WriteLine("Please choose an existing character!");
                    flag = false;
                }
            }

            // Intro
            Console.Clear();
            Print("Nachdem Caradhras den Weg versperrt, bist du mit deiner Gemeinschaft gezwungen, durch die Minen von Moria zu gehen.");
            Print("Grauen erfüllt dich, als du daran denkst, was erwachte, als die Zwerge zu tief gruben.");
            if (p.name == "")
                Print("Du kennst deinen eigenen Namen...");
            else
                Print("Du bist " + name + ", wenn du keinen Weg findest, dann findet ihn niemand!");
            Console.ReadKey();
            Console.Clear();
            Print("Die Halle, die du betrittst, nachdem du 'mellon' gesprochen hast, liegt dunkel und verlassen da.");
            Print("Als sich deine Augen an das Dunkel gewöhnen, erblickst du zu deiner Bestürzung Leichen von Balins Volk.");
            Print("Langsam schreitet die Gemeinschaft voran, willens, einen Weg aus dem Grab zu finden.");
            Console.ReadKey();

            Encounters.Orc();
            Encounters.Goblin();
            Encounters.Orc();
            Encounters.Orc();
            Encounters.Orc2();
            Encounters.Troll();
            Encounters.Orc2();
            
                Console.Clear();
                if (name == "Gimli")
                    Print("Dank deiner breiten Axt besiegst du eine Zwergenhand voll Orcs, während die Gemeinschaft tiefer in den Berg vordringt.");
                else if (name == "Legolas")
                    Print("Dank deines Elbenbogens streckst du viele Orcs nieder, während die Gemeinschaft tiefer in den Berg vordringt.");
                else if (name == "Aragorn")
                    Print("Dank deinem Schwert Andruil bringst du vielen Orscen den Tod, während die Gemeinschaft tiefer in den Berg vordringt..");
                Console.ReadKey();
            
            Encounters.Troll2();
            Encounters.Balrog();

            Console.Clear();
            Print("Ihr habt den Balrog besiegt, eurer Flucht aus den Minen Morias steht nun nichts mehr im Wege!");
            Print("Die neun Gefährten schreiten, Gandalf an der Spitze, voran, um Frau Galdriel in Lothlórien aufzusuchen.");
            Console.ForegroundColor = ConsoleColor.Green;
            Print("Well done!");
            Console.ResetColor();
            Console.ReadKey();

        }

        public static void Print(string text, int speed = 20)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
            Console.WriteLine();
        }

        public static void Quit()
        {
            Environment.Exit(0);
        }

        public static void ProgressBar(string fillerChar, string backgroundChar, decimal value, int size)
        {
            int dif = (int)(value * size);
            for (int i = 0; i < size; i++)
            {
                if (i < dif)
                    Console.Write(fillerChar);
                else
                    Console.Write(backgroundChar);
            }
        }

        public static void Save()
        {
            BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/" + currentPlayer.id.ToString();
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            binForm.Serialize(file, currentPlayer);
            file.Close();
        }

        public static Player Load()
        {
            Console.Clear();
            string[] paths = Directory.GetDirectories("saves");
            List<Player> players = new List<Player>();

            BinaryFormatter binForm = new BinaryFormatter();
            foreach (string p in paths)
            {
                FileStream file = File.Open(p, FileMode.Open);
                Player player = (Player)binForm.Deserialize(file);
                file.Close();
                players.Add(player);
            }                  
            
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Wähle deinen Spieler: ");

                foreach (Player p in players)
                {
                    Console.WriteLine(p.id + ": " + p.name);
                }

                Console.WriteLine("Bitte gib deinen Spielernamen oder Id ein (ID:# oder Spielername)");
                string[] data = Console.ReadLine().Split(':');
                try
                {
                    if(data[0] == "id")
                    {
                        if (int.TryParse(data[1], out int id))
                        {
                            foreach (Player player in players)
                            {
                                if (player.id == id)
                                {
                                    return player;
                                }
                            }
                            Console.WriteLine("Es gibt keinen Spieler mit dieser ID!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Die ID muss eine Nummer sein! Drücke eine Taste um fortzufahren!");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        foreach (Player player in players)
                        {
                            if (player.name == data[0])
                            {
                                return player;
                            }
                        }
                        Console.WriteLine("Es gibt keinen Spieler mit diesem Namen!");
                        Console.ReadKey();
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Die ID muss eine Nummer sein! Drücke eine Taste um fortzufahren!");
                    Console.ReadKey();
                }
            }
           
        }
    }
}

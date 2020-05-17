using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextRPG
{
    public static class GameModel
    {
        public static Random EventRandomizerRnd = new Random();
        public static void EventRandomizer()
        {
            int tmp = EventRandomizerRnd.Next(100);
            if(tmp<50)
            {
                
            }
            else
            if(tmp==75)
            {
                Player.encounter = 100;
                Creature.name = "Cursed Elite RNG Cursed Mini Boss (Better Run Away)";
                Creature.maxhealth = 2000;
                Creature.health = 2000;
                Creature.damage = 20;
                Creature.defence = 10;
                Creature.chargeddamage = 5 * Creature.damage;
                Creature.xpreward = 5000;
                Creature.goldreward = 9001;
    }
            else
                if(tmp>50 && tmp < 75)
            {
                Console.WriteLine("You've found some gold!");
                Player.gold = Player.gold + 20;
            }
            else 
                if(tmp>75)
            {
                Creature.Randomize();
                Console.WriteLine("You've encountered a wild " + Creature.name + "!");
            }

            

        }
        public static void drawGui(Map map)
        {
            
            char key = '0';
            int state = 0;
            string s = "";


            while (Player.GameInProgress)
            {
                Console.Clear();
                Console.WriteLine("");
                switch (Map.map[Player.x, Player.y].symbol)
                {
                    case 'V':
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("===///==@@@=///===@==//////====");
                        Console.WriteLine("===|$|=@@#@@|=|==@#@=|==<>|====");
                        Console.WriteLine("===|=|===#==|=|===#==|$=<>|====");
                        Console.WriteLine("===|$|===#==|$|===#==|$=<>|====");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 'F':
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==@@@==@O===@=========@==@=====");
                        Console.WriteLine("=@@#@@@#@==@#@====@==@#@@#@@===");
                        Console.WriteLine("=^^#===#====#====@#@==#==#@#@==");
                        Console.WriteLine("^^^^===#===^^^====#===#==#=#===");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 'C':
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("*****====================&=****");
                        Console.Write("*******&========");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("(G) (G)");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("==/==***");
                        Console.WriteLine("*******/===================****");
                        Console.WriteLine("**=**======================****");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 'M':
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("=======//////////=========@@@@=");
                        Console.WriteLine("=====//////////////=====@@@@@==");
                        Console.WriteLine("===//////////////////==========");
                        Console.WriteLine("=/////////////////////=========");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default: throw new Exception("Unknown symbol");
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("==============================");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You're currently at ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Map.map[Player.x, Player.y].name);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(Map.map[Player.x, Player.y].desc); ;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("==============================");
                Console.ForegroundColor = ConsoleColor.White;
                if (Player.x == 4 && Player.y == 4)
                {
                    state = 1;
                }
                else
                {
                    if (Player.encounter > 0)
                    {
                        state = 2;
                    }
                    else
                    {
                        state = 0;
                    }
                }
                switch (state)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("What will you do?");
                        Console.WriteLine("1.Check map");
                        Console.WriteLine("2.Move");
                        Console.WriteLine("3.Check Inventory");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;

                        while (true)
                        {
                            s = Console.ReadLine();
                            if (!string.IsNullOrEmpty(s))
                            {
                                key = s[0];

                                break;
                            }

                        }
                        switch (key)
                        {
                            case '1':
                                map.checkMap();
                                Console.ReadKey();
                                drawGui(map);
                                break;
                            case '2':
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("==============================");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Where would you like to go?");
                                Console.WriteLine("W - North");
                                Console.WriteLine("S - South");
                                Console.WriteLine("A - West");
                                Console.WriteLine("D - East");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("==============================");
                                Console.ForegroundColor = ConsoleColor.White;

                                while (true)
                                {
                                    s = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(s))
                                    {
                                        key = s[0];

                                        break;
                                    }

                                }
                                switch (key)
                                {
                                    case 'W': Player.x = Player.x - 1; EventRandomizer(); break; // Ruch o 1 pole w górę
                                    case 'S': Player.x = Player.x + 1; EventRandomizer(); break; // Ruch o 1 pole w górę
                                    case 'A': Player.y = Player.y - 1; EventRandomizer(); break; // Ruch o 1 pole w górę
                                    case 'D': Player.y = Player.y + 1; EventRandomizer(); break; // Ruch o 1 pole w górę
                                    case 'w': Player.x = Player.x - 1; EventRandomizer(); break; // Ruch o 1 pole w górę
                                    case 's': Player.x = Player.x + 1; EventRandomizer(); break; // Ruch o 1 pole w górę
                                    case 'a': Player.y = Player.y - 1; EventRandomizer(); break; // Ruch o 1 pole w górę;
                                    case 'd': Player.y = Player.y + 1; EventRandomizer(); break; // Ruch o 1 pole w górę;

                                }
                                drawGui(map);
                                break;
                            default: drawGui(map); break;
                        }
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("What will you do?");
                        Console.WriteLine("1.Check map");
                        Console.WriteLine("2.Move");
                        Console.WriteLine("3.Check Inventory");
                        Console.WriteLine("4.Rest at Tavern");
                        Console.WriteLine("5. Visit Shop");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        while (true)
                        {
                            s = Console.ReadLine();
                            if (!string.IsNullOrEmpty(s))
                            {
                                key = s[0];

                                break;
                            }

                        }
                        switch (key)
                        {
                            case '1':
                                map.checkMap();
                                Console.ReadKey();
                                break;
                            case '2':
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("==============================");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Where would you like to go?");
                                Console.WriteLine("W - North");
                                Console.WriteLine("S - South");
                                Console.WriteLine("A - West");
                                Console.WriteLine("D - East");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("==============================");
                                Console.ForegroundColor = ConsoleColor.White;
                                while (true)
                                {
                                    s = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(s))
                                    {
                                        key = s[0];

                                        break;
                                    }

                                }

                                switch (key)
                                {
                                    case 'W': Player.x = Player.x - 1; EventRandomizer();  break; // Ruch o 1 pole w górę
                                    case 'S': Player.x = Player.x + 1; EventRandomizer();  break; // Ruch o 1 pole w górę
                                    case 'A': Player.y = Player.y - 1; EventRandomizer();  break; // Ruch o 1 pole w górę
                                    case 'D': Player.y = Player.y + 1; EventRandomizer();  break; // Ruch o 1 pole w górę
                                    case 'w': Player.x = Player.x - 1; EventRandomizer();  break; // Ruch o 1 pole w górę
                                    case 's': Player.x = Player.x + 1; EventRandomizer(); break; // Ruch o 1 pole w górę
                                    case 'a': Player.y = Player.y - 1; EventRandomizer(); break; // Ruch o 1 pole w górę;
                                    case 'd': Player.y = Player.y + 1; EventRandomizer(); break; // Ruch o 1 pole w górę;
                                    default: break;
                                }
                                drawGui(map);
                                break;

                        }
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Wild " + Creature.name + "(" + Creature.health + "/" + Creature.maxhealth + ") is waiting for your move!");
                        Console.WriteLine("1.Fight");
                        Console.WriteLine("2.Check");
                        Console.WriteLine("3.Defend");
                        Console.WriteLine("4.Check Inventory");
                        Console.WriteLine("5.Try running away");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;

                        break;
                    default: drawGui(map); break;

                }
            }
        }
        }
}

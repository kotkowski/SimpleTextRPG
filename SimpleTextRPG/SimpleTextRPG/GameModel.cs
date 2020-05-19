using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextRPG
{
    public static class GameModel
    {
        public static Dictionary<int, Item> Items = new Dictionary<int, Item>(50);
        public static void GameStart()
        {
            

            Items.Add(1, new Item(1));
            Items.Add(2, new Item(2));
            Items.Add(3, new Item(3));
            Items.Add(4, new Item(4));
            Items.Add(8, new Item(8));
            Items.Add(10, new Item(10));
            Items.Add(11, new Item(11));
            Items.Add(12, new Item(12));
            Items.Add(13, new Item(13));
            Items.Add(14, new Item(14));
            Items.Add(15, new Item(15));
            Items.Add(20, new Item(20));
            Items.Add(21, new Item(21));
            Items.Add(22, new Item(22));
            Items.Add(23, new Item(23));
            Items.Add(24, new Item(24));
            Items.Add(30, new Item(30));
            Items.Add(31, new Item(31));
            Items.Add(32, new Item(32));
            Items.Add(33, new Item(33));
            Items.Add(100, new Item(100));
            
        }
        
        public static Random EventRandomizerRnd = new Random();
        public static void EventRandomizer()
        {
            int tmp = EventRandomizerRnd.Next(100);
            if(tmp<50)
            {
                Console.WriteLine("Nothing happened during your journey");
            }
            else
            if(tmp==75)
            {
                Player.encounter = 100;
                Creature.name = "Cursed Elite RNG Cursed Mini Boss (Better Run Away)";
                Creature.maxhealth = 2000;
                Creature.health = 2000;
                Creature.hurtTreshold = 100;
                Creature.healing = 100;
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
                Player.encounter = 2;
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
                if(Player.x == Map.GemX && Player.y == Map.GemY)
                {
                    Creature.InitializeBossFight();
                }
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
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                if (Map.map[Player.x, Player.y].symbol == 'V')
                {
                    Console.WriteLine("You're safe here!");
                }
                else if (Player.encounter < 1)
                { EventRandomizer(); }
                
                if(Player.levelup > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You've reached a new level!");
                    Console.WriteLine("You are fully healed and your stats increase!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Player.LevelUp();
                }

                
                switch(Player.encounter)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You've defeated " + Creature.name + "!");
                        Console.WriteLine("You've gained " + Creature.xpreward + " xp and " + Creature.goldreward + " gold!");
                        Player.encounter = -1;
                        break;
                    case -42:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You took too much damage. You lost your consciousness.");
                        Console.WriteLine("Yet somehow, you made it back to the city, losing some coins.");
                        Player.health = Player.maxhealth;
                        Player.gold = (int)Math.Round(Player.gold * 0.8);
                        Player.encounter = -1;
                        break;
                    case -8:
                        Player.encounter = -1;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You've run away");
                        break;
                    case -666:
                        Player.encounter = -1;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You've aquired the Legendary Gem! ");
                           Console.WriteLine("Bring it to the Village! ");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default: break;
                }
                    
               
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
                        Console.WriteLine(Player.health +"/" +Player.maxhealth + "HP " + Player.damage + "DMG" + Player.defence + "DEF");
                        Console.WriteLine("Level " + Player.level + " ("+Player.exp +"/" +Player.RequiredExp() + " Exp) --- Gold: " + Player.gold);
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
                                Console.WriteLine(Player.health + "/" + Player.maxhealth + "HP " + Player.damage + "DMG" + Player.defence + "DEF");
                                Console.WriteLine("Level " + Player.level + " (" + Player.exp + "/" + Player.RequiredExp() + " Exp) --- Gold: " + Player.gold);
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
                                    case 'W': if (Player.x != 0)  Player.x =  Player.x - 1; break; // Ruch o 1 pole w górę
                                    case 'S': if (Player.x != (Map.mapsize -1)) Player.x = Player.x + 1; break; // Ruch o 1 pole w górę
                                    case 'A': if (Player.y != 0) Player.y = Player.y - 1; break; // Ruch o 1 pole w górę
                                    case 'D': if (Player.y != (Map.mapsize - 1)) Player.y = Player.y + 1; break; // Ruch o 1 pole w górę
                                    case 'w': if (Player.x != 0)  Player.x =  Player.x - 1;  break; // Ruch o 1 pole w górę
                                    case 's': if (Player.x != (Map.mapsize - 1))  Player.x = Player.x + 1;  break; // Ruch o 1 pole w górę
                                    case 'a': if (Player.y != 0) Player.y = Player.y - 1;  break; // Ruch o 1 pole w górę;
                                    case 'd': if (Player.y != (Map.mapsize - 1)) Player.y = Player.y + 1;  break; // Ruch o 1 pole w górę;

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
                        Console.WriteLine(Player.health + "/" + Player.maxhealth + "HP " + Player.damage + "DMG" + Player.defence + "DEF");
                        Console.WriteLine("Level " + Player.level + " (" + Player.exp + "/" + Player.RequiredExp() + " Exp) --- Gold: " + Player.gold);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("What will you do?");
                        Console.WriteLine("1.Check map");
                        Console.WriteLine("2.Move");
                        Console.WriteLine("3.Check Inventory");
                        Console.WriteLine("4.Visit Tavern");
                        Console.WriteLine("5.Visit Shop");
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
                                Console.WriteLine(Player.health + "/" + Player.maxhealth + "HP " + Player.damage + "DMG" + Player.defence + "DEF");
                                Console.WriteLine("Level " + Player.level + " (" + Player.exp + "/" + Player.RequiredExp() + " Exp) --- Gold: " + Player.gold);
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
                                    case 'W': if (Player.x != 0) Player.x = Player.x - 1; break; // Ruch o 1 pole w górę
                                    case 'S': if (Player.x != (Map.mapsize - 1)) Player.x = Player.x + 1; break; // Ruch o 1 pole w górę
                                    case 'A': if (Player.y != 0) Player.y = Player.y - 1; break; // Ruch o 1 pole w górę
                                    case 'D': if (Player.y != (Map.mapsize - 1)) Player.y = Player.y + 1; break; // Ruch o 1 pole w górę
                                    case 'w': if (Player.x != 0) Player.x = Player.x - 1; break; // Ruch o 1 pole w górę
                                    case 's': if (Player.x != (Map.mapsize - 1)) Player.x = Player.x + 1; break; // Ruch o 1 pole w górę
                                    case 'a': if (Player.y != 0) Player.y = Player.y - 1; break; // Ruch o 1 pole w górę;
                                    case 'd': if (Player.y != (Map.mapsize - 1)) Player.y = Player.y + 1; break; // Ruch o 1 pole w górę;
                                    default: break;
                                }
                                drawGui(map);
                                break;
                            case '3':
                                Console.WriteLine("");
                                Console.WriteLine("You take a moment, checking your backpack content: ");
                                
                                break;
                            case '4': Player.gainExp(105); break;

                        }
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(Player.health + "/" + Player.maxhealth + "HP " + Player.damage + "DMG" + Player.defence + "DEF");
                        Console.WriteLine("Level " + Player.level + " (" + Player.exp + "/" + Player.RequiredExp() + " Exp) --- Gold: " + Player.gold);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Wild " + Creature.name + "(" + Creature.health + "/" + Creature.maxhealth + ") is " + Creature.CreatureState[(int)Creature.stateofenemy]);
                        if (Player.run == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You've failed to run away!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (Player.check == true)
                        {
                            Console.WriteLine("==============================");
                            Console.WriteLine(Creature.name);
                            Console.WriteLine(Creature.health + "/" + Creature.maxhealth);
                            Console.WriteLine(Creature.damage + " DMG " + Creature.defence + " DEF");
                            Console.WriteLine(Creature.xpreward + " XP and " + Creature.goldreward + " gold upon defeating");
                            Console.WriteLine("==============================");
                            Player.check = false;
                        }
                        Console.WriteLine("What will you do?");
                        Console.WriteLine("1.Fight (Deal (" +Player.damage +" - Enemy Defence) damage to your enemy");
                        Console.WriteLine("2.Check (Check your enemy stats)");
                        Console.WriteLine("3.Defend (Reduce incoming damage by (" + 5*Player.defence+"))");
                        Console.WriteLine("4.Inventory");
                        Console.WriteLine("5.Try running away (Roll ("+ Player.speed +") in 100 chance, trying to escape)");
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
                            case '1': Player.Attack(); Creature.Attack();  break;
                            case '2': Player.check = true; Creature.Attack(); break;
                            case '3': Player.defence = Player.defence * 5; Creature.Attack(); Player.defence = Player.defence / 5; break;
                            case '4': break;
                            case '5': Player.RunAway(); Creature.Attack(); break;
                            default: break;
                        }
                        break;
                    default: drawGui(map); break;

                }
            }
        }
        }
}

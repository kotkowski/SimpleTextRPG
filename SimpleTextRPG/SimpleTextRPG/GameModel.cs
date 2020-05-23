using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextRPG
{
    public static class GameModel
    {
        
        public static Dictionary<char, Item> Items = new Dictionary<char, Item>(50);
        public static char character;
        
        public static T KeyByValue<T, W>(this Dictionary<T, W> dict, W val)
        {
            T key = default;
            foreach (KeyValuePair<T, W> pair in dict)
            {
                if (EqualityComparer<W>.Default.Equals(pair.Value, val))
                {
                    key = pair.Key;
                    break;
                }
            }
            return key;
        }

        public static void GameStart()
        {
            Items.Add('1', new Item(1));
            Items.Add('2', new Item(2));
            Items.Add('3', new Item(3));
            Items.Add('4', new Item(4));
            Items.Add('5', new Item(8));
            Items.Add('6', new Item(10));
            Items.Add('7', new Item(11));
            Items.Add('8', new Item(12));
            Items.Add('9', new Item(13));
            Items.Add('Q', new Item(14));
            Items.Add('W', new Item(20));
            Items.Add('E', new Item(21));
            Items.Add('R', new Item(22));
            Items.Add('T', new Item(23));
            Items.Add('Y', new Item(24));
            Items.Add('U', new Item(30));
            Items.Add('I', new Item(31));
            Items.Add('O', new Item(32));
            Items.Add('P', new Item(33));
            Items.Add('L', new Item(100));
            Player.Inventory.Add(new Item(1), 0);
            Player.Inventory.Add(new Item(2), 0);
            Player.Inventory.Add(new Item(3), 0);
            Player.Inventory.Add(new Item(4), 0);
            Player.Inventory.Add(new Item(8), 0);
            Player.Inventory.Add(new Item(10), 0);
            Player.Inventory.Add(new Item(11), 0);
            Player.Inventory.Add(new Item(12), 0);
            Player.Inventory.Add(new Item(13), 0);
            Player.Inventory.Add(new Item(14), 0);
            Player.Inventory.Add(new Item(20), 0);
            Player.Inventory.Add(new Item(21), 0);
            Player.Inventory.Add(new Item(22), 0);
            Player.Inventory.Add(new Item(23), 0);
            Player.Inventory.Add(new Item(24), 0);
            Player.Inventory.Add(new Item(30), 0);
            Player.Inventory.Add(new Item(31), 0);
            Player.Inventory.Add(new Item(32), 0);
            Player.Inventory.Add(new Item(33), 0);
            
        }
        
        public static char translateId(int id)
        {
            char key = 'l';
            switch (id)
            {
                case 1:
                    key = '1';
                    break;
                case 2:
                    key = '2';
                    break;
                case 3:
                    key = '3';
                    break;
                case 4:
                    key = '4';
                    break;
                case 8:
                    key = '5';
                    break;
                case 10:
                    key = '6';
                    break;
                case 11:
                    key = '7';
                    break;
                case 12:
                    key = '8';
                    break;
                case 13:
                    key = '9';
                    break;
                case 14:
                    key = 'Q';
                    break;
                case 20:
                    key = 'W';
                    break;
                case 21:
                    key = 'E';
                    break;
                case 22:
                    key = 'R';
                    break;
                case 23:
                    key = 'T';
                    break;
                case 24:
                    key = 'Y';
                    break;
                case 30:
                    key = 'U';
                    break;
                case 31:
                    key = 'I';
                    break;
                case 32:
                    key = 'O';
                    break;
                case 33:
                    key = 'P';
                    break;
            }
            return key;
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
                if (Player.x == Map.GemX && Player.y == Map.GemY)
                {
                    Creature.InitializeBossFight();
                }
                Console.WriteLine("");
                switch (Map.map[Player.x, Player.y].symbol)
                {
                    case 'V':
                        if (Player.inshop == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("=====######5=======^^^^^^^=====");
                            Console.WriteLine("===========5======/==O==O=L====");
                            Console.WriteLine("==7777777=====$==/====V====L===");
                            Console.WriteLine("====7777=====$==/===========L==");
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("===///==@@@=///===@==//////====");
                            Console.WriteLine("===|$|=@@#@@|=|==@#@=|==<>|====");
                            Console.WriteLine("===|=|===#==|=|===#==|$=<>|====");
                            Console.WriteLine("===|$|===#==|$|===#==|$=<>|====");
                            Console.ForegroundColor = ConsoleColor.White;

                        }
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
                if (Player.inshop)
                {
                    Console.WriteLine("The Only Shop at " + Map.map[Player.x, Player.y].name);
                }
                else
                {
                    Console.WriteLine(Map.map[Player.x, Player.y].name);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(Map.map[Player.x, Player.y].desc); ;
                    
                }
            
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                if (Map.map[Player.x, Player.y].symbol == 'V')
                {
                    Console.WriteLine("You're safe here!");
                }
                else if (Player.encounter == -1)
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
                    case -8:
                        Player.encounter = -1;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You've run away");
                        Player.run = false;
                        break;
                    case -15:
                        Player.encounter = -1;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You are holding too many items of that kind.");
                        Player.run = false;
                        break;
                    case -24:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You don't have enough money!");
                        Player.encounter = -1;
                        break;
                    case -42:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You took too much damage. You lost your consciousness.");
                        Console.WriteLine("Yet somehow, you made it back to the city, losing some coins.");
                        Player.health = Player.maxhealth;
                        Player.run = false;
                        Player.gold = (int)Math.Round(Player.gold * 0.8);
                        Player.encounter = -1;
                        break;
                    
                    case -666:
                        Player.encounter = -1;
                        Player.gemcontained = true;
                        Player.Inventory.Add(new Item(100), 1);
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
                if (Player.inshop == true)
                {
                    state = 100;
                }
                else
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
                                        case 'W': if (Player.x != 0) Player.x = Player.x - 1; break; // Ruch o 1 pole w górę
                                        case 'S': if (Player.x != (Map.mapsize - 1)) Player.x = Player.x + 1; break; // Ruch o 1 pole w górę
                                        case 'A': if (Player.y != 0) Player.y = Player.y - 1; break; // Ruch o 1 pole w górę
                                        case 'D': if (Player.y != (Map.mapsize - 1)) Player.y = Player.y + 1; break; // Ruch o 1 pole w górę
                                        case 'w': if (Player.x != 0) Player.x = Player.x - 1; break; // Ruch o 1 pole w górę
                                        case 's': if (Player.x != (Map.mapsize - 1)) Player.x = Player.x + 1; break; // Ruch o 1 pole w górę
                                        case 'a': if (Player.y != 0) Player.y = Player.y - 1; break; // Ruch o 1 pole w górę;
                                        case 'd': if (Player.y != (Map.mapsize - 1)) Player.y = Player.y + 1; break; // Ruch o 1 pole w górę;

                                    }
                                    drawGui(map);
                                    break;
                                case '3':

                                    Player.UseInventory();
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
                        Console.WriteLine("4.Visit Tavern (Recover HP for 5 gold)");
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
                                Player.UseInventory();
                                break;


                            case '4': if (Player.gold > 5)
                                {
                                    Player.gold = Player.gold - 5;
                                    Player.health = Player.maxhealth;
                                }
                            else
                                {
                                    Player.encounter = -24;
                                }

                                 break;
                            case '5':
                                Player.inshop = true;
                                break;
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
                            Player.run = false;
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
                        Console.WriteLine("5.Try running away (Roll ("+ Player.speed +") in 25 chance, trying to escape)");
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
                            case '4':
                                Player.UseInventory();
                                break; 
                            case '5': Player.RunAway(); Creature.Attack(); break;
                            default: break;
                        }
                        break;
                    case 100:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(Player.health + "/" + Player.maxhealth + "HP " + Player.damage + "DMG" + Player.defence + "DEF");
                        Console.WriteLine("Level " + Player.level + " (" + Player.exp + "/" + Player.RequiredExp() + " Exp) --- Gold: " + Player.gold);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Hello There!");
                        Console.WriteLine("Do you need anything?");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Buy gear:");


                        foreach (KeyValuePair<char, Item> i in Items)
                        {
                            if(i.Key !='L')
                                Console.WriteLine( i.Key + ">>>" + i.Value.name + " --- " + i.Value.price + " gold");
                                
                            
                        }
                        
                        
                        Console.WriteLine("X.Leave Shop");
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
                        Item q = new Item(1);

                        switch(key)
                        {
                            case '1':  Items.TryGetValue('1', out q);  if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(1); } else { Player.encounter = -24; } ;  break;
                            case '2': Items.TryGetValue('2', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(2); } else { Player.encounter = -24; }; break;
                            case '3': Items.TryGetValue('3', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(3); } else { Player.encounter = -24; }; break;
                            case '4': Items.TryGetValue('4', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(4); } else { Player.encounter = -24; }; break;
                            case '5': Items.TryGetValue('5', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(8); } else { Player.encounter = -24; }; break;
                            case '6': Items.TryGetValue('6', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(10); } else { Player.encounter = -24; }; break;
                            case '7': Items.TryGetValue('7', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(11); } else { Player.encounter = -24; }; break;
                            case '8': Items.TryGetValue('8', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(12); } else { Player.encounter = -24; }; break;
                            case '9': Items.TryGetValue('9', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(13); } else { Player.encounter = -24; }; break;
                            case 'Q': Items.TryGetValue('Q', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(14); } else { Player.encounter = -24; }; break;
                            case 'q': Items.TryGetValue('Q', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(14); } else { Player.encounter = -24; }; break;
                            case 'W': Items.TryGetValue('W', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(20); } else { Player.encounter = -24; }; break;
                            case 'w': Items.TryGetValue('W', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(20); } else { Player.encounter = -24; }; break;
                            case 'E': Items.TryGetValue('E', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(21); } else { Player.encounter = -24; }; break;
                            case 'e': Items.TryGetValue('E', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(21); } else { Player.encounter = -24; }; break;
                            case 'R': Items.TryGetValue('R', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(22); } else { Player.encounter = -24; }; break;
                            case 'r': Items.TryGetValue('R', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(22); } else { Player.encounter = -24; }; break;
                            case 'T': Items.TryGetValue('T', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(23); } else { Player.encounter = -24; }; break;
                            case 't': Items.TryGetValue('T', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(23); } else { Player.encounter = -24; }; break;
                            case 'Y': Items.TryGetValue('Y', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(24); } else { Player.encounter = -24; }; break;
                            case 'y': Items.TryGetValue('Y', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(24); } else { Player.encounter = -24; }; break;
                            case 'U': Items.TryGetValue('U', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(30); } else { Player.encounter = -24; }; break;
                            case 'u': Items.TryGetValue('U', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(30); } else { Player.encounter = -24; }; break;
                            case 'I': Items.TryGetValue('I', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(31); } else { Player.encounter = -24; }; break;
                            case 'i': Items.TryGetValue('I', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(31); } else { Player.encounter = -24; }; break;
                            case 'O': Items.TryGetValue('O', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(32); } else { Player.encounter = -24; }; break;
                            case 'o': Items.TryGetValue('O', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(32); } else { Player.encounter = -24; }; break;
                            case 'P': Items.TryGetValue('P', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(33); } else { Player.encounter = -24; }; break;
                            case 'p': Items.TryGetValue('P', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(33); } else { Player.encounter = -24; }; break;
                            case 'X': Player.inshop = false;  break;
                            case 'x': Player.inshop = false; break;
                            
                           
                        }

                        break;
                    default: drawGui(map); break;

                }
            }
        }
        }
}

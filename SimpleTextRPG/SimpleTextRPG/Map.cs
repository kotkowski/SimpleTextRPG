using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextRPG
{
    public class Map
    {
        public static int mapsize;
        public static Location[,] map;
        public static int GemX =0;
        public static int GemY = 0;
        Random rand = new Random();
        public Map(int size = 10)
        {
            mapsize = size;
            Initialize();
        }

        void Initialize()
        {
            try
            {
                map = new Location[mapsize, mapsize];
                for (int i = 0; i < mapsize; i++)
                {
                    for (int y = 0; y < mapsize; y++)
                    {
                        int tmp = rand.Next(100);
                        char type = '*';
                        string name = "Invalid Location";
                        string prefix;
                        string mid;
                        string suffix;
                        string descprefix;
                        string descmid;
                        string descsuffix;
                        string desc = "Invalid Description";
                        if (i == 4 && y == 4)
                        {
                            type = 'V';
                            tmp = rand.Next(7);
                            prefix = ((City)tmp).ToString();
                            desc = CityDescription[tmp];
                            name = prefix;
                        }
                        else
                        {
                            if (tmp < 60)
                            {
                                type = 'F';
                                tmp = rand.Next(8);
                                prefix = ((ForestPrefix)tmp).ToString();
                                descprefix = ForestDescriptionPrefix[tmp];
                                tmp = rand.Next(8);
                                mid = ((ForestMid)tmp).ToString();
                                descmid = ForestDescriptionMid[tmp];
                                tmp = rand.Next(7);
                                suffix = ((ForestSuffix)tmp).ToString();
                                descsuffix = ForestDescriptionSuffix[tmp];

                                name = prefix + " " + mid + " " + suffix;
                                desc = descprefix + descsuffix + descmid;

                            }
                            else
                                if (tmp >= 60 && tmp < 90)
                            {
                                type = 'C';
                                tmp = rand.Next(7);
                                prefix = ((CavePrefix)tmp).ToString();
                                descprefix = CaveDescriptionPrefix[tmp];
                                tmp = rand.Next(7);
                                mid = ((CaveMid)tmp).ToString();
                                descmid = CaveDescriptionMid[tmp];
                                tmp = rand.Next(7);
                                suffix = ((CaveSuffix)tmp).ToString();
                                descsuffix = CaveDescriptionSuffix[tmp];

                                name = prefix + " " + mid + " " + suffix;
                                desc = descprefix + descsuffix + descmid;

                            }
                            else
                                if (tmp >= 90)
                            { 
                                    type = 'M';
                                    tmp = rand.Next(3);
                                    prefix = ((MountainPrefix)tmp).ToString();
                                    descprefix = MountainDescriptionPrefix[tmp];
                                    tmp = rand.Next(4);
                                    mid = ((MountainSuffix)tmp).ToString();
                                    descmid = MountainDescriptionMid[tmp];
                                    desc = descprefix + descmid;
                                    name = prefix + " " + mid;
                                 
                            }
                        }
                        
                        map[i, y] = new Location(name, desc, type);
                    }
                }
                do
                {
                    GemX = rand.Next(mapsize);
                    GemY = rand.Next(mapsize);
                }
                while (map[GemX, GemY].symbol == 'V');

                    
            }
            catch(Exception)
            {
                Console.WriteLine("Wrong");
            }

        }
        
        public int Randomize(int size)
        {
            int value = rand.Next(0, size);
            
            value = Convert.ToInt32(Math.Ceiling((decimal)value));
            return value;
        }
        

        enum ForestPrefix
        {
            Dark,
            Young,
            Old,
            Bright,
            Rotten,
            Cursed,
            Blessed,
            Haunted
        }
        List<string> ForestDescriptionPrefix = new List<string>(8)
        {
            "Very Dark ", "Pretty Young ", "Pretty Old ", "Pretty Bright ", "Smelling Funny ", "Filled With Evil Presence ", "Filled With Holy Presence ", "Filled With Unknown Presence "
        };
        enum ForestMid
        {
            Pine,
            Oak,
            Spruce,
            Mahogany,
            Mixed,
            Leafy,
            Owl,
            Birch
        }
        List<string> ForestDescriptionMid = new List<string>(8)
        {
            "Growing Pine Wood ", "Growing Oak Wood ", "Growing Spruce Wood ", "Growing Mahogany Wood ", "Growing All Types of Trees ", "Growing Leafy Trees ", "Filled With Owls ", "Growing Birch Wood "
        };
        enum ForestSuffix
        {
            Forest,
            Woods,
            Lumberyard,
            Jungle,
            Bush,
            Copse,
            Grove
        }
        List<string> ForestDescriptionSuffix = new List<string>(7)
        {
            "Forest ", "Large Forest ", "Abandoned Lumeryard ", "Lush Tropical Forest ", "Dense Forest ", "Manmade Forest ", "Never Touched By Man Forest"
        };
        enum City
        {
            Crowcow,
            Warbore,
            Nest,
            YeOldeVillage,
            Peacefulvillage,
            Stayaway,
            Limanowa
        }
        List<string> CityDescription = new List<string>(7)
        {
            "Big City Cilled With Crowman. It is said that it was once Capital of Winged Cavalry Country.", "Defiled With War, Once Technology Based Metropoly, Now Fantasylike Medieval Village.",
            "Magicbased Birdman Village. Basically A Giant Tree In The Middle Of Nowhere With 2 Kilometers Diameter Nest On The Top.", "Ye Olde Ye Village Ye Founded By Ye Olde Ye Mayore",
            "Peacefulvillage was once founded by a very Peaceful Tribe. Now, Preparing For War With The Unknown.", "Borders Of This City Are Surrounded By Stay Away Signs. Very Hospitable People Live There.",
            "Smells Like Rasberries"
        };
        enum CavePrefix
        {
            Dark,
            Abandoned,
            Dangerous,
            Slimey,
            Flooded,
            Secret,
            Trecherous
        }
        List<string> CaveDescriptionPrefix = new List<string>(7)
        {
            "Prety Dark ", "Abandoned By Man ", "Filled With Traps ", "Covered With Sticky Goo ", "Filled With Water ", "Hidden Among The Woods ", "Filled With Unknown "
        };

        enum CaveMid
        {
            Wolf,
            Zombie,
            Gold,
            Slime,
            Bandit,
            Salt,
            ProjectManager
        }
        List<string> CaveDescriptionMid = new List<string>(7)
        {
            "Habitated By Wolfs", "Cursed With Undead Creatures", "Filled With Gold Ore", "Filled With Gooey Monsters", "Controlled By Bandits", "Filled With White Crystals", "Habitated By Project Manager"
        };

        enum CaveSuffix
        {
            Den,
            Nest,
            Hideout,
            Basement,
            Mine,
            Catacombs,
            Dungeon
        }
        List<string> CaveDescriptionSuffix = new List<string>(7)
        {
            "Den ", "Nest ", "Hideout ", "Underground Basement ", "Mine ", "Catacombs ", "Dungeon "
        };

        enum MountainPrefix
        {
            Mount,
            Mt,
            Peak,
        }

        List<string> MountainDescriptionPrefix = new List<string>(3)
        {
            "The High Mountain ", "The Short Mountain ", "The Peak " 
        };
        enum MountainSuffix
        {
            Celeste,
            Everest,
            Doom,
            Sniezka
        }

        List<string> MountainDescriptionMid = new List<string>(4)
        {
            "Of Unfulfilled Dream", "That Everyone Knows", "OF DOOM", "Covered In Snow"
        };

        public void checkMap()
        {
            if (Player.map == true)
            {
                for (int i = 0; i < mapsize; i++)
                {
                    for (int y = 0; y < mapsize; y++)
                    {
                        if (i == Map.GemX && y == Map.GemY && Player.GolemAlive == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        if (i == Player.x && y == Player.y)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        Console.Write(map[i, y].symbol);

                        Console.ForegroundColor = ConsoleColor.White;



                    }
                    if (i == 0)
                    {
                        Console.Write("    W");

                    }
                    if (i == 1)
                    {
                        Console.Write("   ASD");

                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < mapsize; i++)
                {
                    for (int y = 0; y < mapsize; y++)
                    {
                        
                        if ((Player.x - i == 0 || Player.x - i == 1 || Player.x - i == -1) &&( Player.y - y == 0 || Player.y - y == 1 || Player.y - y == -1))
                        {
                            
                            if (i == Player.x && y == Player.y)
                            { Console.ForegroundColor = ConsoleColor.Red; }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            Console.Write(map[i, y].symbol);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        

                        Console.Write("?");

                        Console.ForegroundColor = ConsoleColor.White;



                    }
                    if (i == 0)
                    {
                        Console.Write("    W");

                    }
                    if (i == 1)
                    {
                        Console.Write("   ASD");

                    }
                    Console.WriteLine();
                }


            }
        }
        
    }
}

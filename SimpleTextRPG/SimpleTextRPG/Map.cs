using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextRPG
{
    public class Map
    {
        public int mapsize;
        public Location[,] map;
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
                        int tmp = rand.Next(3);
                        char type = '*';
                        string name = "Invalid Location";
                        string prefix;
                        string mid;
                        string suffix;
                        switch (tmp)
                        {
                            case 0:
                                type = 'F';
                                tmp = rand.Next(7);
                                prefix = ((ForestPrefix)tmp).ToString();
                                tmp = rand.Next(7);
                                mid = ((ForestMid)tmp).ToString();
                                tmp = rand.Next(7);
                                suffix = ((ForestSuffix)tmp).ToString();

                                name = prefix + mid + suffix;

                                break;
                            case 1:
                                type = 'C';
                                tmp = rand.Next(7);
                                prefix = ((CavePrefix)tmp).ToString();
                                tmp = rand.Next(7);
                                mid = ((CaveMid)tmp).ToString();
                                tmp = rand.Next(7);
                                suffix = ((CaveSuffix)tmp).ToString();

                                name = prefix + mid + suffix;


                                break;
                            case 2:
                                type = 'V';
                                tmp = rand.Next(7);
                                prefix = ((City)tmp).ToString();

                                name = prefix;

                                break;
                            case 3:
                                type = 'M';
                                tmp = rand.Next(3);
                                prefix = ((MountainPrefix)tmp).ToString();
                                tmp = rand.Next(4);
                                mid = ((MountainSuffix)tmp).ToString();
                                name = prefix + mid;
                                break;
                        }

                        string desc = "Test";
                        map[i, y] = new Location(name, desc, type);
                    }
                }
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

        enum CaveSuffix
        {
            Den,
            Next,
            Hideout,
            Basement,
            Mine,
            Catacombs,
            Dungeon
        }

        enum MountainPrefix
        {
            Mount,
            Mt,
            Peak,
        }
        enum MountainSuffix
        {
            Celeste,
            Everest,
            Doom,
            Sniezka
        }

        public void checkMap()
        {
            for (int i = 0; i < mapsize; i++)
            {
                for (int y = 0; y < mapsize; y++)
                {
                    Console.Write(map[i, y].symbol);
                }
                Console.WriteLine();
            }
        }

        
    }
}

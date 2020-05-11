using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextRPG
{
    public class Player
    {
        int health = 100;
        int damage = 5;
        int defence = 5;
        int coins = 0;
        int level = 1;
        public int exp = 0;
        public static int x = 3;
        public static int y = 4;

        int RequiredExp()
        {
            return (level * 100 - exp);
        }

        public void gainExp(int expGained)
        {
            if (exp + expGained >= RequiredExp())
            {
                expGained = expGained - RequiredExp();
                level++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Level Up!");
                Console.ForegroundColor = ConsoleColor.White;
                exp = expGained;
            }

        }

        public void drawGui(Map map, int encounter = -1, Creature enemy = null)
        {
            char key = '0';
            int state = 0;
            if (enemy == null && encounter > 0)
            {
                enemy = new Creature("Debugger", 1, 1, 1);
            }

            if (x == 4 && y == 4)
            {
                state = 1;
            }
            else
            {
                if (encounter >0 )
                {
                    state = 2;
                }
                else
                {
                    state = 0;
                }
            }
            switch(state)
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

                    key = Console.ReadLine()[0];
                    switch (key)
                    {
                        case '1':
                            map.checkMap();
                            Console.ReadKey();
                            drawGui(map, encounter, enemy);
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

                            key = Console.ReadLine()[0];
                            switch (key)
                            {
                                case 'W': Player.x = Player.x - 1; break; // Ruch o 1 pole w górę
                                case 'S': Player.x = Player.x + 1; break; // Ruch o 1 pole w górę
                                case 'A': Player.y = Player.y - 1; break; // Ruch o 1 pole w górę
                                case 'D': Player.y = Player.y + 1; break; // Ruch o 1 pole w górę
                            }
                            drawGui(map, encounter, enemy);
                            break;
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
                    key = Console.ReadLine()[0];
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

                            key = Console.ReadLine()[0];
                            switch (key)
                            {
                                case 'W': Player.x = Player.x - 1; break; // Ruch o 1 pole w górę
                                case 'S': Player.x = Player.x + 1; break; // Ruch o 1 pole w górę
                                case 'A': Player.y = Player.y - 1; break; // Ruch o 1 pole w górę
                                case 'D': Player.y = Player.y + 1; break; // Ruch o 1 pole w górę
                            }
                            drawGui(map, encounter, enemy);
                            break;
                    }
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("==============================");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Wild " +  enemy.name + "(" + enemy.health + "/" + enemy.maxhealth + ") is waiting for your move!");
                    Console.WriteLine("1.Fight");
                    Console.WriteLine("2.Check");
                    Console.WriteLine("3.Defend");
                    Console.WriteLine("4.Check Inventory");
                    Console.WriteLine("5.Try running away");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("==============================");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;
            }
            
        }
    }

    public class Creature
    {
        public string name = "Unknown Creature";
        public int maxhealth = 20;
        public int health = 20;
        public int damage = 3;
        public int defence = 0;

        public Creature(string name, int health, int damage, int defence)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.defence = defence;
        }


    }


    enum CreatureList
    {
        Wolf,
        Bandit,
        Slime,
        Devil,
        Tutor,
        Demon        
    }

    enum RandomModifier
    {
        Devilish,
        Cursed,
        Mutant,
        Greedy,
        Bloodthirsty,
        Dyselextic,
        Thirsty,
        Hungry
    }
}

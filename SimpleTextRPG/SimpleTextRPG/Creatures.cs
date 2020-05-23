using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextRPG
{
    public static class Player
    {
        static public bool map = false;
        static public Item weaponequipped = new Item(-1);
        static public Item armorequipped = new Item(-2);
        static public Item ringequipped = new Item(-2);
        static public bool gemcontained = false;
        static public int maxhealth = 100;
        static public int health = 100;
        static public int damage = 5;
        static public int defence = 5;
        static public int speed = 5;
        static public int gold = 0;
        static public int level = 1;
        static public bool inshop = false;
        public static bool GameInProgress = true;
        public static int exp = 0;
        public static bool check = false;
        public static bool run = false;
        public static int x = 4;
        public static int y = 4;
        public static int encounter = -1;
        public static int levelup = 0;
        public static bool GolemAlive = true;
        public static Dictionary<Item, int> Inventory = new Dictionary<Item,int>();

        public static void UseInventory()
        {
            Console.WriteLine("");
            Console.WriteLine("You take a moment, checking your backpack content: ");
            foreach (KeyValuePair<Item, int> i in Player.Inventory)
            {

                if (i.Value != 0)
                {
                    GameModel.character = GameModel.KeyByValue(GameModel.Items, i.Key);
                    Console.Write(GameModel.character + ">>>" + i.Key.name);
                    if (i.Key.type == 1)
                    {
                        Console.Write(" --- Amount:" + i.Value);
                    }
                    else
                    if(i.Key.type == 2 && i.Key.equipped == true)
                    {
                        Console.Write(" --- Equipped ");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("X - Close  Backpack");
            char key = 'l';
            while (true)
            {
                string s = Console.ReadLine();
                if (!string.IsNullOrEmpty(s))
                {
                    key = s[0];

                    break;
                }

            }
            if (key == 'X' || key == 'x')
            {
            }
            else
            {
                while (true)
                {
                    Item q;
                    try
                    {
                        GameModel.Items.TryGetValue(char.ToUpper(key), out q);
                        q.Use();
                        break;
                    }
                    catch (Exception)
                    { }

                }
            }

        }
        public static int RequiredExp()
        {
            return (level * 100);
        }

        public static void gainExp(int expGained)
        {
            
            Player.exp = Player.exp + expGained;
            while (Player.exp  >= Player.RequiredExp())
            {
                Player.exp = Player.exp - Player.RequiredExp();
                Player.level++;
                Player.levelup = Player.levelup + 1;
 

            }

        }

        public static void LevelUp()
        {
            while (Player.levelup > 0)
            {
                Console.WriteLine("Damage +1");
                Player.damage = Player.damage + 1;
                Console.WriteLine("Max Health +5");
                Player.maxhealth = Player.maxhealth + 5;
                Player.health = Player.maxhealth;
                Player.levelup = Player.levelup - 1;
                Player.level = Player.level++;
            }
        }

        public static void RunAway()
        {

            int tmp = GameModel.EventRandomizerRnd.Next(25);
            if (tmp <= Player.speed)
            {
                Player.encounter = -8;
            }
            else
            {
                Player.run = true;
            }

        }
        public static void Attack()
        {
            if (Player.damage > Creature.defence)
            {
                Creature.health = Creature.health - (Player.damage - Creature.defence);
                if (Creature.health <= 0)
                {
                    Player.gold = Player.gold + Creature.goldreward;
                    Player.gainExp(Creature.xpreward);
                    if (Player.encounter == 666)
                    {
                        GolemAlive = false;
                        
                        Player.encounter = -666;
                    }
                    else
                    {
                        Player.encounter = 0;
                    }
                    
                   
                    
                }
            }
            else
            {
                Creature.health = Creature.health - 1;
                if (Creature.health <= 0)
                {
                    Player.gold = Player.gold + Creature.goldreward;
                    Player.gainExp(Creature.xpreward);
                    Player.encounter = 0;
                }
            }

        }

    }

    public static class Creature
    {
        public static string name = "Unknown Creature";
        public static int maxhealth = 20;
        public static int health = 20;
        public static int healing = 5;
        public static int damage = 3;
        public static int defence = 0;
        public static int chargeddamage = 5*damage;
        public static int xpreward = 5;
        public static int hurtTreshold = 1;
        
        public static int goldreward = 5;
        public static State stateofenemy = State.Idle;

        public static void Attack()
        {
            switch (Creature.stateofenemy)
            {
                case State.Idle:
                    if (Creature.damage > Player.defence)
                    {
                        Player.health = Player.health - (Creature.damage - Player.defence);
                        if (Player.health < 1)
                        {
                            Player.x = 4; Player.y = 4; Player.encounter = -42;
                        }
                    }
                    else
                    {
                        Player.health = Player.health - 1;
                        if (Player.health < 1)
                        {
                            Player.x = 4; Player.y = 4; Player.encounter = -42;
                        }
                    }
                    if (Creature.health < Creature.hurtTreshold)
                    {
                        Creature.stateofenemy = State.Healing;
                    }
                    else
                    {
                        int tmp = GameModel.EventRandomizerRnd.Next(100);
                        if (tmp < 75)
                        {
                            Creature.stateofenemy = State.Idle;
                        }
                        else
                        {
                            Creature.stateofenemy = State.Preparing;
                        }
                    }
                    break;
                case State.Preparing:
                    if (Creature.chargeddamage > Player.defence)
                    {
                        Player.health = Player.health - (Creature.chargeddamage - Player.defence);
                        if (Player.health < 1)
                        {
                            Player.x = 4; Player.y = 4; Player.encounter = -42;
                        }
                    }
                    else
                    {
                        Player.health = Player.health - 1;
                        if (Player.health < 1)
                        {
                            Player.x = 4; Player.y = 4; Player.encounter = -42;
                        }
                    }
                    if (Creature.health < Creature.hurtTreshold)
                    {
                        Creature.stateofenemy = State.Healing;
                    }
                    else
                    { Creature.stateofenemy = State.Idle; }
                    break;
                case State.Healing:
                    if (Creature.health + Creature.healing > Creature.maxhealth)
                    {
                        Creature.health = Creature.maxhealth;
                    }
                    else
                    {
                        Creature.health = Creature.health + Creature.healing;
                    }
                    if (Creature.health < Creature.hurtTreshold)
                    {
                        Creature.stateofenemy = State.Healing;
                    }
                    else
                    { Creature.stateofenemy = State.Idle; }


                    break;

            }
        }


        public enum State
        {
            Idle = 0,
            Attacking = 1,
            Preparing = 2,
            Healing = 3
        }
        public static List<string> CreatureState = new List<string>(3)
        {
            " is waiting for your move!","Debug message, shouldn't appear" ," is preparing heavy attack!", " is planning to rest!"
        };

        public static void InitializeBossFight()
        {
            Player.encounter = 666;
            Creature.name = "Gem Guardian (Boss)";
            Creature.maxhealth = 750;
            Creature.health = 750;
            Creature.hurtTreshold = 100;
            Creature.healing = 30;
            Creature.damage = 30;
            Creature.defence = 20;
            Creature.chargeddamage = 5 * Creature.damage;
            Creature.xpreward = 500;
            Creature.goldreward = 9001;
        }
        public static void Randomize()
        {
            string modifier = "";
            Random rnd = new Random();
            int mod = -1;
            int enemy = Convert.ToInt32(Math.Floor((decimal)rnd.Next(0, 10)));
            if(enemy > 5)
            {
                enemy = Convert.ToInt32(Math.Floor((decimal)rnd.Next(0, 8)));
                modifier = ((RandomModifier)enemy).ToString();
                modifier = string.Concat(modifier, " ");
                mod = enemy;

            }

            enemy = Convert.ToInt32(Math.Floor((decimal)rnd.Next(1, 6)));
            switch (enemy)
            {
                case 1:
                    name = string.Concat(modifier + "Wolf");
                    maxhealth = 15;
                    health = 15;
                    damage = 3;
                    defence = 0;
                    healing = 0;
                    hurtTreshold = -1;
                    chargeddamage = 5 * damage;
                    goldreward = 1;
                    xpreward = 20;
                    break;
                case 2:
                    name = string.Concat(modifier + "Bandit");
                    maxhealth = 45;
                    health = 45;
                    damage = 10;
                    defence = 5;
                    healing = 5;
                    hurtTreshold = 10;
                    chargeddamage = 5 * damage;
                    goldreward = 20;
                    xpreward = 60;
                    break;
                case 3:
                    name = string.Concat(modifier + "Slime");
                    maxhealth = 5;
                    health = 5;
                    damage = 1;
                    defence = 20;
                    healing = 0;
                    hurtTreshold = -1;
                    chargeddamage = 5 * damage;
                    goldreward = 0;
                    xpreward = 10;
                    break;
                case 4:
                    name = string.Concat(modifier + "Devil");
                    maxhealth = 70;
                    health = 70;
                    damage = 10;
                    defence = 10;
                    healing = 0;
                    hurtTreshold = -1;
                    chargeddamage = 5 * damage;
                    goldreward = 600;
                    xpreward = 200;
                    break;
                case 5:
                    name = string.Concat(modifier + "Tutor");
                    maxhealth = 20;
                    health = 20;
                    damage = 1;
                    healing = 20;
                    hurtTreshold = 5;
                    defence = 60;
                    chargeddamage = 5 * damage;
                    goldreward = 1200;
                    xpreward = 200;
                    break;
                case 6:
                    name = string.Concat(modifier + "Demon");
                    maxhealth = 35;
                    health = 35;
                    damage = 20;
                    healing = 5;
                    hurtTreshold = 10;
                    defence = 5;
                    chargeddamage = 5 * damage;
                    goldreward = 300;
                    xpreward = 120;
                    break;
                default:
                    throw new Exception("Wrong enemy ID");
            }
            switch(mod)
            {
                case 0:
                    damage = Convert.ToInt32(damage * 1.2);
                    break;
                case 1:
                    damage = Convert.ToInt32(damage * 1.1);
                    health = Convert.ToInt32(health * 0.8);
                    xpreward = Convert.ToInt32(xpreward * 1.1);
                    break;
                case 2:
                    damage = Convert.ToInt32(damage * 0.9);
                    health = Convert.ToInt32(health * 1.5);
                    xpreward = Convert.ToInt32(xpreward * 1.3);
                    break;
                case 3:
                    goldreward = Convert.ToInt32(damage * 3);
                    break;
                case 4:
                    damage = Convert.ToInt32(damage * 1.5);
                    health = Convert.ToInt32(health * 0.5);
                    xpreward = Convert.ToInt32(xpreward * 2);
                    break;
                case 5:
                    damage = Convert.ToInt32(damage * 0.8);
                    health = Convert.ToInt32(health * 0.5);
                    xpreward = Convert.ToInt32(xpreward * 0.2);
                    goldreward = Convert.ToInt32(goldreward * 0.2);
                    break;
                case 6:
                    health = Convert.ToInt32(health * 0.8);
                    break;
                case 7:
                    damage = Convert.ToInt32(health * 0.8);
                    break;
            }

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

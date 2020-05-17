using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextRPG
{
    public static class Player
    {
        static public int health = 100;
        static public int damage = 5;
        static public int defence = 5;
        static public int gold = 0;
        static public int level = 1;
        public static bool GameInProgress = true;
        public static int exp = 0;
        public static int x = 4;
        public static int y = 4;
        public static int encounter = 0;

        public static int RequiredExp()
        {
            return (level * 100 - exp);
        }

        public static void gainExp(int expGained)
        {
            while (exp + expGained >= RequiredExp())
            {
                expGained = expGained - RequiredExp();
                level++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Level Up!");
                Console.ForegroundColor = ConsoleColor.White;
                exp = expGained;
            }

        }
    



    }

    public static class Creature
    {
        public static string name = "Unknown Creature";
        public static int maxhealth = 20;
        public static int health = 20;
        public static int damage = 3;
        public static int defence = 0;
        public static int chargeddamage = 5*damage;
        public static int xpreward = 5;
        public static int goldreward = 5;
        public static State stateofenemy = State.Idle;


        public enum State
        {
            Idle = 0,
            Attacking = 1,
            Preparing = 2,
            Healing = 3
        }

        public static void Randomize()
        {
            string modifier = "";
            Random rnd = new Random();
            int mod = -1;
            int enemy = Convert.ToInt32(Math.Round((decimal)rnd.Next(0, 10)));
            if(enemy > 5)
            {
                enemy = Convert.ToInt32(Math.Round((decimal)rnd.Next(0, 8)));
                modifier = ((RandomModifier)enemy).ToString();
                modifier = string.Concat(modifier, " ");
                mod = enemy;

            }

            enemy = Convert.ToInt32(Math.Round((decimal)rnd.Next(0, 6)));
            switch (enemy)
            {
                case 1:
                    name = string.Concat(modifier + "Wolf");
                    maxhealth = 15;
                    health = 15;
                    damage = 3;
                    defence = 0;
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
                    chargeddamage = 5 * damage;
                    goldreward = 600;
                    xpreward = 200;
                    break;
                case 5:
                    name = string.Concat(modifier + "Tutor");
                    maxhealth = 20;
                    health = 20;
                    damage = 1;
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

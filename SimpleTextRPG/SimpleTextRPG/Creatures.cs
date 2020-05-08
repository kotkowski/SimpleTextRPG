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
        
        int RequiredExp()
        {
            return (level * 100 - exp);
        }

        public void gainExp(int expGained)
        {
            if(exp + expGained >= RequiredExp())
            {
                expGained =  expGained - RequiredExp();
                level++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Level Up!");
                Console.ForegroundColor = ConsoleColor.White;
                exp = expGained;
            }        

        }
    }

    class Wolf
    {
        int health = 20;
        int damage = 3;
        int defence = 0;
        int exp = 3;
    }
}

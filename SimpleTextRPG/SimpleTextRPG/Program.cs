using System;

namespace SimpleTextRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Map mapa = new Map(10);
            Console.WriteLine(mapa.Randomize(10));
            Player.gainExp(105);
            Console.WriteLine(Player.exp);
            GameModel.drawGui(mapa);


        }
    }
}


/*
 Plans to do next:
- Fixing some bugs
- Implementing Items
- Implementing Shops
- Implementing "Check Stats"
- Implementing Inns
- Implementing Story
- Implementing Fight
 */

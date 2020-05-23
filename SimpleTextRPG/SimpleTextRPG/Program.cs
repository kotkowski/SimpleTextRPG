using System;

namespace SimpleTextRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            GameModel.GameStart();
            Map mapa = new Map(10);
            GameModel.drawGui(mapa);


        }
    }
}


/*
 Plans to do next:
- Fixing some bugs
- Implementing Items
- Implementing Shops
- Implementing Inns
- Implementing Story
 */

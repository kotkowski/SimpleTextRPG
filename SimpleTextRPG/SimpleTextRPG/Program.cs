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
- Revamping Map Generation
- Categorizing monster spawn depending on location type
- Implementing Main Menu with Instructions
- Actually equipped gear printed along Player Stats
- Implementing Story
 */

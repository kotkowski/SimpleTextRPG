using System;

namespace SimpleTextRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Map mapa = new Map(10);
            Console.WriteLine(mapa.Randomize(10));
            Player gracz = new Player();
            gracz.gainExp(105);
            Console.WriteLine(gracz.exp);
            mapa.checkMap();
        }
    }
}

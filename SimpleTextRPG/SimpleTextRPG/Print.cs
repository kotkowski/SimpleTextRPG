using System;
using System.Collections.Generic;
using System.Text;
using SimpleTextRPGLogic;

namespace SimpleTextRPG
{
    class Print
    {
        public static void GameStart() //Inicjalizuje instancje obiektów, wywołuje główne menu i instrukcje (W.I.P)
        {

            GameModel.GameStart();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("============================================");
            Console.WriteLine("SSSSS   TTTTT   RRRR    PPPP    GGGGG       ");
            Console.WriteLine("S         T     R   R   P   P   G           ");
            Console.WriteLine("SSSSS     T     RRRRR   PPP     G  GG       ");
            Console.WriteLine("    S     T     R  R    P       G   G       ");
            Console.WriteLine("SSSSS     T     R   R   P       GGGGG       ");
            Console.WriteLine("============================================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("Hello There, Young Adventurer!");
            Console.WriteLine("You were summoned here for a reason!");
            Console.Write("Our Guardian God,");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Regoult");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" has gone mad and stolen our");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" Mana Gem");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("!");
            Console.WriteLine("");
            Console.WriteLine("Without it, our village will be destroyed within few months!");
            Console.Write("That's why we've summoned you. We want");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" YOU ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" to recover the gem and bring it back to our village.");
            Console.WriteLine("(Press Any Key to Continue)");
            Console.ReadKey();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Do you have any questions?");
                Console.WriteLine("");
                Console.WriteLine("1. No, let's get started already");
                Console.WriteLine("2. What about Locations?");
                Console.WriteLine("3. What about Gear?");
                Console.WriteLine("4. What about Personal Growth?");
                Console.WriteLine("5. What about True Love?");
                Console.WriteLine("6. What about Starting Gear?");
                Console.WriteLine("");
                string s = "";
                char key;
                while (true)
                {
                    s = Console.ReadLine();
                    if (!string.IsNullOrEmpty(s))
                    {
                        key = s[0];

                        break;
                    }

                }
                switch (key)
                {
                    case '1':
                        GameModel.Launch();
                        break;
                    case '2':
                        Console.WriteLine("Our beautiful World shifts in all kinds of ways.");
                        Console.WriteLine("Many generations of heroes came here prepared with maps,");
                        Console.WriteLine("sadly outdated due to process our world posseses.");
                        Console.WriteLine("Heroes used to call it Radum Genetation or something like that");
                        Console.WriteLine("But it was noticed that Village always is being kept in the center of the world");
                        Console.WriteLine("(Press any key to return)");
                        break;
                    case '3':
                        Console.WriteLine("Oh yes, Craftsmen of our Village makes best kind of equipment you can think of.");
                        Console.WriteLine("You want it for free?... Sorry, they need to feed their families too.");
                        Console.Write("Enemies you defeat?... Sorry, for unknown reason, any gear used by people of");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" this world,");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Magically converts itself into gold upon wielder's death.");
                        Console.WriteLine("(Press any key to return)");
                        break;
                    case '4':
                        Console.WriteLine("Oh yes, anyone summoned to this world, gets the blessing of our god. ");
                        Console.WriteLine("Yes, that one, who has gone mad...");
                        Console.WriteLine("Defeating enemies grants you essence, some heroes used to call");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Experience Points");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Upon collecting enough of them, heroes grow stronger and healthier.");
                        Console.WriteLine("Sadly their effect weakens upon consumption, requiring more of theese for growth");
                        Console.WriteLine("(Press any key to return)");
                        break;
                    case '5':
                        Console.WriteLine("Oh yes, the true love...");
                        Console.WriteLine("True love? There's world to be saved");
                        Console.WriteLine("There's no time for such a nonsense");
                        Console.WriteLine("(Press any key to return)");
                        break;
                    case '6':
                        switch(GameModel.FreeCoins())
                        {
                            case 1:
                                Console.WriteLine("Well, our village is pretty poor, but here, take some gold.");
                                Console.WriteLine("(Gained 20 gold coins)");
                                Console.WriteLine("(Press any key to return)");
                                break;
                            case 0:
                                Console.WriteLine("I just gave you some already...");
                                Console.WriteLine("(Press any key to return)");
                                break;
                        }
                       

                        break;
                }
                Console.ReadKey();
            }
        }
    }
}

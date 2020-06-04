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
                        
                        drawGui(GameModel.mapa);
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

        public static void drawGui(Map map) //Większość interakcji z użytkownikiem
        {


            char key = '0'; //Zmienna pomocnicza do wyborów
            
            string s = ""; //Zmienna pomocnicza do wyborów


            while (Player.GameInProgress)
            {
                Console.Clear();
                GameModel.CheckForBoss();
                    
               
                Console.WriteLine("");

                switch (Map.map[Player.x, Player.y].typ) //W zależności od współrzędnych gracza, rysuje miniaturowy obrazek przedstawiający lokalizacje
                {
                    case 'V':
                        if (Player.inshop == true) //Gracz znajduje się w mieście z aktywnym triggerem "inshop" (jest w sklepie)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            DrawShop();
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        else
                        { //Gracz znajduje się w wiosce, bez atywnego triggera "inshop" (jest poza sklepem)
                            DrawVillage();
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        break;
                    case 'F':
                        //Gracz znajduje się w lesie
                        Console.ForegroundColor = ConsoleColor.Green;
                        DrawForest();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 'C':
                        //Gracz znajduje się w jaskini
                        Console.ForegroundColor = ConsoleColor.Gray;
                        DrawCave();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 'M':
                        // Gracz znajduje się w górach
                        Console.ForegroundColor = ConsoleColor.Green;
                        DrawMountain();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default: throw new Exception("Unknown symbol"); //w przypadku nieprawidłowej lokacji, wyrzuca błąd
                }
                Console.WriteLine(); //Wypisuje pod obrazkiem lokacji nazwę i opis lokacji, te są losowo generowane w pliku Map.cs
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("==============================");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You're currently at ");
                Console.ForegroundColor = ConsoleColor.Green;
                
                if (Player.inshop)
                {
                    //Jeżeli gracz znajduje się w sklepie, przed nazwą miasta pojawi się napis "The Only Shop at", oraz nie zostanie wydrukowany opis
                    Console.WriteLine("The Only Shop at " + Map.map[Player.x, Player.y].name);
                }
                else
                {
                    Console.WriteLine(Map.map[Player.x, Player.y].name);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(Map.map[Player.x, Player.y].desc); ;

                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                if (Map.map[Player.x, Player.y].typ == 'V')
                {
                    // Jeżeli gracz znajduje się w wiosce (Gdzie losowe eventy nie mają miejsca), zostanie wyświetlony napis "You're safe"
                    Console.WriteLine("You're safe here!");
                }
                else if (Player.encounter == -1) //w innym wypadku, jeżeli gracz nie znajduje się w stanie wyjątkowym (opisane niżej), zostanie wylosowany event
                {
                    Console.WriteLine(GameModel.EventRandomizer());
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(GameModel.PlayerLevelUp());
                Console.ForegroundColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(GameModel.SpecialEvents());
                Console.ForegroundColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("==============================");
                Console.ForegroundColor = ConsoleColor.White;

                
                
                switch (GameModel.DetectState())
                {
                    case 0: //Stan 0, poza miastem, nie w walce - gracz może sprawdzić mapę, iść do innej lokacji lub użyć przedmiotu
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(Player.health + "/" + Player.maxhealth + "HP " + Player.damage + "DMG" + Player.defence + "DEF");
                        Console.WriteLine("Level " + Player.level + " (" + Player.exp + "/" + Player.RequiredExp() + " Exp) --- Gold: " + Player.gold);
                        Console.WriteLine("Weapon: " + Player.weaponequipped.name + " | Armor: " + Player.armorequipped.name + " | Ring: + " + Player.ringequipped.name);
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
                            case '1': // Wywołuje funkcje check map i czeka na wciśnięcie klawisza, po kliknięciu kontynuuje grę
                                map.checkMap();
                                Console.ReadKey();


                                break;
                            case '2': //Pyta o kierunek w który ma się udać gracz i go tam przenosi
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("==============================");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(Player.health + "/" + Player.maxhealth + "HP " + Player.damage + "DMG" + Player.defence + "DEF");
                                Console.WriteLine("Level " + Player.level + " (" + Player.exp + "/" + Player.RequiredExp() + " Exp) --- Gold: " + Player.gold);
                                Console.WriteLine("Weapon: " + Player.weaponequipped.name + " | Armor: " + Player.armorequipped.name + " | Ring: + " + Player.ringequipped.name);
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

                                while (true)
                                {
                                    s = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(s))
                                    {
                                        key = s[0];

                                        break;
                                    }

                                }
                                switch (Char.ToUpper(key))
                                {
                                    case 'W': GameModel.moveNorth(); break; // Ruch o 1 pole w górę
                                    case 'S': GameModel.moveSouth(); break; // Ruch o 1 pole w górę
                                    case 'A': GameModel.moveWest(); break; // Ruch o 1 pole w górę
                                    case 'D': GameModel.moveEast(); break; // Ruch o 1 pole w górę
                                   

                                }

                                break;
                            case '3': //Wywołuje funckję korzystania z ekwipunku

                                Player.UseInventory();
                                break;
                            default: break;
                        }

                        break;

                    case 1: //Stan 1 - Gracz znajduje się w mieście, ale nie w sklepie
                        // Może to co w stanie 0, a także odwiedzić tawernę (wyleczyć się za 5 złota)
                        // oraz odwiedzić sklep
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(Player.health + "/" + Player.maxhealth + "HP " + Player.damage + "DMG" + Player.defence + "DEF");
                        Console.WriteLine("Level " + Player.level + " (" + Player.exp + "/" + Player.RequiredExp() + " Exp) --- Gold: " + Player.gold);
                        Console.WriteLine("Weapon: " + Player.weaponequipped.name + " | Armor: " + Player.armorequipped.name + " | Ring: + " + Player.ringequipped.name);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("What will you do?");
                        Console.WriteLine("1.Check map");
                        Console.WriteLine("2.Move");
                        Console.WriteLine("3.Check Inventory");
                        Console.WriteLine("4.Visit Tavern (Recover HP for 5 gold)");
                        Console.WriteLine("5.Visit Shop");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        while (true)
                        {
                            s = Console.ReadLine();
                            if (!string.IsNullOrEmpty(s))
                            {
                                key = s[0];

                                break;
                            }

                        }
                        switch (Char.ToUpper(key))
                        {
                            case '1':
                                map.checkMap();
                                Console.ReadKey();
                                break;
                            case '2':
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("==============================");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(Player.health + "/" + Player.maxhealth + "HP " + Player.damage + "DMG" + Player.defence + "DEF");
                                Console.WriteLine("Level " + Player.level + " (" + Player.exp + "/" + Player.RequiredExp() + " Exp) --- Gold: " + Player.gold);
                                Console.WriteLine("Weapon: " + Player.weaponequipped.name + " | Armor: " + Player.armorequipped.name + " | Ring: + " + Player.ringequipped.name);
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
                                while (true)
                                {
                                    s = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(s))
                                    {
                                        key = s[0];

                                        break;
                                    }

                                }

                                switch (Char.ToUpper(key))
                                {
                                    case 'W': GameModel.moveNorth(); break; // Ruch o 1 pole w górę
                                    case 'S': GameModel.moveSouth(); break; // Ruch o 1 pole w górę
                                    case 'A': GameModel.moveWest(); break; // Ruch o 1 pole w górę
                                    case 'D': GameModel.moveEast(); break; // Ruch o 1 pole w górę


                                }
                                drawGui(map);
                                break;
                            case '3':
                                Player.UseInventory();
                                break;


                            case '4':
                                GameModel.Inn();
                                

                                break;
                            case '5': //Zmienia wartość znacznika "w sklepie", wywołując sklep w następnej iteracji DrawGui();
                                Player.inshop = true;
                                break;
                        }
                        break;
                    case 2: //Walka
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(Player.health + "/" + Player.maxhealth + "HP " + Player.damage + "DMG" + Player.defence + "DEF");
                        Console.WriteLine("Level " + Player.level + " (" + Player.exp + "/" + Player.RequiredExp() + " Exp) --- Gold: " + Player.gold);
                        Console.WriteLine("Weapon: " + Player.weaponequipped.name + " | Armor: " + Player.armorequipped.name + " | Ring: + " + Player.ringequipped.name);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Wild " + Creature.name + "(" + Creature.health + "/" + Creature.maxhealth + ") is " + Creature.CreatureState[(int)Creature.stateofenemy]);
                        
                        if (Player.run == true)
                        { //Jeżeli gracz w poprzedniej turze próbował uciec i mu się nie udało, wyświetli odpowiedni komunikat
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You've failed to run away!");
                            Player.run = false;
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        if (Player.check == true)
                        { // Jeżeli gracz w poprzedniej turze wybrał opcję "sprawdź przeciwnika", wyświetlą się dokładne statystyki
                            Console.WriteLine("==============================");
                            Console.WriteLine(Creature.name);
                            Console.WriteLine(Creature.health + "/" + Creature.maxhealth);
                            Console.WriteLine(Creature.damage + " DMG " + Creature.defence + " DEF");
                            Console.WriteLine(Creature.xpreward + " XP and " + Creature.goldreward + " gold upon defeating");
                            Console.WriteLine("==============================");
                            Player.check = false;
                        }
                        Console.WriteLine("What will you do?");
                        Console.WriteLine("1.Fight (Deal (" + Player.damage + " - Enemy Defence) damage to your enemy");
                        Console.WriteLine("2.Check (Check your enemy stats)");
                        Console.WriteLine("3.Defend (Reduce incoming damage by (" + 5 * Player.defence + "))");
                        Console.WriteLine("4.Inventory");
                        Console.WriteLine("5.Try running away (Roll (" + Player.speed + ") in 25 chance, trying to escape)");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;

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
                            case '1': Player.Attack(); Creature.Attack(); break; // Powybraniu 1, gracz zaatakuje
                            case '2': Player.check = true; Creature.Attack(); break; //Po wygraniu 2, trigger "sprawdzajacy" zostanie aktywowany
                            case '3': GameModel.Defend(); Creature.Attack(); GameModel.Defend(); break;
                            // Po wybraniu 3, obrona gracza wzrośnie pięciokrotnie na 1 turę 
                            // Przeznaczenie - gdy przeciwnik szykuje ciężki atak
                            case '4': //Po wybraniu 4, gracz może użyć ekwipunku,
                                Player.UseInventory();
                                break;
                            case '5': Player.RunAway(); Creature.Attack(); break; //Gracz próbuje uciekać
                            default: break;
                        }
                        break;
                    case 4: //Koniec gry
                        if (Player.gemhunger == 25)
                        {
                            //TBA Alternative credits
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("==============================");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(Player.health + "/" + Player.maxhealth + "HP " + Player.damage + "DMG" + Player.defence + "DEF");
                            Console.WriteLine("Level " + Player.level + " (" + Player.exp + "/" + Player.RequiredExp() + " Exp) --- Gold: " + Player.gold);
                            Console.WriteLine("Weapon: " + Player.weaponequipped.name + " | Armor: " + Player.armorequipped.name + " | Ring: + " + Player.ringequipped.name);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("==============================");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Is this?... The Legendary Gem!");
                            Console.WriteLine("You did it! You've...");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("(Gem jumps out of your hand landing on the ground)");
                            Console.WriteLine("(Gem starts absorbing ground, rising and forming into golem)");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Name... Regoult... ");
                            Console.WriteLine("You've let me... Return...");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("(Golem looks at you gratefully, then rises into the sky, observing)");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("What have you done?! Without Golem trapped our Village will be in even greater danger!");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You don't deserve my protection. Trapping your god? Fools.");
                            Console.WriteLine("You don't deserve his help either. Be free human.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("==============================");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("================================================================");
                            Console.WriteLine("");
                            Console.WriteLine("=====   =====   ==  =   =====  ======   =====   =====   =====   ");
                            Console.WriteLine("=       =   =   = = =   =      =    =   =   =     =        =    ");
                            Console.WriteLine("=       =   =   = = =   = ===  ======   =====     =      =      ");
                            Console.WriteLine("=       =   =   = = =   =   =  =  =     =   =     =     =       ");
                            Console.WriteLine("=====   =====   =  ==   =====  =   =    =   =     =     =====   ");
                            Console.WriteLine("");
                            Console.WriteLine("=================================================================");
                            Console.WriteLine(""); Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("The Good Ending");
                            Console.WriteLine("");
                            Console.Write("Press ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("F");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("to exit");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("==============================");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(Player.health + "/" + Player.maxhealth + "HP " + Player.damage + "DMG" + Player.defence + "DEF");
                            Console.WriteLine("Level " + Player.level + " (" + Player.exp + "/" + Player.RequiredExp() + " Exp) --- Gold: " + Player.gold);
                            Console.WriteLine("Weapon: " + Player.weaponequipped.name + " | Armor: " + Player.armorequipped.name + " | Ring: + " + Player.ringequipped.name);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("==============================");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Is this?... The Legendary Gem!");
                            Console.WriteLine("You did it! You've saved the world!");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("==============================");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("======================================");
                            Console.WriteLine("");
                            Console.WriteLine("==== === === = ==  === === ==== ===  ?");
                            Console.WriteLine("=    = = = = = = = = = = =  =    =   ?");
                            Console.WriteLine("==== === = === === = = = =  =   ===  ?");
                            Console.WriteLine("");
                            Console.WriteLine("======================================");
                            Console.WriteLine(""); Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("(Press ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("F");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("to exit)");

                            while (true)
                            {
                                s = Console.ReadLine();
                                if (!string.IsNullOrEmpty(s))
                                {
                                    key = s[0];

                                    break;
                                }

                            }
                            switch (char.ToUpper(key))
                            {
                                case 'F':
                                    Environment.Exit(0);
                                    break;
                            }
                        }
                        break;
                    case 100:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(Player.health + "/" + Player.maxhealth + "HP " + Player.damage + "DMG" + Player.defence + "DEF");
                        Console.WriteLine("Level " + Player.level + " (" + Player.exp + "/" + Player.RequiredExp() + " Exp) --- Gold: " + Player.gold);
                        Console.WriteLine("Weapon: " + Player.weaponequipped.name + " | Armor: " + Player.armorequipped.name + " | Ring: + " + Player.ringequipped.name);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Hello There!");
                        Console.WriteLine("Do you need anything?");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Buy gear:");

                        //Wyświetla wszystkie instancje przedmiotów oraz ich ceny, za wyjątkiem kryształu 
                        
                        foreach (KeyValuePair<char, Item> i in GameModel.Items)
                        {
                            if (i.Key != 'L' && i.Key != 'M' && i.Key != 'N')
                                Console.WriteLine(i.Key + ">>>" + i.Value.name + " --- " + i.Value.price + " gold");


                        }


                        Console.WriteLine("X.Leave Shop");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        while (true)
                        {
                            s = Console.ReadLine();
                            if (!string.IsNullOrEmpty(s))
                            {
                                key = s[0];

                                break;
                            }

                        }
                        
                        GameModel.Buy(key);
                        

                        break;
                    default: drawGui(map); break;

                }
            }
        }
        public static void DrawShop() // Generuje miniobraz zza lady w trakcie wizyty w sklepie
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("=====");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("######");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("5");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("=======");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("^^^^^^^");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("=====");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("===========");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("5");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("======");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("/==");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("O");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("O");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("=L");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("====");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("7777777");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("=====");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("$");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("/====");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("V");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("====L");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("===");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("====");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("7777");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("=====");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("$");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("/===========L");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("==");
            Console.WriteLine();
        }
        static public void DrawForest() //Generuje obrazek lasu w lokacjach z lasem
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@@@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("O");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("===");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("=========");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("=====");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("=");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@@");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@@@");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("====");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@@");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("===");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("=");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("^^");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("===");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("====");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("====");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("==");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("^^^^");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("===");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("===");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("^^^");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("====");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("===");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("=");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("===");
            Console.WriteLine("");
        }
        public static void DrawVillage()//Generuje obrazek wioski w wiosce
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("===");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("///");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@@@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("=");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("///");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("===");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("//////");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("====");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("===");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("|$|");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("=");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@@");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@@");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("|=|");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("=");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("|==");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("<>");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("====");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("===");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("|=|");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("===");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("|=|");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("===");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("|$=");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("<>");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("====");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("===");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("|$|");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("===");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("|$|");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("===");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("|$===|");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("====");
            Console.WriteLine("");
        }

        public static void DrawCave()//Generuje obrazek jaskiń w lokacjach z jaskiniami
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("*****");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("====================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("&");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("=");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("****");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("*******");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("&");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("========");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("(G) (G)");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("***");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("*******");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("===================");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("****");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("=");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("======================");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("****");
            Console.WriteLine("");
        }

        public static void DrawMountain()//Generuje obrazek gór w lokacjach z górami
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("=======");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("//////////");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("=========");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("@@@@");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("=");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("=====");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("//////////////");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("=====");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("@@@@@");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("==");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("===");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("//////////////////");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("==========");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("=");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("/////////////////////");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("=========");
            Console.WriteLine("");
        }
    }


}


 
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextRPG
{
    public static class GameModel
    {

        public static Dictionary<char, Item> Items = new Dictionary<char, Item>(50);
        public static char character;

        public static T KeyByValue<T, W>(this Dictionary<T, W> dict, W val) // Funkcja która posiadając wartość ze słownika, zwróci ID pierwszego napotkanego klucza (używane przy przedmiotach)
        {
            T key = default;
            foreach (KeyValuePair<T, W> pair in dict)
            {
                if (EqualityComparer<W>.Default.Equals(pair.Value, val))
                {
                    key = pair.Key;
                    break;
                }
            }
            return key;
        }

        public static void GameStart() //Inicjalizuje instancje obiektów, wywołuje główne menu i instrukcje (W.I.P)
        {
            
            Items.Add('1', new Item(1));
            Items.Add('2', new Item(2));
            Items.Add('3', new Item(3));
            Items.Add('4', new Item(4));
            Items.Add('5', new Item(8));
            Items.Add('6', new Item(10));
            Items.Add('7', new Item(11));
            Items.Add('8', new Item(12));
            Items.Add('9', new Item(13));
            Items.Add('Q', new Item(14));
            Items.Add('M', new Item(15));
            Items.Add('W', new Item(20));
            Items.Add('E', new Item(21));
            Items.Add('R', new Item(22));
            Items.Add('T', new Item(23));
            Items.Add('Y', new Item(24));
            Items.Add('N', new Item(25));
            Items.Add('U', new Item(30));
            Items.Add('I', new Item(31));
            Items.Add('O', new Item(32));
            Items.Add('P', new Item(33));
            Items.Add('L', new Item(100));
            Player.Inventory.Add(new Item(1), 0);
            Player.Inventory.Add(new Item(2), 0);
            Player.Inventory.Add(new Item(3), 0);
            Player.Inventory.Add(new Item(4), 0);
            Player.Inventory.Add(new Item(8), 0);
            Player.Inventory.Add(new Item(10), 0);
            Player.Inventory.Add(new Item(11), 0);
            Player.Inventory.Add(new Item(12), 0);
            Player.Inventory.Add(new Item(13), 0);
            Player.Inventory.Add(new Item(14), 0);
            Player.Inventory.Add(new Item(15), 0);
            Player.Inventory.Add(new Item(20), 0);
            Player.Inventory.Add(new Item(21), 0);
            Player.Inventory.Add(new Item(22), 0);
            Player.Inventory.Add(new Item(23), 0);
            Player.Inventory.Add(new Item(24), 0);
            Player.Inventory.Add(new Item(25), 0);
            Player.Inventory.Add(new Item(30), 0);
            Player.Inventory.Add(new Item(31), 0);
            Player.Inventory.Add(new Item(32), 0);
            Player.Inventory.Add(new Item(33), 0);
            
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
            Console.WriteLine("(Press Any Key to Continue");
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
                        Map mapa = new Map(10);
                        GameModel.drawGui(mapa);
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
                        Console.WriteLine("this world,");
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
                        if(!Player.startinggear)
                        {
                            Console.WriteLine("Well, our village is pretty poor, but here, take some gold.");
                            Console.WriteLine("(Gained 20 gold coins)");
                            Console.WriteLine("(Press any key to return)");
                            Player.gold = Player.gold + 20;
                            Player.startinggear = true;
                        }
                        else
                        {
                            Console.WriteLine("I just gave you some already...");
                            Console.WriteLine("(Press any key to return)");
                        }
                        
                        break;
                }
                Console.ReadKey();
            }
        }

        public static char translateId(int id) 
            //Używając ID przedmiotu z Items.cs zwraca klawisz z inicjalizacji w GameStart() - "Droga na około" żeby ominąć błędy kompatybilności funkcji
        {
            char key = 'l';
            switch (id)
            {
                case 1:
                    key = '1';
                    break;
                case 2:
                    key = '2';
                    break;
                case 3:
                    key = '3';
                    break;
                case 4:
                    key = '4';
                    break;
                case 8:
                    key = '5';
                    break;
                case 10:
                    key = '6';
                    break;
                case 11:
                    key = '7';
                    break;
                case 12:
                    key = '8';
                    break;
                case 13:
                    key = '9';
                    break;
                case 14:
                    key = 'Q';
                    break;
                case 20:
                    key = 'W';
                    break;
                case 21:
                    key = 'E';
                    break;
                case 22:
                    key = 'R';
                    break;
                case 23:
                    key = 'T';
                    break;
                case 24:
                    key = 'Y';
                    break;
                case 30:
                    key = 'U';
                    break;
                case 31:
                    key = 'I';
                    break;
                case 32:
                    key = 'O';
                    break;
                case 33:
                    key = 'P';
                    break;
            }
            return key;
        }
        public static Random EventRandomizerRnd = new Random(); //Zmienna losująca używana w kilku funkcjach
        public static void EventRandomizer()
            //Wywołuje losowy event:
            // 50% - nic się nie stało
            // 1% - Wywołuje walkę z potężnym przeciwnikiem (praktycznie nie do pokonania bez odpowiedniego grindu
            //24% - "Znalazłeś 20 złota"
            // 25% - Wywołuje walkę z losowym przeciwnikiem
        {
            int tmp = EventRandomizerRnd.Next(100);
            if (tmp < 50)
            {
                Console.WriteLine("Nothing happened during your journey");
            }
            else
            if (tmp == 75)
            {
                //Ustanawia statystyki Przeciwnika
                Player.encounter = 100;
                Creature.name = "Cursed Elite RNG Cursed (Mini-Boss) (Better Run Away)";
                Creature.maxhealth = 20000;
                Creature.health = 20000;
                Creature.hurtTreshold = 100;
                Creature.healing = 100;
                Creature.damage = 200;
                Creature.defence = 100;
                Creature.chargeddamage = 5 * Creature.damage;
                Creature.xpreward = 5000;
                Creature.goldreward = 9001;
            }
            else
                if (tmp >= 50 && tmp < 75)
            {
                Console.WriteLine("You've found some gold!");
                Player.gold = Player.gold + 20;
            }
            else
                if (tmp > 75)
            {
                Player.encounter = 2;
                Creature.Randomize();
                Console.WriteLine("You've encountered a wild " + Creature.name + "!");
            }



        }
        public static void drawGui(Map map) //Większość interakcji z użytkownikiem
        {


            char key = '0'; //Zmienna pomocnicza do wyborów
            int state = 0; // Zmienna ustalająca stan gracza bazując na kilku czynnikach opisanych niżej, w momencie przypisania
            string s = ""; //Zmienna pomocnicza do wyborów


            while (Player.GameInProgress)
            {
                Console.Clear();
                if (Player.x == Map.GemX && Player.y == Map.GemY) 
                {
                    if (Player.encounter != 666 && Player.GolemAlive != false)
                    {
                        Creature.InitializeBossFight(); //Jeżeli gracz znajduje się na współrzędnych klejnotu, inicjalizuje walkę z bossem
                    }
                }
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
                { EventRandomizer(); }

                if (Player.levelup > 0)
                    //Jeżeli gracz zdobył jakiś poziom, zostanie wyświetlona informacja oraz wywołana funkcja LevelUp, 
                    //podnosząca statystyki i lecząca gracza
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You've reached a new level!");
                    Console.WriteLine("You are fully healed and your stats increase!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Player.LevelUp();
                }


                switch (Player.encounter) //Stany wyjątkowe
                {
                    case 0: //Stan 0 - Walka (ze zwykłym wrogiem) zakończona w tym momencie, gracz otrzymuje nagrodę w XP oraz złocie
                        Console.ForegroundColor = ConsoleColor.White;
                        if(Player.PowerSuit == true)
                        {
                            Console.WriteLine("You've found the Power Suit from Another World!");
                            Item.AddItem(25);
                            if(Player.gemcontained && Player.gemhunger < 25)
                            {
                                Console.WriteLine("Gem starts shaking violently in the presence of defeated enemy");
                                
                                if (Player.gemhunger < 25)
                                { Console.WriteLine("You hear a whisper || I want more ||");
                                    Player.gemhunger = Player.gemhunger + 1;
                                }
                                    
                                else
                                {
                                    Console.WriteLine("You hear a whisper || I am ready... Bring me to the village ||");
                                }
                            }
                            Player.PowerSuit = false;
                        }
                        if(Player.Gunner == true)
                        {
                            if (Player.gemcontained )
                            {
                                Console.WriteLine("Gem starts shaking violently in the presence of defeated enemy");
                                if (Player.gemhunger < 25)
                                {
                                    Console.WriteLine("You hear a whisper || I want more ||");
                                    Player.gemhunger = Player.gemhunger + 1;
                                }

                                else
                                {
                                    Console.WriteLine("You hear a whisper || I am ready... Bring me to the village ||");
                                }
                            }
                            Console.WriteLine("You've found the Assault Rifle from Another World!");
                            Item.AddItem(15);
                            Player.Gunner = false;
                        }
                        Console.WriteLine("You've defeated " + Creature.name + "!");
                        Console.WriteLine("You've gained " + Creature.xpreward + " xp and " + Creature.goldreward + " gold!");
                        Player.encounter = -1;
                        break;
                    case -8: //Stan -8 - Walka zakończona ucieczką, gracz otrzymuje informacje o udanej ucieczce, walka się kończy
                        Player.encounter = -1;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You've run away");
                        Player.run = false;
                        break;
                    case -15: //Stan -15, wyświetlany w sklepie, jeżeli gracz spróbuje zakupić drugą kopię unikalnych przedmiotów (ekwipunek, mapa etc)
                        Player.encounter = -1;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("A black tentacle reaches out from your backpack and consumes the item you just bought.");
                        Console.WriteLine("Seems like it likes duplicated items.");
                        Player.consumedInventory = Player.consumedInventory + 1;
                        Player.run = false;
                        break;
                    case -24: //Stan -24, wyświetlany w sklepie lub przy wizycie w karczmie, jeżeli gracza na to nie stać
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You don't have enough money!");
                        Player.encounter = -1;
                        break;
                    case -42: //Stan -42, wyświetlany w momencie śmierci - gracz traci 20% monet i zostaje przywrócony do miasta
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You took too much damage. You lost your consciousness.");
                        Console.WriteLine("Yet somehow, you made it back to the city, losing some coins.");
                        Player.health = Player.maxhealth;
                        Player.run = false;
                        Player.gold = (int)Math.Round(Player.gold * 0.8);
                        Player.encounter = -1;
                        break;
                    case -80:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(Player.checkedItem);
                        Player.encounter = -1;
                        
                        break;

                    case -666: //Stan -666, wyświetlany w momencie śmierci bossa w lokacji klejnotu. Dodaje klejnot do ekwipunku gracza
                        Player.encounter = -1;
                        Player.gemcontained = true;
                        Player.Inventory.Add(new Item(100), 1);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You've defeated " + Creature.name + "!");
                        Console.WriteLine("You've aquired the Legendary Gem! ");
                        Console.WriteLine("Bring it to the Village! ");
                        Console.WriteLine("You've gained " + Creature.xpreward + " xp and " + Creature.goldreward + " gold!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    
                    default: break;
                }


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("==============================");
                Console.ForegroundColor = ConsoleColor.White;
                //Poniższy kod ustanawia stan gracza - stan decyduje o tym, jakie wybory zostaną wyświetlone,
                // oraz czy ma być losowany nowy event
                if (Player.inshop == true) //Jeżeli gracz ma włączony stan "w sklepie" - w normalnych okolicznościach może być wywołany tylko w mieście
                {
                    state = 100;
                }
                else
                if (Player.x == 4 && Player.y == 4) //Jeżeli gracz znajduje się w mieście (gwarantowane na koordynatach 5,5-  czyli 4,4 licząc od 0)
                {
                    if (Player.gemcontained == true) //jeżeli gracz przejął kryształ (pokonał finałowego bossa) i jest w wiosce, ustaw stan 4
                    {
                        state = 4;
                    }
                    else
                    {
                        state = 1; //Jeżeli gracz znajduje się w mieście
                    }
                }
                else
                {
                    if (Player.encounter > 0) //Jeżeli "encounter" jest większy od 0 - czyli gracz znajduje się w bitwie
                    {
                        state = 2;
                    }
                    else // Jeżeli żaden z tych stanów nie miał miejsca
                    {
                        state = 0;
                    }
                }
                switch (state)
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
                                switch (key)
                                {
                                    case 'W': if (Player.x != 0) Player.x = Player.x - 1; break; // Ruch o 1 pole w górę
                                    case 'S': if (Player.x != (Map.mapsize - 1)) Player.x = Player.x + 1; break; // Ruch o 1 pole w górę
                                    case 'A': if (Player.y != 0) Player.y = Player.y - 1; break; // Ruch o 1 pole w górę
                                    case 'D': if (Player.y != (Map.mapsize - 1)) Player.y = Player.y + 1; break; // Ruch o 1 pole w górę
                                    case 'w': if (Player.x != 0) Player.x = Player.x - 1; break; // Ruch o 1 pole w górę
                                    case 's': if (Player.x != (Map.mapsize - 1)) Player.x = Player.x + 1; break; // Ruch o 1 pole w górę
                                    case 'a': if (Player.y != 0) Player.y = Player.y - 1; break; // Ruch o 1 pole w górę;
                                    case 'd': if (Player.y != (Map.mapsize - 1)) Player.y = Player.y + 1; break; // Ruch o 1 pole w górę;

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

                                switch (key)
                                {
                                    case 'W': if (Player.x != 0) Player.x = Player.x - 1; break; // Ruch o 1 pole w górę
                                    case 'S': if (Player.x != (Map.mapsize - 1)) Player.x = Player.x + 1; break; // Ruch o 1 pole w górę
                                    case 'A': if (Player.y != 0) Player.y = Player.y - 1; break; // Ruch o 1 pole w górę
                                    case 'D': if (Player.y != (Map.mapsize - 1)) Player.y = Player.y + 1; break; // Ruch o 1 pole w górę
                                    case 'w': if (Player.x != 0) Player.x = Player.x - 1; break; // Ruch o 1 pole w górę
                                    case 's': if (Player.x != (Map.mapsize - 1)) Player.x = Player.x + 1; break; // Ruch o 1 pole w górę
                                    case 'a': if (Player.y != 0) Player.y = Player.y - 1; break; // Ruch o 1 pole w górę;
                                    case 'd': if (Player.y != (Map.mapsize - 1)) Player.y = Player.y + 1; break; // Ruch o 1 pole w górę;
                                    default: break;
                                }
                                drawGui(map);
                                break;
                            case '3':
                                Player.UseInventory();
                                break;


                            case '4': if (Player.gold > 5) //Jeżeli gracz ma wystarczająco złota, leczy go, w innym wypadku wywołuje encounter -24 (za mało złota)
                                {
                                    Player.gold = Player.gold - 5;
                                    Player.health = Player.maxhealth;
                                }
                                else
                                {
                                    Player.encounter = -24;
                                }

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
                            case '3': Player.defence = Player.defence * 5; Creature.Attack(); Player.defence = Player.defence / 5; break;
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
                            Console.Write("Press ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("F");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("to exit");

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
                        foreach (KeyValuePair<char, Item> i in Items)
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
                        Item q = new Item(1);

                        switch (key)
                        {
                            //Bardzo nieprawidłowa forma kupowania przedmiotów,
                            //później zauważyłem możliwość redukcji objętości kodu o +- 1/3 
                            //poprzez użycie char.ToUpper, ale dodatkowa praca nie wpłynęłaby na optymalizację wydajności
                            case '1': Items.TryGetValue('1', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(1); } else { Player.encounter = -24; }; break;
                            case '2': Items.TryGetValue('2', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(2); } else { Player.encounter = -24; }; break;
                            case '3': Items.TryGetValue('3', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(3); } else { Player.encounter = -24; }; break;
                            case '4': Items.TryGetValue('4', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(4); } else { Player.encounter = -24; }; break;
                            case '5': Items.TryGetValue('5', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(8); } else { Player.encounter = -24; }; break;
                            case '6': Items.TryGetValue('6', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(10); } else { Player.encounter = -24; }; break;
                            case '7': Items.TryGetValue('7', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(11); } else { Player.encounter = -24; }; break;
                            case '8': Items.TryGetValue('8', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(12); } else { Player.encounter = -24; }; break;
                            case '9': Items.TryGetValue('9', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(13); } else { Player.encounter = -24; }; break;
                            case 'Q': Items.TryGetValue('Q', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(14); } else { Player.encounter = -24; }; break;
                            case 'q': Items.TryGetValue('Q', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(14); } else { Player.encounter = -24; }; break;
                            case 'W': Items.TryGetValue('W', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(20); } else { Player.encounter = -24; }; break;
                            case 'w': Items.TryGetValue('W', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(20); } else { Player.encounter = -24; }; break;
                            case 'E': Items.TryGetValue('E', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(21); } else { Player.encounter = -24; }; break;
                            case 'e': Items.TryGetValue('E', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(21); } else { Player.encounter = -24; }; break;
                            case 'R': Items.TryGetValue('R', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(22); } else { Player.encounter = -24; }; break;
                            case 'r': Items.TryGetValue('R', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(22); } else { Player.encounter = -24; }; break;
                            case 'T': Items.TryGetValue('T', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(23); } else { Player.encounter = -24; }; break;
                            case 't': Items.TryGetValue('T', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(23); } else { Player.encounter = -24; }; break;
                            case 'Y': Items.TryGetValue('Y', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(24); } else { Player.encounter = -24; }; break;
                            case 'y': Items.TryGetValue('Y', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(24); } else { Player.encounter = -24; }; break;
                            case 'U': Items.TryGetValue('U', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(30); } else { Player.encounter = -24; }; break;
                            case 'u': Items.TryGetValue('U', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(30); } else { Player.encounter = -24; }; break;
                            case 'I': Items.TryGetValue('I', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(31); } else { Player.encounter = -24; }; break;
                            case 'i': Items.TryGetValue('I', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(31); } else { Player.encounter = -24; }; break;
                            case 'O': Items.TryGetValue('O', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(32); } else { Player.encounter = -24; }; break;
                            case 'o': Items.TryGetValue('O', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(32); } else { Player.encounter = -24; }; break;
                            case 'P': Items.TryGetValue('P', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(33); } else { Player.encounter = -24; }; break;
                            case 'p': Items.TryGetValue('P', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(33); } else { Player.encounter = -24; }; break;
                            case 'X': Player.inshop = false; break;
                            case 'x': Player.inshop = false; break;


                        }

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

using System;
using System.Collections.Generic;
using System.Text;
using SimpleTextRPGLogic;

namespace SimpleTextRPGLogic
{
    public static class GameModel
    {
        public static Map mapa = new Map(10);
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
            Player.Inventory.Add(new Item(100), 0);


        }






        public static int FreeCoins()
        {
            if (!Player.startinggear)
            {

                Player.gold = Player.gold + 20;
                Player.startinggear = true;
                return 1;
            }
            else
            {

                return 0;
            }
        }

        public static Random EventRandomizerRnd = new Random(); //Zmienna losująca używana w kilku funkcjach
        public static string EventRandomizer()
        //Wywołuje losowy event:
        // 50% - nic się nie stało
        // 1% - Wywołuje walkę z potężnym przeciwnikiem (praktycznie nie do pokonania bez odpowiedniego grindu
        //24% - "Znalazłeś 20 złota"
        // 25% - Wywołuje walkę z losowym przeciwnikiem
        {
            int tmp = EventRandomizerRnd.Next(100);
            if (tmp < 50)
            {
                return "Nothing happened during your journey";
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
                return "You are being hunted by powerful enemy.";
            }
            else
                if (tmp >= 50 && tmp < 75)
            {

                Player.gold = Player.gold + 20;
                return "You've found some gold!";
            }
            else

            {
                Player.encounter = 2;
                Creature.Randomize();
                return "You've encountered a wild " + Creature.name + "!";
            }






        }
        public static void CheckForBoss()
        {
            if (Player.x == Map.GemX && Player.y == Map.GemY)
            {
                if (Player.encounter != 666 && Player.GolemAlive != false)
                {
                    Creature.InitializeBossFight(); //Jeżeli gracz znajduje się na współrzędnych klejnotu, inicjalizuje walkę z bossem
                }
            }
        }

        public static string PlayerLevelUp()
        {
            if (Player.levelup > 0)
            //Jeżeli gracz zdobył jakiś poziom, zostanie wyświetlona informacja oraz wywołana funkcja LevelUp, 
            //podnosząca statystyki i lecząca gracza
            {

                Player.LevelUp();
                return "You've reached a new level! You are fully healed and your stats increase!";
            }
            return " ";
        }

        public static string SpecialEvents()
        {
            switch (Player.encounter) //Stany wyjątkowe
            {
                case 0: //Stan 0 - Walka (ze zwykłym wrogiem) zakończona w tym momencie, gracz otrzymuje nagrodę w XP oraz złocie
                    if (Player.PowerSuit == true)
                    {

                        Item.AddItem(25);
                        if (Player.gemcontained && Player.gemhunger < 25)
                        {


                            if (Player.gemhunger < 25)
                            {
                                Player.encounter = -1;
                                Player.gemhunger = Player.gemhunger + 1;
                                return "You've defeated " + Creature.name + "! Gem starts shaking violently in the presence of defeated enemy. You hear a whisper || I want more || You've gained " + Creature.xpreward + " xp and " + Creature.goldreward + " gold!";
                            }

                            else
                            {
                                Player.encounter = -1;
                                return "You've defeated " + Creature.name + "! You hear a whisper || I am ready... Bring me to the village || You've gained " + Creature.xpreward + " xp and " + Creature.goldreward + " gold!";
                            }
                        }
                        Player.encounter = -1;
                        Player.PowerSuit = false;
                        return "You've defeated " + Creature.name + "! You've found the Power Suit from Another World! You've gained " + Creature.xpreward + " xp and " + Creature.goldreward + " gold!";
                    }
                    if (Player.Gunner == true)
                    {
                        if (Player.gemcontained)
                        {

                            if (Player.gemhunger < 25)
                            {
                                Player.encounter = -1;
                                Player.gemhunger = Player.gemhunger + 1;
                                return "You've defeated " + Creature.name + "! Gem starts shaking violently in the presence of defeated enemy. You hear a whisper || I want more || You've gained " + Creature.xpreward + " xp and " + Creature.goldreward + " gold!";
                            }

                            else
                            {
                                Player.encounter = -1;
                                return "You've defeated " + Creature.name + "! You hear a whisper || I am ready... Bring me to the village || You've gained " + Creature.xpreward + " xp and " + Creature.goldreward + " gold!";
                            }
                        }

                        Item.AddItem(15);
                        Player.Gunner = false;
                        Player.encounter = -1;
                        return "You've defeated " + Creature.name + "! You've found the Assault Rifle from Another World! You've gained " + Creature.xpreward + " xp and " + Creature.goldreward + " gold!";
                    }
                    return "You've defeated " + Creature.name + "! You've found the Assault Rifle from Another World! You've gained " + Creature.xpreward + " xp and " + Creature.goldreward + " gold!";


                    
                case -8: //Stan -8 - Walka zakończona ucieczką, gracz otrzymuje informacje o udanej ucieczce, walka się kończy
                    Player.encounter = -1;
                    Player.PowerSuit = false;
                    Player.Gunner = false;

                    Player.run = false;
                    return "You've run away";

                case -15: //Stan -15, wyświetlany w sklepie, jeżeli gracz spróbuje zakupić drugą kopię unikalnych przedmiotów (ekwipunek, mapa etc)
                    Player.encounter = -1;
                    Player.consumedInventory = Player.consumedInventory + 1;
                    Player.run = false;
                    return "A black tentacle reaches out from your backpack and consumes the item you just bought. Seems like it likes duplicated items.";

                case -24: //Stan -24, wyświetlany w sklepie lub przy wizycie w karczmie, jeżeli gracza na to nie stać


                    Player.encounter = -1;
                    return "You don't have enough money!";
                case -42: //Stan -42, wyświetlany w momencie śmierci - gracz traci 20% monet i zostaje przywrócony do miasta
                    Player.health = Player.maxhealth;
                    Player.run = false;
                    Player.PowerSuit = false;
                    Player.Gunner = false;
                    Player.gold = (int)Math.Round(Player.gold * 0.8);
                    Player.encounter = -1;
                    return "You took too much damage. You lost your consciousness. Yet somehow, you made it back to the city, losing some coins.";
                case -80:

                    Player.encounter = -1;
                    return Player.checkedItem;


                case -666: //Stan -666, wyświetlany w momencie śmierci bossa w lokacji klejnotu. Dodaje klejnot do ekwipunku gracza
                    Player.encounter = -1;
                    Player.gemcontained = true;
                    Player.Inventory.Add(new Item(100), 1);

                    return "You've defeated " + Creature.name + "! You've aquired the Legendary Gem! Bring it to the Village! You've gained " + Creature.xpreward + " xp and " + Creature.goldreward + " gold!";

                default: return "";
            }
        }

        public static int DetectState()
        {
            //Poniższy kod ustanawia stan gracza - stan decyduje o tym, jakie wybory zostaną wyświetlone,
            // oraz czy ma być losowany nowy event
            if (Player.inshop == true) //Jeżeli gracz ma włączony stan "w sklepie" - w normalnych okolicznościach może być wywołany tylko w mieście
            {
                return 100;
            }
            else
            if (Player.x == 4 && Player.y == 4) //Jeżeli gracz znajduje się w mieście (gwarantowane na koordynatach 5,5-  czyli 4,4 licząc od 0)
            {
                if (Player.gemcontained == true) //jeżeli gracz przejął kryształ (pokonał finałowego bossa) i jest w wiosce, ustaw stan 4
                {
                    return 4;
                }
                else
                {
                    return 1; //Jeżeli gracz znajduje się w mieście
                }
            }
            else
            {
                if (Player.encounter > 0) //Jeżeli "encounter" jest większy od 0 - czyli gracz znajduje się w bitwie
                {
                    return 2;
                }
                else // Jeżeli żaden z tych stanów nie miał miejsca
                {
                    return 0;
                }
            }
        }

        public static void moveNorth()
        {
            if (Player.x != 0) Player.x = Player.x - 1;
        }

        public static void moveSouth()
        {
            if (Player.x != (Map.mapsize - 1)) Player.x = Player.x + 1;
        }

        public static void moveWest()
        {
            if (Player.y != 0) Player.y = Player.y - 1;
        }

        public static void moveEast()
        {
            if (Player.y != (Map.mapsize - 1)) Player.y = Player.y + 1;
        }
        public static void Inn()
        {
            if (Player.gold > 5) //Jeżeli gracz ma wystarczająco złota, leczy go, w innym wypadku wywołuje encounter -24 (za mało złota)
            {
                Player.gold = Player.gold - 5;
                Player.health = Player.maxhealth;
            }
            else
            {
                Player.encounter = -24;
            }
        }

        public static void Defend()
        {
            Player.defence = Player.defence * 5;
        }

        public static void Idle()
        {
            Player.defence = Player.defence / 5;
        }

        public static void Buy(char key)
        {
            Item q = new Item(1);
            switch (char.ToUpper(key))
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
                case 'W': Items.TryGetValue('W', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(20); } else { Player.encounter = -24; }; break;
                case 'E': Items.TryGetValue('E', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(21); } else { Player.encounter = -24; }; break;
                case 'R': Items.TryGetValue('R', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(22); } else { Player.encounter = -24; }; break;
                case 'T': Items.TryGetValue('T', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(23); } else { Player.encounter = -24; }; break;
                case 'Y': Items.TryGetValue('Y', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(24); } else { Player.encounter = -24; }; break;
                case 'U': Items.TryGetValue('U', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(30); } else { Player.encounter = -24; }; break;
                case 'I': Items.TryGetValue('I', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(31); } else { Player.encounter = -24; }; break;
                case 'O': Items.TryGetValue('O', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(32); } else { Player.encounter = -24; }; break;
                case 'P': Items.TryGetValue('P', out q); if (Player.gold >= q.price) { Player.gold = Player.gold - q.price; Item.AddItem(33); } else { Player.encounter = -24; }; break;
                case 'X': Player.inshop = false; break;



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
    }
}


       
        
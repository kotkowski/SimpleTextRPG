using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextRPG
{
    public static class Player //obiekt gracz
    {
        static public bool startinggear = false; //trigger do interakcji startowej
        static public int gemhunger = 0; //counter do alternatywnego zakończenia
        static public string checkedItem = ""; //string do kopiowania opisów przedmiotu
        static public bool Gunner = false; //trigger, czy gracz walczy z Gunnerem 
        static public bool PowerSuit = false; //trigger, czy gracz walczy z Power Suit
        static public bool map = false; //trigger, czy gracz posiada mapę
        static public Item weaponequipped = new Item(-1); //wyekwipowana broń, standardowo - żadna
        static public Item armorequipped = new Item(-2); //wyekwipowany pancerz, standardowo żaden
        static public Item ringequipped = new Item(-2); //wyekwipowany pierścień, standardowo, żaden
        static public bool gemcontained = false; // trigger, czy gracz posiada klejnot wymagany do ukończenia gry
        static public int maxhealth = 100; // maksymalne zdrowie
        static public int health = 100; //aktualne zdrowie
        static public int damage = 5; //zadawane obrażenia bazowe
        static public int defence = 5; //obrona
        static public int speed = 5; //szybkość (do ucieczek)
        static public int gold = 0; // złoto
        static public int level = 1; //aktualny poziom
        static public bool inshop = false; //trigger, czy gracz znajduje się w sklepie
        public static bool GameInProgress = true; //Czy gra trwa, niezmiennie true
        public static int exp = 0; //aktualnie posiadane doświadczenie
        public static bool check = false; //trigger, czy gracz sprawdza przeciwnika
        public static bool run = false; //trigger, czy gracz spróbował uciec (porażka)
        public static int x = 4; //aktualna pozycja gracza na mapie [x,y]
        public static int y = 4; //aktualna pozycja gracza na mapie [x,y]
        public static int encounter = -1; //Trigger "encounter", większy od 0 - w walce, mniejsze od 0 - różne eventy, -1 = spokój
        public static int levelup = 0; //ilość level up'ów do wywołania
        public static bool GolemAlive = true; //Trigger, czy finałowy boss żyje
        public static Dictionary<Item, int> Inventory = new Dictionary<Item,int>(); //Ekwipunek gracza
        public static int consumedInventory = 0; //Ilość pożartych nadmiarowych przedmiotów

        public static void UseInventory() //Używanie ekwipunku
        {
            Console.WriteLine("");
            Console.WriteLine("You take a moment, checking your backpack content: ");
            foreach (KeyValuePair<Item, int> i in Player.Inventory) //Wyświetla przedmioty w ekwipunku (klawisz do użycia, ilość w przypadku przedmiotów  jednorazowych, oraz czy wyekwipowany w przypadku ekwipunku)
            {

                if (i.Value != 0)
                {
                    GameModel.character = GameModel.KeyByValue(GameModel.Items, i.Key);
                    Console.Write(GameModel.character + ">>>" + i.Key.name);
                    if (i.Key.type == 1)
                    {
                        Console.Write(" --- Amount:" + i.Value);
                    }
                    else
                    if(i.Key.type == 2 && i.Key.equipped == true)
                    {
                        Console.Write(" --- Equipped ");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("X - Close  Backpack");
            char key = 'l';
            while (true)
            {
                string s = Console.ReadLine();
                if (!string.IsNullOrEmpty(s))
                {
                    key = s[0];

                    break;
                }

            }
            if (key == 'X' || key == 'x') //Jeżeli naciśnięto X - zamyka ekwipunek, w innym wypadku próbuje....
            {
            }
            else
            {
                while (true)
                {
                    Item q;
                    try
                    {
                        GameModel.Items.TryGetValue(char.ToUpper(key), out q); //... użyć ekwipunku (korzystając z klawisza próbuje uzyskać informacje o przedmiocie z tablicy z GameModel.cs)
                        q.Use();
                        break;
                    }
                    catch (Exception)
                    { }

                }
            }

        }
        public static int RequiredExp() //Zwraca ilość doświadczenia potrzebną do następnego poziomu (level * 100)
        {
            return (level * 100);
        }

        public static void gainExp(int expGained) //Dodaje doświadczenie i sprawdza czy gracz nie osiągnął wyższego poziomu
        {
            
            Player.exp = Player.exp + expGained;
            while (Player.exp  >= Player.RequiredExp())
            {
                Player.exp = Player.exp - Player.RequiredExp();
                Player.level++;
                Player.levelup = Player.levelup + 1;
 

            }

        }

        public static void LevelUp() //Zwiększa poziom gracza, poprawia jego statystyki oraz leczy
        {
            while (Player.levelup > 0)
            {
                Console.WriteLine("Damage +5");
                Player.damage = Player.damage + 5;
                Console.WriteLine("Max Health +10");
                Player.maxhealth = Player.maxhealth + 10;
                Player.health = Player.maxhealth;
                Player.levelup = Player.levelup - 1;
                Player.level = Player.level++;
            }
        }

        public static void RunAway() //Wywołuje próbę ucieczki, speed/25 szansy na ucieczkę
        {

            int tmp = GameModel.EventRandomizerRnd.Next(25);
            if (tmp <= Player.speed)
            { //jeżeli wylosowana liczba jest mniejsza/równa prędkości gracza, ucieczka udaje się
                Player.encounter = -8;
            }
            else
            { //w innym wypadku wyświetlony zostaje odpowiedni komunikat 
                Player.run = true;
            }

        }
        public static void Attack() //Wywołuje atak
        {
            if (Player.damage > Creature.defence)//Jeżeli obrażenia gracza są większe niż obrona przeciwnika, zadaj Player.damage - Creature.defence obrażeń
            {
                Creature.health = Creature.health - (Player.damage - Creature.defence); 
                if (Creature.health <= 0) //Jeżeli HP przeciwnika spadnie do 0, lub mniej, nagródź gracza nagrodami (creature.goldreward, Creature.xpreward)
                {
                    Player.gold = Player.gold + Creature.goldreward;
                    Player.gainExp(Creature.xpreward);
                    if (Player.encounter == 666) //Jeżeli encounter == 666 (walka z finałowym bossem), zmień trigger "GolemAlive" to false i ustaw encounter na -666
                    {
                        GolemAlive = false;
                        
                        Player.encounter = -666;
                    }
                    else
                    { //W innym wypadku, ustaw encounter na 0
                        Player.encounter = 0;
                    }
                    
                   
                    
                }
            }
            else
            { //Jeżeli damage nie jest większy od obrony, odbierz potworowi 1 zdrowia
                Creature.health = Creature.health - 1;
                if (Creature.health <= 0)
                { //Śmierc potwora odbywa się w ten sam sposób
                    Player.gold = Player.gold + Creature.goldreward;
                    Player.gainExp(Creature.xpreward);
                    if (Player.encounter == 666) //Jeżeli encounter == 666 (walka z finałowym bossem), zmień trigger "GolemAlive" to false i ustaw encounter na -666
                    {
                        GolemAlive = false;

                        Player.encounter = -666;
                    }
                    else
                    { //W innym wypadku, ustaw encounter na 0
                        Player.encounter = 0;
                    }
                }
            }

        }

    }

    public static class Creature //Obiekt przeciwnika
    {
        public static string name = "Unknown Creature"; //nazwa
        public static int maxhealth = 20; //maksymalne zdrowie
        public static int health = 20; //zdrowie
        public static int healing = 5; //ile zdrowia leczy na każde użycie akcji "leczenie"
        public static int damage = 3; // ile obrażeń zadaje
        public static int defence = 0; //obrona
        public static int chargeddamage = 5*damage; //ciężki atak (5* obrażenia)
        public static int xpreward = 5; // ile gracz otrzyma doświaddczenia po pokonaniu potwora
        public static int hurtTreshold = 1; //mając ile hp potwór uważa, że jest ranny
        
        public static int goldreward = 5; // ile gracz otrzyma złota po pokonaniu potwora
        public static State stateofenemy = State.Idle; //Stan przeciwnika, standardowo "Idle" czyli "Bierny"

        public static void Attack() //Prosta funckja podejmująca decyzje
        {
            switch (Creature.stateofenemy) //W zależności od stanu potwora z poprzedniej tury
            {
                case State.Idle: //Jeżeli bierny
                    if (Creature.damage > Player.defence) //Zaatakuj ( damage - obrona, przynajmniej 1)
                    {
                        Player.health = Player.health - (Creature.damage - Player.defence);
                        if (Player.health < 1) //Jeżeli gracz zginie, encounter -42 ("utrata przytomności")
                        {
                            Player.x = 4; Player.y = 4; Player.encounter = -42;
                        }
                    }
                    else
                    {
                        Player.health = Player.health - 1;
                        if (Player.health < 1)
                        {//Jeżeli gracz zginie, encounter -42 ("utrata przytomności")
                            Player.x = 4; Player.y = 4; Player.encounter = -42;
                        }
                    }
                    if (Creature.health < Creature.hurtTreshold) //Po ataku, jeżeli potwór ma mniej HP niż wynosi jego "próg bólu", ustaw stan na "leczenie"
                    {
                        Creature.stateofenemy = State.Healing;
                    }
                    else //Jeżeli próg bólu nie został osiągnięty, losuj  nastepny ruch, 25% na ciężki atak, 75% na stan bierny
                    {
                        int tmp = GameModel.EventRandomizerRnd.Next(100);
                        if (tmp < 75)
                        {
                            Creature.stateofenemy = State.Idle;
                        }
                        else
                        {
                            Creature.stateofenemy = State.Preparing;
                        }
                    }
                    break;
                case State.Preparing: //Stan "Przygotowywanie ciężkiego ataku"
                    if (Creature.chargeddamage > Player.defence) //Zadaje ciężkie obrażenia - obrona (przyn. 1)
                    {
                        Player.health = Player.health - (Creature.chargeddamage - Player.defence);
                        if (Player.health < 1)
                        {//Jeżeli gracz zginie, encounter -42 ("utrata przytomności")
                            Player.x = 4; Player.y = 4; Player.encounter = -42;
                        }
                    }
                    else
                    {
                        Player.health = Player.health - 1;
                        if (Player.health < 1)
                        {//Jeżeli gracz zginie, encounter -42 ("utrata przytomności")
                            Player.x = 4; Player.y = 4; Player.encounter = -42;
                        }
                    }
                    if (Creature.health < Creature.hurtTreshold) //Po ataku, jeżeli potwór ma mniej HP niż wynosi jego "próg bólu", ustaw stan na "leczenie"
                    {
                        Creature.stateofenemy = State.Healing;
                    }
                    else //W innym wypadku, ustaw stan bierny, potwór nie może wykonać ciężkiego ataku 2 razy pod rząd
                    { Creature.stateofenemy = State.Idle; }
                    break;
                case State.Healing: //Jeżeli potwór osiągnął swój próg bólu, spróbuje się uleczyć
                    if (Creature.health + Creature.healing > Creature.maxhealth) //Potwór regeneruje Creature.healing zdrowia, jednak nie przegracza Creature.maxhealth
                    {
                        Creature.health = Creature.maxhealth;
                    }
                    else
                    {
                        Creature.health = Creature.health + Creature.healing;
                    }
                    if (Creature.health < Creature.hurtTreshold) //Jeżeli nadal jest mocno zraniony, potwór powtarza leczenie
                    {
                        Creature.stateofenemy = State.Healing;
                    } 
                    else //w innym wypadku przechodzi w stan bierny
                    { Creature.stateofenemy = State.Idle; }


                    break;

            }
        }

        //enum state - stanowiący wartości stanów potwora  Idle/Preparing/Healing, wartość Attacking jest nieosiągalna, byla używana do debugowania
        public enum State
        {
            Idle = 0,
            Attacking = 1,
            Preparing = 2,
            Healing = 3
        }
        public static List<string> CreatureState = new List<string>(3) // W zależności od stanu, zostanie wyświetlona poniższa wiadomość
        {
            " is waiting for your move!","Debug message, shouldn't appear" ," is preparing heavy attack!", " is planning to rest!"
        };

        public static void InitializeBossFight() //Gdy gracz znajdzie się na odpowiednich koordynatach, inicjalizuje walkę z bossem
        {
            Player.encounter = 666;
            Creature.name = "Incarnation of Regoult The Guardian God (Boss)";
            Creature.maxhealth = 2500;
            Creature.health = 2500;
            Creature.hurtTreshold = 100;
            Creature.healing = 100;
            Creature.damage = 30;
            Creature.defence = 20;
            Creature.chargeddamage = 5 * Creature.damage;
            Creature.xpreward = 5000;
            Creature.goldreward = 9001;
        }
        public static void Randomize() //Losuje potwora, funkcja do przerobienia wkrótce, więc nie dodaję niepotrzebnych komentarzy
        {
            string modifier = "";
            Random rnd = new Random();
            int mod = -1;
            int enemy = Convert.ToInt32(Math.Floor((decimal)rnd.Next(0, 10)));
            if(enemy > 5)
            {
                enemy = Convert.ToInt32(Math.Floor((decimal)rnd.Next(0, 8)));
                modifier = ((RandomModifier)enemy).ToString();
                modifier = string.Concat(modifier, " ");
                mod = enemy;

            }

            switch(Map.map[Player.x, Player.y].typ)
            {
                case 'F':
                    enemy = Convert.ToInt32(Math.Floor((decimal)rnd.Next(1, 6)));
                    switch(enemy)
                    {
                        case 1:
                            name = string.Concat(modifier + "Wolf");
                            maxhealth = 25;
                            health = 25;
                            damage = 3;
                            defence = 0;
                            healing = 0;
                            hurtTreshold = -1;
                            chargeddamage = 10 * damage;
                            goldreward = 10;
                            xpreward = 50;
                            break;
                        case 2:
                            name = string.Concat(modifier + "Forest Bandit");
                            maxhealth = 45;
                            health = 45;
                            damage = 5;
                            defence = 0;
                            healing = 5;
                            hurtTreshold = 3;
                            chargeddamage = 5 * damage;
                            goldreward = 40;
                            xpreward = 90;
                            break;
                        case 3:
                            name = string.Concat(modifier + "Green Slime");
                            maxhealth = 10;
                            health = 10;
                            damage = 1;
                            defence = 20;
                            healing = 0;
                            hurtTreshold = -1;
                            chargeddamage = 3 * damage;
                            goldreward = 5;
                            xpreward = 30;
                            break;
                        case 4:
                            name = string.Concat(modifier + "Living Log");
                            maxhealth = 120;
                            health = 120;
                            damage = 3;
                            defence = 3;
                            healing = 10;
                            hurtTreshold = 40;
                            chargeddamage = 3 * damage;
                            goldreward = 50;
                            xpreward = 140;
                            break;
                        case 5:
                            name = string.Concat(modifier + "Bear");
                            maxhealth = 80;
                            health = 80;
                            damage = 30;
                            defence = 10;
                            healing = 10;
                            hurtTreshold = 30;
                            chargeddamage = 3 * damage;
                            goldreward = 70;
                            xpreward = 240;
                            break;
                        case 6:
                            name = string.Concat(modifier + "Spriggan");
                            maxhealth = 50;
                            health = 50;
                            damage = 1;
                            defence = 5;
                            healing = 50;
                            hurtTreshold = 40;
                            chargeddamage = 5 * damage;
                            goldreward = 70;
                            xpreward = 50;
                            break;
                        default:
                            throw new Exception("Wrong enemy ID");

                    }
                    
                    break;
                case 'C':
                    enemy = Convert.ToInt32(Math.Floor((decimal)rnd.Next(1, 6)));
                    switch (enemy)
                    {
                        case 1:
                            name = string.Concat(modifier + "Bandit Swordsman");
                            maxhealth = 80;
                            health = 80;
                            damage = 10;
                            defence = 10;
                            healing = 15;
                            hurtTreshold = 20;
                            chargeddamage = 5 * damage;
                            goldreward = 140;
                            xpreward = 110;
                            break;
                            
                        case 2:
                            name = string.Concat(modifier + "Bandit Archer");
                            maxhealth = 45;
                            health = 45;
                            damage = 35;
                            defence = 0;
                            healing = 0;
                            hurtTreshold = -1;
                            chargeddamage = 5 * damage;
                            goldreward = 120;
                            xpreward = 100;
                            break;
                        case 3:
                            name = string.Concat(modifier + "Bandit Brutal (Mini-boss)");
                            maxhealth = 220;
                            health = 220;
                            damage = 115;
                            defence = -10;
                            healing = 0;
                            hurtTreshold = -1;
                            chargeddamage = 2 * damage;
                            goldreward = 320;
                            xpreward = 280;
                            break;
                        case 4:
                            name = string.Concat(modifier + "Rock Golem");
                            maxhealth = 120;
                            health = 120;
                            damage = 15;
                            defence = 30;
                            healing = 10;
                            hurtTreshold = -1;
                            chargeddamage = 3 * damage;
                            goldreward = 110;
                            xpreward = 170;
                            break;
                        case 5:
                            name = string.Concat(modifier + "Lesser Imp");
                            maxhealth = 35;
                            health = 35;
                            damage = 25;
                            defence = 40;
                            healing = 1;
                            hurtTreshold = -1;
                            chargeddamage = 3 * damage;
                            goldreward = 75;
                            xpreward = 120;
                            break;
                        case 6:
                            name = string.Concat(modifier + "Mimic");
                            maxhealth = 250;
                            health = 250;
                            damage = 25;
                            defence = 15;
                            healing = 0;
                            hurtTreshold = -1;
                            chargeddamage = 5 * damage;
                            goldreward = 230;
                            xpreward = 130;
                            break;
                        case 7:
                            name = string.Concat(modifier + "Gray Slime");
                            maxhealth = 50;
                            health = 50;
                            damage = 5;
                            defence = 100;
                            healing = 0;
                            hurtTreshold = -1;
                            chargeddamage = 3 * damage;
                            goldreward = 60;
                            xpreward = 170;
                            break;
                        default:
                            throw new Exception("Wrong enemy ID");

                    }
                    break;
                case 'M':
                    enemy = Convert.ToInt32(Math.Floor((decimal)rnd.Next(1, 6)));
                    switch (enemy)
                    {
                        case 1:
                            name = string.Concat(modifier + "Higher Imp");
                            maxhealth = 260;
                            health = 260;
                            damage = 45;
                            defence = 30;
                            healing = 25;
                            hurtTreshold = 100;
                            chargeddamage = 5 * damage;
                            goldreward = 240;
                            xpreward = 310;
                            break;

                        case 2:
                            name = string.Concat(modifier + "False Prophet");
                            maxhealth = 42;
                            health = 42;
                            damage = 5;
                            defence = 400;
                            healing = 0;
                            hurtTreshold = -1;
                            chargeddamage = 5 * damage;
                            goldreward = 130;
                            xpreward = 400;
                            break;
                        case 3:
                            name = string.Concat(modifier + "Gunner From Another World");
                            maxhealth = 100;
                            health = 100;
                            damage = 315;
                            defence = 0;
                            healing = 0;
                            hurtTreshold = -1;
                            chargeddamage = 2 * damage;
                            goldreward = 10;
                            xpreward = 520;
                            Player.Gunner = true;
                            break;
                        case 4:
                            name = string.Concat(modifier + "Power Suit Soldier (Mini-boss)");
                            maxhealth = 1200;
                            health = 1200;
                            damage = 230;
                            defence = 30;
                            healing = 50;
                            hurtTreshold = 300;
                            chargeddamage = 1 * damage;
                            goldreward = 1100;
                            xpreward = 1700;
                            Player.PowerSuit = true;
                            break;
                        case 5:
                            name = string.Concat(modifier + "Devil");
                            maxhealth = 350;
                            health = 350;
                            damage = 130;
                            defence = 80;
                            healing = 0;
                            hurtTreshold = -1;
                            chargeddamage = 3 * damage;
                            goldreward = 750;
                            xpreward = 500;
                            break;
                        case 6:
                            name = string.Concat(modifier + "Unseen");
                            maxhealth = 5;
                            health = 5;
                            damage = 200;
                            defence = 999999;
                            healing = 1;
                            hurtTreshold = 3;
                            chargeddamage = 3 * damage;
                            goldreward = 9999;
                            xpreward = 9999;
                            break;
                        default:
                            throw new Exception("Wrong enemy ID");
                    }
                    break;
            }
            
            switch(mod)
            {
                case 0:
                    damage = Convert.ToInt32(damage * 1.2);
                    break;
                case 1:
                    damage = Convert.ToInt32(damage * 1.1);
                    health = Convert.ToInt32(health * 0.8);
                    maxhealth = Convert.ToInt32(health * 0.8);
                    xpreward = Convert.ToInt32(xpreward * 1.1);
                    break;
                case 2:
                    damage = Convert.ToInt32(damage * 0.9);
                    health = Convert.ToInt32(health * 1.5);
                    maxhealth = Convert.ToInt32(health * 1.5);
                    xpreward = Convert.ToInt32(xpreward * 1.3);
                    break;
                case 3:
                    goldreward = Convert.ToInt32(damage * 3);
                    break;
                case 4:
                    damage = Convert.ToInt32(damage * 1.5);
                    health = Convert.ToInt32(health * 0.5);
                    maxhealth = Convert.ToInt32(health * 0.5);
                    xpreward = Convert.ToInt32(xpreward * 2);
                    break;
                case 5:
                    damage = Convert.ToInt32(damage * 0.8);
                    health = Convert.ToInt32(health * 0.5);
                    maxhealth = Convert.ToInt32(health * 0.5); ;
                    xpreward = Convert.ToInt32(xpreward * 0.2);
                    goldreward = Convert.ToInt32(goldreward * 0.2);
                    break;
                case 6:
                    health = Convert.ToInt32(health * 0.8);
                    maxhealth = Convert.ToInt32(health * 0.8);
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

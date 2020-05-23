using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextRPG
{
    public class Item
    {
        public int slot = 0;
        // 0 - unequipable
        // 1 - weapon
        // 2 - armor
        // 3 - ring
        public int type = 0;
        // 0 - invalid
        // 1 - consumable
        // 2 - equipment
        // 3 - key item
        public string name = "None";
        public int price = 0;
        public int def = 0;
        public int dmg = 0;
        public int hp = 0;
        public int speed = 0;
        public int restoredhp = 0;
        public bool equipped = false;

        public void Use()
        {
            switch(this.type)
            {
                case 0:
                    throw new Exception("Invalid Type");
                    
                case 1:
                    int amount;
                    bool ifexists = Player.Inventory.TryGetValue(this, out amount);
                    if(ifexists)
                    {
                        if(Player.health + this.restoredhp > Player.maxhealth)
                        {
                            Player.health = Player.maxhealth;
                        }
                        else
                        {
                            Player.health = Player.health + this.restoredhp;
                        }
                        
                        Player.Inventory.Remove(this);
                        if (amount > 0)
                            Player.Inventory.Add(this, amount - 1);

                    }
                    break;
                case 2:
                    {
                        switch (this.slot)
                        {
                            case 1:
                                Player.defence = Player.defence - Player.weaponequipped.def;
                                Player.maxhealth = Player.maxhealth - Player.weaponequipped.hp;
                                Player.speed = Player.speed - Player.weaponequipped.speed;
                                Player.damage = Player.damage - Player.weaponequipped.dmg;
                                Player.weaponequipped.equipped = false;
                                Player.weaponequipped = this;
                                this.equipped = true;
                                Player.defence = Player.defence + Player.weaponequipped.def;
                                Player.maxhealth = Player.maxhealth + Player.weaponequipped.hp;
                                Player.speed = Player.speed + Player.weaponequipped.speed;
                                Player.damage = Player.damage + Player.weaponequipped.dmg;
                                break;
                            case 2:
                                Player.defence = Player.defence - Player.armorequipped.def;
                                Player.maxhealth = Player.maxhealth - Player.armorequipped.hp;
                                Player.speed = Player.speed - Player.armorequipped.speed;
                                Player.damage = Player.damage - Player.armorequipped.dmg;
                                Player.armorequipped.equipped = false;
                                Player.armorequipped = this;
                                this.equipped = true;
                                Player.defence = Player.defence + Player.armorequipped.def;
                                Player.maxhealth = Player.maxhealth + Player.armorequipped.hp;
                                Player.speed = Player.speed + Player.armorequipped.speed;
                                Player.damage = Player.damage + Player.armorequipped.dmg;
                                break;
                            case 3:
                                Player.defence = Player.defence - Player.ringequipped.def;
                                Player.maxhealth = Player.maxhealth - Player.ringequipped.hp;
                                Player.speed = Player.speed - Player.ringequipped.speed;
                                Player.damage = Player.damage - Player.ringequipped.dmg;
                                Player.ringequipped.equipped = false;
                                Player.ringequipped = this;
                                this.equipped = true;
                                Player.defence = Player.defence + Player.ringequipped.def;
                                Player.maxhealth = Player.maxhealth + Player.ringequipped.hp;
                                Player.speed = Player.speed + Player.ringequipped.speed;
                                Player.damage = Player.damage + Player.ringequipped.dmg;
                                break;
                            default:
                                throw new Exception("Unknown ID");
                        }
                    }
                    break;
                case 3:
                    {
                        break;
                    }
                default:
                    throw new Exception("Invalid Item Type");
            }
            
        }
        public static void AddItem(int id)
        {
            char key = GameModel.translateId(id);
            Item i = GameModel.Items[char.ToUpper(key)];
            switch (i.type)
            {
                case 1:
                    {
                        int amount;
                        Player.Inventory.TryGetValue(i, out amount);
                        
                            Player.Inventory.Remove(i);
                            if (amount >= 0)
                                Player.Inventory.Add(i, amount + 1);
                        }
                    break;
                case 2:
                    {
                        int amount;
                        bool ifexists = Player.Inventory.TryGetValue(i, out amount);

                        if (amount == 0)
                        {
                            Player.Inventory.Remove(i);
                            Player.Inventory.Add(i, 1);
                        }
                        else
                        {
                            Player.encounter = -15;
                        }
                    }
                    break;
                case 3:
                    {
                        int amount;
                        bool ifexists = Player.Inventory.TryGetValue(i, out amount);

                        if (amount == 0)
                        {
                            Player.Inventory.Remove(i);
                            Player.Inventory.Add(i, 1);
                            Player.map = true;
                        }
                        else
                        {
                            Player.encounter = -15;
                        }
                    }
                    break;
            }
        }
        public Item(int id)
        {
            switch(id)
            {
                case -1:
                    slot = 1;
                    type = 2;
                    name = "None";
                    equipped = true;
                    break;
                case -2:
                    slot = 2;
                    type = 2;
                    name = "None";
                    equipped = true;
                    break;
                case -3:
                   slot = 1;
                   type = 2;
                    name = "None";
                    equipped = true;
                    break;
                case 1:
                    this.name = "Small Health Potion";
                    this.restoredhp = 10;
                    this.price = 5;
                    this.type = 1;
                    break;
                case 2:
                    this.name = "Medium Health Potion";
                    this.restoredhp = 50;
                    this.price = 20;
                    this.type = 1;
                    break;
                case 3:
                    this.name = "Big Health Potion";
                    this.restoredhp = 200;
                    this.price = 50;
                    this.type = 1;
                    break;
                case 4:
                    this.name = "Giant Health Potion";
                    this.restoredhp = 500;
                    this.price = 100;
                    this.type = 1;
                    break;
                case 8:
                    this.name = "Map";
                    this.type = 3;
                    this.price = 10;
                    break;
                case 10:
                    this.name = "Wooden Sword";
                    this.type = 2;
                    this.slot = 1;
                    this.dmg = 10;
                    this.price = 10;
                    break;
                case 11:
                    this.name = "Steel Sword";
                    this.type = 2;
                    this.slot = 1;
                    this.dmg = 25;
                    this.price = 50;
                    break;
                case 12:
                    this.name = "Mithril Sword";
                    this.type = 2;
                    this.slot = 1;
                    this.dmg = 45;
                    this.price = 150;
                    break;
                case 13:
                    this.name = "Adamantite Sword";
                    this.type = 2;
                    this.slot = 1;
                    this.dmg = 100;
                    this.price = 350;
                    break;
                case 14:
                    this.name = "Magic Sword";
                    this.type = 2;
                    this.slot = 1;
                    this.dmg = 55;
                    this.speed = 20;
                    this.price = 250;
                    break;
                case 20:
                    this.name = "Chainmail";
                    this.type = 2;
                    this.slot = 2;
                    this.def = 10;
                    this.price = 20;
                    break;
                case 21:
                    this.name = "Platemail";
                    this.type = 2;
                    this.slot = 2;
                    this.def = 30;
                    this.price = 100;
                    break;
                case 22:
                    this.name = "Enchanted Platemail";
                    this.type = 2;
                    this.slot = 2;
                    this.def = 30;
                    this.hp = 10;
                    this.price = 120;
                    break;
                case 23:
                    this.name = "Enchanted Chainmail";
                    this.type = 2;
                    this.slot = 2;
                    this.def = 10;
                    this.hp = 10;
                    this.price = 40;
                    break;
                case 24:
                    this.name = "Dragonscale Platemail";
                    this.type = 2;
                    this.slot = 2;
                    this.def = 60;
                    this.hp = 30;
                    this.price = 300;
                    break;
                case 30:
                    this.name = "Ring of Health";
                    this.type = 2;
                    this.slot = 3;
                    this.hp = 15;
                    this.price = 100;
                    break;
                case 31:
                    this.name = "Ring of Strength";
                    this.type = 2;
                    this.slot = 3;
                    this.dmg = 15;
                    this.price = 100;
                    break;
                case 32:
                    this.name = "Ring of Defence";
                    this.type = 2;
                    this.slot = 3;
                    this.def = 15;
                    this.price = 100;
                    break;
                case 33:
                    this.name = "Ring of Speed";
                    this.type = 2;
                    this.slot = 3;
                    this.speed = 15;
                    this.price = 100;
                    break;


                case 100:
                    this.name = "Gem";
                    this.type = 3;
                    break;

            }
        }
    }
}

/* Item List
 * 
 * ID 1 - Small Health Potion
 * Restores 10 HP
 * Consumable
 * Price 5 gold
 * 
 * ID 2 - Medium Health Potion
 * Restores 50 HP
 * Consumable
 * Price 20 gold
 * 
 * ID 3 - Big Health Potion
 * Restores 200 HP
 * Consumable
 * Price 50 gold
 * 
 * ID 4 - Giant Health Potion
 * Restores 500 HP
 * Consumable
 * Price 100 gold
 * 
 * 
 * 
 * ID 8 - Map
 * Allows use of "Check Map"
 * Price 10 gold
 * 
 * 
 * ID 10 - Wooden Sword
 * Slot 1 (Weapon)
 * Adds 10 DMG
 * Equipment
 * Price 10 gold
 * 
 * ID 11 - Steel Sword
 * Slot 1 (Weapon)
 * Adds 25 DMG
 * Equipment
 * Price 50 gold
 * 
 * ID 12 - Mithril Sword
 * Slot 1 (Weapon)
 * Adds 45 DMG
 * Equipment
 * Price 150 gold
 * 
 * ID 13 - Adamantite Sword
 * Slot 1 (Weapon)
 * Adds 100 DMG
 * Equipment
 * Price 350 gold
 * 
 * ID 14 - Magic Sword
 * Slot 1 (Weapon)
 * Adds 55 DMG
 * Adds 20 SPD
 * Equipment
 * Price 350 gold
 * 

 * 
 * 
 * 
 * ID 20 - Chainmail
 * Slot 2 (Armor)
 * Adds 10 DEF
 * Equipment
 * Price 20 gold
 * 
 * ID 21 - Platemail
 * Slot 2 (Armor)
 * Adds 30 DEF
 * Equipment
 * Price 100 gold
 * 
 * ID 22 - Enchanted Platemail
 * Slot 2 (Armor)
 * Adds 30 DEF
 * Adds 10 HP
 * Equipment
 * Price 120 gold
 * 
 * ID 23 - Enchanted Chainmail
 * Slot 2 (Armor)
 * Adds 10 DEF
 * Adds 10 HP
 * Equipment
 * Price 40 gold
 * 
 * ID 24 - Dragonscale Platemail
 * Slot 2 (Armor)
 * Adds 60 DEF
 * Adds 30 HP
 * Equipment
 * Price 300 gold
 * 
 * ID 30 - Ring of Health
 * Slot 3 (Ring)
 * Adds 15 HP
 * Equipment
 * Price 100 gold
 * 
 * ID 31 - Ring of Strength
 * Slot 3 (Ring)
 * Adds 15 DMG
 * Equipment
 * Price 100 gold
 * 
 * 
 * ID 32 - Ring of Defence
 * Slot 3 (Ring)
 * Adds 15 DEF
 * Equipment
 * Price 100 gold
 * 
 * ID 33 - Ring of Speed
 * Slot 3 (Ring)
 * Adds 15 SPD
 * Equipment
 * Price 100 gold
 * 
 * ID 100 - Gem
 * Required to complete the game. 
 * 
 * */

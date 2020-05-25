using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextRPG
{
    public class Location
    {
        public char symbol = '*'; //Symbol, reprezentuje lokacje na mapie
        public char typ = '?'; // Typ - reprezentuje lokacje w funkcjach
        public string name = "Unknown Location"; // Nazwa lokacji, wyświetlana w trakcie wizyty
        public string desc = "Place that should never exist"; //Opis lokacji, wyświetlany w trakcie wizyty

        public Location(string name, string description, char typ) //Konstruktor, przypisuje wygenerowane wartości do lokacji
        {
            this.name = name;
            this.desc = description;
            switch(typ)
            {
                case 'F': this.typ = 'F'; this.symbol = 'F'; break;
                case 'C': this.typ = 'C';this.symbol = 'C';break;
                case 'V': this.typ = 'V'; this.symbol = 'V'; break;
                case 'M': this.typ = 'M'; this.symbol = 'M'; break;
                case '*': this.typ = '?'; this.symbol = '?'; break;
                default:
                    throw new ArgumentException("Wrong Location Type");
            }
        }
    }
}

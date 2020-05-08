using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextRPG
{
    public class Location
    {
        public char symbol = '*';
        public char typ = '?';
        public string name = "Unknown Location";
        public string desc = "Place that should never exist";

        public Location(string name, string description, char typ)
        {
            this.name = name;
            this.desc = description;
            switch(typ)
            {
                case 'F': typ = 'F'; symbol = 'F'; break;
                case 'C': typ = 'C';symbol = 'C';break;
                case 'V': typ = 'V'; symbol = 'V'; break;
                case 'M': typ = 'M'; symbol = 'M'; break;
                case '*': typ = '?'; symbol = '?'; break;
                default:
                    throw new ArgumentException("Wrong Location Type");
            }
        }
    }
}

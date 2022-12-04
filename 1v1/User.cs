using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1v1
{
    public class User
    { 
        public int Strenght { get; set; } = 1;
        public int Constitution { get; set; } = 1;
        public int Intellengence { get; set; } = 1; 
        public int Dexterity { get; set; } = 1;
        public int Lvl { get; set; } = 1;
        public int Point { get; set; } = 1;
        public double Luck { get; set; } = 1;
        public double Damage { get; set; } = 1;
        public double Evasion { get; set; } = 0;
        public double pDamage { get; set; } = 0;
        public double MagicDamage { get; set; } = 2;
        public double Mana { get; set; } =7;
        public double Health { get; set; } = 5;
        public double ManaCost { get; set; } = 5;
        public double CrtChance { get; set; } = 0;
        public string Names { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBattleGame.Entities
{
    public class Rogue : FighterClass
    {
        public Rogue(string name)
            : base(name)
        {
            MaxHealth = 200;
            CurrentHealth = MaxHealth;
            Armor = 5;
            AttackPower = 30;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBattleGame.Entities
{
    public class Mage : FighterClass
    {
        public Mage(string name)
        : base(name)
        {
            MaxHealth = 150;
            CurrentHealth = MaxHealth;
            Armor = 0;
            AttackPower = 50;
        }
    }
}

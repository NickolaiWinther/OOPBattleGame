using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBattleGame.Entities
{
    public class Warrior : FighterClass
    {
        public Warrior(string name) 
            :base(name)
        {
            MaxHealth = 350;
            CurrentHealth = MaxHealth;
            Armor = 10;
            AttackPower = 17.5;
        }
    }
}

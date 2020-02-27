using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBattleGame.Entities
{
    public abstract class FighterClass
    {
        protected FighterClass(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public double CurrentHealth { get; set; }
        public double MaxHealth { get; set; }
        public double Armor { get; set; }
        public double AttackPower { get; set; }
        public double HealthPercentage { get => CurrentHealth / MaxHealth * 100; }

        public override string ToString()
            => $"{Name}";

        public void Attack(FighterClass enemyPlayer)
        {
            if(CurrentHealth != MaxHealth || enemyPlayer.CurrentHealth != enemyPlayer.MaxHealth)
            {
                Console.WriteLine("\n\nPress any button to attack");
                Console.ReadKey();
            }
            Console.Clear();

            int minDamage = (int)Math.Floor(AttackPower/2);
            int maxDamage = (int)AttackPower;
            double damage = (new Random().Next(minDamage, maxDamage) - enemyPlayer.Armor);
            if(damage > enemyPlayer.CurrentHealth)
            {
                enemyPlayer.CurrentHealth = 0;
            }
            else
            {
                enemyPlayer.CurrentHealth -= damage;
            }
            Console.WriteLine($"{Name} did {damage} damage to {enemyPlayer.Name}");
        }
    }
}

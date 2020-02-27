using OOPBattleGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBattleGame
{
    class Program
    {
        public static FighterClass player1;
        public static FighterClass player2;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to OOPBattleGame \n\nPress any key to start");
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.Gray;
            player1 = CharacterSelection();
            player2 = CharacterSelection();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{player1.Name} has chosen: {player1.GetType().Name}");
            Console.WriteLine($"{player2.Name} has chosen: {player2.GetType().Name}");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press a button to start the battle!");
            Console.ReadKey();

            FighterClass winner = BattlePhase();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The winner is {winner.Name} with {winner.CurrentHealth} health left!");
            Console.ReadKey();
        }

        public static FighterClass BattlePhase()
        {
            Console.Clear();
            List<FighterClass> fighters = new List<FighterClass>() { player1, player2 };
            
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                fighters[0].Attack(fighters[1]);

                DisplayHealth(new List<FighterClass>() { player1, player2 });

                List<FighterClass> survivor = fighters.Where(f => f.CurrentHealth != 0).ToList();
                if (survivor.Count == 1)
                {
                    return survivor[0];
                }
                fighters.Reverse();
            }
        }

        public static void DisplayHealth(List<FighterClass> fighters)
        {
            foreach (FighterClass fighter in fighters)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{fighter.Name} \n--{{");
                string healthbar = "";

                double healthChunks = Math.Ceiling(fighter.HealthPercentage / 10);

                for (int i = 0; i < healthChunks; i++)
                {
                    healthbar += "■";
                }
                double lostHealthChunks = 10 - healthChunks;
                for (int i = 0; i < lostHealthChunks; i++)
                {
                    healthbar += " ";
                }

                Console.ForegroundColor = HealthbarColor(fighter);
                Console.Write(healthbar);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"}}--  {fighter.CurrentHealth} / {fighter.MaxHealth}");
            }
        }

        public static ConsoleColor HealthbarColor(FighterClass fighter)
        {
            if (fighter.HealthPercentage >= 90)
                return ConsoleColor.DarkGreen;
            else if (fighter.HealthPercentage < 90 && fighter.HealthPercentage >= 60)
                return ConsoleColor.Green;
            else if (fighter.HealthPercentage < 60 && fighter.HealthPercentage >= 30)
                return ConsoleColor.Yellow;
            else
                return ConsoleColor.Red;
        }

        public static FighterClass CharacterSelection()
        {
            Console.Clear();
            bool classConfirmed = false;
            bool nameConfirmed = false;

            int charaterClass = 0;
            string characterName = "";

            while (classConfirmed == false)
            {
                Console.WriteLine("Choose your class:\n" +
                                  "1: Warrior\n" +
                                  "2: Rogue\n" +
                                  "3: Mage");

                int.TryParse(Console.ReadLine(), out int result);
                if(result < 1 || result > 3)
                {
                    Console.Clear();
                    Console.WriteLine("Class does not exist");
                }
                else
                {
                    charaterClass = result;
                    classConfirmed = true;
                }
            }

            Console.Clear();
            while (nameConfirmed == false)
            {
                Console.WriteLine("Tell me your name");
                string result = Console.ReadLine();

                if(result is null || result.Length < 2 || result.Any(char.IsDigit))
                {
                    Console.Clear();
                    Console.WriteLine("Name is not valid");
                }
                else
                {
                    characterName = result;
                    nameConfirmed = true;
                }
            }

            switch (charaterClass)
            {
                case 1:
                    return new Warrior(characterName);
                case 2:
                    return new Rogue(characterName);
                case 3:
                    return new Mage(characterName);
                default:
                    return null;
            }
        }
    }
}

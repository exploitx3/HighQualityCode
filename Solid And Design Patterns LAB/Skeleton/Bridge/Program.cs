namespace RPG
{
    using System;

    using RPG.Characters;

    public class Program
    {
        static void Main()
        {
            Warrior axeWarrior = new WarriorWithAxe();
            Warrior swordWarrior = new WarriorWithSword();
            Mage axeMage = new MageWithAxe();
            Mage swordMage = new MageWithSword();

            Console.WriteLine(axeWarrior);
            Console.WriteLine(swordMage);
        }
    }
}

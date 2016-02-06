namespace RpgGame
{
    using System;
    using System.Collections.Generic;

    public class RpgGameMain
    {
        static void Main()
        {
            var possibleItemDrops = new List<Item>
            {
                new Item("Axe", 25, 5),
                new Item("Shield", 5, 50),
                new Item("Resilience Potion", 0, 30)
            };
            
            IRandomNumberProvider numberProvider = new RandomNumberProvider();
            var character = new Character(possibleItemDrops, numberProvider);

            var droppedItem = character.DropItem();
            Console.WriteLine(droppedItem);
        }
    }
}

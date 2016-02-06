namespace RpgGame
{
    using System;
    using System.Collections.Generic;

    public class Character
    {
        private readonly IRandomNumberProvider random;
        private readonly List<Item> possibleItemDrops;

        public Character(List<Item> items, IRandomNumberProvider random)
        {
            this.random = random;
            this.possibleItemDrops = items;
        }

        public Item DropItem()
        {
            var randomIndex = random.GetRandomNumber(0, this.possibleItemDrops.Count-1);

            return this.possibleItemDrops[randomIndex];
        }
    }

    public interface IRandomNumberProvider
    {
        int GetRandomNumber(int min, int max);
    }

    public class RandomNumberProvider : IRandomNumberProvider
    {
        private Random random;

        public RandomNumberProvider()
        {
            random = new Random();
        }

        public int GetRandomNumber(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }
}

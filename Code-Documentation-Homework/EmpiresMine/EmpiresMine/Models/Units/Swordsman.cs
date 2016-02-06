using System;
using EmpiresMine.Models.Interfaces;

namespace EmpiresMine.Models.Units
{
    public class Swordsman : IUnit
    {

        private const int DefaultHealthValue = 25;
        private const int DefaultDamageValue = 7;

        private int health;
        private int attackDamage;

        public Swordsman(int health = DefaultHealthValue, int attackDamage = DefaultDamageValue)
        {
            this.Health = health;
            this.AttackDamage = attackDamage;
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("health", "Health value must be positive");
                }
                this.health = value;
            }
        }

        public int AttackDamage
        {
            get { return this.attackDamage; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("attackDamage", "Attack Damage value must be positive");
                }
                this.attackDamage = value;
            }
        }
    }
}
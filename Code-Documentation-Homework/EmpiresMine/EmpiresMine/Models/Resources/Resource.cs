using System;
using EmpiresMine.Enums;
using EmpiresMine.Models.Interfaces;

namespace EmpiresMine.Models.Resources
{
    public class Resource : IResource
    {
        private int quantity;

        public Resource(ResourceType resourceType, int quantity)
        {
            this.Quantity = quantity;
            this.ResourceType = resourceType;
        }

        public ResourceType ResourceType { get; }

        public int Quantity
        {
            get { return this.quantity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("quantity","Quantity must be non-negative");
                }
                this.quantity = value;
            }
        }
    }
}
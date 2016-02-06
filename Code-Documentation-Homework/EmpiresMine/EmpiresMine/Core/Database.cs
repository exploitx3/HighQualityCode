using System.Collections.Generic;
using EmpiresMine.Enums;
using EmpiresMine.Interfaces;
using EmpiresMine.Models.Interfaces;

namespace EmpiresMine.Core
{
    public class Database : IDatabase
    {
        private readonly IDictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();
        private readonly IList<IUnit> units = new List<IUnit>(); 
         
        private readonly IList<IBuilding> buildings = new List<IBuilding>();

        public Database()
        {
            this.Resources[ResourceType.Gold] = 0;
            this.Resources[ResourceType.Steel] = 0;
        }


        public IDictionary<ResourceType, int> Resources
        {
            get { return this.resources; }
        }

        public IEnumerable<IUnit> Units {
            get { return this.units; }
        }
        public void AddUnit(IUnit unit)
        {
            this.units.Add(unit);
        }

        public IList<IBuilding> Buildings
        {
            get { return this.buildings; }
        }
    }
}
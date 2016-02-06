using System.Collections;
using System.Collections.Generic;
using EmpiresMine.Enums;
using EmpiresMine.Models.Interfaces;

namespace EmpiresMine.Interfaces
{
    public interface IDatabase
    {
        /// <summary>
        /// Returns the Resources
        /// </summary>
        IDictionary<ResourceType, int> Resources { get; }
        /// <summary>
        /// Returns the Units
        /// </summary>
        IEnumerable<IUnit> Units { get; }
        /// <summary>
        /// Returns the Buildings
        /// </summary>
        IList<IBuilding> Buildings { get; }
        /// <summary>
        /// Adds a unit to the Database
        /// </summary>
        /// <param name="unit"></param>
        void AddUnit(IUnit unit);

        
    }
}
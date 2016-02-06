using System;
using EmpiresMine.Interfaces;
using EmpiresMine.Models.Buildings;
using EmpiresMine.Models.Interfaces;

namespace EmpiresMine.Core.Commands
{
    public class BuildCommand : Command
    {
        public BuildCommand(string name, string buildingType, IDatabase db) : base(name, db)
        {
            this.BuildingType = buildingType;
        }

        public string BuildingType { get; private set; }
        public override void Execute()
        {
            IBuilding newBuilding = null;
            switch (this.BuildingType)
            {
                case "barracks":
                    newBuilding = new Barracks();
                    break;
                case "archery":
                    newBuilding = new Archery();
                    break;
                default:
                    throw new ArgumentException("Invalid building type");
            }
            this.Database.Buildings.Add(newBuilding);
        }
    }
}
using System;
using EmpiresMine.Enums;
using EmpiresMine.Interfaces;
using EmpiresMine.Models.Interfaces;

namespace EmpiresMine.Core
{
    internal static class CommandExecutor 
    {
        internal static void ExecuteCommand(ICommand command, IDatabase database)
        {
            try
            {
                command.Execute();
                TurnsIncrement(database);
            }
            catch
                (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void TurnsIncrement(IDatabase database)
        {
            foreach (IBuilding building in database.Buildings)
            {
                building.Update();
                if (building.CanProduceResource())
                {
                    IResource newResource = building.ProduceResource();
                    database.Resources[newResource.ResourceType] += newResource.Quantity;
                }
                if (building.CanProduceUnit())
                {
                    IUnit newUnit = building.ProduceUnit();
                    database.AddUnit(newUnit);
                }
            }
        }
    }
}
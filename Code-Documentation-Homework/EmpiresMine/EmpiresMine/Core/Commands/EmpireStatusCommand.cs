using System;
using System.Linq;
using EmpiresMine.Enums;
using EmpiresMine.Interfaces;
using EmpiresMine.Models.Interfaces;
using EmpiresMine.Models.Units;

namespace EmpiresMine.Core.Commands
{
    public class EmpireStatusCommand : Command
    {
        public EmpireStatusCommand(string name, IDatabase db) : base(name ,db)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("Treasury:");
            Console.WriteLine("--Gold: {0}", this.Database.Resources[ResourceType.Gold]);
            Console.WriteLine("--Steel: {0}", this.Database.Resources[ResourceType.Steel]);
            Console.WriteLine("Buildings:");

            foreach (IBuilding building in this.Database.Buildings)
            {
                Console.WriteLine(building.ToString());
            }

            Console.WriteLine("Units:");
            int unitsCount = this.Database.Units.Count();
            if (unitsCount == 0)
            {
                Console.WriteLine("N/A");
            }
            else
            {

                int archersCount = this.Database.Units.Count(u => u.GetType().Name == "Archer");
                int swordsmanCount = this.Database.Units.Count(u => u.GetType().Name == "Swordsman");

                if (this.Database.Units.FirstOrDefault().GetType().Name == "Archer")
                {
                    if (archersCount != 0)
                    {
                        Console.WriteLine("--Archer: {0}", this.Database.Units.Count(u => u.GetType().Name == "Archer"));
                    }
                    if (swordsmanCount != 0)
                    {
                        Console.WriteLine("--Swordsman: {0}",
                        this.Database.Units.Count(u => u.GetType().Name == "Swordsman"));
                    }
                }
                else
                {
                    if (swordsmanCount != 0)
                    {
                        Console.WriteLine("--Swordsman: {0}",
                            this.Database.Units.Count(u => u.GetType().Name == "Swordsman"));
                    }

                    if (archersCount != 0)
                    {
                        Console.WriteLine("--Archer: {0}", this.Database.Units.Count(u => u.GetType().Name == "Archer"));
                    }
                }
            }
        }
    }
}
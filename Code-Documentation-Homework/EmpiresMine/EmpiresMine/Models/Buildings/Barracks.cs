using System.Text;
using EmpiresMine.Enums;
using EmpiresMine.Models.Interfaces;
using EmpiresMine.Models.Resources;
using EmpiresMine.Models.Units;

namespace EmpiresMine.Models.Buildings
{
    public class Barracks : Building
    {
        private int turnCounter = -1;
        public override IResource ProduceResource()
        {
            return new Resource(ResourceType.Steel, 10);
        }

        public override bool CanProduceResource()
        {
            if (this.turnCounter % 3 == 0 && this.turnCounter != 0)
            {
                return true;
            }
            return false;
        }

        public override IUnit ProduceUnit()
        {
            return new Swordsman();
        }

        public override bool CanProduceUnit()
        {
            if (this.turnCounter % 4 == 0 && this.turnCounter != 0)
            {
                return true;
            }
            return false;
        }

        public override void Update()
        {
            this.turnCounter++;
        }


        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(
                string.Format(
                    "--Barracks: {0} turns ({1} turns until Swordsman, {2} turns until Steel)",
                    this.turnCounter,
                    (this.turnCounter % 4 == 0 ? 4 : 4-this.turnCounter%4),
                    (this.turnCounter % 3 == 0? 3 : 3-this.turnCounter%3)));

            return output.ToString();
        }
    }
}
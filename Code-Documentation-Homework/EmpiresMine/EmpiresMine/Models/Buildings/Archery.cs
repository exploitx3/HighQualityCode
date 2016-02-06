using System.Text;
using EmpiresMine.Enums;
using EmpiresMine.Models.Interfaces;
using EmpiresMine.Models.Resources;
using EmpiresMine.Models.Units;

namespace EmpiresMine.Models.Buildings
{
    public class Archery : Building
    {
        private int turnCounter = -1;
        

        public override IResource ProduceResource()
        {
            return new Resource(ResourceType.Gold, 5);
        }

        public override bool CanProduceResource()
        {
            if (this.turnCounter%2 == 0 && this.turnCounter != 0)
            {
                return true;
            }
            return false;
        }

        public override IUnit ProduceUnit()
        {
            return new Archer();
        }

        public override bool CanProduceUnit()
        {
            if (this.turnCounter % 3 == 0 && this.turnCounter != 0)
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
                    "--Archery: {0} turns ({1} turns until Archer, {2} turns until Gold)",
                    this.turnCounter,
                    (this.turnCounter%3 == 0 ? 3 : 3-this.turnCounter%3),
                    (this.turnCounter%2 == 0 ? 2:2-this.turnCounter%2)));

            return output.ToString();
        }
    }
}
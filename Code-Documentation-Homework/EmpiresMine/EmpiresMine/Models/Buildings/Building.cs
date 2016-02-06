using EmpiresMine.Models.Interfaces;

namespace EmpiresMine.Models.Buildings
{
    public abstract class Building : IBuilding
    {
        public abstract IResource ProduceResource();
        public abstract bool CanProduceResource();
        public abstract IUnit ProduceUnit();
        public abstract bool CanProduceUnit();
        public abstract void Update();
        
    }
}
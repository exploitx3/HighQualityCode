namespace EmpiresMine.Models.Interfaces
{
    public interface IUnitProduceable
    {
        IUnit ProduceUnit();
        bool CanProduceUnit();
    }
}
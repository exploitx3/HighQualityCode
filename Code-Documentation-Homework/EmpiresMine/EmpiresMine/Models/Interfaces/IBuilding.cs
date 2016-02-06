namespace EmpiresMine.Models.Interfaces
{
    public interface IBuilding : IResourceProduceable, IUnitProduceable
    {
         void Update();
    }
}
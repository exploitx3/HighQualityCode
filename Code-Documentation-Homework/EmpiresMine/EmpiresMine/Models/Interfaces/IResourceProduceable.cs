namespace EmpiresMine.Models.Interfaces
{
    public interface IResourceProduceable
    {
        IResource ProduceResource();
        bool CanProduceResource();
    }
}
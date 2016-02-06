using EmpiresMine.Enums;

namespace EmpiresMine.Models.Interfaces
{
    public interface IResource
    {
        ResourceType ResourceType { get; }
        int Quantity { get; } 
    }
}
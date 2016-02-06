using Blobs_Remake.Models.EventHandlers;

namespace Blobs_Remake.Interfaces
{
    public interface IAttackable
    {
        void Respond(int damage);

        event BlobDeadEventHandler OnBlobDead;
    }
}
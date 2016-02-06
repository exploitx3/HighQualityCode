namespace Blobs_Remake.Models.EventHandlers
{
    public class EventHandler
    {
     using Events;

    public delegate void BehaviorToggledEventHandler(object sender, BehaviorToggledEventArgs e);

    public delegate void BlobDeadEventHandler(object sender, BlobDeadEventArgs e);
}
}
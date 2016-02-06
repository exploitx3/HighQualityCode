namespace Blobs_Remake.Models.Events
{
    public class BehaviorToggledEventArgs
    {
        public BehaviorToggledEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; }
    }
}
namespace Blobs_Remake.Models.Events
{
    public class BlobDeadEventArgs
    {
        public BlobDeadEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; }
    }
}
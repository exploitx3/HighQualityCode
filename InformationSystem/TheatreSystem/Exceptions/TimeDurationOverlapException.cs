namespace TheatreSystem.Exceptions
{
    using System;

    public class TimeDurationOverlapException : Exception
    {
        public TimeDurationOverlapException(string msg)
            : base(msg)
        {
        }
    }
}
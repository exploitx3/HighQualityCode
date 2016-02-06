namespace TheatreSystem.Exceptions
{
    using System;

    public class TheatreNotFoundException : Exception
    {
        public TheatreNotFoundException(string msg)
            : base(msg)
        {
        }
    }
}
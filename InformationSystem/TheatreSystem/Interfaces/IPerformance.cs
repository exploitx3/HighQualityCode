namespace TheatreSystem.Interfaces
{
    using System;
    using Models;

    public interface IPerformance
    {
        string TheatreName { get; }

        string PerformanceName { get; }

        DateTime DateTime { get; }

        TimeSpan Duration { get; }

        decimal Price { get; }
    }
}
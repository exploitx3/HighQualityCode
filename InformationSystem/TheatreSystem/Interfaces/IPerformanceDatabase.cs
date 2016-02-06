namespace TheatreSystem.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Interface for the TheatreSystem Database.
    /// Contains all the methods that the database uses.
    /// </summary>
    public interface IPerformanceDatabase
    {
        /// <summary>
        /// Adds a theatre to the database
        /// </summary>
        /// <param name="theatreName">The theatre name to be added.</param>
        void AddTheatre(string theatreName);

        /// <summary>
        /// Returns all Theatres.
        /// </summary>
        /// <returns>IEnumerable with all the Theatres in the database.</returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// Adds Performance to specified theatre
        /// </summary>
        /// <param name="theatreName">Theatre name to be added to</param>
        /// <param name="performanceName">The New-Performance's name</param>
        /// <param name="startDateTime">The New-Performance's start date and time</param>
        /// <param name="duration">The New-Performance's duration</param>
        /// <param name="price">The New-Performance's price</param>
        void AddPerformance(string theatreName, string performanceName, DateTime startDateTime, TimeSpan duration, decimal price);

        /// <summary>
        /// Returns all Performances.
        /// </summary>
        /// <returns>IEnumerable&lt;Performance&gt; with all the performances in the database</returns>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// Returns all Performances by Theatre Name
        /// </summary>
        /// <param name="theatreName"></param>
        /// <returns>IEnumerable&lt;Performance&gt; with all the performances in the database for Theatre with specified name</returns>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}
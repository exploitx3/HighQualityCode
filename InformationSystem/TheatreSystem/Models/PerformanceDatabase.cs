namespace TheatreSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Exceptions;
    using Interfaces;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> sortedTheatresWithPerformances =
        new SortedDictionary<string, SortedSet<Performance>>();

        public void AddTheatre(string theatreName)
        {
            if (this.sortedTheatresWithPerformances.ContainsKey(theatreName))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.sortedTheatresWithPerformances[theatreName] = new SortedSet<Performance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var sortedListOfTheatres = this.sortedTheatresWithPerformances.Keys;

            return sortedListOfTheatres;
        }

        public void AddPerformance(
            string theatreName,
            string performanceName,
            DateTime startDateTime,
            TimeSpan duration,
            decimal price)
        {
            if (!this.sortedTheatresWithPerformances.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var sortedSetPerformances = this.sortedTheatresWithPerformances[theatreName];

            var performanceEndTime = startDateTime + duration;
            if (this.CheckForIncorrectDuration(sortedSetPerformances, startDateTime, performanceEndTime))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var newPerformance = new Performance(theatreName, performanceName, startDateTime, duration, price);
            sortedSetPerformances.Add(newPerformance);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatreNames = this.sortedTheatresWithPerformances.Keys;

            var allPerformances = new List<Performance>();
            foreach (var theatre in theatreNames)
            {
                var performances = this.sortedTheatresWithPerformances[theatre];
                allPerformances.AddRange(performances);
            }

            return allPerformances;
        }
        
        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.sortedTheatresWithPerformances.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performancesByTheatre = this.sortedTheatresWithPerformances[theatreName];

            return performancesByTheatre;
        }

        protected bool CheckForIncorrectDuration(IEnumerable<Performance> performances, DateTime newDateTime, DateTime newEndTime)
        {
            foreach (var performance in performances)
            {
                var performanceStartTime = performance.DateTime;
                var performanceEndTime = performanceStartTime + performance.Duration;

                var checkForIncorrectDuration =
                    (performanceStartTime <= newDateTime && newDateTime <= performanceEndTime) ||
                    (performanceStartTime <= newEndTime && newEndTime <= performanceEndTime) ||
                    (newDateTime <= performanceStartTime && performanceStartTime <= newEndTime) ||
                    (newDateTime <= performanceEndTime && performanceEndTime <= newEndTime);

                if (checkForIncorrectDuration)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

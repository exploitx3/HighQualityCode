namespace TheatreSystem.Models
{
    using System;
    using Interfaces;

    public class Performance : IPerformance, IComparable<Performance>
    {
        public Performance(string theatreName, string performanceName, DateTime dateTime, TimeSpan duration, decimal price)
        {
            this.TheatreName = theatreName;
            this.PerformanceName = performanceName;
            this.DateTime = dateTime;
            this.Duration = duration;
            this.Price = price;
        }

        public string TheatreName { get; private set; }

        public string PerformanceName { get; private set; }

        public DateTime DateTime { get; private set; }

        public TimeSpan Duration { get; private set; }

        public decimal Price { get; private set; }

        int IComparable<Performance>.CompareTo(Performance otherPerformance)
        {
            int tmp = this.DateTime.CompareTo(otherPerformance.DateTime);
            return tmp;
        }

        public override string ToString()
        {
            string result = string.Format("({0}, {1}, {2})",
                this.PerformanceName,
                this.TheatreName,
                this.DateTime.ToString("dd.MM.yyyy HH:mm"));

            return result;
        }
    }
}
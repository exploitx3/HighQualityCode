namespace VehicleParkSystem.Utilities
{
    using System;

    public static class DateTimeUtilities
    {
        public static DateTime ParseISODateTime(string dateTimeString)
        {
            return DateTime.Parse(dateTimeString, null, System.Globalization.DateTimeStyles.RoundtripKind);
        }
    }
}

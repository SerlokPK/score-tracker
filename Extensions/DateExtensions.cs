namespace ScoreTracker.Extensions
{
    public static class DateExtensions
    {
        public static DateTime GetAbsoluteStart(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0, date.Kind);
        }

        public static DateTime GetAbsoluteEnd(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999, date.Kind);
        }

        public static DateTime GetAbsoluteStartMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime GetAbsoluteEndMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        public static DateTime GetAbsoluteStartYear(this DateTime date)
        {
            return new DateTime(date.Year, 1, 1);
        }

        public static DateTime GetAbsoluteEndYear(this DateTime date)
        {
            return new DateTime(date.Year, 12, 31);
        }
    }
}

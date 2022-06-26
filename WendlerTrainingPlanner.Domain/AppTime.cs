namespace WendlerTrainingPlanner.Domain
{
    public static class AppTime
    {
        public static Func<DateTime> CurrentTimeProvider
        { get; set; } = () => DateTime.Now;

        public static Func<DateTime> CurrentUtcTimeProvider
        { get; set; } = () => DateTime.UtcNow;

        public static DateTime Now() => CurrentTimeProvider();
        public static DateTime UtcNow() => CurrentUtcTimeProvider();
    }
}

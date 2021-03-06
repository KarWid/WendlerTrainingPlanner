namespace WendlerTrainingPlanner.Domain
{
    public static class AppTime
    {
        public static Func<DateTime> CurrentTimeProvider
        { get; set; } = () => DateTime.Now;

        public static DateTime Now() => CurrentTimeProvider();
    }
}

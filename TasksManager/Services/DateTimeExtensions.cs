namespace TasksManager.Services;

public static class DateTimeExtensions
{
    public static DateTime StartOfWeek(this DateTime date, DayOfWeek startDay)
    {
        int diff = (7 + (date.DayOfWeek - startDay)) % 7;
        return date.AddDays(-1 * diff).Date;
    }
}

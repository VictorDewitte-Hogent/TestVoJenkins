namespace Domain.Notifications;

public class Notification
{
    public String content { get; private set; }
    public DateTime date { get; private set; }
    public String relativeDate => GetRelativeDate();

    public NotificationCategory notificationCategory { get; private set; }

    public Notification(String content, DateTime date, NotificationCategory notificationCategory)
    {
        this.content = content;
        this.date = date;
        this.notificationCategory = notificationCategory;
    }

    private string GetRelativeDate()
    {
        TimeSpan time = DateTime.UtcNow.Subtract(date);
        Console.WriteLine(time.ToString());
        if (time.Days > 0)
        {
            return $"{time.Days}d ago";
        }
        else if (time.Hours > 0)
        {
            return $"{time.Hours}h ago";
        }
        else if (time.Minutes > 0)
        {
            return $"{time.Minutes}min ago";
        }
        else
        {
            return $"now";
        }
    }
}

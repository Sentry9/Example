namespace PSB_ex6.Logger;

public class LogEntry
{
    public DateTime Timestamp { get; }
    public LoggerLevel Level { get; }
    public string Message { get; }

    public LogEntry(DateTime timestamp, LoggerLevel level, string message)
    {
        Timestamp = timestamp;
        Level = level;
        Message = message;
    }
}
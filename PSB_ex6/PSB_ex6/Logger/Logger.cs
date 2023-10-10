namespace PSB_ex6.Logger;

public class Logger
{
    private static Logger _instance;
    private List<LogEntry> _logHistory = new List<LogEntry>();

    private Logger()
    {
    }

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Logger();
        }

        return _instance;
    }

    public void LogMessage(LoggerLevel level, string message)
    {
        LogEntry logEntry = new LogEntry(DateTime.Now, level, message);
        _logHistory.Add(logEntry);
        if (_logHistory.Count > 10)
        {
            _logHistory.RemoveAt(0);
        }
    }

    public void PrintLogHistory()
    {
        foreach (LogEntry logEntry in _logHistory)
        {
            Console.WriteLine($"{logEntry.Timestamp} - [{logEntry.Level}] {logEntry.Message}");
        }
    }
}
using PSB_ex6.Logger;

public class LogMessages
{
    public static void Launch()
    {
        var logger = Logger.GetInstance();

        logger.LogMessage(LoggerLevel.LOG_NORMAL, "program loaded");
        logger.LogMessage(LoggerLevel.LOG_ERROR, "error happens! help me!");
        logger.LogMessage(LoggerLevel.LOG_NORMAL, "program loaded");
        logger.LogMessage(LoggerLevel.LOG_WARNING, "Be careful! program loaded");
        logger.LogMessage(LoggerLevel.LOG_NORMAL, "program loaded");
        logger.LogMessage(LoggerLevel.LOG_ERROR, "error happens! help me!");
        logger.LogMessage(LoggerLevel.LOG_NORMAL, "program loaded");
        logger.LogMessage(LoggerLevel.LOG_NORMAL, "program loaded");
        logger.LogMessage(LoggerLevel.LOG_NORMAL, "program loaded");
        logger.LogMessage(LoggerLevel.LOG_NORMAL, "program loaded");
        logger.LogMessage(LoggerLevel.LOG_NORMAL, "program loaded");

        logger.PrintLogHistory();
    }
}
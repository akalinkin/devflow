using Microsoft.Extensions.Logging;

namespace GitLabCli.Console
{
    public static class LogLevelExtensions
    {
        public static LogLevel FromString(
            string level, 
            LogLevel defaultLevel = LogLevel.Information) 
        {
            switch (level.ToUpper().Trim()) {
                case "TRACE":
                    return LogLevel.Trace;
                case "DEBUG":
                    return LogLevel.Debug;
                case "INFORMATION":
                    return LogLevel.Information;
                case "WARNING":
                    return LogLevel.Warning;
                case "ERROR":
                    return LogLevel.Error;
                case "CRITICAL":
                    return LogLevel.Critical;
                default:
                    return defaultLevel;
            }
        }
    }
}

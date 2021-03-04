using System;

namespace SDRSharp.Plugin.TdDiscord
{
    public enum LogLevel
    {
        Debug,
        Message,
        Warning,
        Error,
        Critical,
    }

    public interface ILogger<T>
    {
        void Log(LogLevel logLevel, Exception exception = null, object message = null, params object[] args);
    }

    public sealed class Logger<T> : ILogger<T>
    {
        public void Log(LogLevel logLevel, Exception exception = null, object message = null, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
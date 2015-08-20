namespace Archimedes.Common.Logging
{
    public interface ILogger
    {
        void Trace(string message, object metadata);
        void Debug(string message, object metadata);
        void Info(string message, object metadata);
        void Warn(string message, object metadata);
        void Error(string message, object metadata);
        void Fatal(string message, object metadata);
    }
}